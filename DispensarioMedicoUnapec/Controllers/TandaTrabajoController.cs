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
    public class TandaTrabajoController : Controller
    {
        private DispensarioMedicoEntities db = new DispensarioMedicoEntities();

        // GET: TandaTrabajo
        public ActionResult Index()
        {
            return View(db.TandaTrabajo.ToList());
        }

        // GET: TandaTrabajo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TandaTrabajo tandaTrabajo = db.TandaTrabajo.Find(id);
            if (tandaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tandaTrabajo);
        }

        // GET: TandaTrabajo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TandaTrabajo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTandaTrabajo,Nombre")] TandaTrabajo tandaTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.TandaTrabajo.Add(tandaTrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tandaTrabajo);
        }

        // GET: TandaTrabajo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TandaTrabajo tandaTrabajo = db.TandaTrabajo.Find(id);
            if (tandaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tandaTrabajo);
        }

        // POST: TandaTrabajo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTandaTrabajo,Nombre")] TandaTrabajo tandaTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tandaTrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tandaTrabajo);
        }

        // GET: TandaTrabajo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TandaTrabajo tandaTrabajo = db.TandaTrabajo.Find(id);
            if (tandaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tandaTrabajo);
        }

        // POST: TandaTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TandaTrabajo tandaTrabajo = db.TandaTrabajo.Find(id);
            db.TandaTrabajo.Remove(tandaTrabajo);
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
