using FancyNotes.Service;
using FancyNotes.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FancyNotes.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            try
            {
                var note = await _noteService.GetNoteById(id);

                if (note == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(note);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpPatch]
        public async Task<ActionResult<Note>> UpdateNote(Note updatedNote)
        {
            try
            {
                var note = await _noteService.UpdateNote(updatedNote);
                if (note == null)
                {
                    return NotFound();
                }
                else 
                {
                    return Ok(note);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            try
            {
                await _noteService.DeleteNote(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Note>> CreateNewNote([FromBody] Note noteToCreate)
        {
            try
            {
                var newNote = await _noteService.CreateNote(noteToCreate);

                if (newNote== null)
                {
                    return NoContent();
                }

                return CreatedAtAction(nameof(GetNote), new { id = newNote.Id }, newNote);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId}/GetNoteList")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNoteList(int userId)
        {
            try
            {
                var notes = await _noteService.GetUserNotesList(userId);
                return Ok(notes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }
    }
}
