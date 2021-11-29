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
    public class LoaiCLBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LoaiCLBs
        public ActionResult Index()
        {
            return View(db.LoaiCLB.ToList());
        }

        // GET: Admin/LoaiCLBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiCLB loaiCLB = db.LoaiCLB.Find(id);
            if (loaiCLB == null)
            {
                return HttpNotFound();
            }
            return View(loaiCLB);
        }

        // GET: Admin/LoaiCLBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiCLBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLoaiCLB,TenLoaiCLB")] LoaiCLB loaiCLB)
        {
            if (ModelState.IsValid)
            {
                db.LoaiCLB.Add(loaiCLB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiCLB);
        }

        // GET: Admin/LoaiCLBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiCLB loaiCLB = db.LoaiCLB.Find(id);
            if (loaiCLB == null)
            {
                return HttpNotFound();
            }
            return View(loaiCLB);
        }

        // POST: Admin/LoaiCLBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLoaiCLB,TenLoaiCLB")] LoaiCLB loaiCLB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiCLB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiCLB);
        }

        // GET: Admin/LoaiCLBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiCLB loaiCLB = db.LoaiCLB.Find(id);
            if (loaiCLB == null)
            {
                return HttpNotFound();
            }
            return View(loaiCLB);
        }

        // POST: Admin/LoaiCLBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiCLB loaiCLB = db.LoaiCLB.Find(id);
            db.LoaiCLB.Remove(loaiCLB);
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
