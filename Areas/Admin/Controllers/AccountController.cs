using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private ClubPortalMSEntitiess db = new ClubPortalMSEntitiess();
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                var profile = new ThanhVien();
                profile.IDUser = user.ID;
                db.ThanhViens.Add(profile);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Username + " " + "đã đăng nhập thành công";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = db.Users.Single(u => u.Username == user.Username && u.HashedPassword == user.HashedPassword);
            if (usr != null)
            {
                Session["ID"] = usr.ID.ToString();
                Session["Username"] = usr.Username.ToString();
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("","Tài khoản hoặc mật khẩu không đúng");
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if(Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}