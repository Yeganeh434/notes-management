using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Notes.Queries
{
    public class FindByTitleQuery:IRequest<IEnumerable<Note>>
    {
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
