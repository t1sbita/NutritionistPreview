using NutritionistPreview.Api.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace NutritionistPreview.Api.Filters
{
    /// <summary>
    /// ExceptionHandlerFilterAttribute
    /// </summary>
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {

        /// <summary>
        /// ExceptionHandlerFilterAttribute.OnException
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (context != null)
            {
                context.HttpContext.Response.ContentType = "application/problem+json";

                var businessException = context.Exception as BusinessException;
                if (businessException != null)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    if ((businessException?.Problem?.Erros?.Count ?? 0) > 0)
                    {
                        context.Result = new JsonResult(new
                        {
                            status = context.HttpContext.Response.StatusCode,
                            error = businessException.Problem.Erros.SelectMany(e => e.FieldErros)
                        });
                    }
                    else
                    {
                        context.Result = new JsonResult(new
                        {
                            status = context.HttpContext.Response.StatusCode,
                            error = businessException?.Message
                        });
                    }
                }
                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    context.Result = new JsonResult(new
                    {
                        status = context.HttpContext.Response.StatusCode,
                        error = context.Exception.Message,
                        stackTrace = context.Exception.StackTrace
                    });
                }
            }
        }
    }
}
