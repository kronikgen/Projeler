using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjesiSonGün.Models;

namespace WebProjesiSonGün.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kontrol(WebProjesiSonGün.Models.User userModeli)
        {
            using (GirisİslemlerliEntities db = new GirisİslemlerliEntities())
            {
                var userDetails = db.User.Where(x => x.Username == userModeli.Username && x.Password == userModeli.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModeli.LoginErrorMessage = "                Kullanıcı Adı Yada Sifre Hatalı !";
                    return View("Index", userModeli);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.Username;
                    Session["admin"] = userDetails.IsAdmin;
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }

        }
        public ActionResult Cikis()
        {
            int userId = (int)Session["userID"];/// Girilen Sayfaya
            
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}