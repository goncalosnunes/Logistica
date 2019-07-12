using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logistica.Models;

namespace Logistica.Controllers
{
    public class TransportadorasController : Controller
    {
        private LogisticaDB db = new LogisticaDB();

        // GET: Transportadoras
        public ActionResult Index()
        {
            return View(db.Transportadora.ToList());
        }

        // GET: Transportadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportadora transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // GET: Transportadoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportadoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomeTransportadora,Pais,Cidade,Rua,CodigoPostal,NumPorta,NIF,Contacto,Email")] Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.Transportadora.Add(transportadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportadora);
        }

        // GET: Transportadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportadora transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // POST: Transportadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomeTransportadora,Pais,Cidade,Rua,CodigoPostal,NumPorta,NIF,Contacto,Email")] Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportadora);
        }

        // GET: Transportadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transportadora transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // POST: Transportadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transportadora transportadora = db.Transportadora.Find(id);
            db.Transportadora.Remove(transportadora);
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
