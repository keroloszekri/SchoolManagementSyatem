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
    public class SubCatsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: SubCats
        public ActionResult Index()
        {
            Computony.Controllers.HomeController.CatsList = (db.Cat.Include(s => s.SubCats)).ToList();
            var subCat = db.SubCat.Include(s => s.Products);
            return View(subCat.ToList());
        }

        // GET: SubCats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCat subCat = db.SubCat.Find(id);
            if (subCat == null)
            {
                return HttpNotFound();
            }
            return View(subCat);
        }

        // GET: SubCats/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Cat, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CatID")] SubCat subCat)
        {
            if (ModelState.IsValid)
            {
                db.SubCat.Add(subCat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.Cat, "ID", "Name", subCat.CatID);
            return View(subCat);
        }

        // GET: SubCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCat subCat = db.SubCat.Find(id);
            if (subCat == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Cat, "ID", "Name", subCat.CatID);
            return View(subCat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CatID")] SubCat subCat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Cat, "ID", "Name", subCat.CatID);
            return View(subCat);
        }

        // GET: SubCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCat subCat = db.SubCat.Find(id);
            if (subCat == null)
            {
                return HttpNotFound();
            }
            return View(subCat);
        }

        // POST: SubCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCat subCat = db.SubCat.Find(id);
            db.SubCat.Remove(subCat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
