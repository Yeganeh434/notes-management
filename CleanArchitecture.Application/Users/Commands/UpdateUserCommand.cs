using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Users.Commands
{
    public class UpdateUserCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
    }
}
