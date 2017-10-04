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
    public class PROFESIONsController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();

        [Authorize(Roles ="Administrador")]
        // GET: PROFESIONs
        public ActionResult Index()
        {
            return View(db.PROFESION.ToList());
        }

        [Authorize(Roles = "Administrador")]
        // GET: PROFESIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESION pROFESION = db.PROFESION.Find(id);
            if (pROFESION == null)
            {
                return HttpNotFound();
            }
            return View(pROFESION);
        }

        [Authorize(Roles = "Administrador")]
        // GET: PROFESIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: PROFESIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] PROFESION pROFESION)
        {
            if (ModelState.IsValid)
            {
                db.PROFESION.Add(pROFESION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROFESION);
        }

        [Authorize(Roles = "Administrador")]
        // GET: PROFESIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESION pROFESION = db.PROFESION.Find(id);
            if (pROFESION == null)
            {
                return HttpNotFound();
            }
            return View(pROFESION);
        }

        [Authorize(Roles = "Administrador")]
        // POST: PROFESIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,DESCRIPCION")] PROFESION pROFESION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFESION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROFESION);
        }

        [Authorize(Roles = "Administrador")]
        // GET: PROFESIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESION pROFESION = db.PROFESION.Find(id);
            if (pROFESION == null)
            {
                return HttpNotFound();
            }
            return View(pROFESION);
        }

        [Authorize(Roles = "Administrador")]
        // POST: PROFESIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROFESION pROFESION = db.PROFESION.Find(id);
            db.PROFESION.Remove(pROFESION);
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
