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
    public class CotacaosController : Controller
    {
        private LogisticaDB db = new LogisticaDB();

        // GET: Cotacaos
        public ActionResult Index()
        {
            var cotacao = db.Cotacao.Include(c => c.Pedido).Include(c => c.Transportadora);
            return View(cotacao.ToList());
        }

        // GET: Cotacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // GET: Cotacaos/Create
        public ActionResult Create()
        {
            ViewBag.Pedidofk = new SelectList(db.Pedido, "ID", "Nome");
            ViewBag.Transportadorafk = new SelectList(db.Transportadora, "ID", "NomeTransportadora");
            return View();
        }

        // POST: Cotacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,valorCotacao,Pedidofk,Transportadorafk")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Cotacao.Add(cotacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pedidofk = new SelectList(db.Pedido, "ID", "Nome", cotacao.Pedidofk);
            ViewBag.Transportadorafk = new SelectList(db.Transportadora, "ID", "NomeTransportadora", cotacao.Transportadorafk);
            return View(cotacao);
        }

        // GET: Cotacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pedidofk = new SelectList(db.Pedido, "ID", "Nome", cotacao.Pedidofk);
            ViewBag.Transportadorafk = new SelectList(db.Transportadora, "ID", "NomeTransportadora", cotacao.Transportadorafk);
            return View(cotacao);
        }

        // POST: Cotacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,valorCotacao,Pedidofk,Transportadorafk")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pedidofk = new SelectList(db.Pedido, "ID", "Nome", cotacao.Pedidofk);
            ViewBag.Transportadorafk = new SelectList(db.Transportadora, "ID", "NomeTransportadora", cotacao.Transportadorafk);
            return View(cotacao);
        }

        // GET: Cotacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // POST: Cotacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            db.Cotacao.Remove(cotacao);
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
