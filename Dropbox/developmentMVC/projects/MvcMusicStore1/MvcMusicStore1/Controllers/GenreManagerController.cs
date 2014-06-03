using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore1.Models;

namespace MvcMusicStore1.Controllers
{ 
    public class GenreManagerController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /GenreManager/

        public ViewResult Index()
        {
            return View(db.Genres.ToList());
        }

        //
        // GET: /GenreManager/Details/5

        public ViewResult Details(int id)
        {
            Genre genre = db.Genres.Find(id);
            return View(genre);
        }

        //
        // GET: /GenreManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /GenreManager/Create

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(genre);
        }
        
        //
        // GET: /GenreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Genre genre = db.Genres.Find(id);
            return View(genre);
        }

        //
        // POST: /GenreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //
        // GET: /GenreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            return View(genre);
        }

        //
        // POST: /GenreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}