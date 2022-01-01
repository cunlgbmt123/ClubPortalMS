using ClubPortalMS.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubPortalMS.Areas.Profile.Controllers
{
    public class QuanLyDkyCLBController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult QLDkyCLB(int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<DkyCLB> dangKies = db.DkyCLB.ToList();
            List<LoaiCLB> loaiCLBs = db.LoaiCLB.ToList();
            var DsDangKyCLB = from e in dangKies
                              join i in loaiCLBs on e.IDLoaiCLB equals i.IDLoaiCLB into table
                              from i in table.ToList()
                              select new ViewModel1 
                              { 
                                  DkyCLB = e,
                                  LoaiCLB = i
                              };

            ViewBag.DsDangKyCLB = DsDangKyCLB;
            return View();
        }
        public ActionResult ThemCLB(int? id)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            DkyCLB dangKy = db.DkyCLB.Find(id);
            CLB cLB = new CLB();
            cLB.IdLoaiCLB = dangKy.IDLoaiCLB;
            cLB.TenCLB = dangKy.TenCLB;
            cLB.NgayThanhLap = DateTime.Now;
            cLB.HinhCLB = "/Hinh/HinhCLB/CLB_default.png";
            db.CLB.Add(cLB);
            ThanhVien_CLB thanhVien_CLB = new ThanhVien_CLB();
            thanhVien_CLB.IDCLB = cLB.ID;
            thanhVien_CLB.IDtvien = dangKy.IdTvien;
            thanhVien_CLB.IDRoles = 2;
            ThanhVien_CLB thanhVien_CLB2 = new ThanhVien_CLB();
            thanhVien_CLB.IDCLB = cLB.ID;
            thanhVien_CLB.IDtvien = IdTvien;
            thanhVien_CLB.IDRoles = 2;
            db.ThanhVien_CLB.Add(thanhVien_CLB);
            db.ThanhVien_CLB.Add(thanhVien_CLB2);
            db.DkyCLB.Remove(dangKy);
            db.SaveChanges();
            return RedirectToAction("QLDkyCLB");
        }
        public ActionResult TuChoiCLB(int? id)
        {
            DkyCLB dangKy = db.DkyCLB.Find(id);
            db.DkyCLB.Remove(dangKy);
            db.SaveChanges();
            return RedirectToAction("QLDkyCLB");
        }
    }
}
