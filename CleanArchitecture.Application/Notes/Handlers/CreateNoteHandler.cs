using CleanArchitecture.Application.Notes.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Application.Notes.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Handlers
{
    public class CreateNoteHandler:IRequestHandler<CreateNoteCommand,NoteDTO>
    {
        private readonly INoteRepository _noteRepository;
        public CreateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteDTO> Handle(CreateNoteCommand request,CancellationToken cancellationToken)
        {
            Note note=new Note(request.Title,request.Content,request.UserId);
            await _noteRepository.AddAsync(note);
            await _noteRepository.SaveChangesAsync();

            NoteDTO DTO = new NoteDTO
            {
                Id=note.Id,
                Title = note.Title,
                Content = note.Content
            };

            return DTO;
        }
    }
}
