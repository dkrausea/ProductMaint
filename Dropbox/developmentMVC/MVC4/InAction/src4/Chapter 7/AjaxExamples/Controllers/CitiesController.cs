using System.Web.Mvc;
using System.Linq;
using AjaxExamples.Models;

namespace AjaxExamples.Controllers
{
    public class CitiesController : Controller
    {
        private readonly CityRepository _repository;

        public CitiesController() 
        {
            _repository = new CityRepository();
        }

		public ActionResult Index() 
		{
			return View();
		}

        public ActionResult Find(string term)
        {
            City[] cities = _repository.FindCities(term);

            // Project the cities into the strucutre we want serialized to JSON
            var projection = from city in cities
                             select new 
                             {
                                id = city.Id, 
                                label = city.DisplayName, 
                                value = city.DisplayName
                             };

            return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}