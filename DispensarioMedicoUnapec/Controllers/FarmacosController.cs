using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DispensarioMedicoUnapec;

namespace DispensarioMedicoUnapec.Controllers
{
    [Authorize(Roles = "Administrador , Consulta")]
    public class FarmacosController : Controller
    {
        private DispensarioMedicoEntities db = new DispensarioMedicoEntities();

        // GET: Farmacos
        public ActionResult Index(String Criterio = null)
        {
            return View(db.Farmacos.Where(p => Criterio == null || p.Nombre.StartsWith(Criterio) ||
          p.PrincipioActivo.StartsWith(Criterio)).ToList());
        }


        // GET: Farmacos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacos farmacos = db.Farmacos.Find(id);
            if (farmacos == null)
            {
                return HttpNotFound();
            }
            return View(farmacos);
        }

        // GET: Farmacos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.IdViaAdministracion = new SelectList(db.ViaAdmin, "IdViaAdministracion", "Nombre");
            return View();
        }

        // POST: Farmacos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFarmaco,Nombre,PrincipioActivo,IdViaAdministracion,FormaFarmaceutica,Estado")] Farmacos farmacos)
        {
            if (ModelState.IsValid)
            {
                db.Farmacos.Add(farmacos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdViaAdministracion = new SelectList(db.ViaAdmin, "IdViaAdministracion", "Nombre", farmacos.IdViaAdministracion);
            return View(farmacos);
        }

        // GET: Farmacos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacos farmacos = db.Farmacos.Find(id);
            if (farmacos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdViaAdministracion = new SelectList(db.ViaAdmin, "IdViaAdministracion", "Nombre", farmacos.IdViaAdministracion);
            return View(farmacos);
        }

        // POST: Farmacos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFarmaco,Nombre,PrincipioActivo,IdViaAdministracion,FormaFarmaceutica,Estado")] Farmacos farmacos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmacos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdViaAdministracion = new SelectList(db.ViaAdmin, "IdViaAdministracion", "Nombre", farmacos.IdViaAdministracion);
            return View(farmacos);
        }

        // GET: Farmacos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacos farmacos = db.Farmacos.Find(id);
            if (farmacos == null)
            {
                return HttpNotFound();
            }
            return View(farmacos);
        }

        // POST: Farmacos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmacos farmacos = db.Farmacos.Find(id);
            db.Farmacos.Remove(farmacos);
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
