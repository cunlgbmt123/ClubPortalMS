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
    public class DangKiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DangKies
        public ActionResult Index()
        {
            return View(db.DangKy.ToList());
        }

        // GET: Admin/DangKies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKy dangKy = db.DangKy.Find(id);
            if (dangKy == null)
            {
                return HttpNotFound();
            }
            return View(dangKy);
        }

        // GET: Admin/DangKies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DangKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ten,MSSV,Email,SDT,NgayDangKy,TrangThai,IdCLB")] DangKy dangKy)
        {
            if (ModelState.IsValid)
            {
                db.DangKy.Add(dangKy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dangKy);
        }

        // GET: Admin/DangKies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKy dangKy = db.DangKy.Find(id);
            if (dangKy == null)
            {
                return HttpNotFound();
            }
            return View(dangKy);
        }

        // POST: Admin/DangKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ten,MSSV,Email,SDT,NgayDangKy,TrangThai,IdCLB")] DangKy dangKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dangKy);
        }

        // GET: Admin/DangKies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKy dangKy = db.DangKy.Find(id);
            if (dangKy == null)
            {
                return HttpNotFound();
            }
            return View(dangKy);
        }

        // POST: Admin/DangKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DangKy dangKy = db.DangKy.Find(id);
            db.DangKy.Remove(dangKy);
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
