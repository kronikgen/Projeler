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
    public class KayitController : Controller
    {
        private evlatedindirmeEntities db = new evlatedindirmeEntities();

        // GET: Kayit
        public ActionResult Index()
        {
            var kayit = db.Kayit.Include(k => k.Cocuk).Include(k => k.Ebeveyn);
            return View(kayit.ToList());
        }

        // GET: Kayit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = db.Kayit.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // GET: Kayit/Create
        public ActionResult Create()
        {
            ViewBag.CocukID = new SelectList(db.Cocuk, "CocukID", "Ad");
            ViewBag.EbeveynID = new SelectList(db.Ebeveyn, "EbeveynID", "Ad");
            return View();
        }

        // POST: Kayit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KayitID,CocukID,EbeveynID,CocukAlmaDurumu")] Kayit kayit)
        {
            if (ModelState.IsValid)
            {
                db.Kayit.Add(kayit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CocukID = new SelectList(db.Cocuk, "CocukID", "Ad", kayit.CocukID);
            ViewBag.EbeveynID = new SelectList(db.Ebeveyn, "EbeveynID", "Ad", kayit.EbeveynID);
            return View(kayit);
        }

        // GET: Kayit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = db.Kayit.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CocukID = new SelectList(db.Cocuk, "CocukID", "Ad", kayit.CocukID);
            ViewBag.EbeveynID = new SelectList(db.Ebeveyn, "EbeveynID", "Ad", kayit.EbeveynID);
            return View(kayit);
        }

        // POST: Kayit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KayitID,CocukID,EbeveynID,CocukAlmaDurumu")] Kayit kayit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kayit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CocukID = new SelectList(db.Cocuk, "CocukID", "Ad", kayit.CocukID);
            ViewBag.EbeveynID = new SelectList(db.Ebeveyn, "EbeveynID", "Ad", kayit.EbeveynID);
            return View(kayit);
        }

        // GET: Kayit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = db.Kayit.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // POST: Kayit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kayit kayit = db.Kayit.Find(id);
            db.Kayit.Remove(kayit);
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
