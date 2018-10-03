using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationPrueba.Models;

namespace WebApplicationPrueba.Controllers
{
    public class HologramasController : Controller
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: Hologramas
        public ActionResult Index()
        {
            return View(db.Holograma.ToList());
        }

        // GET: Hologramas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holograma holograma = db.Holograma.Find(id);
            if (holograma == null)
            {
                return HttpNotFound();
            }
            return View(holograma);
        }

        // GET: Hologramas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hologramas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Duracion")] Holograma holograma)
        {
            if (ModelState.IsValid)
            {
                db.Holograma.Add(holograma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(holograma);
        }

        // GET: Hologramas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holograma holograma = db.Holograma.Find(id);
            if (holograma == null)
            {
                return HttpNotFound();
            }
            return View(holograma);
        }

        // POST: Hologramas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Duracion")] Holograma holograma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holograma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(holograma);
        }

        // GET: Hologramas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holograma holograma = db.Holograma.Find(id);
            if (holograma == null)
            {
                return HttpNotFound();
            }
            return View(holograma);
        }

        // POST: Hologramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Holograma holograma = db.Holograma.Find(id);
            db.Holograma.Remove(holograma);
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
