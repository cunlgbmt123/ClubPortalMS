using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;

namespace ClubPortalMS.Areas.Profile.Controllers
{
    public class ThongTinTVController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        #region task chỉnh sửa  hồ sơ
        [HttpGet]
        public ActionResult HoSo(int? id)
        {
            int UserID = Convert.ToInt32(Session["UserId"]);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id != UserID)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Khoa_ID = new SelectList(db.Khoa, "ID", "TenKhoa", thanhVien.Khoa_ID);
            ViewBag.ThanhVien = thanhVien;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HoSo(ProfileViewModel thanhVien)
        {
            int UserID = Convert.ToInt32(Session["UserId"]);
            if (ModelState.IsValid)
            {
                ThanhVien thanhViens = db.ThanhVien.Find(thanhVien.ID);
                thanhViens.ID = thanhVien.ID;
                thanhViens.Ho = thanhVien.Ho;
                thanhViens.Ten = thanhVien.Ten;
                thanhViens.Lop = thanhVien.Lop;
                thanhViens.MSSV = thanhVien.MSSV;
                thanhViens.Khoa_ID = thanhVien.Khoa_ID;
                thanhViens.NgaySinh = thanhVien.NgaySinh;
                thanhViens.Mail = thanhVien.Email;
                db.SaveChanges();
                ViewBag.ThanhVien = thanhViens;
                ViewBag.Message = "Cập nhật hồ sơ thành công!";

            }
            ViewBag.Khoa_ID = new SelectList(db.Khoa, "ID", "TenKhoa", thanhVien.Khoa_ID);
            return View(thanhVien);
        }
        #endregion
    }
}
