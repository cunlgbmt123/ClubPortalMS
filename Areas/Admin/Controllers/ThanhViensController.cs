﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using WebApplication1.Models;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class ThanhViensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ThanhViens
        public ActionResult Index()
        {
            return View(db.ThanhVien.ToList());
        }

        // GET: Admin/ThanhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // GET: Admin/ThanhViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThanhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCLB,Ten,NgaySinh,MSSV,Lop,SDT,Mail,IDUser")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.ThanhVien.Add(thanhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thanhVien);
        }

        // GET: Admin/ThanhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // POST: Admin/ThanhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCLB,Ten,NgaySinh,MSSV,Lop,SDT,Mail,IDUser")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thanhVien);
        }

        // GET: Admin/ThanhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // POST: Admin/ThanhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            db.ThanhVien.Remove(thanhVien);
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
