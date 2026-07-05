using CleanArchitecture.Application.Notes.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Notes.DTOs;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Handlers
{
    public class GetNoteByIdHandler:IRequestHandler<GetNoteByIdQuery,NoteDTO>
    {
        private readonly INoteRepository _noteRepository;
        public GetNoteByIdHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteDTO> Handle(GetNoteByIdQuery request,CancellationToken cancellationToken)
        {
            Note? note=await _noteRepository.GetByIdAsync(request.UserId,request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new NotFoundException("No note found with this ID.");
            }

            NoteDTO DTO = new NoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content
            };

            return DTO;
        }
    }
}
