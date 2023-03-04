using DbAccess;
using FancyNotes.Service;
using FancyNotes.Shared;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Cryptography;

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

        [HttpGet("byLoginData")]
        public bool Get(string userName, string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                password = Convert.ToHexString(hashBytes);
            }
            return _userService.VerifyLoginData(userName, password);
        }

        [HttpGet("byUserName")]
        public bool Get(string userName)
        {
            return _userService.IsUniqUsername(userName);
        }

        [HttpPost("registrate")]
        public User Post(string userName, string password) 
        { 
            User newUser = new User();
            newUser.UserName = userName;
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                password = Convert.ToHexString(hashBytes);
            }
            newUser.Password = password;
            return _userService.CreateUser(newUser);
        }
    }
}
