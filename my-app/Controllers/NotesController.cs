using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_app.Entitys;
using my_app.Services;
using System.Collections.Generic;

namespace my_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly NotesService _notesService;
        private readonly ILogger<NoteController> _logger;

        public NoteController(NotesService notesService, ILogger<NoteController> logger)
        {
            _notesService = notesService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Note> GetAllNotes()
        {
            return _notesService.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetNoteById(long id)
        {
            var note = _notesService.FindById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            var exisingNote = _notesService.CreateNote(note);

            if (exisingNote == null)
            {
                return Ok(note);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(long id, [FromBody] Note note)
        {
            var updatedNote = _notesService.Update(id, note);

            if (updatedNote == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(updatedNote);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(long id)
        {
            _notesService.Delete(id);
            return NoContent();
        }
    }
}
