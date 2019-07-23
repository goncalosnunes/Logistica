using Logistica.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logistica.Controllers
{
    public class CotacoesController : Controller
    {
        private LogisticaDB db = new LogisticaDB();

        // GET: Cotacaos
        [Authorize(Roles = "Gestor,Transportador")]
        public ActionResult Encomendas()
        {
            var listaDeCotacoes = new List<Cotacoes>();
            var listaDePedidos = db.Pedidos.Include(c => c.Transportadora)
                                    .Where(a => a.Estado == 0)
                                    .OrderByDescending(a => a.DataEntregaPretendida)
                                    .ToList();
            foreach (var item in listaDePedidos)
            {
                var modelo = new Cotacoes();
                modelo.Pedido = item;
                modelo.Pedidofk = item.ID;
                int idTransportadora = db.Transportadora
                              .Where(a => a.Email == User.Identity.Name)
                              .FirstOrDefault()
                              .ID;
                modelo.Transportadora = db.Transportadora.Find(idTransportadora);
                modelo.Transportadorafk = db.Transportadora.Find(idTransportadora).ID;
                modelo.valorCotacao = 0;
                modelo.Aceite = false;
                var existe = false;
                foreach (var iten in db.Cotacoes)
                {
                    if ((iten.Pedidofk.Equals(modelo.Pedidofk)) && (iten.Transportadorafk.Equals(modelo.Transportadorafk)))
                    {
                        existe = true;
                    }
                }
                if (!existe) listaDeCotacoes.Add(modelo);
            }

            foreach (var item in listaDeCotacoes)
            {
                db.Cotacoes.Add(item);
                db.SaveChanges();
            }

            var listaFinal = db.Pedidos.Include(c => c.Transportadora)
                                    .Where(a => a.Transportadora.Email == User.Identity.Name)
                                    .OrderBy(a => a.Estado)
                                    .ToList();
            return View(listaFinal);
        }

        public ActionResult Cotadas()
        {
            var listaDeCotacoes = db.Cotacoes.Include(c => c.Pedido).Include(c => c.Transportadora)
                                    .Where(a => a.Transportadora.Email == User.Identity.Name)
                                    .OrderByDescending(a => a.ID)
                                    .ToList();
            listaDeCotacoes = listaDeCotacoes
                                .Where(b => db.Pedidos.Find(b.Pedidofk).Estado == 0)
                                .OrderByDescending(a => a.ID)
                                .ToList();
            listaDeCotacoes = listaDeCotacoes
                                .Where(a => !(a.valorCotacao.Equals(0)))
                                .OrderByDescending(a => a.ID)
                                .ToList();
            return View(listaDeCotacoes);
        }

        // POST: Cotacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Encomendas([Bind(Include = "ID, valorCotacao, Pedidofk, Transportadorafk,")] Cotacoes cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("EmEspera");
            }
            return View(cotacao);
        }
        // GET: Cotacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacoes cotacao = db.Cotacoes.Include(c => c.Pedido).Include(c => c.Transportadora).SingleOrDefault(u => u.ID == id); ;
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }


        // GET: Cotacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacoes cotacao = db.Cotacoes.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // POST: Cotacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID, valorCotacao, Pedidofk, Transportadorafk")] Cotacoes cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("EmEspera");
            }
            return View(cotacao);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult EmEspera()
        {
            var listaDeCotacoes = db.Cotacoes.Include(c => c.Pedido).Include(c => c.Transportadora)
                                     .Where(a => a.Transportadora.Email == User.Identity.Name)
                                     .OrderByDescending(a => a.ID)
                                     .ToList();
            listaDeCotacoes = listaDeCotacoes
                                .Where(a => a.valorCotacao.Equals(0))
                                .OrderByDescending(a => a.ID)
                                .ToList();
            return View(listaDeCotacoes);
        }

        public ActionResult Encomenda(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pedido = db.Pedidos.Include(c => c.Transportadora)
                            .Where(a => a.ID == id)
                            .OrderByDescending(a => a.ID)
                            .First();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Encomenda([Bind(Include = "ID,Nome,Apelido,NomeEmpresaDestinataria,PaisDestino,CidadeDestino,RuaDestino,CodigoPostalDestino,NumPortaDestino,ContactoDestinatario,EmailDestinatario,Peso,Comprimento,Largura,Altura,DataEntregaPretendida,Estado,Utilizador,Utilizadorfk")] Pedidos pedido)
        {
            var pedidoAux = db.Pedidos
                            .Where(a => a.ID == pedido.ID)
                            .OrderByDescending(a => a.ID)
                            .First();
            pedidoAux.Estado = pedido.Estado;
            db.Entry(pedidoAux).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Encomendas");
            return View(pedido);
        }

    }
}
