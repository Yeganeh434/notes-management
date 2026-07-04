using CleanArchitecture.Application.Notes.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Queries
{
    public class GetAllNotesQuery:IRequest<IEnumerable<NoteDTO>>
    {
        public int UserId { get; set; }
    }
}
