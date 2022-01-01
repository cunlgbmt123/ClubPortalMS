using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using ClubPortalMS.ViewModel.Sukien;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class LoaiSuKiensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LoaiSuKiens
        public ActionResult Index()
        {
            List<LoaiSuKien> albums = db.LoaiSuKien.ToList();
            var dsSK = from e in albums
                          select new LoaiSuKienViewModel
                          {
                              ID = e.ID,
                              TenLoaiSK = e.TenLoaiSK,
                              TrangThai = e.TrangThai
                          };

            return View(dsSK);
        }

        // GET: Admin/LoaiSuKiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LoaiSuKien.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiSuKienViewModel
            {
                ID = data.ID,
                TenLoaiSK = data.TenLoaiSK,
                TrangThai = data.TrangThai

            };
            return View(viewModel);
        }

        // GET: Admin/LoaiSuKiens/Create
        public ActionResult Create()
        {
            var createLoaiSK = new LoaiSuKienViewModel();
            return View(createLoaiSK);
        }

        // POST: Admin/LoaiSuKiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiSuKienViewModel loaiSuKienView)
        {
            if (ModelState.IsValid)
            {
                LoaiSuKien loaiSuKien = new LoaiSuKien();
                loaiSuKien.ID = loaiSuKienView.ID;
                loaiSuKien.TenLoaiSK = loaiSuKienView.TenLoaiSK;
                loaiSuKien.TrangThai = loaiSuKienView.TrangThai;
                db.LoaiSuKien.Add(loaiSuKien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSuKienView);
        }

        // GET: Admin/LoaiSuKiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LoaiSuKien.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiSuKienViewModel
            {
                ID = data.ID,
                TenLoaiSK = data.TenLoaiSK,
                TrangThai = data.TrangThai

            };
            return View(viewModel);
        }

        // POST: Admin/LoaiSuKiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiSuKienViewModel loaiSuKienView,int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var loaiSuKien = db.LoaiSuKien.SingleOrDefault(n => n.ID == id);
            if (loaiSuKien == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                loaiSuKien.ID = loaiSuKienView.ID;
                loaiSuKien.TenLoaiSK = loaiSuKienView.TenLoaiSK;
                loaiSuKien.TrangThai = loaiSuKienView.TrangThai;
                db.Entry(loaiSuKien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSuKienView);
        }

        // GET: Admin/LoaiSuKiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LoaiSuKien.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiSuKienViewModel
            {
                ID = data.ID,
                TenLoaiSK = data.TenLoaiSK,
                TrangThai = data.TrangThai

            };
            return View(viewModel);
        }

        // POST: Admin/LoaiSuKiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(LoaiSuKienViewModel loaiSuKienView ,int id)
        {
            LoaiSuKien loaiSuKien = db.LoaiSuKien.Find(id);
            loaiSuKien.ID = loaiSuKienView.ID;
            loaiSuKien.TenLoaiSK = loaiSuKienView.TenLoaiSK;
            loaiSuKien.TrangThai = loaiSuKienView.TrangThai;
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
