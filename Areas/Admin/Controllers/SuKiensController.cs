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
    public class SuKiensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/SuKiens
        public ActionResult Index()
        {

            List<SuKien> hd = db.SuKien.ToList();
            var ds = from e in hd
                     select new SuKiensViewModel
                     {
                         ID = e.ID,
                         TieuDeSK = e.TieuDeSK,
                         NgayBatDau = e.NgayBatDau,
                         NgayKetThuc = e.NgayKetThuc,
                         MoTa = e.MoTa,
                         TenFile = e.TenFile,
                         ContentType = e.ContentType,
                         File = e.File,
                         NoiDung = e.NoiDung,
                         DiaDiem = e.DiaDiem,
                         CLB = e.CLB.TenCLB,
                         LoaiSK = e.LoaiSuKien.TenLoaiSK
                     };

            return View(ds);
        }

        // GET: Admin/SuKiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = db.SuKien.SingleOrDefault(n => n.ID == id);
            if (e == null)
            {
                return HttpNotFound();
            }
            var viewModel = new SuKiensViewModel
            {
                ID = e.ID,
                TieuDeSK = e.TieuDeSK,
                NgayBatDau = e.NgayBatDau,
                NgayKetThuc = e.NgayKetThuc,
                MoTa = e.MoTa,
                TenFile = e.TenFile,
                ContentType = e.ContentType,
                File = e.File,
                NoiDung = e.NoiDung,
                DiaDiem = e.DiaDiem,
                CLB = e.CLB.TenCLB,
                LoaiSK = e.LoaiSuKien.TenLoaiSK
            };
            return View(viewModel);
        }

        public ActionResult DeleteConfirmed(SuKiensViewModel skvm)
        {
            SuKien suKien = db.SuKien.Find(skvm.ID);
            db.SuKien.Remove(suKien);
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
