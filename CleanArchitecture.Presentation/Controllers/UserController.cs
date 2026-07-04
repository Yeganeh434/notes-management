using CleanArchitecture.Application.Users.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser(CreateUserCommand request)
        {
            UserDTO user=await _mediator.Send(request);

            return StatusCode(201, user);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            DeleteUserCommand request = new DeleteUserCommand
            {
                Id = id
            };
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpPatch("Update/{id:int}")]
        public async Task<IActionResult> UpdateUser(int id,UpdateUserCommand request)
        {
            request.Id = id;
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
