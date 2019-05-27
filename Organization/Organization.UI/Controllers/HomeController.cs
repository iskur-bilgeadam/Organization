using Organization.BLL;
using Organization.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organization.UI.Controllers
{
    public class HomeController : Controller
    {
        UserBLL userBLL = new UserBLL();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users User)
        {
            userBLL.AddUser(User);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users User)
        {
            Users user = userBLL.GetUser(User.E_mail);

            if (user != null)
            {
                if (user.Password == User.Password)
                {
                    Session["Login"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Hata");

                }

            }
            else
            {
                return RedirectToAction("Hata"); 

            }

        }
        public ActionResult Hata()
        {
            return View();
        }
    }
}