using System;
using System.Runtime.Remoting;
using System.Web.Mvc;
using Collections101.BusinessLayer.Entities;

namespace Collections101.Website.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult RunSample(string number)
      {
         ISample sample = SampleFactory.CreateSample(number);
         sample.RunDemo();
         
         return RedirectToAction("Index");
      }
   }

   #region Factory for Sample Instances

   public class SampleFactory
   {
      public static ISample CreateSample(string number)
      {
         string type = 
            string.Format("Collections101.BusinessLayer.Sample{0}", number);
         ObjectHandle handle = 
            Activator.CreateInstance("Collections101.BusinessLayer", type);
         return (ISample)handle.Unwrap();
      }
   }

   #endregion
}
