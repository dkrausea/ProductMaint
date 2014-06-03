using System;
using System.Linq;
using System.Web.Mvc;

namespace Website.ActionResults
{
   public class AutoMappedViewResult : ViewResult
   {
      public static Func<object, Type, Type, object> Map = (a, b, c) =>
      {
         throw new InvalidOperationException(
            @"The Mapping function must be 
		   set on the AutoMapperResult class");
      };

      public AutoMappedViewResult(Type type)
      {
         DestinationType = type;
      }

      public Type DestinationType { get; set; }

      public override void ExecuteResult
         (ControllerContext context)
      {
         ViewData.Model = Map(ViewData.Model,
                              ViewData.Model.GetType(),
                              DestinationType);
         base.ExecuteResult(context);
      }
   }
}