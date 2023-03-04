using DbAccess;
using Microsoft.AspNetCore.Mvc;

namespace FancyNotes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController
    {
        private readonly AppDbContext db;

        public  NotesController(AppDbContext db)
        {
            this.db = db;
        }
    }
}
