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
    public class TTNhatKiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TTNhatKies
        public ActionResult Index()
        {
            var tTNhatKy = db.TTNhatKy.Include(t => t.ThanhVien);
            return View(tTNhatKy.ToList());
        }

        // GET: Admin/TTNhatKies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTNhatKy tTNhatKy = db.TTNhatKy.Find(id);
            if (tTNhatKy == null)
            {
                return HttpNotFound();
            }
            return View(tTNhatKy);
        }

        // GET: Admin/TTNhatKies/Create
        public ActionResult Create()
        {
            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten");
            return View();
        }

        // POST: Admin/TTNhatKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdThanhVien,TGThamGia,SKDaThamGia")] TTNhatKy tTNhatKy)
        {
            if (ModelState.IsValid)
            {
                db.TTNhatKy.Add(tTNhatKy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten", tTNhatKy.IdThanhVien);
            return View(tTNhatKy);
        }

        // GET: Admin/TTNhatKies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTNhatKy tTNhatKy = db.TTNhatKy.Find(id);
            if (tTNhatKy == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten", tTNhatKy.IdThanhVien);
            return View(tTNhatKy);
        }

        // POST: Admin/TTNhatKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdThanhVien,TGThamGia,SKDaThamGia")] TTNhatKy tTNhatKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tTNhatKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdThanhVien = new SelectList(db.ThanhVien, "ID", "Ten", tTNhatKy.IdThanhVien);
            return View(tTNhatKy);
        }

        // GET: Admin/TTNhatKies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTNhatKy tTNhatKy = db.TTNhatKy.Find(id);
            if (tTNhatKy == null)
            {
                return HttpNotFound();
            }
            return View(tTNhatKy);
        }

        // POST: Admin/TTNhatKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TTNhatKy tTNhatKy = db.TTNhatKy.Find(id);
            db.TTNhatKy.Remove(tTNhatKy);
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
