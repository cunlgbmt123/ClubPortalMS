﻿using ClubPortalMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClubPortalMS.Areas.Profile.Controllers
{
    public class QuanLyCLBController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult QuanLyCLB_DSCLB()
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
                                   NgayThanhLap = i.NgayThanhLap
                               };
            ViewBag.DsCLB = Dsclbthamgia;
            return View();
        }
        public ActionResult QLCLB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLB cLB = db.CLB.Find(id);
            if (cLB == null)
            {
                return HttpNotFound();
            }
            return View(cLB);
        }
        [HttpGet]
        public ActionResult SuaCLB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLB cLB = db.CLB.Find(id);
            if (cLB == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLB = cLB;
            ViewBag.IdLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB", cLB.IdLoaiCLB);
            return View();          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaCLB(CLBViewModels cLBViewModel)
        {
            int UserID = Convert.ToInt32(Session["UserId"]);
            if (ModelState.IsValid)
            {
                CLB cLB = db.CLB.Find(cLBViewModel.ID);
                cLB.Email = cLBViewModel.Email;
                cLB.FanPage = cLBViewModel.FanPage;
                cLB.IdLoaiCLB = cLBViewModel.IdLoaiCLB;
                cLB.Mota = cLBViewModel.Mota;
                cLB.TenCLB = cLBViewModel.TenCLB;
                cLB.LienHe = cLBViewModel.LienHe;
                cLB.FanPage = cLBViewModel.FanPage;
                cLB.NgayThanhLap = cLBViewModel.NgayThanhLap;
                db.SaveChanges();
                ViewBag.IdLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB", cLB.IdLoaiCLB);
            }
            return RedirectToAction("QLCLB",new {id = cLBViewModel.ID});
        }
        public ActionResult XacNhanXoaCLB(int id)
        {
            CLB clb = db.CLB.Find(id);
            db.CLB.Remove(clb);
            db.SaveChanges();
            return RedirectToAction("QuanLyCLB_DSCLB");
        }

    }
}