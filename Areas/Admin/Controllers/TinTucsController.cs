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
using ClubPortalMS.ViewModel.TinTuc;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class TinTucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TinTucs
        public ActionResult Index()
        {
            List<TinTuc> tinTucs = db.TinTucs.ToList();
            var ds = from e in tinTucs
                          select new TinTucViewModel
                          {
                              ID = e.ID,
                              TieuDe = e.TieuDe,
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

        // GET: Admin/TinTucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.TinTucs.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new TinTucViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
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

        // GET: Admin/TinTucs/Create
        public ActionResult Create()
        {
            var createTintuc = new TinTucViewModel();
            return View(createTintuc);
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TinTucViewModel data)
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


                TinTuc tintuc = new TinTuc();
                tintuc.ID = data.ID;
                tintuc.TieuDe = data.TieuDe;
                tintuc.MoTa = data.MoTa;
                tintuc.NoiDung = data.NoiDung;
                tintuc.KeyWord = data.KeyWord;
                tintuc.URL = data.URL;
                tintuc.HinhAnhBaiViet = data.HinhAnhBaiViet;
                tintuc.HinhAnhChiTiet = data.HinhAnhChiTiet;
                tintuc.NgayDang = data.NgayDang;
                tintuc.TenNguoiDang = data.TenNguoiDang;
                db.TinTucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        // GET: Admin/TinTucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.TinTucs.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new TinTucViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
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

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TinTucViewModel tinTucView,int? id)
        {
            string hinhanh = Path.GetFileNameWithoutExtension(tinTucView.ImageFile.FileName);
            string hinhanhchitiet = Path.GetFileNameWithoutExtension(tinTucView.ImageDetailFile.FileName);

            string imgExtension = Path.GetExtension(tinTucView.ImageFile.FileName);

            string hinhanhchitietExtension = Path.GetExtension(tinTucView.ImageDetailFile.FileName);

            hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
            hinhanhchitiet = hinhanhchitiet + DateTime.Now.ToString("yyyymmssfff") + hinhanhchitietExtension;

            tinTucView.HinhAnhChiTiet = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
            tinTucView.HinhAnhBaiViet = "~/Areas/Admin/Resource/HinhAnh/" + hinhanhchitiet;
            hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
            hinhanhchitiet = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanhchitiet);
            tinTucView.ImageFile.SaveAs(hinhanh);
            tinTucView.ImageDetailFile.SaveAs(hinhanhchitiet);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.TinTucs.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                data.ID = tinTucView.ID;
                data.TieuDe = tinTucView.TieuDe;
                data.MoTa = tinTucView.MoTa;
                data.NoiDung = tinTucView.NoiDung;
                data.KeyWord = tinTucView.KeyWord;
                data.URL = tinTucView.URL;
                data.HinhAnhBaiViet = tinTucView.HinhAnhBaiViet;
                data.HinhAnhChiTiet = tinTucView.HinhAnhChiTiet;
                data.NgayDang = tinTucView.NgayDang;
                data.TenNguoiDang = tinTucView.TenNguoiDang;

                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinTucView);
        }

        // GET: Admin/TinTucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.TinTucs.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new TinTucViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
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

        // POST: Admin/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TinTucViewModel data,int id)
        {
            TinTuc tintuc = db.TinTucs.Find(id);
            tintuc.ID = data.ID;
            tintuc.TieuDe = data.TieuDe;
            tintuc.MoTa = data.MoTa;
            tintuc.NoiDung = data.NoiDung;
            tintuc.KeyWord = data.KeyWord;
            tintuc.URL = data.URL;
            tintuc.HinhAnhBaiViet = data.HinhAnhBaiViet;
            tintuc.HinhAnhChiTiet = data.HinhAnhChiTiet;
            tintuc.NgayDang = data.NgayDang;
            tintuc.TenNguoiDang = data.TenNguoiDang;
            db.TinTucs.Remove(tintuc);
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
