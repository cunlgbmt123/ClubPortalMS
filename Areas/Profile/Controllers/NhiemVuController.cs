﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using Microsoft.Owin.Security.Infrastructure;

namespace ClubPortalMS.Areas.Profile.Controllers
{
    public class NhiemVuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        #region Nhiệm vụ mới nhất và nhiệm vụ theo CLB
        public ActionResult listCLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<CLB> clb = db.CLB.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            List<NhiemVu_ThanhVien> nhiemVus = db.NhiemVu_ThanhVien.ToList();
            var Dsclbthamgia = from e in thanhVien_clb
                                   //join d in thanhVien on e.IDtvien equals IdTvien into table1
                                   //from d in table1.ToList()
                               join i in clb on e.IDCLB equals i.ID into table
                               from i in table.ToList()
                               where e.IDtvien == IdTvien
                               && e.IDRoles == 1
                               select new PhanHoiCLBViewModel
                               {
                                   TenCLB = i.TenCLB,
                                   IdCLB = i.ID
                               };
            ViewBag.DsCLB = Dsclbthamgia;

            var DsNVGanDay = from e in thanhVien_clb
                             join d in nhiemVus on e.IDtvien equals d.IdTVien  into table1
                             from d in table1.ToList()
                             where e.IDtvien == IdTvien
                             && e.IDCLB == d.NhiemVu.IdCLB
                             && e.IDRoles == 1
                             select new ViewModel1
                             {
                                 ThanhVien_CLB = e,
                                 NhiemVu_ThanhVien = d
                             };
            ViewBag.DsNVGanDay = DsNVGanDay.OrderByDescending(x => x.NhiemVu_ThanhVien.ID).Take(3).ToList();
            return View();
        }
        #endregion
        #region list Nhiệm vụ sau khi chọn theo clb
        // GET: Profile/NhiemVu
        public ActionResult Index(int? id)
        {
            List<NhiemVu_ThanhVien> nhiemVus = db.NhiemVu_ThanhVien.ToList();
            var nhiemVu_CLB = from e in nhiemVus
                              where e.NhiemVu.IdCLB == id
                              select e;
            return View(nhiemVu_CLB);
        }
        #endregion
        #region chức năng Nộp bài
        // GET: Profile/NhiemVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhiemVu_ThanhVien nhiemVu = db.NhiemVu_ThanhVien.Find(id);
            if (nhiemVu == null)
            {
                return HttpNotFound();
            }
            return View(nhiemVu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "FileNop")] NhiemVu_ThanhVien nhiemVu, HttpPostedFileBase upload, int id)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    int filelength = upload.ContentLength;
                    string fileName = upload.FileName;
                    string contentType = upload.ContentType;
                    byte[] Myfile = new byte[filelength];
                    upload.InputStream.Read(Myfile, 0, filelength);
                    nhiemVu.FileNop = Myfile;
                    var nhiemVUs = db.NhiemVu_ThanhVien.Where(u => u.ID == id).FirstOrDefault();
                    nhiemVUs.FileNop = nhiemVu.FileNop;
                    nhiemVUs.ContentType = contentType;
                    nhiemVUs.TenFileNop = fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = nhiemVUs.ID });
                }
                else
                {
                    return RedirectToAction("Index", new { id = nhiemVu.ID });
                }
            }

            return View(nhiemVu);
        }
        [HttpGet]
        public FileResult DocumentDownload(int? id)
        {
            var nhiemVUs = db.NhiemVu_ThanhVien.Where(u => u.ID == id).FirstOrDefault();
            return File(nhiemVUs.FileNop, nhiemVUs.ContentType, nhiemVUs.TenFileNop);
        }
        #endregion
        #region code tự sinh
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}