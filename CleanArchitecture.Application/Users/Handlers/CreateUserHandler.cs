using CleanArchitecture.Application.Users.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Application.Users.DTOs;
using CleanArchitecture.Application.Exceptions;
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

            if (await _userRepository.ExistsByUsernameAsync(user.Username))
            {
                throw new UsernameAlreadyExistsException();
            }

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
