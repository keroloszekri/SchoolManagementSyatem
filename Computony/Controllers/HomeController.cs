using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Computony.Models;


namespace Computony.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        public static IEnumerable<Cat> CatsList ;

        public ActionResult Index()
        {
            CatsList = (db.Cat.Include(s => s.SubCats)).ToList();
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ShowCourseDetails(int id)
        {
            SubCat crs = db.SubCat.FirstOrDefault(s => s.ID == id);
            return PartialView("_PartialData", crs);
        }
    }
}