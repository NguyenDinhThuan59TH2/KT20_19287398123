using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT20_19287398123.Models;

namespace KT20_19287398123.Controllers
{
    public class MaysController : Controller
    {
        private QLNETEntities db = new QLNETEntities();

        // GET: Mays
        public ActionResult Index()
        {
            var mays = db.Mays.Include(m => m.LoaiMay);
            return View(mays.ToList());
        }

        public ActionResult TimKiem()
        {
            var mays = db.Mays.Include(m => m.LoaiMay);
            return View("TimKiem", mays.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem(string MaM, string TenMay)
        {
            // bool TimKiemGioiTinh = false;
            // if (GioiTinh != null)
            // {
                // TimKiemGioiTinh = true;
            // }
            // bool GioiTinhBool = TimKiemGioiTinh ? (GioiTinh == "Nam" ? true : false) : false;
            var mays = db.Mays.Where(may =>
                (MaM == "" || may.MaM.Contains(MaM)) &&
                (TenMay == "" || may.TenMay.Contains(TenMay))
                //&& (TimKiemGioiTinh ? KhachHang.GioiTinh == GioiTinhBool : true)
            );
            ViewBag.MaM = MaM;
            ViewBag.TenMay = TenMay;
            // ViewBag.GioiTinh = GioiTinh;
            return View("TimKiem", mays);
        }

        // GET: Mays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.Mays.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            return View(may);
        }

        // GET: Mays/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiMay = new SelectList(db.LoaiMays, "MaLoaiMay", "CauHinh");
            return View();
        }

        // POST: Mays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaM,TenMay,MaLoaiMay")] May may)
        {
            if (ModelState.IsValid)
            {
                db.Mays.Add(may);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiMay = new SelectList(db.LoaiMays, "MaLoaiMay", "CauHinh", may.MaLoaiMay);
            return View(may);
        }

        // GET: Mays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.Mays.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiMay = new SelectList(db.LoaiMays, "MaLoaiMay", "CauHinh", may.MaLoaiMay);
            return View(may);
        }

        // POST: Mays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaM,TenMay,MaLoaiMay")] May may)
        {
            if (ModelState.IsValid)
            {
                db.Entry(may).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiMay = new SelectList(db.LoaiMays, "MaLoaiMay", "CauHinh", may.MaLoaiMay);
            return View(may);
        }

        // GET: Mays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            May may = db.Mays.Find(id);
            if (may == null)
            {
                return HttpNotFound();
            }
            return View(may);
        }

        // POST: Mays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            May may = db.Mays.Find(id);
            db.Mays.Remove(may);
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
