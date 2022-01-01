using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using ClubPortalMS.ViewModel.User;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class DBUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DBUsers
        public ActionResult Index()
        {
            List<DBUser> users = db.DBUser.ToList();
            var ds = from e in users
                          select new UserViewModel
                          {
                              ID = e.ID,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              Username = e.Username,
                              Email = e.Email,
                              Identifier = e.Identifier,
                              EmailConfirmation = e.EmailConfirmation,
                              HashedPassword = e.HashedPassword,
                              Salt = e.Salt,
                              IsLocked = e.IsLocked,
                              DateCreated = e.DateCreated,
                              IsDeleted = e.IsDeleted,
                              ActivationCode = e.ActivationCode,
                              NgayXoa = e.NgayXoa,
                              UserDeleted = e.UserDeleted
                              
                          };

            return View(ds);
        }

        // GET: Admin/DBUsers/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.DBUser.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new UserViewModel
            {
                ID = data.ID,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Username = data.Username,
                Email = data.Email,
                Identifier = data.Identifier,
                EmailConfirmation = data.EmailConfirmation,
                HashedPassword = data.HashedPassword,
                Salt = data.Salt,
                IsLocked = data.IsLocked,
                DateCreated = data.DateCreated,
                IsDeleted = data.IsDeleted,
                ActivationCode = data.ActivationCode,
                NgayXoa = data.NgayXoa,
                UserDeleted = data.UserDeleted

            };
            return View(viewModel);
        }

        // GET: Admin/DBUsers/Create
        public ActionResult Create()
        {
            var createUserView = new UserViewModel();
            return View(createUserView);
        }

        // POST: Admin/DBUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel dBUserView, int? id)
        {
            
            if (ModelState.IsValid)
            {
                DBUser data = new DBUser();
                data.ID = dBUserView.ID;
                data.FirstName = dBUserView.FirstName;
                data.LastName = dBUserView.LastName;
                data.Username = dBUserView.Username;
                data.Email = dBUserView.Email;
                data.Identifier = dBUserView.Identifier;
                data.EmailConfirmation = dBUserView.EmailConfirmation;
                data.HashedPassword = dBUserView.HashedPassword;
                data.Salt = dBUserView.Salt;
                data.IsLocked = dBUserView.IsLocked;
                data.DateCreated = dBUserView.DateCreated;
                data.IsDeleted = dBUserView.IsDeleted;
                data.ActivationCode = dBUserView.ActivationCode;
                data.NgayXoa = dBUserView.NgayXoa;
                data.UserDeleted = dBUserView.UserDeleted;

                db.DBUser.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dBUserView);
        }

        // GET: Admin/DBUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.DBUser.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new UserViewModel
            {
                ID = data.ID,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Username = data.Username,
                Email = data.Email,
                Identifier = data.Identifier,
                EmailConfirmation = data.EmailConfirmation,
                HashedPassword = data.HashedPassword,
                Salt = data.Salt,
                IsLocked = data.IsLocked,
                DateCreated = data.DateCreated,
                IsDeleted = data.IsDeleted,
                ActivationCode = data.ActivationCode,
                NgayXoa = data.NgayXoa,
                UserDeleted = data.UserDeleted

            };
            return View(viewModel);
        }

        // POST: Admin/DBUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel dBUserView, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.DBUser.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                data.ID = dBUserView.ID;
                data.FirstName = dBUserView.FirstName;
                data.LastName = dBUserView.LastName;
                data.Username = dBUserView.Username;
                data.Email = dBUserView.Email;
                data.Identifier = dBUserView.Identifier;
                data.EmailConfirmation = dBUserView.EmailConfirmation;
                data.HashedPassword = dBUserView.HashedPassword;
                data.Salt = dBUserView.Salt;
                data.IsLocked = dBUserView.IsLocked;
                data.DateCreated = dBUserView.DateCreated;
                data.IsDeleted = dBUserView.IsDeleted;
                data.ActivationCode = dBUserView.ActivationCode;
                data.NgayXoa = dBUserView.NgayXoa;
                data.UserDeleted = dBUserView.UserDeleted;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBUserView);
        }

        // GET: Admin/DBUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.DBUser.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new UserViewModel
            {
                ID = data.ID,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Username = data.Username,
                Email = data.Email,
                Identifier = data.Identifier,
                EmailConfirmation = data.EmailConfirmation,
                HashedPassword = data.HashedPassword,
                Salt = data.Salt,
                IsLocked = data.IsLocked,
                DateCreated = data.DateCreated,
                IsDeleted = data.IsDeleted,
                ActivationCode = data.ActivationCode,
                NgayXoa = data.NgayXoa,
                UserDeleted = data.UserDeleted

            };
            return View(viewModel);
        }

        // POST: Admin/DBUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserViewModel dBUserView,int id)
        {
            DBUser data = db.DBUser.Find(id);
            data.ID = dBUserView.ID;
            data.FirstName = dBUserView.FirstName;
            data.LastName = dBUserView.LastName;
            data.Username = dBUserView.Username;
            data.Email = dBUserView.Email;
            data.Identifier = dBUserView.Identifier;
            data.EmailConfirmation = dBUserView.EmailConfirmation;
            data.HashedPassword = dBUserView.HashedPassword;
            data.Salt = dBUserView.Salt;
            data.IsLocked = dBUserView.IsLocked;
            data.DateCreated = dBUserView.DateCreated;
            data.IsDeleted = dBUserView.IsDeleted;
            data.ActivationCode = dBUserView.ActivationCode;
            data.NgayXoa = dBUserView.NgayXoa;
            data.UserDeleted = dBUserView.UserDeleted;
            db.DBUser.Remove(data);
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
