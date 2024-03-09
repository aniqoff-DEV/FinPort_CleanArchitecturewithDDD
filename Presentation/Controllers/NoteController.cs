using Application.CQRS.Notes.Queries;
using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class NoteController : ApiController
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{noteId:guid}")]
        [ProducesResponseType(typeof(Note), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNote(Guid noteId)
        {
            var note = await _noteService.GetBy(noteId);

            return Ok(note);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Note>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNotes()
        {
            var note = await _noteService.GetAll();

            return Ok(note);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Note), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNote([FromBody] Note request)
        {
            var newNote = await _noteService.Insert(request);

            return Ok(newNote);
        }
    }
}
