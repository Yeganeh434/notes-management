using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Commands
{
    public class CreateNoteCommand:IRequest<Note>
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int UserId  { get; set; }
    }
}
