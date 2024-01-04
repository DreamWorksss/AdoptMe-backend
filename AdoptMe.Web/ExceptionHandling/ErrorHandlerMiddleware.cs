using AdoptMe.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AdoptMe.Web.ExceptionHandling
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                ProblemDetails error;
                switch (exception)
                {
                    case NotFoundException ex:
                        {
                            error = new ProblemDetails()
                            {
                                Detail = ex.Message,
                                Status = StatusCodes.Status404NotFound,
                                Type = ErrorTypes.NotFound
                            };
                            break;
                        }
                    case AlreadyExistsException ex:
                        {
                            error = new ProblemDetails()
                            {
                                Detail = ex.Message,
                                Status = StatusCodes.Status400BadRequest,
                                Type = ErrorTypes.AlreadyExists
                            };
                            break;
                        }
                    default:
                        error = new ProblemDetails()
                        {
                            Detail = exception.Message,
                            Status = StatusCodes.Status500InternalServerError,
                            Type = ErrorTypes.InternalServerError,
                        };
                        break;
                }

                var result = JsonSerializer.Serialize(new GenericResponse(null, error));
                context.Response.StatusCode = error.Status.GetValueOrDefault((int)HttpStatusCode.InternalServerError);
                await response.WriteAsync(result);
            }
        }
    }
}
