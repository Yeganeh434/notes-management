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
    public class FindByContentHandler:IRequestHandler<FindByContentQuery,IEnumerable<Note>>
    {
        private readonly INoteRepository _noteRepository;
        public FindByContentHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Handle(FindByContentQuery request,CancellationToken cancellationToken)
        {
            IEnumerable<Note> notes = await _noteRepository.FindByContentAsync(request.UserId,request.Word);
            return notes;
        }
    }
}
