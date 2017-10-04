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
    public class SOFTWAREsController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();

        // GET: SOFTWAREs
        public ActionResult Index()
        {
            var sOFTWARE = db.SOFTWARE.Include(s => s.CATEGORIA1).Include(s => s.EMPRESA1).Include(s => s.TIPO_LICENCIA1).Include(s => s.TIPO_PLATAFORMA1);
            return View(sOFTWARE.ToList());
        }

        // GET: SOFTWAREs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOFTWARE sOFTWARE = db.SOFTWARE.Find(id);
            if (sOFTWARE == null)
            {
                return HttpNotFound();
            }
            return View(sOFTWARE);
        }

        // GET: SOFTWAREs/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIA, "CODIGO", "NOMBRE");
            ViewBag.EMPRESA = new SelectList(db.EMPRESA, "CODIGO", "NOMBRE");
            ViewBag.TIPO_LICENCIA = new SelectList(db.TIPO_LICENCIA, "CODIGO", "NOMBRE");
            ViewBag.TIPO_PLATAFORMA = new SelectList(db.TIPO_PLATAFORMA, "CODIGO", "NOMBRE");
            return View();
        }

        // POST: SOFTWAREs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,NOMBRE,DEMO_GRATUITO,SOPORTE,AÑO,CATEGORIA,TIPO_LICENCIA,TIPO_PLATAFORMA,EMPRESA")] SOFTWARE sOFTWARE)
        {
            if (ModelState.IsValid)
            {
                db.SOFTWARE.Add(sOFTWARE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATEGORIA = new SelectList(db.CATEGORIA, "CODIGO", "NOMBRE", sOFTWARE.CATEGORIA);
            ViewBag.EMPRESA = new SelectList(db.EMPRESA, "CODIGO", "NOMBRE", sOFTWARE.EMPRESA);
            ViewBag.TIPO_LICENCIA = new SelectList(db.TIPO_LICENCIA, "CODIGO", "NOMBRE", sOFTWARE.TIPO_LICENCIA);
            ViewBag.TIPO_PLATAFORMA = new SelectList(db.TIPO_PLATAFORMA, "CODIGO", "NOMBRE", sOFTWARE.TIPO_PLATAFORMA);
            return View(sOFTWARE);
        }

        // GET: SOFTWAREs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOFTWARE sOFTWARE = db.SOFTWARE.Find(id);
            if (sOFTWARE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIA, "CODIGO", "NOMBRE", sOFTWARE.CATEGORIA);
            ViewBag.EMPRESA = new SelectList(db.EMPRESA, "CODIGO", "NOMBRE", sOFTWARE.EMPRESA);
            ViewBag.TIPO_LICENCIA = new SelectList(db.TIPO_LICENCIA, "CODIGO", "NOMBRE", sOFTWARE.TIPO_LICENCIA);
            ViewBag.TIPO_PLATAFORMA = new SelectList(db.TIPO_PLATAFORMA, "CODIGO", "NOMBRE", sOFTWARE.TIPO_PLATAFORMA);
            return View(sOFTWARE);
        }

        // POST: SOFTWAREs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,DEMO_GRATUITO,SOPORTE,AÑO,CATEGORIA,TIPO_LICENCIA,TIPO_PLATAFORMA,EMPRESA")] SOFTWARE sOFTWARE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOFTWARE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIA, "CODIGO", "NOMBRE", sOFTWARE.CATEGORIA);
            ViewBag.EMPRESA = new SelectList(db.EMPRESA, "CODIGO", "NOMBRE", sOFTWARE.EMPRESA);
            ViewBag.TIPO_LICENCIA = new SelectList(db.TIPO_LICENCIA, "CODIGO", "NOMBRE", sOFTWARE.TIPO_LICENCIA);
            ViewBag.TIPO_PLATAFORMA = new SelectList(db.TIPO_PLATAFORMA, "CODIGO", "NOMBRE", sOFTWARE.TIPO_PLATAFORMA);
            return View(sOFTWARE);
        }

        // GET: SOFTWAREs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOFTWARE sOFTWARE = db.SOFTWARE.Find(id);
            if (sOFTWARE == null)
            {
                return HttpNotFound();
            }
            return View(sOFTWARE);
        }

        // POST: SOFTWAREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOFTWARE sOFTWARE = db.SOFTWARE.Find(id);
            db.SOFTWARE.Remove(sOFTWARE);
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
