using DbAccess;
using FancyNotes.Shared;
using Microsoft.AspNetCore.Mvc;


namespace FancyNotes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly AppDbContext db;

        public UsersController(AppDbContext db)
        {
            this.db = db;
        }

        //[HttpGet("{id}")]
        //public async Task<User> Get()
        //{
            
        //}
    }
}
