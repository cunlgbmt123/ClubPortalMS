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
    public class PhanHoisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PhanHois
        public ActionResult Index()
        {
            return View(db.PhanHoi.ToList());
        }

        // GET: Admin/PhanHois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return HttpNotFound();
            }
            return View(phanHoi);
        }

        // GET: Admin/PhanHois/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanHois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ten,NoiDung,Email,SDT,DiaChi,IdCLB")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                db.PhanHoi.Add(phanHoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phanHoi);
        }

        // GET: Admin/PhanHois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return HttpNotFound();
            }
            return View(phanHoi);
        }

        // POST: Admin/PhanHois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ten,NoiDung,Email,SDT,DiaChi,IdCLB")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanHoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phanHoi);
        }

        // GET: Admin/PhanHois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            if (phanHoi == null)
            {
                return HttpNotFound();
            }
            return View(phanHoi);
        }

        // POST: Admin/PhanHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanHoi phanHoi = db.PhanHoi.Find(id);
            db.PhanHoi.Remove(phanHoi);
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
