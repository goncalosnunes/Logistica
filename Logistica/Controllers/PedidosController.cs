using Logistica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logistica.Controllers
{
    public class PedidosController : Controller
    {
        private LogisticaDB db = new LogisticaDB();

        // GET: Pedidoes
        [Authorize(Roles = "Gestor,Cliente")]
        public ActionResult Index()
        {
            var listaDePedidos = db.Pedidos
                                   .OrderByDescending(a => a.ID)
                                   .ToList();
            listaDePedidos = listaDePedidos
                                .Where(a => a.Estado.Equals(2))
                                .ToList();

            // se for apenas agente
            //SELECT * FROM Agente WHERE UserName = username da pessoa autenticada
            if (!User.IsInRole("Gestor"))
            {
                listaDePedidos = listaDePedidos
                                   .OrderByDescending(a => a.ID)
                                   .Where(a => db.Utilizadores.Find(a.Utilizadorfk).Email == User.Identity.Name)
                                   .ToList();
            }
            return View(listaDePedidos);
        }

        [Authorize(Roles = "Gestor,Cliente")]
        public ActionResult EmTransito()
        {
            var listaDePedidos = db.Pedidos
                                   .OrderByDescending(a => a.ID)
                                   .ToList();
            listaDePedidos = listaDePedidos
                                .Where(a => a.Estado.Equals(1))
                                .ToList();

            // se for apenas agente
            //SELECT * FROM Agente WHERE UserName = username da pessoa autenticada
            if (!User.IsInRole("Gestor"))
            {
                    listaDePedidos = listaDePedidos
                                       .OrderByDescending(a => a.ID)
                                       .Where(a => db.Utilizadores.Find(a.Utilizadorfk).Email == User.Identity.Name)
                                       .ToList();
            }
            return View(listaDePedidos);
        }

        [Authorize(Roles = "Gestor,Cliente")]
        public ActionResult PorAceitar()
        {
            var listaDePedidos = db.Pedidos
                                   .OrderByDescending(a => a.ID)
                                   .ToList();
            listaDePedidos = listaDePedidos
                                .OrderBy(c => c.DataEntregaPretendida)
                                .Where(a => a.Estado.Equals(0))
                                .ToList();

            // se for apenas agente
            //SELECT * FROM Agente WHERE UserName = username da pessoa autenticada
            if (!User.IsInRole("Gestor"))
            {
                    listaDePedidos = listaDePedidos
                                   .OrderBy(a => a.DataEntregaPretendida)
                                   .Where(a => db.Utilizadores.Find(a.Utilizadorfk).Email == User.Identity.Name)
                                   .ToList();
            }
            return View(listaDePedidos);
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Apelido,NomeEmpresaDestinataria,PaisDestino,CidadeDestino,RuaDestino,CodigoPostalDestino,NumPortaDestino,ContactoDestinatario,EmailDestinatario,Peso,Comprimento,Largura,Altura,DataEntregaPretendida")] Pedidos pedido)
        {
            pedido.Utilizador = db.Utilizadores
                                    .OrderByDescending(a => a.ID)
                                    .Where(a => a.Email == User.Identity.Name)
                                    .First();
            pedido.Utilizadorfk = pedido.Utilizador.ID;
            pedido.Aceite = 0;

            pedido.Estado = 0;
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                var cotacao = db.Cotacoes.Include(c => c.Pedido).Include(c => c.Transportadora)
                                .Where(a => a.Pedido.ID == id)
                                .OrderByDescending(a => a.ID)
                                .ToList();
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            
            return View(cotacao);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID, valorCotacao, Pedidofk, Transportadorafk,Aceite")]  Cotacoes cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cotacao);
        }

        public async  Task<ActionResult> Aceitar(int? id) {
            var cotacao = db.Cotacoes.Find(id);
            var pedido = db.Pedidos.Find(cotacao.Pedidofk);
            pedido.Aceite = 1;
            pedido.Estado = 1;
            pedido.Transportadora = db.Transportadora.Find(cotacao.Transportadorafk);
            pedido.Transportadorafk = cotacao.Transportadora.ID;
            pedido.Preco = cotacao.valorCotacao;
            db.Entry(pedido).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("PorAceitar");
        }

        public ActionResult Encomendas(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pedido = db.Pedidos.Include(c => c.Transportadora)
                            .Where(a => a.ID == id)
                            .OrderByDescending(a => a.ID)
                            .FirstOrDefault();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }
            // GET: Pedidoes/Delete/5
            public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedidos pedido = db.Pedidos.Find(id);
            if (pedido.Aceite == 0)
            {
                db.Pedidos.Remove(pedido);
                db.SaveChanges();
            }
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
