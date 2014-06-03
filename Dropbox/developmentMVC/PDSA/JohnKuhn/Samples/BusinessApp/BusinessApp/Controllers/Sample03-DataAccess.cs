using System;
using System.Diagnostics;
using System.Web.Mvc;
using BusinessApp.BusinessLayer;
using BusinessApp.BusinessLayer.Entities;

namespace BusinessApp.Controllers
{
   /// <summary>
   /// Sample 03 - Data Access - Controller class
   /// </summary>
   public class Sample03Controller : Controller
   {
      /// <summary>
      /// Get a collection of products
      /// </summary>
      /// <returns>An ActionResult for a view of a product collection</returns>
      public ActionResult Index()
      {
         Debugger.Break();

         ProductCollection products = null;
         ProductManager manager = null;
         ActionResult result = null;

         try
         {
            // Encapsulate access to data stores, etc.,
            // using business objects and follow
            // a 'chain of responsibility' pattern:

            // Controller > ViewModel > Business Object 
            //  > Repository/Data > Database/Storage

            manager = new ProductManager();
            products = manager.GetAllProducts();
            result = View(products);
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError(string.Empty, ex.Message);
            products = new ProductCollection(); // empty collection
            result = View(products);
         }

         return result;
      }
   }
}
