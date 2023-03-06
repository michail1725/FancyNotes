using FancyNotes.Service;
using FancyNotes.Server.Utilities;
using FancyNotes.Shared;
using Microsoft.AspNetCore.Mvc;


namespace FancyNotes.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);

                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(user);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet("Verify")]
        public async Task<ActionResult<User>> VerifyLoginData(string userName, string password)
        {
            password = HashGenerator.Generate(password);
            try
            {
                var user = await _userService.VerifyLoginData(userName, password);

                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(user);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet("Check")]
        public async Task<ActionResult<bool>> CheckUniqUsername(string userName)
        {
            try
            {
                    return Ok( await _userService.IsUniqUsername(userName));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        

        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUser([FromBody] User userToCreate) 
        {
            try
            {
                var newUser = await _userService.CreateUser(userToCreate);

                if (newUser == null)
                {
                    return NoContent();
                }

                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
