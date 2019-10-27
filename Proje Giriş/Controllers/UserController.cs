using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjesiSonGün.Models;

namespace WebProjesiSonGün.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult EkleVeDegistir(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        //[HttpPost]
        //public ActionResult EkleVeDegistir(User userModel)
        //{
        //    using (DbModel dbModel = new DbModel())
        //    {

        //        dbModel.User.Add(userModel);
        //        dbModel.SaveChanges();
        //    }
        //    ModelState.Clear();
        //    ViewBag.SucessMessage = "Kayıt Başarılı !";
        //    return View("EkleVeDegistir", new User());
        //}
        [HttpPost]
        public ActionResult EkleVeDegistir(User userModel)
        {
            using (GirisİslemlerliEntities dbModel = new GirisİslemlerliEntities())
            {

                string Username = null;
                if (dbModel.User.Any(x => Username == userModel.Username))///Hata vermiyor aynı kullanıcıda
                {
                    ViewBag.DuplicateMessage = "Kullanıcı Adı Zaten Mevcut !";
                    return View("EkleVeDegistir", userModel);
                }
                Session["admin"] = null;
                dbModel.User.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SucessMessage = "Kayıt Başarılı !";
            return View("EkleVeDegistir", new User());
        }
    }
}