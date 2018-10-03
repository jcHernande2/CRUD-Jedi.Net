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
    public class HologramaJedisController : Controller
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: HologramaJedis
        public ActionResult Index()
        {
            var hologramaJedi = db.HologramaJedi.OrderBy(h => h.Holograma.Nombre).Include(h => h.Holograma).Include(h => h.Jedis);
           
            return View(hologramaJedi.ToList());
        }

        // GET: HologramaJedis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HologramaJedi hologramaJedi = db.HologramaJedi.Find(id);
            if (hologramaJedi == null)
            {
                return HttpNotFound();
            }
            return View(hologramaJedi);
        }

        // GET: HologramaJedis/Create
        public ActionResult Create()
        {
            ViewBag.idHolograma = new SelectList(db.Holograma, "Id", "Nombre");
            ViewBag.idJedi = new SelectList(db.Jedis, "Id", "Nombre");
            return View();
        }

        // POST: HologramaJedis/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHolograma,idJedi")] HologramaJedi hologramaJedi)
        {
            if (ModelState.IsValid)
            {
                db.HologramaJedi.Add(hologramaJedi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idHolograma = new SelectList(db.Holograma, "Id", "Nombre", hologramaJedi.idHolograma);
            ViewBag.idJedi = new SelectList(db.Jedis, "Id", "Nombre", hologramaJedi.idJedi);
            return View(hologramaJedi);
        }

        // GET: HologramaJedis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HologramaJedi hologramaJedi = db.HologramaJedi.Find(id);
            if (hologramaJedi == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHolograma = new SelectList(db.Holograma, "Id", "Nombre", hologramaJedi.idHolograma);
            ViewBag.idJedi = new SelectList(db.Jedis, "Id", "Nombre", hologramaJedi.idJedi);
            return View(hologramaJedi);
        }

        // POST: HologramaJedis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,idHolograma,idJedi")] HologramaJedi hologramaJedi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hologramaJedi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHolograma = new SelectList(db.Holograma, "Id", "Nombre", hologramaJedi.idHolograma);
            ViewBag.idJedi = new SelectList(db.Jedis, "Id", "Nombre", hologramaJedi.idJedi);
            return View(hologramaJedi);
        }

        // GET: HologramaJedis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HologramaJedi hologramaJedi = db.HologramaJedi.Find(id);
            if (hologramaJedi == null)
            {
                return HttpNotFound();
            }
            return View(hologramaJedi);
        }

        // POST: HologramaJedis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HologramaJedi hologramaJedi = db.HologramaJedi.Find(id);
            db.HologramaJedi.Remove(hologramaJedi);
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
