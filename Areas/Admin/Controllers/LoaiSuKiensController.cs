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
    public class LoaiSuKiensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LoaiSuKiens
        public ActionResult Index()
        {
            return View(db.LoaiSuKien.ToList());
        }

        // GET: Admin/LoaiSuKiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSuKien loaiSuKien = db.LoaiSuKien.Find(id);
            if (loaiSuKien == null)
            {
                return HttpNotFound();
            }
            return View(loaiSuKien);
        }

        // GET: Admin/LoaiSuKiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSuKiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLoaiSK,TrangThai")] LoaiSuKien loaiSuKien)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSuKien.Add(loaiSuKien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSuKien);
        }

        // GET: Admin/LoaiSuKiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSuKien loaiSuKien = db.LoaiSuKien.Find(id);
            if (loaiSuKien == null)
            {
                return HttpNotFound();
            }
            return View(loaiSuKien);
        }

        // POST: Admin/LoaiSuKiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLoaiSK,TrangThai")] LoaiSuKien loaiSuKien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSuKien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSuKien);
        }

        // GET: Admin/LoaiSuKiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSuKien loaiSuKien = db.LoaiSuKien.Find(id);
            if (loaiSuKien == null)
            {
                return HttpNotFound();
            }
            return View(loaiSuKien);
        }

        // POST: Admin/LoaiSuKiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiSuKien loaiSuKien = db.LoaiSuKien.Find(id);
            db.LoaiSuKien.Remove(loaiSuKien);
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
