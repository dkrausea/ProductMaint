using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelectionSample.Controllers
{

   public class JsonpResult : JsonResult
   {
      public override void ExecuteResult(ControllerContext context)
      {
         if (context == null)
         {
            throw new ArgumentNullException("context");
         }

         var request = context.HttpContext.Request;
         var response = context.HttpContext.Response;
         
         string jsonCallBack = (context.RouteData.Values["callback"] as string) ?? request["callback"];

         if (!string.IsNullOrEmpty(jsonCallBack))
         {
            if (string.IsNullOrEmpty(base.ContentType))
            {
               base.ContentType = "application/x-javascript";
            }
            response.Write(string.Format("{0}(", jsonCallBack));
         }

         base.ExecuteResult(context);

         if (!string.IsNullOrEmpty(jsonCallBack))
         {
            response.Write(")");
         }
      }
   }

   public class SearchController : Controller
   {
      private static List<Employee> _employees
        = new List<Employee>
         {
            new Employee { id = 1, text = "johnk"},
            new Employee { id = 2, text = "russm"},
            new Employee { id = 3, text = "johnb"}
         };

      public ActionResult Find(string q, int page_limit)
      {
         return new JsonpResult
         {
            Data = _employees.FindAll(e => e.text.StartsWith(q)),
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
         };
      }
   }
}