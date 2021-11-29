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
    public class QLDSHoatDongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/QLDSHoatDongs
        public ActionResult Index()
        {
            var qLDSHoatDong = db.QLDSHoatDong.Include(q => q.CLB).Include(q => q.LoaiHD);
            return View(qLDSHoatDong.ToList());
        }

        // GET: Admin/QLDSHoatDongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLDSHoatDong qLDSHoatDong = db.QLDSHoatDong.Find(id);
            if (qLDSHoatDong == null)
            {
                return HttpNotFound();
            }
            return View(qLDSHoatDong);
        }

        // GET: Admin/QLDSHoatDongs/Create
        public ActionResult Create()
        {
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB");
            ViewBag.IdLoaiHD = new SelectList(db.LoaiHD, "ID", "TenLoaiHD");
            return View();
        }

        // POST: Admin/QLDSHoatDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ChuDe,NgayBatDau,NgayKetThuc,TrangThai,IdCLB,IdLoaiHD")] QLDSHoatDong qLDSHoatDong)
        {
            if (ModelState.IsValid)
            {
                db.QLDSHoatDong.Add(qLDSHoatDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", qLDSHoatDong.IdCLB);
            ViewBag.IdLoaiHD = new SelectList(db.LoaiHD, "ID", "TenLoaiHD", qLDSHoatDong.IdLoaiHD);
            return View(qLDSHoatDong);
        }

        // GET: Admin/QLDSHoatDongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLDSHoatDong qLDSHoatDong = db.QLDSHoatDong.Find(id);
            if (qLDSHoatDong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", qLDSHoatDong.IdCLB);
            ViewBag.IdLoaiHD = new SelectList(db.LoaiHD, "ID", "TenLoaiHD", qLDSHoatDong.IdLoaiHD);
            return View(qLDSHoatDong);
        }

        // POST: Admin/QLDSHoatDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ChuDe,NgayBatDau,NgayKetThuc,TrangThai,IdCLB,IdLoaiHD")] QLDSHoatDong qLDSHoatDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qLDSHoatDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", qLDSHoatDong.IdCLB);
            ViewBag.IdLoaiHD = new SelectList(db.LoaiHD, "ID", "TenLoaiHD", qLDSHoatDong.IdLoaiHD);
            return View(qLDSHoatDong);
        }

        // GET: Admin/QLDSHoatDongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLDSHoatDong qLDSHoatDong = db.QLDSHoatDong.Find(id);
            if (qLDSHoatDong == null)
            {
                return HttpNotFound();
            }
            return View(qLDSHoatDong);
        }

        // POST: Admin/QLDSHoatDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QLDSHoatDong qLDSHoatDong = db.QLDSHoatDong.Find(id);
            db.QLDSHoatDong.Remove(qLDSHoatDong);
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
