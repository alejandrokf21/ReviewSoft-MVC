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
    public class USUARIOsController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();

        // GET: USUARIOs
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.PROFESION1).Include(u => u.TIPO_USUARIO1);
            return View(uSUARIO.ToList());
        }

        // GET: USUARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            ViewBag.PROFESION = new SelectList(db.PROFESION, "CODIGO", "NOMBRE");
            ViewBag.TIPO_USUARIO = new SelectList(db.TIPO_USUARIO, "CODIGO", "NOMBRE");
            return View();
        }

        // POST: USUARIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMBRE,FECHA_NACIMIENTO,CORREO,CONTRASEÑA,TIPO_USUARIO,PROFESION")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROFESION = new SelectList(db.PROFESION, "CODIGO", "NOMBRE", uSUARIO.PROFESION);
            ViewBag.TIPO_USUARIO = new SelectList(db.TIPO_USUARIO, "CODIGO", "NOMBRE", uSUARIO.TIPO_USUARIO);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROFESION = new SelectList(db.PROFESION, "CODIGO", "NOMBRE", uSUARIO.PROFESION);
            ViewBag.TIPO_USUARIO = new SelectList(db.TIPO_USUARIO, "CODIGO", "NOMBRE", uSUARIO.TIPO_USUARIO);
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,FECHA_NACIMIENTO,CORREO,CONTRASEÑA,TIPO_USUARIO,PROFESION")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROFESION = new SelectList(db.PROFESION, "CODIGO", "NOMBRE", uSUARIO.PROFESION);
            ViewBag.TIPO_USUARIO = new SelectList(db.TIPO_USUARIO, "CODIGO", "NOMBRE", uSUARIO.TIPO_USUARIO);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
