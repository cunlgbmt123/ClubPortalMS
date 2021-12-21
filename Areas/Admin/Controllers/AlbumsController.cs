﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using System.IO;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Albums
        public ActionResult Index()
        {
            return View(db.Album.ToList());
        }

        // GET: Admin/Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Admin/Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            string hinhanh = Path.GetFileNameWithoutExtension(album.ImageFile.FileName);
            string video = Path.GetFileNameWithoutExtension(album.VideoFile.FileName);
            
            string imgExtension = Path.GetExtension(album.ImageFile.FileName);

            string videoExtension = Path.GetExtension(album.VideoFile.FileName);

            hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
            video = video + DateTime.Now.ToString("yyyymmssfff") + videoExtension;
            
            album.HinhAnh = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
            album.Video = "~/Areas/Admin/Resource/Video/" + video;
            hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
            video = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/Video/"), video);
            album.ImageFile.SaveAs(hinhanh);
            album.ImageFile.SaveAs(video);
            if (ModelState.IsValid)
            {
                
                db.Album.Add(album);
                db.SaveChanges();
               /* ModelState.Clear();*/
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Admin/Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Admin/Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TieuDe,HinhAnh,Video,MoTa")] Album album)
        {
            /*string hinhanh = Path.GetFileNameWithoutExtension(album.ImageFile.FileName);
            string video = Path.GetFileNameWithoutExtension(album.VideoFile.FileName);

            string imgExtension = Path.GetExtension(album.ImageFile.FileName);

            string videoExtension = Path.GetExtension(album.VideoFile.FileName);

            hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
            video = video + DateTime.Now.ToString("yyyymmssfff") + videoExtension;

            album.HinhAnh = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
            album.Video = "~/Areas/Admin/Resource/Video/" + video;
            hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
            video = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/Video/"), video);
            album.ImageFile.SaveAs(hinhanh);
            album.ImageFile.SaveAs(video);*/
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Admin/Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Admin/Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Album.Find(id);
            db.Album.Remove(album);
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
