using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Data.Objects;
using System.Data.Entity;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBModel _db = new MoviesDBModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Movies.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var movieToSearchOnIMDB = (from m in _db.Movies
                               where m.Id == id
                               select m).First();

            return Redirect("http://www.imdb.com/find?ref_=nv_sr_fn&q="+movieToSearchOnIMDB.Title+"&s=all");
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Movies.Add(movieToCreate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Movies
                               where m.Id == id
                               select m).First();

            return View(movieToEdit);
        }

        // POST: Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Movie movieToEdit)
        {
            _db.Entry(movieToEdit).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var movieToDelete = (from m in _db.Movies
                                 where m.Id == id
                                 select m).First();
            _db.Movies.Remove(movieToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    var movieToDelete = (from m in _db.Movies
        //                         where m.Id == id
        //                         select m).First();
        //    return View(movieToDelete);
        //}



        ////Currently unused. Might implement confirmation box later
        //// POST: Home/Delete/5
        //[HttpPost]
        //public ActionResult Delete()
        //{

        //    _db.Movies.Remove();


        //    return RedirectToAction("Index");
        //}
    }
}
