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
    public class UtilizadoresController : Controller
    {
        private LogisticaDB db = new LogisticaDB();

        // GET: Utilizadores
        public ActionResult Index()
        {
            return View(db.Utilizador.ToList());
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizador.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Apelido,Fotografia")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Utilizador.Add(utilizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizador.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Apelido,Fotografia")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizador.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizadores utilizadores = db.Utilizador.Find(id);
            db.Utilizador.Remove(utilizadores);
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
