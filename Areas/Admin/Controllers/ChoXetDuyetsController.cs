using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using WebApplication1.Models;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class ChoXetDuyetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ChoXetDuyets
        public ActionResult Index()
        {
            return View(db.ChoXetDuyet.ToList());
        }

        // GET: Admin/ChoXetDuyets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoXetDuyet choXetDuyet = db.ChoXetDuyet.Find(id);
            if (choXetDuyet == null)
            {
                return HttpNotFound();
            }
            return View(choXetDuyet);
        }

        // GET: Admin/ChoXetDuyets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChoXetDuyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDNguoiDK,TrangThai")] ChoXetDuyet choXetDuyet)
        {
            if (ModelState.IsValid)
            {
                db.ChoXetDuyet.Add(choXetDuyet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(choXetDuyet);
        }

        // GET: Admin/ChoXetDuyets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoXetDuyet choXetDuyet = db.ChoXetDuyet.Find(id);
            if (choXetDuyet == null)
            {
                return HttpNotFound();
            }
            return View(choXetDuyet);
        }

        // POST: Admin/ChoXetDuyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDNguoiDK,TrangThai")] ChoXetDuyet choXetDuyet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choXetDuyet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(choXetDuyet);
        }

        // GET: Admin/ChoXetDuyets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoXetDuyet choXetDuyet = db.ChoXetDuyet.Find(id);
            if (choXetDuyet == null)
            {
                return HttpNotFound();
            }
            return View(choXetDuyet);
        }

        // POST: Admin/ChoXetDuyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChoXetDuyet choXetDuyet = db.ChoXetDuyet.Find(id);
            db.ChoXetDuyet.Remove(choXetDuyet);
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
