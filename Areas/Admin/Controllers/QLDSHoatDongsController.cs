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
    public class QLDSHoatDongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {

            List<QLDSHoatDong> hd = db.QLDSHoatDong.ToList();
            var ds = from e in hd
                     select new QLDSHoatDongViewModel
                       {
                           ID = e.ID,
                           ChuDe = e.ChuDe,
                           NgayBatDau = e.NgayBatDau,
                           NgayKetThuc = e.NgayKetThuc,
                           Mota = e.Mota,
                           TenFile = e.TenFile,
                           ContentType = e.ContentType,
                           File = e.File,
                           NoiDung = e.NoiDung,
                           DiaDiem = e.DiaDiem,
                           TenCLB = e.CLB.TenCLB,
                           LoaiHD = e.LoaiHD.TenLoaiHD
                     };

            return View(ds);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = db.QLDSHoatDong.SingleOrDefault(n => n.ID == id);
            if (e == null)
            {
                return HttpNotFound();
            }
            var viewModel = new QLDSHoatDongViewModel
            {
                ID = e.ID,
                ChuDe = e.ChuDe,
                NgayBatDau = e.NgayBatDau,
                NgayKetThuc = e.NgayKetThuc,
                Mota = e.Mota,
                TenFile = e.TenFile,
                ContentType = e.ContentType,
                File = e.File,
                NoiDung = e.NoiDung,
                DiaDiem = e.DiaDiem,
                TenCLB = e.CLB.TenCLB,
                LoaiHD = e.LoaiHD.TenLoaiHD
            };
            return View(viewModel);           
        }

        public ActionResult DeleteConfirmed(QLDSHoatDongViewModel hdvm)
        {
            QLDSHoatDong qLDSHoatDong = db.QLDSHoatDong.Find(hdvm.ID);
            db.QLDSHoatDong.Remove(qLDSHoatDong);
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
