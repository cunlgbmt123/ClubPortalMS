using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using System.IO;
using ClubPortalMS.ViewModel.Album;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Albums
        public ActionResult Index()
        {
            List<Album> albums = db.Album.ToList();
            var dsAlbum = from e in albums
                          select new AlbumViewModel{ 
                             ID = e.ID,
                             TieuDe = e.TieuDe,
                             HinhAnh = e.HinhAnh,
                             Video = e.Video,
                             MoTa = e.MoTa
                          };

            return View(dsAlbum);
        }

        // GET: Admin/Albums/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.Album.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new AlbumViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
                HinhAnh = data.HinhAnh,
                Video = data.Video,
                MoTa = data.MoTa

            };
            return View(viewModel);
        }

        // GET: Admin/Albums/Create
        public ActionResult Create()
        {
            // all vewmodel
            var createAlbum = new AlbumViewModel();
            return View(createAlbum); 
            
        }

        // POST: Admin/Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumViewModel albumView)
        {

            string hinhanh = Path.GetFileNameWithoutExtension(albumView.ImageFile.FileName);
            string video = Path.GetFileNameWithoutExtension(albumView.VideoFile.FileName);

            string imgExtension = Path.GetExtension(albumView.ImageFile.FileName);

            string videoExtension = Path.GetExtension(albumView.VideoFile.FileName);

            hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
            video = video + DateTime.Now.ToString("yyyymmssfff") + videoExtension;

            albumView.HinhAnh = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
            albumView.Video = "~/Areas/Admin/Resource/Video/" + video;
            hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
            video = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/Video/"), video);
            albumView.ImageFile.SaveAs(hinhanh);
            albumView.ImageFile.SaveAs(video);

            if (ModelState.IsValid)
            {
                Album album = new Album();
                album.ID = albumView.ID;
                album.TieuDe = albumView.TieuDe;
                album.HinhAnh = albumView.HinhAnh;
                album.Video = albumView.Video;
                album.MoTa = albumView.MoTa;
                db.Album.Add(album);
                db.SaveChanges();
               /* ModelState.Clear();*/
                return RedirectToAction("Index");
            }

            return View(albumView);
        }

        // GET: Admin/Albums/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.Album.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new AlbumViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
                HinhAnh = data.HinhAnh,
                Video = data.Video,
                MoTa = data.MoTa

            };
            return View(viewModel);
        }

        // POST: Admin/Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumViewModel albumView,int? id)
        {

            string hinhanh = Path.GetFileNameWithoutExtension(albumView.ImageFile.FileName);

            string video = Path.GetFileNameWithoutExtension(albumView.VideoFile.FileName);

            string imgExtension = Path.GetExtension(albumView.ImageFile.FileName);

            string videoExtension = Path.GetExtension(albumView.VideoFile.FileName);

            hinhanh = hinhanh + DateTime.Now.ToString("yyyymmssfff") + imgExtension;
            video = video + DateTime.Now.ToString("yyyymmssfff") + videoExtension;

            albumView.HinhAnh = "~/Areas/Admin/Resource/HinhAnh/" + hinhanh;
            albumView.Video = "~/Areas/Admin/Resource/Video/" + video;
            hinhanh = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/HinhAnh/"), hinhanh);
            video = Path.Combine(Server.MapPath("~/Areas/Admin/Resource/Video/"), video);
            albumView.ImageFile.SaveAs(hinhanh);
            albumView.ImageFile.SaveAs(video);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.Album.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                data.ID = albumView.ID;
                data.TieuDe = albumView.TieuDe;
                data.HinhAnh = albumView.HinhAnh;
                data.Video = albumView.Video;
                data.MoTa = albumView.MoTa;


                db.Entry(data).State = EntityState.Modified;
                
                db.SaveChanges();
                /* ModelState.Clear();*/
                return RedirectToAction("Index");
            }

            return View(albumView);
        }
       
        // GET: Admin/Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.Album.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new AlbumViewModel
            {
                ID = data.ID,
                TieuDe = data.TieuDe,
                HinhAnh = data.HinhAnh,
                Video = data.Video,
                MoTa = data.MoTa

            };
            return View(viewModel);
        }

        // POST: Admin/Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(AlbumViewModel albumView,int id)
        {
            Album data = db.Album.Find(id);
            data.ID = albumView.ID;
            data.TieuDe = albumView.TieuDe;
            data.HinhAnh = albumView.HinhAnh;
            data.Video = albumView.Video;
            data.MoTa = albumView.MoTa;
            db.Album.Remove(data);
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
