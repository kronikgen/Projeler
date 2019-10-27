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
    public class CocukController : Controller
    {
        private evlatedindirmeEntities db = new evlatedindirmeEntities();

        // GET: Cocuk
        public ActionResult Index()
        {
            return View(db.Cocuk.ToList());
        }

        // GET: Cocuk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocuk cocuk = db.Cocuk.Find(id);
            if (cocuk == null)
            {
                return HttpNotFound();
            }
            return View(cocuk);
        }

        // GET: Cocuk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cocuk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CocukID,Ad,Soyad,DogumTarihi,Yas")] Cocuk cocuk)
        {
            if (ModelState.IsValid)
            {
                db.Cocuk.Add(cocuk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cocuk);
        }

        // GET: Cocuk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocuk cocuk = db.Cocuk.Find(id);
            if (cocuk == null)
            {
                return HttpNotFound();
            }
            return View(cocuk);
        }

        // POST: Cocuk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CocukID,Ad,Soyad,DogumTarihi,Yas")] Cocuk cocuk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cocuk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cocuk);
        }

        // GET: Cocuk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocuk cocuk = db.Cocuk.Find(id);
            if (cocuk == null)
            {
                return HttpNotFound();
            }
            return View(cocuk);
        }

        // POST: Cocuk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cocuk cocuk = db.Cocuk.Find(id);
            db.Cocuk.Remove(cocuk);
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
