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
    public class TTNhatKiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TTNhatKies
        public ActionResult Index()
        {
            return View(db.TTNhatKy.ToList());
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
