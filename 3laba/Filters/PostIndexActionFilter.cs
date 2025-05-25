using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace _3laba.Filters
{
    public class PostIndexActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id") && context.ActionArguments["id"] is int id && id < 0)
            {
                var provider = context.HttpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)) as Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider;
                var viewResult = new ViewResult
                {
                    ViewName = "NegativeIdResult",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IDictionary<string, object>>(
                        provider,
                        context.ModelState)
                    {
                        Model = context.ActionArguments
                    }
                };
                context.Result = viewResult;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
} 