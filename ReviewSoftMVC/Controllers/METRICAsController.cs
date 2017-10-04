using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewSoftMVC.Models;

namespace ReviewSoftMVC.Controllers
{
    public class METRICAsController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();

        // GET: METRICAs
        public ActionResult Index()
        {
            return View(db.METRICA.ToList());
        }

        // GET: METRICAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METRICA mETRICA = db.METRICA.Find(id);
            if (mETRICA == null)
            {
                return HttpNotFound();
            }
            return View(mETRICA);
        }

        // GET: METRICAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: METRICAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] METRICA mETRICA)
        {
            if (ModelState.IsValid)
            {
                db.METRICA.Add(mETRICA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mETRICA);
        }

        // GET: METRICAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METRICA mETRICA = db.METRICA.Find(id);
            if (mETRICA == null)
            {
                return HttpNotFound();
            }
            return View(mETRICA);
        }

        // POST: METRICAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] METRICA mETRICA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mETRICA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mETRICA);
        }

        // GET: METRICAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METRICA mETRICA = db.METRICA.Find(id);
            if (mETRICA == null)
            {
                return HttpNotFound();
            }
            return View(mETRICA);
        }

        // POST: METRICAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            METRICA mETRICA = db.METRICA.Find(id);
            db.METRICA.Remove(mETRICA);
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
