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
    public class LoaiMaysController : Controller
    {
        private QLNETEntities db = new QLNETEntities();

        // GET: LoaiMays
        public ActionResult Index()
        {
            return View(db.LoaiMays.ToList());
        }

        // GET: LoaiMays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMay loaiMay = db.LoaiMays.Find(id);
            if (loaiMay == null)
            {
                return HttpNotFound();
            }
            return View(loaiMay);
        }

        // GET: LoaiMays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiMays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiMay,CauHinh,GiaTien,Hinh")] LoaiMay loaiMay)
        {
            if (ModelState.IsValid)
            {
                var Anh = Request.Files["Anh"];
                loaiMay.Hinh = "MacDinh.png";
                if (Anh.FileName != "")
                {
                    string FileName = System.IO.Path.GetFileName(Anh.FileName);
                    var path = Server.MapPath("/Images/" + FileName);
                    Anh.SaveAs(path);
                    loaiMay.Hinh = FileName;
                }
                db.LoaiMays.Add(loaiMay);
                db.SaveChanges();
                return View("Index", db.LoaiMays.ToList());
            }
            return View(loaiMay);
        }

        // GET: LoaiMays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMay loaiMay = db.LoaiMays.Find(id);
            if (loaiMay == null)
            {
                return HttpNotFound();
            }
            return View(loaiMay);
        }

        // POST: LoaiMays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiMay,CauHinh,GiaTien,Hinh")] LoaiMay loaiMay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMay);
        }

        // GET: LoaiMays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMay loaiMay = db.LoaiMays.Find(id);
            if (loaiMay == null)
            {
                return HttpNotFound();
            }
            return View(loaiMay);
        }

        // POST: LoaiMays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiMay loaiMay = db.LoaiMays.Find(id);
            db.LoaiMays.Remove(loaiMay);
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
