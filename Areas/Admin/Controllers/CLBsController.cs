using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using ClubPortalMS.ViewModel.CLB;



namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class CLBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<CLB> CLB = db.CLB.ToList();
            List<LoaiCLB> loaiCLB = db.LoaiCLB.ToList();
            var clb = from e in CLB
                      join d in loaiCLB on e.IdLoaiCLB equals d.IDLoaiCLB
                      select new ViewModel.CLB.CLBViewModels
                      {
                              ID = e.ID,
                              LoaiCLB = d.TenLoaiCLB,
                              TenCLB = e.TenCLB,
                              LienHe = e.LienHe,
                              Mota = e.Mota,
                              Email=e.Email,
                              HinhCLB =e.HinhCLB,
                              FanPage=e.FanPage,
                              NgayThanhLap=e.NgayThanhLap
                      };


            return View(clb);
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = db.CLB.SingleOrDefault(n => n.ID == id);
            if (e == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ViewModel.CLB.CLBViewModels
            {
                ID = e.ID,
                LoaiCLB = e.LoaiCLB.TenLoaiCLB,
                TenCLB = e.TenCLB,
                LienHe = e.LienHe,
                Mota = e.Mota,
                Email = e.Email,
                FanPage = e.FanPage,
                NgayThanhLap = e.NgayThanhLap,
                HinhCLB=e.HinhCLB

            };
            return View(viewModel);
        }
        public ActionResult DeleteConfirmed(ViewModel.CLB.CLBViewModels cLBViewModels)
        {
            CLB data = db.CLB.Find(cLBViewModels.ID);
            var tv_clb = db.ThanhVien_CLB.Where(u => u.IDCLB.ToString().Equals(cLBViewModels.ID.ToString())).FirstOrDefault();
            db.ThanhVien_CLB.Remove(tv_clb);
            db.CLB.Remove(data);
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
