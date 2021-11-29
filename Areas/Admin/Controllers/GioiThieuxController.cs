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
    public class GioiThieuxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/GioiThieux
        public ActionResult Index()
        {
            var gioiThieu = db.GioiThieu.Include(g => g.CLB);
            return View(gioiThieu.ToList());
        }

        // GET: Admin/GioiThieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieu.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // GET: Admin/GioiThieux/Create
        public ActionResult Create()
        {
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB");
            return View();
        }

        // POST: Admin/GioiThieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCLB,MoTa,HinhAnh,LichSuHinhThanh")] GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                db.GioiThieu.Add(gioiThieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", gioiThieu.IdCLB);
            return View(gioiThieu);
        }

        // GET: Admin/GioiThieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieu.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", gioiThieu.IdCLB);
            return View(gioiThieu);
        }

        // POST: Admin/GioiThieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCLB,MoTa,HinhAnh,LichSuHinhThanh")] GioiThieu gioiThieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioiThieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", gioiThieu.IdCLB);
            return View(gioiThieu);
        }

        // GET: Admin/GioiThieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioiThieu gioiThieu = db.GioiThieu.Find(id);
            if (gioiThieu == null)
            {
                return HttpNotFound();
            }
            return View(gioiThieu);
        }

        // POST: Admin/GioiThieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GioiThieu gioiThieu = db.GioiThieu.Find(id);
            db.GioiThieu.Remove(gioiThieu);
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
