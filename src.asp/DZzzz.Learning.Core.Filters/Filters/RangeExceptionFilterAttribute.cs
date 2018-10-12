using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DZzzz.Learning.Core.Filters.Filters
{
    /// <summary>
    /// They are
    /// invoked when an exception is not handled by the action method or by the action or result filters that have
    /// been applied to the action method. (Action and result filters can deal with an unhandled exception by
    /// setting the ExceptionHandled property of their context objects to true.)
    /// </summary>
    public class RangeExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Message",
                    ViewData = new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = @"The data received by the application cannot be processed"
                    }
                };
            }
        }
    }
}