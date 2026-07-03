using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notes.Commands
{
    public class DeleteNoteCommand:IRequest<Unit>
    {
        public int UserId { get; set; }
        public int NoteId { get; set; }
    }
}
