using CleanArchitecture.Application.Notes.Commands;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Exceptions;

namespace CleanArchitecture.Application.Notes.Handlers
{
    public class DeleteNoteHandler:IRequestHandler<DeleteNoteCommand,Unit>
    {
        private readonly INoteRepository _noteRepository;
        public DeleteNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request,CancellationToken cancellationToken)
        {
            Note? note = await _noteRepository.GetByIdAsync(request.UserId,request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new NotFoundException("Note not found");
            }

            _noteRepository.Delete(note);
            await _noteRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
