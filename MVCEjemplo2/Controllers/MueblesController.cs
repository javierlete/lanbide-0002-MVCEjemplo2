using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEjemplo2;

namespace MVCEjemplo2.Controllers
{
    public class MueblesController : Controller
    {
        private mf0966Entities db = new mf0966Entities();

        // GET: Muebles
        public ActionResult Index()
        {
            return View(db.Muebles.ToList());
        }

        // GET: Muebles/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mueble mueble = db.Muebles.Find(id);
            if (mueble == null)
            {
                return HttpNotFound();
            }
            return View(mueble);
        }

        // GET: Muebles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Muebles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Precio,Largo,Ancho,Alto,FechaFabricacion")] Mueble mueble)
        {
            if (ModelState.IsValid)
            {
                db.Muebles.Add(mueble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mueble);
        }

        // GET: Muebles/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mueble mueble = db.Muebles.Find(id);
            if (mueble == null)
            {
                return HttpNotFound();
            }
            return View(mueble);
        }

        // POST: Muebles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Precio,Largo,Ancho,Alto,FechaFabricacion")] Mueble mueble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mueble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mueble);
        }

        // GET: Muebles/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mueble mueble = db.Muebles.Find(id);
            if (mueble == null)
            {
                return HttpNotFound();
            }
            return View(mueble);
        }

        // POST: Muebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Mueble mueble = db.Muebles.Find(id);
            db.Muebles.Remove(mueble);
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
