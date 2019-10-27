using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProjesiSonGün.Models;

namespace WebProjesiSonGün.Controllers
{
    public class EbeveynController : Controller
    {
        private evlatedindirmeEntities db = new evlatedindirmeEntities();

        // GET: Ebeveyn
        public ActionResult Index()
        {
            return View(db.Ebeveyn.ToList());
        }

        // GET: Ebeveyn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebeveyn ebeveyn = db.Ebeveyn.Find(id);
            if (ebeveyn == null)
            {
                return HttpNotFound();
            }
            return View(ebeveyn);
        }

        // GET: Ebeveyn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ebeveyn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EbeveynID,Ad,Soyad,Gelir")] Ebeveyn ebeveyn)
        {
            if (ModelState.IsValid)
            {
                db.Ebeveyn.Add(ebeveyn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ebeveyn);
        }

        // GET: Ebeveyn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebeveyn ebeveyn = db.Ebeveyn.Find(id);
            if (ebeveyn == null)
            {
                return HttpNotFound();
            }
            return View(ebeveyn);
        }

        // POST: Ebeveyn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EbeveynID,Ad,Soyad,Gelir")] Ebeveyn ebeveyn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ebeveyn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ebeveyn);
        }

        // GET: Ebeveyn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebeveyn ebeveyn = db.Ebeveyn.Find(id);
            if (ebeveyn == null)
            {
                return HttpNotFound();
            }
            return View(ebeveyn);
        }

        // POST: Ebeveyn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ebeveyn ebeveyn = db.Ebeveyn.Find(id);
            db.Ebeveyn.Remove(ebeveyn);
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
