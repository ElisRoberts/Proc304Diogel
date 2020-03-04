using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digoel.Filters
{
    public class MyLogginFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var req = filterContext.HttpContext.Request;

            base.OnActionExecuted(filterContext);
        }
    }
}