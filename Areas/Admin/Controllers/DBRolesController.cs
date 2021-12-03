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
    public class DBRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DBRoles
        public ActionResult Index()
        {
            return View(db.DBRoles.ToList());
        }

        // GET: Admin/DBRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRoles dBRoles = db.DBRoles.Find(id);
            if (dBRoles == null)
            {
                return HttpNotFound();
            }
            return View(dBRoles);
        }

        // GET: Admin/DBRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DBRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MoTa")] DBRoles dBRoles)
        {
            if (ModelState.IsValid)
            {
                db.DBRoles.Add(dBRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dBRoles);
        }

        // GET: Admin/DBRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRoles dBRoles = db.DBRoles.Find(id);
            if (dBRoles == null)
            {
                return HttpNotFound();
            }
            return View(dBRoles);
        }

        // POST: Admin/DBRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MoTa")] DBRoles dBRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBRoles);
        }

        // GET: Admin/DBRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRoles dBRoles = db.DBRoles.Find(id);
            if (dBRoles == null)
            {
                return HttpNotFound();
            }
            return View(dBRoles);
        }

        // POST: Admin/DBRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBRoles dBRoles = db.DBRoles.Find(id);
            db.DBRoles.Remove(dBRoles);
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
