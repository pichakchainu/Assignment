using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Services.Base;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<APIResponseWrapper<T>> APIResponse<T>(T result, ValidationResult validationResult,
            int failureStatusCode = StatusCodes.Status500InternalServerError)
        {
            return InternalAPIResponse<T>(result, validationResult, failureStatusCode);
        }

        private ActionResult<APIResponseWrapper<T>> InternalAPIResponse<T>(object result, ValidationResult validationResult,
       int failureStatusCode = StatusCodes.Status500InternalServerError)
        {
            var apiResponse = new APIResponseWrapper<T>();

            if (!validationResult.IsValid)
            {
                apiResponse.Errors = validationResult.Errors;
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                if (result is T data)
                {
                    apiResponse.Data = data;
                }
            }
            return apiResponse;
        }
    }
}
