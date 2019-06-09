using Organization.BLL;
using Organization.ENTITY;
using Organization.UI.Filters;
using Organization.UI.Models;
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
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = userBLL.GetUser(model.Mail);
                if (user != null)
                {
                    ModelState.AddModelError("", "Bu Mail Kullanılıyor.");
                    return View(model);
                }
                Users newUser = new Users
                {
                    E_mail = model.Mail,
                    FirstName = model.FullName,
                    Password = model.Password,
                    Phone = model.Phone
                };

                userBLL.AddUser(newUser);
                Session["Login"] = newUser;
                return RedirectToAction("Index");
            }

            return View(model);
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

        [MyAuthenticationFilter]
        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Login");
        }
        [MyAuthenticationFilter]
        public ActionResult Hata()
        {
            return View();
        }
    }
}