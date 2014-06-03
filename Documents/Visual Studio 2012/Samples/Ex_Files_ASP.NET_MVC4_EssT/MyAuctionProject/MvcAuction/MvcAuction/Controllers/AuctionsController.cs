using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAuction.Controllers
{
    public class AuctionsController : Controller
    {
        //
        // GET: /Auctions/

        public ActionResult Index()
        {
            var auctions = new[]
                {
                   new Models.Auction()
                   {
                    Title = "Example Aution #1",
                    Description = "This is an example Auction",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = null,
                   },

                   new Models.Auction()
                   {
                    Title = "Example Aution #2",
                    Description = "This is a second Auction",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = 30m,
                   },

                   new Models.Auction()
                   {
                    Title = "Example Aution #3",
                    Description = "This is a third Auction",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = 24m,
                   },
                
                };

            return View(auctions);
        }

        public ActionResult TempDataDemo()
        {
            TempData["SuccessMessage"] = "The action succeeded!";
            return RedirectToAction("Index");
        }

        public ActionResult Auction()
        {

            var auction = new MvcAuction.Models.Auction()
            {
                Title = "Example Aution",
                Description = "This is an example Auction",
                StartTime = DateTime.Now.AddDays(7),
                StartPrice = 1.00m,
                CurrentPrice = null,
            };

            return View(auction);
        }

        public ActionResult Create()
        {
            var categoryList = new SelectList(new[] { "Automotive", "Electonics", "Games", "Home" });
            ViewBag.CategoryList = categoryList;
            return View();
        }

    }
}
