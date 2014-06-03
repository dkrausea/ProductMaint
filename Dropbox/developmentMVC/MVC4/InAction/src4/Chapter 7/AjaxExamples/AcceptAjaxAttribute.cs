using System;
using System.Reflection;
using System.Web.Mvc;

namespace AjaxExamples
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AcceptAjaxAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}