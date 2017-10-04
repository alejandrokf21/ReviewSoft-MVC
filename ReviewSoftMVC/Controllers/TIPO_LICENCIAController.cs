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
    public class TIPO_LICENCIAController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();

        // GET: TIPO_LICENCIA
        public ActionResult Index()
        {
            return View(db.TIPO_LICENCIA.ToList());
        }

        // GET: TIPO_LICENCIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_LICENCIA tIPO_LICENCIA = db.TIPO_LICENCIA.Find(id);
            if (tIPO_LICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_LICENCIA);
        }

        // GET: TIPO_LICENCIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_LICENCIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] TIPO_LICENCIA tIPO_LICENCIA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_LICENCIA.Add(tIPO_LICENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_LICENCIA);
        }

        // GET: TIPO_LICENCIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_LICENCIA tIPO_LICENCIA = db.TIPO_LICENCIA.Find(id);
            if (tIPO_LICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_LICENCIA);
        }

        // POST: TIPO_LICENCIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] TIPO_LICENCIA tIPO_LICENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_LICENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_LICENCIA);
        }

        // GET: TIPO_LICENCIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_LICENCIA tIPO_LICENCIA = db.TIPO_LICENCIA.Find(id);
            if (tIPO_LICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_LICENCIA);
        }

        // POST: TIPO_LICENCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_LICENCIA tIPO_LICENCIA = db.TIPO_LICENCIA.Find(id);
            db.TIPO_LICENCIA.Remove(tIPO_LICENCIA);
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
