using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filter
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            {
                Title = "An error ocurred while processing your request.",
                Instance = context.HttpContext.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            }; 

            var error = new { error = problemDetails.Title };

            context.Result = new ObjectResult(problemDetails);  

            context.ExceptionHandled = true;
        }
    }
}
