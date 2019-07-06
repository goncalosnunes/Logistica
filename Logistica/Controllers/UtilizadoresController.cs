using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logistica.Models;

namespace Logistica.Controllers
{
    public class UtilizadoresController : Controller
    {
        private LogisticaDB db = new LogisticaDB();
        [Authorize (Roles = "Gestor")]
        // GET: Utilizadores
        public async Task<ActionResult> Index()
        {
            return View(await db.Utilizadores.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = await db.Utilizadores.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "ID,Nome,Apelido,Fotografia,NomeEmpresa,Pais,Cidade,Rua,CodigoPostal,NumPorta,NIF,Contacto,Email")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadores.Add(utilizadores);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = await db.Utilizadores.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nome,Apelido,Fotografia,NomeEmpresa,Pais,Cidade,Rua,CodigoPostal,NumPorta,NIF,Contacto,Email")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizadores).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = await db.Utilizadores.FindAsync(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Utilizadores utilizadores = await db.Utilizadores.FindAsync(id);
            db.Utilizadores.Remove(utilizadores);
            await db.SaveChangesAsync();
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
