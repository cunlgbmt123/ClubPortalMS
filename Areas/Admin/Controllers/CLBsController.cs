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
using PagedList;


namespace ClubPortalMS.Areas.Admin.Controllers
{
    public class CLBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult QLDkyCLB(int? page)
        {
            int IdTvien = Convert.ToInt32(Session["UserId"]);
            List<DkyCLB> dangKies = db.DkyCLB.ToList();
            List<CLB> CLB = db.CLB.ToList();
            List<LoaiCLB> loaiCLBs = db.LoaiCLB.ToList();
            var DsDangKyCLB = from e in dangKies
                              join i in loaiCLBs on e.IDLoaiCLB equals i.IDLoaiCLB into table
                              from i in table.ToList()
                              select new ViewModel1
                              {
                                  DkyCLB = e,
                                  LoaiCLB = i
                              };
            ViewBag.DsDangKyCLB = DsDangKyCLB.ToList().ToPagedList(page ?? 1, 5);

            var DsCLB = from e in CLB
                        join i in loaiCLBs on e.IdLoaiCLB equals i.IDLoaiCLB into table
                        from i in table.ToList()
                        select new ViewModel1
                        {
                            CLB = e,
                            LoaiCLB = i

                        };

            ViewBag.DsCLB = DsCLB.ToList().ToPagedList(page ?? 1,5);
            
            return View();
        }
        public ActionResult ThemCLB(int? id)
        {
            DkyCLB dangKy = db.DkyCLB.Find(id);
            CLB cLB = new CLB();
            cLB.IdLoaiCLB = dangKy.IDLoaiCLB;
            cLB.TenCLB = dangKy.TenCLB;
            cLB.NgayThanhLap = DateTime.Now;
            db.CLB.Add(cLB);
            ThanhVien_CLB thanhVien_CLB = new ThanhVien_CLB();
            thanhVien_CLB.IDCLB = cLB.ID;
            thanhVien_CLB.IDtvien = dangKy.IdTvien;
            thanhVien_CLB.IDRoles = 2;
            db.ThanhVien_CLB.Add(thanhVien_CLB);
            db.DkyCLB.Remove(dangKy);
            db.SaveChanges();
            return RedirectToAction("QLDkyCLB");
        }
        public ActionResult TuChoiCLB(int? id)
        {
            DkyCLB dangKy = db.DkyCLB.Find(id);
            db.DkyCLB.Remove(dangKy);
            db.SaveChanges();
            return RedirectToAction("QLDkyCLB");
        }
        // GET: Admin/CLBs
        public ActionResult Index()
        {
            List<CLB> CLB = db.CLB.ToList();
            List<LoaiCLB> loaiCLBs = db.LoaiCLB.ToList();
            var DsCLB = from e in CLB
                              join i in loaiCLBs on e.IdLoaiCLB equals i.IDLoaiCLB into table
                              from i in table.ToList()
                              select new ViewModel1
                              {
                                 CLB = e,
                                 LoaiCLB = i

                              };

            ViewBag.DsCLB = DsCLB;



            return View();

            /*var DsCLB = (from item in db.CLB
                         select item).ToList();
            return View(DsCLB);*/
        }
        private IEnumerable<LoaiCLBViewModel> GetAllLoaiCLB()
        {
            var loaiCLB = db.LoaiCLB.Select(n => new LoaiCLBViewModel
            {
                IDLoaiCLB = n.IDLoaiCLB,
                TenLoaiCLB = n.TenLoaiCLB

            });
            return loaiCLB;
        }
        // GET: Admin/CLBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.CLB.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CLBViewModel
            {
                ID = data.ID,
                IdLoaiCLB = data.IdLoaiCLB,
                TenCLB = data.TenCLB,
                TrangThai = data.TrangThai,
                NgayThanhLap = data.NgayThanhLap,
                LienHe = data.LienHe,
                Mota = data.Mota,
                FanPage = data.FanPage,
                Email = data.Email

            };
            return View(viewModel);
        }

        // GET: Admin/CLBs/Create
        public ActionResult Create()
        {
            var createCLB = new CLBViewModel();


            ViewBag.IdLoaiCLB = new SelectList(GetAllLoaiCLB(), "IDLoaiCLB", "TenLoaiCLB");

            return View(createCLB);
        }

        // POST: Admin/CLBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CLBViewModel cLB, int? id)
        {
            if (ModelState.IsValid)
            {
                CLB CLB = new CLB();
                CLB.IdLoaiCLB = cLB.IdLoaiCLB;
                CLB.TenCLB = cLB.TenCLB;
                CLB.TrangThai = cLB.TrangThai;
                cLB.NgayThanhLap = DateTime.Now;
                CLB.NgayThanhLap = cLB.NgayThanhLap;
                CLB.LienHe = cLB.LienHe;
                CLB.Mota = cLB.Mota;
                CLB.FanPage = cLB.FanPage;
                CLB.Email = cLB.Email;
                db.CLB.Add(CLB);
                db.SaveChanges();
                return RedirectToAction("QLDkyCLB");
            }

            ViewBag.IdLoaiCLB = new SelectList(GetAllLoaiCLB(), "IDLoaiCLB", "TenLoaiCLB");
            return View(cLB);
        }

        // GET: Admin/CLBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.CLB.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CLBViewModel
            {
                ID = data.ID,
                IdLoaiCLB = data.IdLoaiCLB,
                TenCLB = data.TenCLB,
                TrangThai = data.TrangThai,
                NgayThanhLap = data.NgayThanhLap,
                LienHe = data.LienHe,
                Mota = data.Mota,
                FanPage = data.FanPage,
                Email = data.Email

            };
            return View(viewModel);
        }

        // POST: Admin/CLBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CLBViewModel cLB, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.CLB.SingleOrDefault(n => n.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                data.ID = cLB.ID;
                data.IdLoaiCLB = cLB.IdLoaiCLB;
                data.TenCLB = cLB.TenCLB;
                data.TrangThai = cLB.TrangThai;
                data.NgayThanhLap = DateTime.Now;
                data.NgayThanhLap = cLB.NgayThanhLap;
                data.LienHe = cLB.LienHe;
                data.Mota = cLB.Mota;
                data.FanPage = cLB.FanPage;
                data.Email = cLB.Email;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLDkyCLB");
            }

            ViewBag.IdLoaiCLB = new SelectList(GetAllLoaiCLB(), "IDLoaiCLB", "TenLoaiCLB", data.IdLoaiCLB);

            return View(cLB);
        }

        // GET: Admin/CLBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLB cLB = db.CLB.Find(id);
            if (cLB == null)
            {
                return HttpNotFound();
            }
            return View(cLB);
        }

        // POST: Admin/CLBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLB cLB = db.CLB.Find(id);
            db.CLB.Remove(cLB);
            db.SaveChanges();
            return RedirectToAction("QLDkyCLB");
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
