using CleanArchitecture.Application.Notes.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Application.Exceptions;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Handlers
{
    public class GetNoteByIdHandler:IRequestHandler<GetNoteByIdQuery,Note>
    {
        private readonly INoteRepository _noteRepository;
        public GetNoteByIdHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> Handle(GetNoteByIdQuery request,CancellationToken cancellationToken)
        {
            Note? note=await _noteRepository.GetByIdAsync(request.UserId,request.NoteId);
            if (note == null)
            {
                throw new NotFoundException("No note found with this ID.");
            }

            return note;
        }
    }
}
