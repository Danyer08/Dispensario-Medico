using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DispensarioMedicoUnapec;

namespace DispensarioMedicoUnapec.Controllers
{
    [Authorize(Roles = "Administrador , Consulta")]
    public class Registro_VisitasController : Controller
    {
        private DispensarioMedicoEntities db = new DispensarioMedicoEntities();

        // GET: Registro_Visitas
        public ActionResult Index(String Criterio = null)
        {

            var registro_Visitas = db.Registro_Visitas.Include(r => r.Medicamentos).Include(r => r.Medicos).Include(r => r.Pacientes);
            return View(registro_Visitas.Where(p => Criterio == null || p.Sintomas.StartsWith(Criterio) ||
            p.Pacientes.Nombre.StartsWith(Criterio)).ToList());


        }


        // GET: Registro_Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Visitas registro_Visitas = db.Registro_Visitas.Find(id);
            if (registro_Visitas == null)
            {
                return HttpNotFound();
            }
            return View(registro_Visitas);
        }

        // GET: Registro_Visitas/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.IdMedicamento = new SelectList(db.Medicamentos, "IdMedicamento", "Nombre");
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombre");
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nombre");
            return View();
        }

        // POST: Registro_Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVisita,IdMedico,IdPaciente,FechaVisita,HoraVisita,Sintomas,IdMedicamento,Recomendaciones,Estado")] Registro_Visitas registro_Visitas)
        {
            if (ModelState.IsValid)
            {
                db.Registro_Visitas.Add(registro_Visitas);
                db.SaveChanges();
                Medicamentos medicamentos = (from r in db.Medicamentos.Where(predicate: a => a.IdMedicamento == registro_Visitas.IdMedicamento) select r).FirstOrDefault();
                medicamentos.Cantidad = medicamentos.Cantidad - 1;
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }

            ViewBag.IdMedicamento = new SelectList(db.Medicamentos, "IdMedicamento", "Nombre", registro_Visitas.IdMedicamento);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombre", registro_Visitas.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nombre", registro_Visitas.IdPaciente);
            return View(registro_Visitas);
        }

        // GET: Registro_Visitas/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Visitas registro_Visitas = db.Registro_Visitas.Find(id);
            if (registro_Visitas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMedicamento = new SelectList(db.Medicamentos, "IdMedicamento", "Nombre", registro_Visitas.IdMedicamento);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombre", registro_Visitas.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nombre", registro_Visitas.IdPaciente);
            return View(registro_Visitas);
        }

        // POST: Registro_Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVisita,IdMedico,IdPaciente,FechaVisita,HoraVisita,Sintomas,IdMedicamento,Recomendaciones,Estado")] Registro_Visitas registro_Visitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_Visitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMedicamento = new SelectList(db.Medicamentos, "IdMedicamento", "Nombre", registro_Visitas.IdMedicamento);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "Nombre", registro_Visitas.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nombre", registro_Visitas.IdPaciente);
            return View(registro_Visitas);
        }

        // GET: Registro_Visitas/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Visitas registro_Visitas = db.Registro_Visitas.Find(id);
            if (registro_Visitas == null)
            {
                return HttpNotFound();
            }
            return View(registro_Visitas);
        }

        // POST: Registro_Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro_Visitas registro_Visitas = db.Registro_Visitas.Find(id);
            db.Registro_Visitas.Remove(registro_Visitas);
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


        public ActionResult Exportar()
        {
            string filename = "Registro Visita.csv";
            string filepath = @"C:\Users\Danyer\Desktop" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("Servicio,Descripcion,Estado"); //Encabezado 
            foreach (var i in db.Registro_Visitas.ToList())
            {
                sw.WriteLine(i.IdVisita.ToString() + "," + i.IdMedico.ToString() + "," + i.IdPaciente.ToString() + "," + i.FechaVisita + "," + i.HoraVisita + "," + i.Sintomas
                    + "," + i.IdMedicamento.ToString() + "," + i.Recomendaciones + "," + i.Estado);
            }
            sw.Close();

            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = false,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);

        }
    }
}
