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
    public class JedisController : Controller
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: Jedis
        public ActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name)) { 
                var jedis = db.Jedis.Include(j => j.Grado);
                return View(jedis.ToList());
            }
            else
            {
                ViewBag.Name = name;
                var jedis = db.Jedis.Include(j => j.Grado);
                return View(jedis.Where(c => c.Grado.Nombre.ToLower().Contains(name)));
            }
        }

        // GET: Jedis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jedis jedis = db.Jedis.Find(id);
            if (jedis == null)
            {
                return HttpNotFound();
            }
            return View(jedis);
        }

        // GET: Jedis/Create
        public ActionResult Create()
        {
            ViewBag.idGrado = new SelectList(db.Grado, "Id", "Nombre");
            return View();
        }

        // POST: Jedis/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,idGrado,Edad,Direccion,Color")] Jedis jedis)
        {
            if (ModelState.IsValid)
            {
                db.Jedis.Add(jedis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGrado = new SelectList(db.Grado, "Id", "Nombre", jedis.idGrado);
            return View(jedis);
        }

        // GET: Jedis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jedis jedis = db.Jedis.Find(id);
            if (jedis == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGrado = new SelectList(db.Grado, "Id", "Nombre", jedis.idGrado);
            return View(jedis);
        }

        // POST: Jedis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,idGrado,Edad,Direccion,Color")] Jedis jedis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jedis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGrado = new SelectList(db.Grado, "Id", "Nombre", jedis.idGrado);
            return View(jedis);
        }

        // GET: Jedis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jedis jedis = db.Jedis.Find(id);
            if (jedis == null)
            {
                return HttpNotFound();
            }
            return View(jedis);
        }

        // POST: Jedis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jedis jedis = db.Jedis.Find(id);
            db.Jedis.Remove(jedis);
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
