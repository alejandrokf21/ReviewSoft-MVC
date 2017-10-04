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
    public class TIPO_PLATAFORMAController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();

        // GET: TIPO_PLATAFORMA
        public ActionResult Index()
        {
            return View(db.TIPO_PLATAFORMA.ToList());
        }

        // GET: TIPO_PLATAFORMA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PLATAFORMA tIPO_PLATAFORMA = db.TIPO_PLATAFORMA.Find(id);
            if (tIPO_PLATAFORMA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PLATAFORMA);
        }

        // GET: TIPO_PLATAFORMA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_PLATAFORMA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] TIPO_PLATAFORMA tIPO_PLATAFORMA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_PLATAFORMA.Add(tIPO_PLATAFORMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_PLATAFORMA);
        }

        // GET: TIPO_PLATAFORMA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PLATAFORMA tIPO_PLATAFORMA = db.TIPO_PLATAFORMA.Find(id);
            if (tIPO_PLATAFORMA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PLATAFORMA);
        }

        // POST: TIPO_PLATAFORMA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] TIPO_PLATAFORMA tIPO_PLATAFORMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_PLATAFORMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_PLATAFORMA);
        }

        // GET: TIPO_PLATAFORMA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PLATAFORMA tIPO_PLATAFORMA = db.TIPO_PLATAFORMA.Find(id);
            if (tIPO_PLATAFORMA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PLATAFORMA);
        }

        // POST: TIPO_PLATAFORMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_PLATAFORMA tIPO_PLATAFORMA = db.TIPO_PLATAFORMA.Find(id);
            db.TIPO_PLATAFORMA.Remove(tIPO_PLATAFORMA);
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
