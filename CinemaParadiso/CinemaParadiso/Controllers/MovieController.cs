using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaParadiso.Models;

namespace CinemaParadiso.Controllers
{
    public class MovieController : Controller
    {
        private CinemaParadisoDb db = new CinemaParadisoDb();

        
        //
        // GET: /Movie/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            if(!User.IsInRole("admin") && movie.Approved == false)
            {
                return new HttpNotFoundResult("This entry is waiting for approval from administrators.");
            }
            return View(movie);
        }

        //
        // GET: /Movie/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Creator = User.Identity.Name;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Details", "Movie", new { movie.Id});
            }

            return View(movie);
        }

        //
        // GET: /Movie/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            if (!User.IsInRole("admin") && !User.Identity.Name.Equals(movie.Creator))
            {
                return HttpNotFound();
            }
            if (!User.IsInRole("admin") && movie.Approved == false)
            {
                return new HttpNotFoundResult("This entry is waiting for approval from administrators.");
            }
            return View(movie);
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Movie movie)
        {
            if (!User.IsInRole("admin") && !User.Identity.Name.Equals(movie.Creator))
            {
                return HttpNotFound();
            }
            if (!User.IsInRole("admin") && movie.Approved == false)
            {
                return new HttpNotFoundResult("This entry is waiting for approval from administrators.");
            }
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Movie", new { movie.Id });
            }
            return View(movie);
        }

        //
        // GET: /Movie/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            if (!User.IsInRole("admin") && !User.Identity.Name.Equals(movie.Creator))
            {
                return HttpNotFound();
            }
            if (!User.IsInRole("admin") && movie.Approved == false)
            {
                return new HttpNotFoundResult("This entry is waiting for approval from administrators.");
            }
            return View(movie);
        }

        //
        // POST: /Movie/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (!User.IsInRole("admin") && !User.Identity.Name.Equals(movie.Creator))
            {
                return HttpNotFound();
            }
            if (!User.IsInRole("admin") && movie.Approved == false)
            {
                return new HttpNotFoundResult("This entry is waiting for approval from administrators.");
            }
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}