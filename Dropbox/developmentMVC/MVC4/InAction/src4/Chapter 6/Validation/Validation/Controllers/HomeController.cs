using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Edit()
        {
            return View(new CompanyInput());
        }

        [HttpGet]
        public ActionResult ClientValidation()
        {
            return View(new CompanyInputClient());
        }

        public ActionResult RemoteAttribute(UsingRemote input)
        {
            return View(input);
        }

        [HttpGet]
        public JsonResult IsNumberEven(int evenNumber)
        {
            return Json(evenNumber % 2 == 0, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(CompanyInput input)
        {
            if (ModelState.IsValid)
            {
                return View("Success");
            }
            return View(new CompanyInput());
        }
    }
}


