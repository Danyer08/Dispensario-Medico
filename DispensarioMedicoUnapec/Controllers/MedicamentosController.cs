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
    public class MedicamentosController : Controller
    {
        private DispensarioMedicoEntities db = new DispensarioMedicoEntities();

        // GET: Medicamentos
        public ActionResult Index(string Criterio = null)
        {
            var medicamentos = db.Medicamentos.Include(m => m.Marcas).Include(m => m.Farmacos).Include(m => m.Ubicacion);
            return View(db.Medicamentos.Where(p => Criterio == null || p.Nombre.StartsWith(Criterio) ||
          p.Descripcion.StartsWith(Criterio)).ToList());


        }
        // GET: Medicamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // GET: Medicamentos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.IdFarmaco = new SelectList(db.Farmacos, "IdFarmaco", "Nombre");
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "Nombre");
            ViewBag.IdUbicacion = new SelectList(db.Ubicacion, "IdUbicacion", "Descripcion");
            return View();
        }

        // POST: Medicamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMedicamento,Nombre,IdFarmaco,IdMarca,IdUbicacion,Cantidad,Dosis,Estado,Descripcion")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentos.Add(medicamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFarmaco = new SelectList(db.Farmacos, "IdFarmaco", "Nombre", medicamentos.IdFarmaco);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "Nombre", medicamentos.IdMarca);
            ViewBag.IdUbicacion = new SelectList(db.Ubicacion, "IdUbicacion", "Descripcion", medicamentos.IdUbicacion);
            return View(medicamentos);
        }

        // GET: Medicamentos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFarmaco = new SelectList(db.Farmacos, "IdFarmaco", "Nombre", medicamentos.IdFarmaco);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "Nombre", medicamentos.IdMarca);
            ViewBag.IdUbicacion = new SelectList(db.Ubicacion, "IdUbicacion", "Descripcion", medicamentos.IdUbicacion);
            return View(medicamentos);
        }

        // POST: Medicamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMedicamento,Nombre,IdFarmaco,IdMarca,IdUbicacion,Cantidad,Dosis,Estado,Descripcion")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFarmaco = new SelectList(db.Farmacos, "IdFarmaco", "Nombre", medicamentos.IdFarmaco);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "Nombre", medicamentos.IdMarca);
            ViewBag.IdUbicacion = new SelectList(db.Ubicacion, "IdUbicacion", "Descripcion", medicamentos.IdUbicacion);
            return View(medicamentos);
        }

        // GET: Medicamentos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            db.Medicamentos.Remove(medicamentos);
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
