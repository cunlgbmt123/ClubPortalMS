using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using ClubPortalMS.ViewModel.ThongBao;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class ThongBaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ThongBaos
        public ActionResult Index()
        {
            List<ThongBao> tb = db.ThongBao.ToList();
            var dsTB = from e in tb
                          select new ThongBaosViewModels
                          {
                              ID = e.ID,
                              TieuDe = e.TieuDe,
                              CLB = e.CLB.TenCLB,
                              NgayThongBao = e.NgayThongBao,
                              MoTa = e.MoTa,
                              TenFile=e.TenFile,
                              ContentType=e.ContentType,
                              File=e.File,
                              NoiDung=e.NoiDung
                          };

            return View(dsTB);
        }

        // GET: Admin/ThongBaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = db.ThongBao.SingleOrDefault(n => n.ID == id);
            if (e == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ThongBaosViewModels
            {
                ID = e.ID,
                TieuDe = e.TieuDe,
                CLB = e.CLB.TenCLB,
                NgayThongBao = e.NgayThongBao,
                MoTa = e.MoTa,
                TenFile = e.TenFile,
                ContentType = e.ContentType,
                File = e.File,
                NoiDung = e.NoiDung

            };
            return View(viewModel);
        }

       
        public ActionResult DeleteConfirmed(ThongBaosViewModels tbvm)
        {
            ThongBao thongBao = db.ThongBao.Find(tbvm.ID);
            db.ThongBao.Remove(thongBao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public FileResult DocumentDownloadFileDinhKem(int? id)
        {
            var tb = db.ThongBao.Where(u => u.ID == id).FirstOrDefault();
            return File(tb.File, tb.ContentType, tb.TenFile);
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
