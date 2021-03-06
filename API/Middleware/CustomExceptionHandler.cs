﻿using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Application.Interfaces;
using Application.Abstractions;

namespace API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
                   
            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is BaseHttpException ex)
            {
                code = ex.Code;

                context.HttpContext.Response.StatusCode = (int)code;
                context.Result = new JsonResult(new
                {
                    type = "Custom_" + ex.Type
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)code;

                context.Result = new JsonResult(new
                {
                    error = new[] { context.Exception.Message },
                    innerException = context.Exception.InnerException?.Message,
                    stackTrace = context.Exception.StackTrace
                });
            }
        }
    }
}