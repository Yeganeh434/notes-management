using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Commands
{
    public class CreateUserCommand:IRequest<User>
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
    }
}
