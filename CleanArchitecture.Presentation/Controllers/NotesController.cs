using CleanArchitecture.Application.Notes.Commands;
using CleanArchitecture.Application.Notes.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Notes.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotesController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddNote(CreateNoteCommand request)
        {
            NoteDTO note=await _mediator.Send(request);
            
            return StatusCode(201, note);
        }

        [HttpDelete("Delete/{userId:int}/{noteId:int}")]
        public IActionResult DeleteNote(int userId,int noteId)
        {
            DeleteNoteCommand request = new DeleteNoteCommand 
            { 
                UserId= userId,
                NoteId= noteId
            };

            _mediator.Send(request);
            return NoContent();
        }

        [HttpPatch("Update/{userId:int}/{noteId:int}")]
        public async Task<IActionResult> UpdateNote(int userId,int noteId,UpdateNoteCommand request)
        {
            request.UserId = userId;
            request.NoteId = noteId;
            
            await _mediator.Send(request);
            return NoContent(); 
        }

        [HttpGet("GetAll/{userId:int}")]
        public async Task<IActionResult> GetAllNotes(int userId)
        {
            GetAllNotesQuery request = new GetAllNotesQuery
            {
                UserId = userId
            };

            IEnumerable<NoteDTO> notes= await _mediator.Send(request);

            return Ok(notes);
        }

        [HttpGet("GetById/{userId:int}/{noteId:int}")]
        public async Task<IActionResult> GetNoteById(int userId,int noteId)
        {
            GetNoteByIdQuery request = new GetNoteByIdQuery
            {
                UserId = userId,
                NoteId = noteId
            };

            NoteDTO note=await _mediator.Send(request);

            return Ok(note);
        }

        [HttpGet("FindByTitle/{userId:int}")]
        public async Task<IActionResult> FindNoteByTitle(int userId,string title)
        {
            FindByTitleQuery request = new FindByTitleQuery
            {
                UserId = userId,
                Title = title
            };

            IEnumerable<NoteDTO> notes=await _mediator.Send(request);

            return Ok(notes);
        }

        [HttpGet("FindByContent/{userId:int}")]
        public async Task<IActionResult> FindNoteByContent(int userId,string word)
        {
            FindByContentQuery request = new FindByContentQuery
            {
                UserId = userId,
                Word = word
            };

            await _mediator.Send(request);
            IEnumerable<NoteDTO> notes = await _mediator.Send(request);

            return Ok(notes);
        }
    }
}
