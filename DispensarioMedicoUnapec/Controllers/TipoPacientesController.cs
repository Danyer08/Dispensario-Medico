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
   
    public class TipoPacientesController : Controller
    {
        private DispensarioMedicoEntities db = new DispensarioMedicoEntities();

        // GET: TipoPacientes
        public ActionResult Index()
        {
            return View(db.TipoPaciente.ToList());
        }

        // GET: TipoPacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPaciente tipoPaciente = db.TipoPaciente.Find(id);
            if (tipoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipoPaciente);
        }

        // GET: TipoPacientes/Create
       
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPaciente,Nombre")] TipoPaciente tipoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.TipoPaciente.Add(tipoPaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPaciente);
        }

        // GET: TipoPacientes/Edit/5
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPaciente tipoPaciente = db.TipoPaciente.Find(id);
            if (tipoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipoPaciente);
        }

        // POST: TipoPacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPaciente,Nombre")] TipoPaciente tipoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPaciente);
        }

        // GET: TipoPacientes/Delete/5
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPaciente tipoPaciente = db.TipoPaciente.Find(id);
            if (tipoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipoPaciente);
        }

        // POST: TipoPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPaciente tipoPaciente = db.TipoPaciente.Find(id);
            db.TipoPaciente.Remove(tipoPaciente);
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
