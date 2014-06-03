using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcChipRequest.DAL;
using MvcChipRequest.Models;
using MvcChipRequest.ViewModels;
using System.Web.Security;
using MvcChipRequest.Mailers;
using Mvc.Mailer;



namespace MvcChipRequest.Controllers
{
    public class ChipRequestController : Controller
    {
        private RequestContext _db = new RequestContext();
        private int _id = 0;

        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

       


        private SelectList ReturnActiveMCNList()
        {
            var McnQry = from mcn in _db.Chips
                         orderby mcn.MCN
                         where mcn.IsActive == true
                         select new { mcn.ChipID, mcn.MCN };


            return new SelectList(McnQry, "ChipID", "MCN");
        }

        //
        //Send Welcome Message
        public ActionResult SendWelcomeMessage()
        {
            UserMailer.Welcome().Send(); //Send() exention method:  using Mvc.Mailer
            return RedirectToAction("GTW");
        }

        




        //
        // GET: /ChipRequest/

        [HttpGet]
        [Authorize(Roles="opsIT.Admins")]
        public ActionResult Index()
        {
            
            return View(_db.ChipRequests.ToList());
        }

        //
        // GET: /ChipRequest/Create
        [HttpGet]
        [Authorize(Roles = "ChipRequestCreate, opsIT.Admins")]
        public ActionResult Create()
        {

            //ViewBag.ChipID = new SelectList(_db.Chips, "ChipID", "MCN");
            ViewBag.ChipID = ReturnActiveMCNList();

            return View();
        }

        //
        // POST: /ChipRequest/Create

        [HttpPost]
        [Authorize(Roles = "ChipRequestCreate, opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChipRequest chiprequest)
        {
            if (ModelState.IsValid)
            {
                var Uin = User.Identity.Name.Substring(3);
                chiprequest.Quantity = 0;
                chiprequest.CreatedBy = Uin;
                chiprequest.CreatedOn = DateTime.Now;
                chiprequest.IsActive = bool.Parse("True");
                chiprequest.ModifideBy = Uin;
                chiprequest.ModifiedOn = DateTime.Now;


                _db.ChipRequests.Add(chiprequest);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ChipID = new SelectList(_db.Chips, "ChipID", "MCN", chiprequest.ChipID);
            return View(chiprequest);
        }
        //
        // GET: /ChipRequest/Edit/5
        [HttpGet]
        [Authorize(Roles="ChipRequest")]
        public ActionResult Edit(int id, int dsid = 0)
        {
            ActionResult result;

            ChipRequestViewModel vm = new ChipRequestViewModel();
            vm.Load(id, dsid);

            if (vm.IsNotFound)
            {
                result = RedirectToAction("RequestNotFound");
            }
            else
            {
                ViewBag.ChipID = vm.chips;

                result = View(vm);
            }

            return result;
        }


        // 
        // POST: /ChipRequest/Edit/5

        [HttpPost]
        [Authorize(Roles = "ChipRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChipRequest chiprequest)
        {

            if (ModelState.IsValid)
            {
                chiprequest.ModifideBy = User.Identity.Name.Substring(3);
                chiprequest.ModifiedOn = DateTime.Now;


                _db.Entry(chiprequest).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = chiprequest.ChipRequestID });
            }
            ViewBag.ChipID = new SelectList(_db.Chips, "ChipID", "MCN", chiprequest.ChipID);
            return View(chiprequest);
        }

        //
        // GET: /ChipRequest/Delete/5 
        [HttpGet]
        [Authorize(Roles = "opsIT.Admins")]
        public ActionResult Delete(int id = 0)
        {
            ChipRequest chiprequest = _db.ChipRequests.Find(id);
            if (chiprequest == null)
            {
                return HttpNotFound();
            }
            return View(chiprequest);
        }

        //
        // POST: /ChipRequest/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChipRequest chiprequest = _db.ChipRequests.Find(id);
            _db.ChipRequests.Remove(chiprequest);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        //
        // GET: /Demand/Edit/5
        [HttpGet]
        [Authorize(Roles="ChipRequest")]
        public ActionResult DemandEdit(int id = 0)
        {
            Demand demand = _db.Demands.Find(id);

            if (demand == null)
            {
                return HttpNotFound();
            }
            ViewBag.DemandStatusID = new SelectList(_db.DemandStatuses, "DemandStatusID", "Status", demand.DemandStatusID);
            ViewBag.DEMCN = _db.Demands.Find(id).ChipRequest.Chip.MCN;
            ViewBag.DEDesc = _db.Demands.Find(id).ChipRequest.Chip.Description;

            return View(demand);
        }

        //
        // POST: /Demand/Edit/5

        [HttpPost]
        [Authorize(Roles = "ChipRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult DemandEdit(Demand demand)
        {
            var Uin = User.Identity.Name.Substring(3);
            if (ModelState.IsValid)
            {
                demand.ModifideBy = Uin;
                demand.ModifiedOn = DateTime.Now;

                _db.Entry(demand).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = demand.ChipRequestID, dsid=4 });
            }
            ViewBag.ChipID = new SelectList(_db.Demands, "DemandStatusID", "Status", demand.DemandStatusID);


            return View(demand);
        }


        //
        // GET: /Demand/Create
        [HttpGet]
        [Authorize(Roles = "ChipRequest")]
        public ActionResult DemandCreate(int id)
        {

            Demand demand = new Demand();
            demand.Planners = User.Identity.Name.Substring(3);
            demand.NeededBy = DateTime.Now;


            this._id = id;
            ViewBag.DemandStatusID = new SelectList(_db.DemandStatuses, "DemandStatusID", "Status");
            ViewBag.MCN = _db.ChipRequests.Find(id).Chip.MCN;
            ViewBag.Description = _db.ChipRequests.Find(id).Chip.Description;

            return View(demand);
        }

        //
        // POST: /Demand/Create

        [HttpPost]
        [Authorize(Roles = "ChipRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult DemandCreate(Demand demand, int id)
        {
            var Uin = User.Identity.Name.Substring(3);
            if (ModelState.IsValid)
            {
                demand.DemandStatusID = 1;
                demand.ChipRequestID = id;
                demand.CreatedBy = Uin;
                demand.CreatedOn = DateTime.Now;
                demand.IsActive = bool.Parse("True");
                demand.ModifideBy = Uin;
                demand.ModifiedOn = DateTime.Now;

                _db.Demands.Add(demand);
                _db.SaveChanges();
                return RedirectToAction("Edit", "ChipRequest", new { id = demand.ChipRequestID, dsid = 4 });
            }

            ViewBag.ChipID = new SelectList(_db.Demands, "DemandStatusID", "Status", demand.DemandStatusID);
            return View(demand);
        }


        //
        // GET: /Demand/Delete/5
        [HttpGet]
        [Authorize(Roles = "ChipRequest")]
        public ActionResult DemandDelete(int id = 0)
        {
            Demand demand = _db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }

            ViewBag.DEMCN = _db.Demands.Find(id).ChipRequest.Chip.MCN;
            ViewBag.DEDesc = _db.Demands.Find(id).ChipRequest.Chip.Description;

            return View(demand);
        }

        //
        // POST: /Demand/Delete/5

        [HttpPost, ActionName("DemandDelete")]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult DemandDeleteConfirmed(int id)
        {
            Demand demand = _db.Demands.Find(id);

            if (demand.ReleaseQuantity == 0  )
            {
                _db.Demands.Remove(demand);
                _db.SaveChanges();
                return RedirectToAction("GTW", "ChipRequest");
            }
            else {
                ViewBag.DEMCN = _db.Demands.Find(id).ChipRequest.Chip.MCN;
                ViewBag.DEDesc = _db.Demands.Find(id).ChipRequest.Chip.Description;
                this.ModelState.AddModelError("", "This Demand has a Relese and cannot be deleted.");
            }
            return View(demand);
        }


        //
        // GET: /ATP/Create
        [HttpGet]
        [Authorize(Roles = "ChipRequest")]
        public ActionResult ATPCreate(int id)
        {
            Demand demand = _db.Demands.Find(id);

            //var sourceList = new SelectList(new[] {"Inventory", "MQDS-W Test Floor", "Santa Claus", "SAT Direct", "Singapore" });
            //ViewBag.SourceList = sourceList;

            ATP atpItem = new ATP
            {
                DemandID = id,
                Quantity = demand.ATPDelta,
                ExpectedBy = DateTime.Now
            };

            ViewBag.MCN = _db.Demands.Find(id).ChipRequest.Chip.MCN;
            ViewBag.Description = _db.Demands.Find(id).ChipRequest.Chip.Description;

            return View(atpItem);
        }


        //
        // POST: /ATP/Create

        [HttpPost]
        [Authorize(Roles = "ChipRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult ATPCreate(ATP atp)
             
        {

            if (atp.ExpectedBy == null)
            {
                ModelState.AddModelError(
                    "ExpectedBy",
                    "Expected By cannot be NULL!"
                    );
            }

            if (ModelState.IsValid)
            {

                atp.CreatedBy = User.Identity.Name.Substring(3);
                atp.CreatedOn = DateTime.Now;
                atp.IsActive = bool.Parse("True");
                atp.ModifideBy = User.Identity.Name.Substring(3);
                atp.ModifiedOn = DateTime.Now;


                _db.ATPs.Add(atp);
                _db.SaveChanges();

                int chiprequestID = _db.Demands.Find(atp.DemandID).ChipRequestID;

                return RedirectToAction("Edit", "ChipRequest", new { id = chiprequestID, dsid=4 });
            }

            ViewBag.DemandID = new SelectList(_db.Demands, "DemandID", "CrPlanners", atp.DemandID);
            return View(atp);
        }

        //
        // GET: /ATP/Edit/5
        [HttpGet]
        [Authorize(Roles = "ChipRequest")]
        public ActionResult ATPEdit(int id = 0)
        {
            ATP atp = _db.ATPs.Find(id);

            if (atp == null)
            {
                return HttpNotFound();
            }
            ViewBag.DemandID = new { DemandID = atp.DemandID };
            ViewBag.MCN = _db.ATPs.Find(id).Demand.ChipRequest.Chip.MCN;
            ViewBag.Description = _db.ATPs.Find(id).Demand.ChipRequest.Chip.Description;

            return View(atp);
        }

        //
        // POST: /ATP/Edit/5

        [HttpPost]
        [Authorize(Roles = "ChipRequest")]
        [ValidateAntiForgeryToken]
        public ActionResult ATPEdit(ATP atp)
        {
            if (atp.ExpectedBy == null)
            { 
               ModelState.AddModelError(
                   "ExpectedBy",
                   "Expected By cannont be NULL!!!"
                   );
            }


            if (ModelState.IsValid)
            {

                atp.ModifideBy = User.Identity.Name.Substring(3);
                atp.ModifiedOn = DateTime.Now;

                _db.Entry(atp).State = EntityState.Modified;
                _db.SaveChanges();

                int chiprequestID = _db.Demands.Find(atp.DemandID).ChipRequestID;

                return RedirectToAction("Edit", "ChipRequest", new { id = chiprequestID, dsid = 4 });
            }
            ViewBag.DemandID = new SelectList(_db.Demands, "DemandID", "CrPlanners", atp.DemandID);
            return View(atp);
        }

        //
        // GET: /Release/Create
        [HttpGet]
        [Authorize(Roles="qct.materials, opsIT.Admins")]
        public ActionResult ReleaseCreate(int id)
        {
            ATP atp = _db.ATPs.Find(id);

            Release releaseItem = new Release //Created a new instance of Release and name it releaseItem then make the ATPID property equal to the passed in int id variable.
            {
                ATPID = id,
                ReleaseDate = DateTime.Now,
                Quantity = atp.ReleaseDelta
            };

            ViewBag.ATPID = new SelectList(_db.ATPs, "ATPID", "PMPA");
            ViewBag.MCN = _db.ATPs.Find(id).Demand.ChipRequest.Chip.MCN;
            ViewBag.Description = _db.ATPs.Find(id).Demand.ChipRequest.Chip.Description;


            return View(releaseItem);
        }

        //
        // POST: /Release/Create

        [HttpPost]
        [Authorize(Roles = "qct.materials, opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult ReleaseCreate(Release release)
        {
            var Uin = User.Identity.Name.Substring(3);
            if (ModelState.IsValid)
            {

                release.CreatedBy = Uin;
                release.CreatedOn = DateTime.Now;
                release.ReleasedBy = Uin;
                release.ModifideBy = Uin;
                release.ModifiedOn = DateTime.Now;

                _db.Releases.Add(release);
                _db.SaveChanges();

                //TODO:  Send Email message to 


                ATP atp = _db.ATPs.Find(release.ATPID);
                // TODO:  Check if  ATPID is found


                int chiprequestID = _db.Demands.Find(atp.DemandID).ChipRequestID;

                return RedirectToAction("Edit", "ChipRequest", new { id = chiprequestID, dsid = 4 });
            }

            return View(release);
        }

        //
        // GET: /Release/Edit/5
        [HttpGet]
        [Authorize(Roles="qct.materials, opsIT.Admins")]
        public ActionResult ReleaseEdit(int id = 0)
        {
            Release release = _db.Releases.Find(id);

            if (release == null)
            {
                return HttpNotFound();
            }
            ViewBag.ATPID = new { ATPID = release.ATPID };
            ViewBag.MCN = release.ATP.Demand.ChipRequest.Chip.MCN;
            ViewBag.Description = release.ATP.Demand.ChipRequest.Chip.Description;


            return View(release);
        }

        //
        // POST: /Release/Edit/5

        [HttpPost]
        [Authorize(Roles = "qct.materials, opsIT.Admins")]
        [ValidateAntiForgeryToken]
        public ActionResult ReleaseEdit(Release release)
        {
            var Uin = User.Identity.Name.Substring(3);

            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {

                // Commented out during PDSA session with John Kuhn 10/25/2013
                //release.ModifideBy = Uin;
                //release.ModifiedOn = DateTime.Now;


                Release Current = _db.Releases.Find(release.ReleaseID);

                Current.IDF = release.IDF;
                Current.Quantity = release.Quantity;
                Current.ReleaseDate = release.ReleaseDate;
                Current.ModifideBy = Uin;
                Current.ModifiedOn = DateTime.Now;
                Current.ReleaseNotes = release.ReleaseNotes;

                // Commented out during PDSA session with John Kuhn 10/25/2013
                //_db.Entry(release).State = EntityState.Modified;
                _db.SaveChanges();

                int chiprequestID = _db.ATPs.Find(release.ATPID).Demand.ChipRequestID;

                return RedirectToAction("Edit", "ChipRequest", new { id = chiprequestID, dsid = 4 });
            }

            return View(release);
        }


        //
        //GET: Get to work!
        [HttpGet]
        [Authorize(Roles="ChipRequest")]
        public ActionResult GTW(string sortOrder)
        {
            ActionResult result;
            
            AllChipRequestsViewModel av = new AllChipRequestsViewModel();
            av.CLoad();

            if (av.IsNotFound)
            {
                result = RedirectToAction("RequestNotFound");
            }
            else
            {

                result = View(av);
            }

            return result;
        }


        // 
        // POST: Get to work!

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ChipRequest")]
        public ActionResult GTW(ChipRequest chiprequest)
        {

            if (ModelState.IsValid)
            {
                chiprequest.ModifideBy = User.Identity.Name.Substring(3);
                chiprequest.ModifiedOn = DateTime.Now;


                _db.Entry(chiprequest).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = chiprequest.ChipRequestID });
            }
            ViewBag.ChipID = new SelectList(_db.Chips, "ChipID", "MCN", chiprequest.ChipID);
            return View(chiprequest);
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult RequestNotFound()
        {
            return View();
        }
    }
}