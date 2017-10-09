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
    public class SOFTWAREUsuarioController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();
        private object Movies;

        // GET: SOFTWAREUsuario
        public ActionResult Index(string searchString)
        {
            var soft = from q in db.SOFTWARE
                       select q;
            //List<string> categoria = db.Database.SqlQuery<string>("select NOMBRE from CATEGORIA").ToList<string>();
            //ViewBag.cateDropdow=new SelectList(categoria);

            ViewBag.cateDropdow = new SelectList(db.CATEGORIA, "CODIGO", "NOMBRE");
            ViewBag.platDrop = new SelectList(db.TIPO_PLATAFORMA, "CODIGO", "NOMBRE");
            int plat = Convert.ToInt16(Request["platDrop"]);
           
            if (!String.IsNullOrEmpty(searchString) && !plat.Equals(null))
            {
               
                soft = soft.Where(s => s.NOMBRE.Contains(searchString));
            }
            

            

                return View(soft);
            //var sOFTWARE = db.SOFTWARE.Include(s => s.CATEGORIA1).Include(s => s.EMPRESA1).Include(s => s.TIPO_LICENCIA1).Include(s => s.TIPO_PLATAFORMA1);
            //return View(sOFTWARE.ToList());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: SOFTWAREUsuario/Details/5
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

        // GET: SOFTWAREUsuario/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIA, "CODIGO", "NOMBRE");
            ViewBag.EMPRESA = new SelectList(db.EMPRESA, "CODIGO", "NOMBRE");
            ViewBag.TIPO_LICENCIA = new SelectList(db.TIPO_LICENCIA, "CODIGO", "NOMBRE");
            ViewBag.TIPO_PLATAFORMA = new SelectList(db.TIPO_PLATAFORMA, "CODIGO", "NOMBRE");
            return View();
        }

        // POST: SOFTWAREUsuario/Create
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

        // GET: SOFTWAREUsuario/Edit/5
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

        // POST: SOFTWAREUsuario/Edit/5
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

        // GET: SOFTWAREUsuario/Delete/5
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

        // POST: SOFTWAREUsuario/Delete/5
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
