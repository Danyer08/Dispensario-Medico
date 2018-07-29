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
    public class ViaAdministracionController : Controller
    {
        private DispensarioMedicoEntities db = new DispensarioMedicoEntities();

        // GET: ViaAdministracion
        public ActionResult Index()
        {
            return View(db.ViaAdmin.ToList());
        }

        // GET: ViaAdministracion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViaAdmin viaAdmin = db.ViaAdmin.Find(id);
            if (viaAdmin == null)
            {
                return HttpNotFound();
            }
            return View(viaAdmin);
        }

        // GET: ViaAdministracion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViaAdministracion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdViaAdministracion,Nombre")] ViaAdmin viaAdmin)
        {
            if (ModelState.IsValid)
            {
                db.ViaAdmin.Add(viaAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viaAdmin);
        }

        // GET: ViaAdministracion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViaAdmin viaAdmin = db.ViaAdmin.Find(id);
            if (viaAdmin == null)
            {
                return HttpNotFound();
            }
            return View(viaAdmin);
        }

        // POST: ViaAdministracion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdViaAdministracion,Nombre")] ViaAdmin viaAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaAdmin);
        }

        // GET: ViaAdministracion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViaAdmin viaAdmin = db.ViaAdmin.Find(id);
            if (viaAdmin == null)
            {
                return HttpNotFound();
            }
            return View(viaAdmin);
        }

        // POST: ViaAdministracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViaAdmin viaAdmin = db.ViaAdmin.Find(id);
            db.ViaAdmin.Remove(viaAdmin);
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
