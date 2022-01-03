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
using ClubPortalMS.ViewModel.HoatDong;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class HoatDongsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/HoatDongs
        public ActionResult Index()
        {
            List<HoatDong> hoatdong = db.HoatDong.ToList();
            var ds = from e in hoatdong
                     select new HoatdongViewModels
                     {
                         ID = e.ID,
                         Ten = e.Ten,
                         MoTa = e.MoTa,
                         NoiDung = e.NoiDung,
                         KeyWord = e.KeyWord,
                         URL = e.URL,
                         HinhAnhBaiViet = e.HinhAnhBaiViet,
                         HinhAnhChiTiet = e.HinhAnhChiTiet,
                         NgayDang = e.NgayDang,
                         TenNguoiDang = e.TenNguoiDang

                     };

            return View(ds);
        }

        // GET: Admin/HoatDongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.HoatDong.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new HoatdongViewModels
            {
                ID = data.ID,
                Ten = data.Ten,
                MoTa = data.MoTa,
                NoiDung = data.NoiDung,
                KeyWord = data.KeyWord,
                URL = data.URL,
                HinhAnhBaiViet = data.HinhAnhBaiViet,
                HinhAnhChiTiet = data.HinhAnhChiTiet,
                NgayDang = data.NgayDang,
                TenNguoiDang = data.TenNguoiDang

            };
            return View(viewModel);
        }

        // GET: Admin/HoatDongs/Create
        public ActionResult Create()
        {
            var createHoatdong = new HoatdongViewModels();
            return View(createHoatdong);
        }

        // POST: Admin/HoatDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HoatdongViewModels data)
        {
            if (ModelState.IsValid)
            {
                string hinhanh = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                string hinhanhchitiet = Path.GetFileNameWithoutExtension(data.ImageDetailFile.FileName);

                string imgExtension = Path.GetExtension(data.ImageFile.FileName);

                string hinhanhchitietExtension = Path.GetExtension(data.ImageDetailFile.FileName);

                hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
                hinhanhchitiet = hinhanhchitiet + DateTime.Now.ToString("yyyymmssfff") + hinhanhchitietExtension;

                data.HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
                data.HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/" + hinhanhchitiet;
                hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
                hinhanhchitiet = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanhchitiet);
                data.ImageFile.SaveAs(hinhanh);
                data.ImageDetailFile.SaveAs(hinhanhchitiet);

                HoatDong hoatDong= new HoatDong();
                hoatDong.ID = data.ID;
                hoatDong.Ten = data.Ten;
                hoatDong.MoTa = data.MoTa;
                hoatDong.NoiDung = data.NoiDung;
                hoatDong.KeyWord = data.KeyWord;
                hoatDong.URL = data.URL;
                hoatDong.HinhAnhBaiViet = data.HinhAnhBaiViet;
                hoatDong.HinhAnhChiTiet = data.HinhAnhChiTiet;
                hoatDong.NgayDang = data.NgayDang;
                hoatDong.TenNguoiDang = data.TenNguoiDang;

                db.HoatDong.Add(hoatDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        // GET: Admin/HoatDongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.HoatDong.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new HoatdongViewModels
            {

                ID = data.ID,
                Ten = data.Ten,
                MoTa = data.MoTa,
                NoiDung = data.NoiDung,
                KeyWord = data.KeyWord,
                URL = data.URL,
                HinhAnhBaiViet = data.HinhAnhBaiViet,
                HinhAnhChiTiet = data.HinhAnhChiTiet,
                NgayDang = data.NgayDang,
                TenNguoiDang = data.TenNguoiDang

            };
            return View(viewModel);
        }

        // POST: Admin/HoatDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HoatdongViewModels data, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hoatDong = db.HoatDong.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                string hinhanh = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                string hinhanhchitiet = Path.GetFileNameWithoutExtension(data.ImageDetailFile.FileName);

                string imgExtension = Path.GetExtension(data.ImageFile.FileName);

                string hinhanhchitietExtension = Path.GetExtension(data.ImageDetailFile.FileName);

                hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
                hinhanhchitiet = hinhanhchitiet + DateTime.Now.ToString("yyyymmssfff") + hinhanhchitietExtension;

                data.HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
                data.HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/" + hinhanhchitiet;
                hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
                hinhanhchitiet = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanhchitiet);
                data.ImageFile.SaveAs(hinhanh);
                data.ImageDetailFile.SaveAs(hinhanhchitiet);

                hoatDong.ID = data.ID;
                hoatDong.Ten = data.Ten;
                hoatDong.MoTa = data.MoTa;
                hoatDong.NoiDung = data.NoiDung;
                hoatDong.KeyWord = data.KeyWord;
                hoatDong.URL = data.URL;
                hoatDong.HinhAnhBaiViet = data.HinhAnhBaiViet;
                hoatDong.HinhAnhChiTiet = data.HinhAnhChiTiet;
                hoatDong.NgayDang = data.NgayDang;
                hoatDong.TenNguoiDang = data.TenNguoiDang;

                db.Entry(hoatDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        // GET: Admin/HoatDongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.HoatDong.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new HoatdongViewModels
            {
                ID = data.ID,
                Ten = data.Ten,
                MoTa = data.MoTa,
                NoiDung = data.NoiDung,
                KeyWord = data.KeyWord,
                URL = data.URL,
                HinhAnhBaiViet = data.HinhAnhBaiViet,
                HinhAnhChiTiet = data.HinhAnhChiTiet,
                NgayDang = data.NgayDang,
                TenNguoiDang = data.TenNguoiDang

            };
            return View(viewModel);
        }

        // POST: Admin/HoatDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(HoatdongViewModels data, int id)
        {

            HoatDong hoatDong = db.HoatDong.Find(id);
            hoatDong.ID = data.ID;
            hoatDong.Ten = data.Ten;
            hoatDong.MoTa = data.MoTa;
            hoatDong.NoiDung = data.NoiDung;
            hoatDong.KeyWord = data.KeyWord;
            hoatDong.URL = data.URL;
            hoatDong.HinhAnhBaiViet = data.HinhAnhBaiViet;
            hoatDong.HinhAnhChiTiet = data.HinhAnhChiTiet;
            hoatDong.NgayDang = data.NgayDang;
            hoatDong.TenNguoiDang = data.TenNguoiDang;
            db.HoatDong.Remove(hoatDong);
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
