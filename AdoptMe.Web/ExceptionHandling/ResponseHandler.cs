using Microsoft.AspNetCore.Mvc;

namespace AdoptMe.Web.ExceptionHandling
{
    public static class ResponseHandler
    {
        public static GenericActionResult HandleResponse(object? response)
        {
            return new GenericActionResult(response);
        }

        public static GenericActionResult HandleResponse(string errorMessage)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = ErrorTypes.InternalServerError,
                Title = "An error has occured",
                Detail = errorMessage
            };
            return new GenericActionResult(problemDetails);
        }

        public static GenericActionResult HandleResponse(object? response, string warningMessage)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status200OK,
                Type = WarningTypes.ApplicationWarning,
                Title = "Request passed with warnings",
                Detail = warningMessage
            };
            return new GenericActionResult(response, problemDetails);
        }

        public static GenericActionResult HandleUnauthorizedResponse(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = ErrorTypes.Unauthorized,
                Title = "You are not authorized",
                Detail = message
            };
            return new GenericActionResult(problemDetails);
        }
    }
}