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
    public class SuKiensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/SuKiens
        public ActionResult Index()
        {
            var suKien = db.SuKien.Include(s => s.CLB).Include(s => s.LoaiSuKien);
            return View(suKien.ToList());
        }

        // GET: Admin/SuKiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }

        // GET: Admin/SuKiens/Create
        public ActionResult Create()
        {
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB");
            ViewBag.IdLoaiSK = new SelectList(db.LoaiSuKien, "ID", "TenLoaiSK");
            return View();
        }

        // POST: Admin/SuKiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TieuDeSK,MoTa,NgayBatDau,NgayKetThuc,NoiDung,KetQua,DiaDiem,HinhThuc,TenFile,ContentType,File,IdLoaiSK,IdCLB")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                db.SuKien.Add(suKien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", suKien.IdCLB);
            ViewBag.IdLoaiSK = new SelectList(db.LoaiSuKien, "ID", "TenLoaiSK", suKien.IdLoaiSK);
            return View(suKien);
        }

        // GET: Admin/SuKiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", suKien.IdCLB);
            ViewBag.IdLoaiSK = new SelectList(db.LoaiSuKien, "ID", "TenLoaiSK", suKien.IdLoaiSK);
            return View(suKien);
        }

        // POST: Admin/SuKiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TieuDeSK,MoTa,NgayBatDau,NgayKetThuc,NoiDung,KetQua,DiaDiem,HinhThuc,TenFile,ContentType,File,IdLoaiSK,IdCLB")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suKien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", suKien.IdCLB);
            ViewBag.IdLoaiSK = new SelectList(db.LoaiSuKien, "ID", "TenLoaiSK", suKien.IdLoaiSK);
            return View(suKien);
        }

        // GET: Admin/SuKiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }

        // POST: Admin/SuKiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuKien suKien = db.SuKien.Find(id);
            db.SuKien.Remove(suKien);
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
