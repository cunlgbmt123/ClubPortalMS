using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubPortalMS.Models;
using ClubPortalMS.ViewModel.CLB;
using ClubPortalMS.ViewModel.ThongBao;

namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class ThongBaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ThongBaos
        public ActionResult Index()
        {
            List<ThongBao> thongBaos = db.ThongBao.ToList();
            List<CLB> CLB = db.CLB.ToList();
            var dsTB = from e in thongBaos
                       join i in CLB on e.IdCLB equals i.ID into table
                       from i in table.ToList()
                       select new ThongBaoViewModels
                          {
                              ID = e.ID,
                              TieuDe = e.TieuDe,
                              MoTa = e.MoTa,
                              IdCLB = e.IdCLB,
                              NgayThongBao = e.NgayThongBao,
                              NoiDung = e.NoiDung,
                              TenFile = e.TenFile,
                              ContentType = e.ContentType,
                              File = e.File,
                          };

            return View(dsTB);
        }

        // GET: Admin/ThongBaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var e = db.ThongBao.SingleOrDefault(n => n.ID == id);
            if (e == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ThongBaoViewModels
            {
                ID = e.ID,
                TieuDe = e.TieuDe,
                MoTa = e.MoTa,
                IdCLB = e.IdCLB,
                NgayThongBao = e.NgayThongBao,
                NoiDung = e.NoiDung,
                TenFile = e.TenFile,
                ContentType = e.ContentType,
                File = e.File,

            };
            return View(viewModel);
        }
        public IEnumerable<CLBViewModel> getCLB()
        {
            var CLB = db.CLB.Select(n => new CLBViewModel
            {
                ID = n.ID,
                TenCLB = n.TenCLB

            });
            return CLB;
            
        }
        // GET: Admin/ThongBaos/Create
        public ActionResult Create()
        {
            var createThongbao = new ThongBaoViewModels();
            ViewBag.IdCLB = new SelectList(getCLB(), "ID", "TenCLB", createThongbao.IdCLB);
            return View(createThongbao);
        } 

        // POST: Admin/ThongBaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThongBaoViewModels thongBaoView)
        {
            if (ModelState.IsValid)
            {
                ThongBao thongBao = new ThongBao();
                thongBao.ID = thongBaoView.ID;
                thongBao.TieuDe = thongBaoView.TieuDe;
                thongBao.MoTa = thongBaoView.MoTa;
                thongBao.IdCLB = thongBaoView.IdCLB;
                thongBao.NgayThongBao = thongBaoView.NgayThongBao;
                thongBao.NoiDung = thongBaoView.NoiDung;
                thongBao.TenFile = thongBaoView.TenFile;
                thongBao.ContentType = thongBaoView.ContentType;
                thongBao.File = thongBaoView.File;
                db.ThongBao.Add(thongBao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCLB = new SelectList(getCLB(), "ID", "TenCLB", thongBaoView.IdCLB);
            return View(thongBaoView);
        }

        // GET: Admin/ThongBaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBao.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", thongBao.IdCLB);
            return View(thongBao);
        }

        // POST: Admin/ThongBaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TieuDe,MoTa,IdCLB,NgayThongBao,NoiDung,File")] ThongBao thongBao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongBao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCLB = new SelectList(db.CLB, "ID", "TenCLB", thongBao.IdCLB);
            return View(thongBao);
        }

        // GET: Admin/ThongBaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongBao thongBao = db.ThongBao.Find(id);
            if (thongBao == null)
            {
                return HttpNotFound();
            }
            return View(thongBao);
        }

        // POST: Admin/ThongBaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongBao thongBao = db.ThongBao.Find(id);
            db.ThongBao.Remove(thongBao);
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
