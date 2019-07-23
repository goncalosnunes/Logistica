using Logistica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Logistica.Controllers
{
    public class UtilizadoresController : Controller
    {
        private LogisticaDB db = new LogisticaDB();
        public UtilizadoresController()
        {
        }

        public UtilizadoresController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "Gestor,Cliente")]
        // GET: Utilizadores
        public ActionResult Index()
        {

            // LINQ
            // SELECT * FROM Agentes ORDER BY ID DESC   <--- só as pessoas dos recursos humanos
            var listaDeUtilizadores = db.Utilizadores
                                   .OrderByDescending(a => a.ID)
                                   .ToList();

            // se for apenas agente
            //SELECT * FROM Agente WHERE UserName = username da pessoa autenticada
            if (!User.IsInRole("Gestor"))
            {
                // vou restringir a listagem inicial apenas aos dados do Agente
                //  listaDeAgentes = listaDeAgentes.Where(a => a.UserName == User.Identity.Name).ToList();

                // redirecionar para página dos detalhes
                int idUtilizador = db.Utilizadores
                               .Where(a => a.Email == User.Identity.Name)
                               .FirstOrDefault()
                               .ID;
                return RedirectToAction("Details", new { id = idUtilizador });
            }
            return View(listaDeUtilizadores);
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

            if (User.IsInRole("Gestor") ||
            utilizadores.Email == User.Identity.Name)
            {
                // envia os dados do AGENTE para a View
                return View(utilizadores);
            }
            else
            {
                // estou a tentar aceder a dados não autorizados
                return RedirectToAction("Index");
            }
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
        //
        // GET: /Users/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var utilizador = db.Utilizadores
                                        .Where(a => a.ID == id)
                                        .OrderByDescending(a => a.ID)
                                        .First();
            var user = UserManager.FindByName(utilizador.Email);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        //
        // POST: /Users/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var utilizador = db.Utilizadores
                                     .Where(a => a.ID == id)
                                     .OrderByDescending(a => a.ID)
                                     .First();
                var user = UserManager.FindByName(utilizador.Email);

                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                var pedidos = db.Pedidos
                    .Where(a => a.Utilizadorfk == id)
                    .OrderByDescending(a => a.ID)
                    .ToList();
                foreach (var item in pedidos)
                {
                    db.Pedidos.Remove(item);
                    db.SaveChanges();
                }
                db.Utilizadores.Remove(utilizador);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
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
