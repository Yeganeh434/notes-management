using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Exceptions
{
    public class GlobalExceptionHandler:IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,Exception exception,CancellationToken cancellationToken)
        {
            ProblemDetails problem = new();

            switch (exception) {
                case DomainException ex:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                    problem.Status = StatusCodes.Status400BadRequest;
                    problem.Title = "Domain validation error";
                    problem.Detail = ex.Message;

                    break;

                case NotFoundException ex:
                    httpContext.Response.StatusCode= StatusCodes.Status404NotFound;

                    problem.Status = StatusCodes.Status404NotFound;
                    problem.Title = "Not found";
                    problem.Detail = ex.Message;

                    break;

                case UsernameAlreadyExistsException ex:
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;

                    problem.Status = StatusCodes.Status409Conflict;
                    problem.Title = "Username already exists";
                    problem.Detail = ex.Message;

                    break;

                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    problem.Status = StatusCodes.Status500InternalServerError;
                    problem.Title = "Server Error";
                    problem.Detail = "An unexpected error occurred.";

                    break;
            }

            await httpContext.Response.WriteAsJsonAsync(problem,cancellationToken);

            return true;
        }
    }
}
