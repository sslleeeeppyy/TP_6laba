using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _3laba.Filters
{
    public class ArgumentOutOfRangeExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException ex)
            {
                context.Result = new ViewResult
                {
                    ViewName = "ArgumentOutOfRangeError",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<string>(
                        context.HttpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)) as Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,
                        context.ModelState)
                    {
                        Model = ex.Message
                    }
                };
                context.ExceptionHandled = true;
            }
        }
    }
} 