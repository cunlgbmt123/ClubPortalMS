//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using ClubPortalMS.Models;

//namespace ClubPortalMS.Areas.Admin.Controllers
//{
//    public class NhiemVusController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/NhiemVus
//        public ActionResult Index()
//        {
//            var nhiemVu = db.NhiemVu.Include(n => n.ThanhVien);
//            return View(nhiemVu.ToList());
//        }

//        // GET: Admin/NhiemVus/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NhiemVu nhiemVu = db.NhiemVu.Find(id);
//            if (nhiemVu == null)
//            {
//                return HttpNotFound();
//            }
//            return View(nhiemVu);
//        }

//        // GET: Admin/NhiemVus/Create
//        public ActionResult Create()
//        {
//            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten");
//            return View();
//        }

//        // POST: Admin/NhiemVus/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ID,TieuDe,MoTa,IdCLB,IdThanhVien")] NhiemVu nhiemVu)
//        {
//            if (ModelState.IsValid)
//            {
//                db.NhiemVu.Add(nhiemVu);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten", nhiemVu.IdThanhVien);
//            return View(nhiemVu);
//        }

//        // GET: Admin/NhiemVus/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NhiemVu nhiemVu = db.NhiemVu.Find(id);
//            if (nhiemVu == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten", nhiemVu.IdThanhVien);
//            return View(nhiemVu);
//        }

//        // POST: Admin/NhiemVus/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ID,TieuDe,MoTa,IdCLB,IdThanhVien")] NhiemVu nhiemVu)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(nhiemVu).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten", nhiemVu.IdThanhVien);
//            return View(nhiemVu);
//        }

//        // GET: Admin/NhiemVus/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NhiemVu nhiemVu = db.NhiemVu.Find(id);
//            if (nhiemVu == null)
//            {
//                return HttpNotFound();
//            }
//            return View(nhiemVu);
//        }

//        // POST: Admin/NhiemVus/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            NhiemVu nhiemVu = db.NhiemVu.Find(id);
//            db.NhiemVu.Remove(nhiemVu);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
