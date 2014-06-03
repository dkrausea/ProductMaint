using System;
using System.Web;
using System.Web.Mvc;

namespace RoutingSample
{
	public class NotFoundResult : ActionResult
	{
		public override void ExecuteResult(ControllerContext context)
		{
			context.HttpContext.Response.StatusCode = 404;
			new ViewResult() { ViewName = "NotFound" }.ExecuteResult(context);
		}
	}
}