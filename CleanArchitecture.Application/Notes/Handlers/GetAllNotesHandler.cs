using CleanArchitecture.Application.Notes.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Handlers
{
    public class GetAllNotesHandler:IRequestHandler<GetAllNotesQuery,IEnumerable<Note>>
    {
        private readonly INoteRepository _noteRepository;
        public GetAllNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Handle(GetAllNotesQuery request,CancellationToken cancellationToken)
        {
            IEnumerable<Note> response = await _noteRepository.GetAllAsync(request.UserId);

            return response;
        }
    }
}
