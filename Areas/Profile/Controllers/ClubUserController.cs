﻿using ClubPortalMS.Models;
using System;
using System.Net;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ClubPortalMS.Areas.Profile.Controllers
{
    public class ClubUserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        #region' Thông báo CLB
        //Thông báo CLB
        public ActionResult ThongBao_CLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            List<CLB> clb = db.CLB.ToList();
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

            List<ThongBao> thongBaos = db.ThongBao.ToList();
            var DsTBGanDay = from e in thanhVien_clb
                             join d in thongBaos on e.IDCLB equals d.IdCLB into table1
                             from d in table1.ToList()
                             where e.IDtvien == IdTvien
                             && e.IDRoles == 1
                             select new ThongBaoViewModel
                             {
                                 ThanhVien_CLB = e,
                                 ThongBao = d
                             };
            ViewBag.DsTBGanDay = DsTBGanDay.OrderByDescending(x => x.ThongBao.ID).Take(3).ToList();
            return View();
        }
        public ActionResult ThongBaoCLB(int? id,int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<ThongBao> thongBaos = db.ThongBao.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            var DsThongBao = from e in thanhVien_clb                             
                               join i in thongBaos on e.IDCLB equals i.IdCLB into table
                               from i in table.ToList()
                               where e.IDtvien == IdTvien
                               && e.IDRoles == 1
                               && i.IdCLB == id
                               select new ThongBaoViewModel
                               {
                                   ThanhVien_CLB = e,
                                   ThongBao = i
                               };
            ViewBag.idCLB = id;
            ViewBag.DsThongBao = DsThongBao.ToList().ToPagedList(page ?? 1, 5);
            return View();
        }
        #endregion
        #region' Đăng ký CLB

        [HttpGet]
        public ActionResult DangKyCLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
           // List<ThanhVien> thanhVien = db.ThanhVien.ToList();
            List<CLB> clb = db.CLB.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            var Dsclbthamgia = from e in thanhVien_clb
                                      //join d in thanhVien on e.IDtvien equals IdTvien into table1
                                      //from d in table1.ToList()
                                  join i in clb on e.IDCLB equals i.ID into table
                                  from i in table.ToList()
                                  where e.IDtvien == IdTvien
                                  && e.IDRoles == 1
                                  select new ViewModel1
                                 {
                                     ThanhVien_CLB = e,
                                     CLB = i
                                 };

            var hai = from a in thanhVien_clb
                                 where a.IDtvien == IdTvien && a.IDRoles == 1
                                 select a;
            var ba = clb.Select(sc => sc.ID)
              .Union(hai.Select(st => st.IDCLB));          
            var DsclbchThamGia =
              from id in ba
              join sc in clb on id equals sc.ID into jsc
              from sc in jsc.DefaultIfEmpty()
              join st in hai on id equals st.IDCLB into jst
              from st in jst.DefaultIfEmpty()
              where st == null ^ sc == null
              select new ViewModel2
              { IDCLB = sc.ID,
                TenCLB = sc.TenCLB
              };
           
            ViewBag.Dsclbthamgia = Dsclbthamgia;
            ViewBag.DsclbchThamGia = DsclbchThamGia;
            ViewBag.Test = new SelectList(DsclbchThamGia, "IDCLB","TenCLB");
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKyCLB([Bind(Include = "ID,Ten,MSSV,Email,SDT,LyDoDkyCLB,IDCLB")] DangKy dangKy)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserId"] == null)
                {
                    return HttpNotFound();
                }
                int IdTvien = Convert.ToInt32(Session["UserId"]);
                var userAccount = db.DangKy.Where(u => u.IdTv == IdTvien && u.IDCLB == (dangKy.IDCLB)).FirstOrDefault();
                if (userAccount!=null)
                {
                    TempData["Message"] = "Bạn đã đăng ký CLB này rồi và đang chờ xét duyệt";
                    return RedirectToAction("DangKyCLB");
                }
                else { 
                dangKy.IdTv = IdTvien;
                dangKy.NgayDangKy = DateTime.Now;
                db.DangKy.Add(dangKy);
                db.SaveChanges();
                TempData["Message"] = "Bạn đã đăng ký thành công, đơn đăng ký bạn sẽ được xem xét sớm!";
                return RedirectToAction("DangKyCLB");
                }
            }

            return View(dangKy);
        }
        #endregion
        #region Phản hồi CLB
        [HttpGet]
        public ActionResult PhanHoiCLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            // List<ThanhVien> thanhVien = db.ThanhVien.ToList();
            List<CLB> clb = db.CLB.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
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
            ViewBag.DsCLB = new SelectList(Dsclbthamgia, "IdCLB", "TenCLB");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhanHoiCLB([Bind(Include = "ID,Ten,NoiDung,Email,SDT,DiaChi,IdCLB")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                int IdTvien = Convert.ToInt32(Session["UserId"]);
                phanHoi.Idtv = IdTvien;
                phanHoi.TGphanhoi = DateTime.Now;
                db.PhanHoi.Add(phanHoi);
                db.SaveChanges();
            }

            return View(phanHoi);
        }
        #endregion
        #region Danh sách Hoạt động CLB
        public ActionResult HoatDong_CLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            List<CLB> clb = db.CLB.ToList();
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
            List<QLDSHoatDong> hoatDongs = db.QLDSHoatDong.ToList();
            var DsHDGanDay = from e in thanhVien_clb
                             join d in hoatDongs on e.IDCLB equals d.IdCLB into table1
                             from d in table1.ToList()
                             where e.IDtvien == IdTvien
                             && e.IDRoles == 1
                             select new ViewModel1
                             {
                                 ThanhVien_CLB = e,
                                 QLDSHoatDong = d
                             };
            ViewBag.DsHDGanDay = DsHDGanDay.OrderByDescending(x => x.QLDSHoatDong.ID).Take(3).ToList();
            return View()
;        }
        public ActionResult HoatDongCLB(int? id, int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<QLDSHoatDong> QLDShoatDongs = db.QLDSHoatDong.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            var DsHoatDong = from e in thanhVien_clb
                             join i in QLDShoatDongs on e.IDCLB equals i.IdCLB into table
                             from i in table.ToList()
                             where e.IDtvien == IdTvien
                             && e.IDRoles == 1
                             && i.IdCLB == id
                             select new HoatDongViewModel
                             {
                                 ThanhVien_CLB = e,
                                 QLDSHoatDong = i,
                             };
            ViewBag.idCLB = id;
            ViewBag.DsHoatDong = DsHoatDong.ToList().ToPagedList(page ?? 1, 5);
            return View(DsHoatDong);
        }
        public ActionResult ThamGiaHD(int? id)
        {
            if (ModelState.IsValid)
            {
                int IdTvien = Convert.ToInt32(Session["UserId"]);
                QLDSHoatDong qLDSHoatDong = db.QLDSHoatDong.Find(id);            
                var userAccount = db.TTNhatKy.Where(u => u.IDHoatDong==id).FirstOrDefault();
                if (userAccount != null)
                {
                    ViewBag.Message = "Bạn đã tham gia hoạt động này rồi!!";
                }
                else
                {
                    ViewBag.Message = "Tham gia thành công!!";
                    var user = new TTNhatKy()
                    {
                        IdThanhVien = IdTvien,
                        TGThamGia = DateTime.Now,
                        SKDaThamGia = qLDSHoatDong.ChuDe,
                        IDHoatDong = qLDSHoatDong.ID,
                        DiemDanh = false
                    };
                    db.TTNhatKy.Add(user);
                    db.SaveChanges();
                }
                return RedirectToAction("HoatDongCLB");
            }
            return View();
        }
        public ActionResult BaiVietHDCLB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLDSHoatDong hoatDong = db.QLDSHoatDong.Find(id);
            ViewBag.idCLB = hoatDong.IdCLB;
            if (hoatDong == null)
            {
                return HttpNotFound();
            }
            return View(hoatDong);
        }
        public FileResult DocumentDownloadHD(int? id)
        {
            var hoatDong = db.QLDSHoatDong.Where(u => u.ID == id).FirstOrDefault();
            return File(hoatDong.File, hoatDong.ContentType, hoatDong.TenFile);
        }
        #endregion
        #region Ds sự kiện CLB
        public ActionResult SuKien_CLB()
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            List<CLB> clb = db.CLB.ToList();
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
            List<SuKien> suKiens = db.SuKien.ToList();
            var DsSKGanDay = from e in thanhVien_clb
                             join d in suKiens on e.IDCLB equals d.IdCLB into table1
                             from d in table1.ToList()
                             where e.IDtvien == IdTvien
                             && e.IDRoles == 1
                             select new ViewModel1
                             {
                                 ThanhVien_CLB = e,
                                 SuKien = d
                             };
            ViewBag.DsSKGanDay = DsSKGanDay.OrderByDescending(x => x.SuKien.ID).Take(3).ToList();
            return View()
;
        }
        public ActionResult SuKienCLB(string messageRegistration, int? id , int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<SuKien> suKiens = db.SuKien.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
            var DsSuien = from e in thanhVien_clb
                             join i in suKiens on e.IDCLB equals i.IdCLB into table
                             from i in table.ToList()
                             where e.IDtvien == IdTvien
                             && e.IDRoles == 1
                             && e.IDCLB == id
                             select new SukienViewModel
                             {
                                 ThanhVien_CLB = e,
                                 SuKien = i
                             };
            ViewBag.Message = messageRegistration;
            ViewBag.idCLB = id;
            ViewBag.DsSuien = DsSuien.ToList().ToPagedList(page ?? 1, 5);
            return View();
        }

        public ActionResult ThamGiaSK(int? id)
        {
            string messageRegistration = string.Empty;
            if (ModelState.IsValid)
            {
               
                int IdTvien = Convert.ToInt32(Session["UserId"]);
                SuKien suKien = db.SuKien.Find(id);
                var userAccount = db.TTNhatKy.Where(u => u.IDSuKien==id).FirstOrDefault();
                if (userAccount != null)
                {
                    messageRegistration = "Bạn đã tham gia hoạt động này rồi!!";
                }
                else
                {
                    var user = new TTNhatKy()
                    {
                        IdThanhVien = IdTvien,
                        TGThamGia = DateTime.Now,
                        SKDaThamGia = suKien.TieuDeSK,
                        IDSuKien = suKien.ID,
                        DiemDanh = false
                    };
                    db.TTNhatKy.Add(user);
                    db.SaveChanges();
                    messageRegistration = "Tham gia thành công!!";
                }
               
            }
            return RedirectToAction("SuKienCLB", new { messageRegistration });
        }
        public FileResult DocumentDownloadSK(int? id)
        {
            var suKien = db.SuKien.Where(u => u.ID == id).FirstOrDefault();
            return File(suKien.File, suKien.ContentType, suKien.TenFile);
        }
        public ActionResult BaiVietSKCLB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            ViewBag.idCLB = suKien.IdCLB;
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }
        #endregion
        #region Nhật ký CLB
        public ActionResult NhatKyCLB(int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<TTNhatKy> tTNhatKies = db.TTNhatKy.ToList();
            var listNhatKy = from e in tTNhatKies
                             where e.IdThanhVien == IdTvien
                             select e;
            ViewBag.ListNhatKy = listNhatKy.OrderByDescending(x => x.ID).ToList().ToPagedList(page ?? 1, 5);
            return View();
        }
        #endregion
        #region Đăng ký thành lập CLB
        [HttpGet]
        public ActionResult DangKyTLCLB()
        {
            ViewBag.IDLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKyTLCLB([Bind(Include = "ID,TenCLB,IDLoaiCLB,LyDoThanhLap")] DkyCLB dkyCLB)
        {
            if (ModelState.IsValid)
            {
                int IdTvien = Convert.ToInt32(Session["UserId"]);
                dkyCLB.IdTvien = IdTvien;         
                db.DkyCLB.Add(dkyCLB);
                db.SaveChanges();
            }
            ViewBag.IDLoaiCLB = new SelectList(db.LoaiCLB, "IDLoaiCLB", "TenLoaiCLB", dkyCLB.IDLoaiCLB);
            return View(dkyCLB);
        }
        #endregion
        #region Lịch tap
        public ActionResult LichTap_CLB()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<CLB> clb = db.CLB.ToList();
            List<ThanhVien_CLB> thanhVien_clb = db.ThanhVien_CLB.ToList();
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
            ViewBag.Dsclbthamgia = Dsclbthamgia;
            return View();
        }
        public ActionResult LichTap(int? id, int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<LichTap_ThanhVien> lichTap_ThanhVien = db.LichTap_ThanhVien.ToList();
            var nhiemVu_CLB = from e in lichTap_ThanhVien
                              where e.LichTap.IdCLB == id
                              && e.IDTvien == IdTvien
                              select e;
            int? idCLB = id;
            ViewBag.idCLB = idCLB;
            ViewBag.nhiemVu_CLB = nhiemVu_CLB.ToList().ToPagedList(page ?? 1, 5);
            return View();
        }
        #endregion
    }
}