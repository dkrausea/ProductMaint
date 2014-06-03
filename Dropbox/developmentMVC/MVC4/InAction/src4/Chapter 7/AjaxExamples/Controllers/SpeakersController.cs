using System.Web.Mvc;
using AjaxExamples.Models;

namespace AjaxExamples.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly SpeakerRepository _repository = new SpeakerRepository();

        public ActionResult Index()
        {
            var speakers = _repository.FindAll();
            return View(speakers);
        }
        
        [AcceptAjax]
        public ActionResult Details(int id)
        {
            var speaker = _repository.FindSpeaker(id);

            // Allow GET requests to this action using the JsonRequestBehavior enum. 
            // By default, MVC only allows POST results to retrieve JSON
            // because you could be exposing a security hole if you return sensitive data in a JSON array over a GET.
            return Json(speaker, JsonRequestBehavior.AllowGet);
        }

        [ActionName("Details")]
        public ActionResult Details_NonAjax(int id)
        {
            var speaker = _repository.FindSpeaker(id);
            return View(speaker);
        }
    }
}