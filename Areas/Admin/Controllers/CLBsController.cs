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
    public class CLBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CLBs
        public ActionResult Index()
        {
            var cLB = db.CLB.Include(c => c.LoaiCLB);
            return View(cLB.ToList());
        }

        // GET: Admin/CLBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLB cLB = db.CLB.Find(id);
            if (cLB == null)
            {
                return HttpNotFound();
            }
            return View(cLB);
        }

        // GET: Admin/CLBs/Create
        public ActionResult Create()
        {
            ViewBag.IdLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB");
            return View();
        }

        // POST: Admin/CLBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdLoaiCLB,TenCLB,TrangThai,NgayThanhLap,LienHe,Mota,FanPage,Email")] CLB cLB)
        {
            if (ModelState.IsValid)
            {
                db.CLB.Add(cLB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB", cLB.IdLoaiCLB);
            return View(cLB);
        }

        // GET: Admin/CLBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLB cLB = db.CLB.Find(id);
            if (cLB == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB", cLB.IdLoaiCLB);
            return View(cLB);
        }

        // POST: Admin/CLBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdLoaiCLB,TenCLB,TrangThai,NgayThanhLap,LienHe,Mota,FanPage,Email")] CLB cLB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB", cLB.IdLoaiCLB);
            return View(cLB);
        }

        // GET: Admin/CLBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLB cLB = db.CLB.Find(id);
            if (cLB == null)
            {
                return HttpNotFound();
            }
            return View(cLB);
        }

        // POST: Admin/CLBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLB cLB = db.CLB.Find(id);
            db.CLB.Remove(cLB);
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
