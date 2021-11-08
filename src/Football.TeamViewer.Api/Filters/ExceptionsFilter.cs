using System.Net;
using Football.TeamViewer.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Football.TeamViewer.Api.Filters
{
    public class ExceptionsFilter: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch (exception)
            {
                case ValidationException validationException:
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new JsonResult(
                        validationException.Failures);

                    return;
                
                // Discussible: many tradeoffs 
                case NotFoundException notFoundException:
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new JsonResult(
                        notFoundException.Message);

                    return;
                
                default:
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Result = new JsonResult(new { Error = "An unexpected internal server error has occurred."});

                    return;
            }
        }
    }
}