using CleanArchitecture.Application.Notes.Queries;
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
    public class GetAllNotesHandler:IRequestHandler<GetAllNotesQuery,IEnumerable<NoteDTO>>
    {
        private readonly INoteRepository _noteRepository;
        public GetAllNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<NoteDTO>> Handle(GetAllNotesQuery request,CancellationToken cancellationToken)
        {
            IEnumerable<Note> notes = await _noteRepository.GetAllAsync(request.UserId, cancellationToken);

            IEnumerable<NoteDTO> DTO = notes.Select(n => new NoteDTO
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content
            });

            return DTO;
        }
    }
}
