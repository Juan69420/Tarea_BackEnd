using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea_BackEnd_MVC.Models;

namespace Tarea_BackEnd_MVC.Controllers
{
    public class GianellasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Gianellas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Gianellas.ToList());
        }

        // GET: Gianellas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gianella gianella = db.Gianellas.Find(id);
            if (gianella == null)
            {
                return HttpNotFound();
            }
            return View(gianella);
        }

        // GET: Gianellas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gianellas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gianellaID,Friendofgianella,Place,Email,Birthdate")] Gianella gianella)
        {
            if (ModelState.IsValid)
            {
                db.Gianellas.Add(gianella);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gianella);
        }

        // GET: Gianellas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gianella gianella = db.Gianellas.Find(id);
            if (gianella == null)
            {
                return HttpNotFound();
            }
            return View(gianella);
        }

        // POST: Gianellas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gianellaID,Friendofgianella,Place,Email,Birthdate")] Gianella gianella)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gianella).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gianella);
        }

        // GET: Gianellas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gianella gianella = db.Gianellas.Find(id);
            if (gianella == null)
            {
                return HttpNotFound();
            }
            return View(gianella);
        }

        // POST: Gianellas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gianella gianella = db.Gianellas.Find(id);
            db.Gianellas.Remove(gianella);
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
