using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;

using ClubPortalMS.ViewModel.HoatDong;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class LoaiHDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LoaiHDs
        public ActionResult Index()
        {
            List<LoaiHD> loaiHD = db.LoaiHD.ToList();
            var ds = from e in loaiHD
                          select new LoaiHDViewModel
                          {
                              ID = e.ID,
                              TenLoaiHD = e.TenLoaiHD
                          };

            return View(ds);
            
        }

        // GET: Admin/LoaiHDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LoaiHD.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiHDViewModel
            {
                ID = data.ID,
                TenLoaiHD = data.TenLoaiHD

            };
            return View(viewModel);
        }

        // GET: Admin/LoaiHDs/Create
        public ActionResult Create()
        {
            var createLoaiHD = new LoaiHDViewModel();
            return View(createLoaiHD);
        }

        // POST: Admin/LoaiHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiHDViewModel loaiHDView)
        {
            if (ModelState.IsValid)
            {
                LoaiHD loaiHD = new LoaiHD();
                loaiHD.ID = loaiHDView.ID;
                loaiHD.TenLoaiHD = loaiHDView.TenLoaiHD;
                db.LoaiHD.Add(loaiHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiHDView);
        }

        // GET: Admin/LoaiHDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LoaiHD.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiHDViewModel
            {
                ID = data.ID,
                TenLoaiHD = data.TenLoaiHD

            };
            return View(viewModel);
        }

        // POST: Admin/LoaiHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( LoaiHDViewModel loaiHDView,int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loaiHD = db.LoaiHD.SingleOrDefault(n => n.ID == id);
            if (loaiHD == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                loaiHD.ID = loaiHDView.ID;
                loaiHD.TenLoaiHD = loaiHDView.TenLoaiHD;
                db.Entry(loaiHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiHDView);
        }

        // GET: Admin/LoaiHDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LoaiHD.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiHDViewModel
            {
                ID = data.ID,
                TenLoaiHD = data.TenLoaiHD

            };
            return View(viewModel);
        }

        // POST: Admin/LoaiHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(LoaiHDViewModel loaiHDView, int id)
        {
            
            LoaiHD loaiHD = db.LoaiHD.Find(id);
            loaiHD.ID = loaiHDView.ID;
            loaiHD.TenLoaiHD = loaiHDView.TenLoaiHD;
            db.LoaiHD.Remove(loaiHD);
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
