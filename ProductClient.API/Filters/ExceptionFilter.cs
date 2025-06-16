﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClient.Communication.Responses;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProductClientHubException productClientHubException)
            {
                context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubException.GetErrors()));

            } else
            {
                ThrowUnkownError(context);
            }
        }

        private void ThrowUnkownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("Unknown error."));
        }
    }
}
