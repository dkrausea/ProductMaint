using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        
        //
        // GET: /Store/Browse
        public ActionResult Browse(String genre)
        {
            var genreModel = new Genre { Name = genre };
            return View(genreModel);
        }

        //
        // GET: /Store/Detail
        public ActionResult Details(int id) 
        {
            var album = new Album { Title = "Album " + id };
            return View(album);
        }


        public IView genres { get; set; }
    }
}
