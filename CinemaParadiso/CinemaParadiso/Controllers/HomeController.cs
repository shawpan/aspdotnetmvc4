using CinemaParadiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaParadiso.Controllers
{
    public class HomeController : Controller
    {
        CinemaParadisoDb _db = new CinemaParadisoDb();

        public ActionResult AutoComplete(string term)
        {
            var model = _db.Movies
                .Where(movie => movie.Name.Contains(term))
                .Take(10)
                .Select(r => new { 
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchText = null)
        {
            var movies = _db.Movies
                .OrderByDescending(movie => movie.Year)
                .Where(movie => searchText == null || movie.Name.Contains(searchText));

            ViewBag.SearchText = searchText;

            if(Request.IsAjaxRequest())
            {
                return PartialView("_Movies",movies);
            }

            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
