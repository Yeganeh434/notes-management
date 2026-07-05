using CleanArchitecture.Application.Users.Commands;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Handlers
{
    public class DeleteUserHandler:IRequestHandler<DeleteUserCommand,Unit>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request,CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
