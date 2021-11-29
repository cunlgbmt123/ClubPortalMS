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
    public class LoaiHDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LoaiHDs
        public ActionResult Index()
        {
            return View(db.LoaiHD.ToList());
        }

        // GET: Admin/LoaiHDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHD loaiHD = db.LoaiHD.Find(id);
            if (loaiHD == null)
            {
                return HttpNotFound();
            }
            return View(loaiHD);
        }

        // GET: Admin/LoaiHDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLoaiHD")] LoaiHD loaiHD)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHD.Add(loaiHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiHD);
        }

        // GET: Admin/LoaiHDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHD loaiHD = db.LoaiHD.Find(id);
            if (loaiHD == null)
            {
                return HttpNotFound();
            }
            return View(loaiHD);
        }

        // POST: Admin/LoaiHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLoaiHD")] LoaiHD loaiHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiHD);
        }

        // GET: Admin/LoaiHDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHD loaiHD = db.LoaiHD.Find(id);
            if (loaiHD == null)
            {
                return HttpNotFound();
            }
            return View(loaiHD);
        }

        // POST: Admin/LoaiHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiHD loaiHD = db.LoaiHD.Find(id);
            db.LoaiHD.Remove(loaiHD);
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
