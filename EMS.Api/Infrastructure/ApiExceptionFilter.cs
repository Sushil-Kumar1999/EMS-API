using EMS.Core.Application.Exceptions;
using EMS.Core.DataTransfer.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Api.Infrastructure
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case EntityNotFoundException enfe:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.ExceptionHandled = true;
                    break;
                case ValidationException ve:
                    var validationErrorResponse = new ValidationErrorsResponse(ve.Errors);
                    var data = Encoding.UTF8.GetBytes(validationErrorResponse.ToJson());

                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.HttpContext.Response.ContentType = "application/json";
                    await context.HttpContext.Response.Body.WriteAsync(data, 0, data.Length);
                    context.ExceptionHandled = true;
                    break;
                case InvalidLoginAttemptException ilae:
                    var validationErrorsResponse = new ValidationErrorsResponse(ilae.Message);
                    var ilaeData = Encoding.UTF8.GetBytes(validationErrorsResponse.ToJson());

                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.HttpContext.Response.ContentType = "application/json";
                    await context.HttpContext.Response.Body.WriteAsync(ilaeData, 0, ilaeData.Length);
                    context.ExceptionHandled = true;
                    break;
                default:
                    var errorGuid = Guid.NewGuid();
                    var exception = context.Exception;

                    _logger.LogError(exception, "Unexpected error with GUID {ErrorGuid} - {ExceptionMessage}", errorGuid, exception.Message);

                    var response = context.HttpContext.Response;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.ContentType = "application/json";

                    var content = JsonConvert.SerializeObject(new ApiErrorDto(
                        "An error has occurred. If this persists please contact us.", errorGuid.ToString(), $"Error occured. {exception.Message}"));

                    response.ContentLength = content.Length;
                    await response.WriteAsync(content, Encoding.UTF8);

                    break;
            }
            base.OnException(context);
        }
    }
}
