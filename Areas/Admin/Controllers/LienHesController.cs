using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using ClubPortalMS.ViewModel.LienHe;
using CustomAuthorizationFilter.Infrastructure;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorize("Admin")]
    public class LienHesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LienHes
        public ActionResult Index()
        {
            List<LienHe> lienhe = db.LienHe.ToList();
            var dsLienhe = from e in lienhe
                          select new LienHeViewModel
                          {
                              ID = e.ID,
                              TieuDe = e.TieuDe,
                              DiaChi = e.DiaChi,
                              HotLine = e.HotLine,
                              Email = e.Email,
                              NoiDung = e.NoiDung,
                              Ten=e.Ten
                          };

            return View(dsLienhe);
        }

        // GET: Admin/LienHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.LienHe.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LienHeViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
                DiaChi = data.DiaChi,
                HotLine = data.HotLine,
                Ten = data.Ten,
                Email = data.Email,
                NoiDung = data.NoiDung

            };
            return View(viewModel);
        }

        // GET: Admin/LienHes/Create
        //public ActionResult Create()
        //{
        //    var themLH = new LienHeViewModel();

        //    return View(themLH);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(LienHeViewModel lienHeView, int? id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        LienHe lienHe = new LienHe();
        //        lienHe.ID = lienHeView.ID;
        //        lienHe.TieuDe = lienHeView.TieuDe;
        //        lienHe.DiaChi = lienHeView.DiaChi;
        //        lienHe.HotLine = lienHeView.HotLine;
        //        lienHe.Ten = lienHeView.Ten;
        //        lienHe.Email = lienHeView.Email;
        //        lienHe.NoiDung = lienHeView.Email;
        //        db.LienHe.Add(lienHe);
        //        db.SaveChanges();
        //        return RedirectToAction("index");
        //    }

        //    return View(lienHeView);
        //}

        //// GET: Admin/LienHes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var data = db.LienHe.SingleOrDefault(n => n.ID == id);
        //    if (data == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var viewModel = new LienHeViewModel
        //    {
        //        ID = data.ID,
        //        TieuDe = data.TieuDe,
        //        DiaChi = data.DiaChi,
        //        HotLine = data.HotLine,
        //        Ten = data.Ten,
        //        Email = data.Email,
        //        NoiDung = data.NoiDung

        //    };
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit( LienHeViewModel lienHeView,int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var data = db.LienHe.SingleOrDefault(n => n.ID == id);
        //    if (data == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        data.ID = lienHeView.ID;
        //        data.TieuDe = lienHeView.TieuDe;
        //        data.DiaChi = lienHeView.DiaChi;
        //        data.HotLine = lienHeView.HotLine;
        //        data.Ten = lienHeView.Ten;
        //        data.Email = lienHeView.Email;
        //        data.NoiDung = lienHeView.Email;
        //        db.Entry(data).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(lienHeView);
        //}

        public ActionResult DeleteConfirmed( int id)
        {
            LienHe data = db.LienHe.Find(id);
            db.LienHe.Remove(data);
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
