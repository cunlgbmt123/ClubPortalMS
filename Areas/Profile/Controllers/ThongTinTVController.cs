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

        // GET: Admin/ThongTinTV
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ThongTinTV/Details/5
        public ActionResult Details(int? id)
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
            return View(thanhVien);
        }

        // GET: Admin/ThongTinTV/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CLB_ID = new SelectList(db.CLB, "ID", "TenCLB", thanhVien.CLB_ID);
            ViewBag.User_ID = new SelectList(db.DBUser, "ID", "FirstName", thanhVien.User_ID);
            return View(thanhVien);
        }

        // POST: Admin/ThongTinTV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ten,Ho,NgaySinh,MSSV,Lop,SDT,Mail,CLB_ID,User_ID")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLB_ID = new SelectList(db.CLB, "ID", "TenCLB", thanhVien.CLB_ID);
            ViewBag.User_ID = new SelectList(db.DBUser, "ID", "FirstName", thanhVien.User_ID);
            return View(thanhVien);
        }
    }
}
