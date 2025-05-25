using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace _3laba.Filters
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var query = context.HttpContext.Request.Query;
            var values = query.Select(x => x.Value.ToString()).ToList();
            if (values.Count < 2)
            {
                context.Result = new ViewResult
                {
                    ViewName = "ArgumentOutOfRangeError",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<string>(
                        context.HttpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)) as Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,
                        context.ModelState)
                    {
                        Model = "Недостаточно параметров в строке запроса"
                    }
                };
                return;
            }
            string floatStr = values[0];
            string longStr = values[1];
            try
            {
                float f = float.Parse(floatStr);
                long l = long.Parse(longStr);
            }
            catch (FormatException)
            {
                context.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<string>(
                        context.HttpContext.RequestServices.GetService(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)) as Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider,
                        context.ModelState)
                    {
                        Model = $"Ошибка преобразования параметров: {floatStr}, {longStr}"
                    }
                };
            }
        }
    }
} 