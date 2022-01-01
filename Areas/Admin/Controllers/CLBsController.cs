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
using PagedList;
using CLBViewModels = ClubPortalMS.ViewModel.CLB.CLBViewModels;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class CLBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult QLDkyCLB(int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<DkyCLB> dangKies = db.DkyCLB.ToList();
            List<CLB> CLB = db.CLB.ToList();
            List<LoaiCLB> loaiCLBs = db.LoaiCLB.ToList();
            var DsDangKyCLB = from e in dangKies
                              join i in loaiCLBs on e.IDLoaiCLB equals i.IDLoaiCLB into table
                              from i in table.ToList()
                              select new ViewModel1
                              {
                                  DkyCLB = e,
                                  LoaiCLB = i
                              };
            ViewBag.DsDangKyCLB = DsDangKyCLB.ToList().ToPagedList(page ?? 1, 5);

            var DsCLB = from e in CLB
                        join i in loaiCLBs on e.IdLoaiCLB equals i.IDLoaiCLB into table
                        from i in table.ToList()
                        select new ViewModel1
                        {
                            CLB = e,
                            LoaiCLB = i

                        };

            ViewBag.DsCLB = DsCLB.ToList().ToPagedList(page ?? 1,5);
            
            return View();
        }
        public ActionResult ThemCLB(int? id)
        {
            DkyCLB dangKy = db.DkyCLB.Find(id);
            CLB cLB = new CLB();
            cLB.IdLoaiCLB = dangKy.IDLoaiCLB;
            cLB.TenCLB = dangKy.TenCLB;
            cLB.NgayThanhLap = DateTime.Now;
            db.CLB.Add(cLB);
            ThanhVien_CLB thanhVien_CLB = new ThanhVien_CLB();
            thanhVien_CLB.IDCLB = cLB.ID;
            thanhVien_CLB.IDtvien = dangKy.IdTvien;
            thanhVien_CLB.IDRoles = 2;
            db.ThanhVien_CLB.Add(thanhVien_CLB);
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
        // GET: Admin/CLBs
        

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
