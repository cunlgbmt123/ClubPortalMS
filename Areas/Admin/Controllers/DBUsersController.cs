using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class DBUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DBUsers
        public ActionResult Index()
        {
            return View(db.DBUser.ToList());
        }

        // GET: Admin/DBUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBUser dBUser = db.DBUser.Find(id);
            if (dBUser == null)
            {
                return HttpNotFound();
            }
            return View(dBUser);
        }

        // GET: Admin/DBUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DBUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Username,Email,EmailConfirmation,HashedPassword,Salt,IsLocked,DateCreated,IsDeleted,ActivationCode,NgayXoa,UserDeleted")] DBUser dBUser)
        {
            if (ModelState.IsValid)
            {
                db.DBUser.Add(dBUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dBUser);
        }

        // GET: Admin/DBUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBUser dBUser = db.DBUser.Find(id);
            if (dBUser == null)
            {
                return HttpNotFound();
            }
            return View(dBUser);
        }

        // POST: Admin/DBUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Username,Email,EmailConfirmation,HashedPassword,Salt,IsLocked,DateCreated,IsDeleted,ActivationCode,NgayXoa,UserDeleted")] DBUser dBUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBUser);
        }

        // GET: Admin/DBUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBUser dBUser = db.DBUser.Find(id);
            if (dBUser == null)
            {
                return HttpNotFound();
            }
            return View(dBUser);
        }

        // POST: Admin/DBUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBUser dBUser = db.DBUser.Find(id);
            db.DBUser.Remove(dBUser);
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
