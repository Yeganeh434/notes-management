using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Queries
{
    public class FindByContentQuery:IRequest<IEnumerable<Note>>
    {
        public int UserId {  get; set; }
        public string Word {  get; set; }
    }
}
