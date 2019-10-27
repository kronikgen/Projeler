using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProjesiSonGün.Models;

namespace WebProjesiSonGün.Controllers
{
    public class HomeController : Controller
    {
        private evlatedindirmeEntities db = new evlatedindirmeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(db.Cocuk.ToList());
        }
        public ActionResult CocukDetails(int? id)
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(db.Ebeveyn.ToList());
        }
        // GET: Ebeveyn/Details/5
        public ActionResult EbeveynDetails(int? id)
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
    }
}