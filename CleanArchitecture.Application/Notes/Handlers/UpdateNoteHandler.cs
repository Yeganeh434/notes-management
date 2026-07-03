using CleanArchitecture.Application.Notes.Commands;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Handlers
{
    public class UpdateNoteHandler:IRequestHandler<UpdateNoteCommand,Unit>
    {
        private readonly INoteRepository _noteRepository;
        public UpdateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request,CancellationToken cancellationToken)
        {
            Note? note=await _noteRepository.GetByIdAsync(request.UserId,request.NoteId);
            if (note == null)
            {
                throw new NotFoundException("Note not found");
            }

            note.Update(request.Title,request.Content);
            await _noteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
