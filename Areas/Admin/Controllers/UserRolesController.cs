﻿using System;
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
    public class UserRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/UserRoles
        public ActionResult Index()
        {
            var userRole = db.DBUserRoles.Include(u => u.DBRoles).Include(u => u.DBUser);
            return View(userRole.ToList());
        }

        // GET: Admin/UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBUserRoles userRoles = db.DBUserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        // GET: Admin/UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.DBRoles, "ID", "Name");
            ViewBag.UserID = new SelectList(db.DBUser, "ID", "Username");
            return View();
        }

        // POST: Admin/UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,RoleID")] DBUserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.DBUserRoles.Add(userRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.DBRoles, "ID", "Name", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.DBUser, "ID", "Username", userRoles.UserID);
            return View(userRoles);
        }

        // GET: Admin/UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBUserRoles userRoles = db.DBUserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.DBRoles, "ID", "Name", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.DBUser, "ID", "Username", userRoles.UserID);
            return View(userRoles);
        }

        // POST: Admin/UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,RoleID")] DBUserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.DBRoles, "ID", "Name", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.DBUser, "ID", "Username", userRoles.UserID);
            return View(userRoles);
        }

        // GET: Admin/UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBUserRoles userRoles = db.DBUserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        // POST: Admin/UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBUserRoles userRoles = db.DBUserRoles.Find(id);
            db.DBUserRoles.Remove(userRoles);
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