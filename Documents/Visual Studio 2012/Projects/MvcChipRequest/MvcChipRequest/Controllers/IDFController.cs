using MvcChipRequest.DAL;
using MvcChipRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.Mailers;
using Mvc.Mailer;

namespace MvcChipRequest.Controllers
{
    public class IDFController : Controller
    {
        private RequestContext _db = new RequestContext();

        private IDriverMailer _driverMailer = new DriverMailer();
        public IDriverMailer DriverMailer
        {
            get { return _driverMailer; }
            set { _driverMailer = value; }
        }

        //
        //Send Driver MSM Alert
        public ActionResult DriverMSMAlert()
        {
            DriverMailer.DeliveryDriver().Send();
            return View();
        }

        //
        // GET: /IDF/


        public ActionResult Index()
        {
            ActionResult result;

            AllChipRequestsViewModel IdfView = new AllChipRequestsViewModel();
            IdfView.RLoad();

            if (IdfView.IsNotFound)
            {
                result = RedirectToAction("RequestNotFound");
            }
            else
            {
                result = View(IdfView);
            }

            return result;
        }

    }
}
