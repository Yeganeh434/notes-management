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
    public class FindByTitleHandler:IRequestHandler<FindByTitleQuery, IEnumerable<Note>>
    {
        private readonly INoteRepository _noteRepository;
        public FindByTitleHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Handle(FindByTitleQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Note> notes =await _noteRepository.FindByTitleAsync(request.UserId, request.Title);
            return notes;
        }
    }
}
