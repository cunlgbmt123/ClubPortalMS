using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
                if (thanhVien.ImageFile != null) {
                    string fileName = Path.GetFileNameWithoutExtension(thanhVien.ImageFile.FileName);
                    string extension = Path.GetExtension(thanhVien.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    thanhVien.HinhDaiDien = "/Hinh/HinhDaiDienNguoiDung/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Hinh/HinhDaiDienNguoiDung/"), fileName);
                    thanhVien.ImageFile.SaveAs(fileName);

                    ThanhVien thanhViens = db.ThanhVien.Find(thanhVien.ID);
                    thanhViens.ID = thanhVien.ID;
                    thanhViens.Ho = thanhVien.Ho;
                    thanhViens.Ten = thanhVien.Ten;
                    thanhViens.Lop = thanhVien.Lop;
                    thanhViens.SDT = thanhVien.SDT;
                    thanhViens.MSSV = thanhVien.MSSV;
                    thanhViens.Khoa_ID = thanhVien.Khoa_ID;
                    thanhViens.NgaySinh = thanhVien.NgaySinh;
                    thanhViens.HinhDaiDien = thanhVien.HinhDaiDien;
                    thanhViens.ImageFile = thanhVien.ImageFile;
                    db.SaveChanges();
                    ViewBag.ThanhVien = thanhViens;
                    ViewBag.Message = "Cập nhật hồ sơ thành công!";
                }
                else
                {
                    ThanhVien thanhViens = db.ThanhVien.Find(thanhVien.ID);
                    thanhViens.ID = thanhVien.ID;
                    thanhViens.Ho = thanhVien.Ho;
                    thanhViens.Ten = thanhVien.Ten;
                    thanhViens.SDT = thanhVien.SDT;
                    thanhViens.Lop = thanhVien.Lop;
                    thanhViens.MSSV = thanhVien.MSSV;
                    thanhViens.Khoa_ID = thanhVien.Khoa_ID;
                    thanhViens.NgaySinh = thanhVien.NgaySinh;
                    db.SaveChanges();
                    ViewBag.ThanhVien = thanhViens;
                    ViewBag.Message = "Cập nhật hồ sơ thành công!";
                }
            }
            ViewBag.Khoa_ID = new SelectList(db.Khoa, "ID", "TenKhoa", thanhVien.Khoa_ID);
            return View(thanhVien);
        }
        #endregion
    }
}
