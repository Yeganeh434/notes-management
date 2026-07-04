using CleanArchitecture.Application.Users.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Handlers
{
    public class CreateUserHandler:IRequestHandler<CreateUserCommand,UserDTO>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            User user=new User(request.Username, request.Password,request.Email);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            UserDTO DTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return DTO;
        }
    }
}
