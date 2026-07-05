using CleanArchitecture.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Commands
{
    public class CreateUserCommand:IRequest<UserDTO>
    {
        public string Username { get;  set; }
        public string Password { get;  set; }
        public string Email { get;  set; }
    }
}
