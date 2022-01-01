using ClubPortalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ClubPortalMS.Areas.Profile.Controllers
{
    public class QuanLyXetDuyetDKTVController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult QLXetDuyetTV_CLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<CLB> clb = db.CLB.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            var Dsclbthamgia = from e in thanhVien_clb
                               join i in clb on e.IDCLB equals i.ID into table
                               from i in table.ToList()
                               where e.IDtvien == IdTvien
                               && e.IDRoles == 2
                               select new CLBDaThamGiaViewModel
                               {
                                   TenCLB = i.TenCLB,
                                   IDCLB = i.ID,
                                   Mota = i.Mota,
                                   HinhCLB = i.HinhCLB,
                                   NgayThanhLap = i.NgayThanhLap
                               };
            ViewBag.DsCLB = Dsclbthamgia;
            return View();
        }
        public ActionResult QLXetDuyetTV(int? id, int? page)
        {

            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<DangKy> dangKies = db.DangKy.ToList();
            var DsTvDangKy = from e in dangKies
                               where  e.IDCLB == id
                               select new ViewModel1
                               {
                                 DangKy=e
                               };
            ViewBag.DsTvDangKy = DsTvDangKy;
            return View();
        }
        public ActionResult ThemTV(int? id)
        {
            DangKy dangKy = db.DangKy.Find(id);
            ThanhVien_CLB thanhVien_CLB = new ThanhVien_CLB();
            thanhVien_CLB.IDCLB = dangKy.IDCLB;
            thanhVien_CLB.IDtvien = dangKy.IdTv;
            thanhVien_CLB.IDRoles = 1;
            db.ThanhVien_CLB.Add(thanhVien_CLB);
            db.DangKy.Remove(dangKy);
            db.SaveChanges();
            return RedirectToAction("QLXetDuyetTV", new {id});
        }
        public ActionResult TuChoiTV(int? id)
        {
            DangKy dangKy = db.DangKy.Find(id);
            db.DangKy.Remove(dangKy);
            db.SaveChanges();
            return RedirectToAction("QLXetDuyetTV", new {id});
        }
    }
}