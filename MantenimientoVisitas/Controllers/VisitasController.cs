using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MantenimientoVisitas.Models;

namespace MantenimientoVisitas.Controllers
{
    public class VisitasController : Controller
    {
        private MantenimientoVisitasContext db = new MantenimientoVisitasContext();

        // GET: Visitas
        public ActionResult Index()
        {
            var visitas = db.Visitas.Include(v => v.Area).Include(v => v.Persona);
            return View(visitas.ToList());
        }

        public ActionResult Indexs(string nombre)
        {
            var visitas = db.Visitas.Include(v => v.Area).Include(v => v.Persona).Where(v => v.Area.NombreArea.Contains(nombre));
            return View("Index", visitas.ToList());
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "NombreArea");
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "Nombre");
            return View();
        }

        // POST: Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitaID,AreaID,Fecha,HoraEntrada,HoraSalida,PersonaID,Motivo")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visitas.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "NombreArea", visita.AreaID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "Nombre", visita.PersonaID);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "NombreArea", visita.AreaID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "Nombre", visita.PersonaID);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitaID,AreaID,Fecha,HoraEntrada,HoraSalida,PersonaID,Motivo")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "NombreArea", visita.AreaID);
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "Nombre", visita.PersonaID);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visitas.Find(id);
            db.Visitas.Remove(visita);
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
