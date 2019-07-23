using Logistica.Models;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

using System.Threading.Tasks;


namespace Logistica.Controllers
{
    public class TransportadorasController : Controller
    {
        public TransportadorasController()
        {
        }

        public TransportadorasController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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

        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }
        private LogisticaDB db = new LogisticaDB();
        // GET: Transportadoras
        [Authorize(Roles = "Gestor,Transportador")]
        public ActionResult Index()
        {
            var listaDeTransportadores = db.Transportadora
                                   .OrderByDescending(a => a.ID)
                                   .ToList();
            // se for apenas agente
            //SELECT * FROM Agente WHERE UserName = username da pessoa autenticada
            if (!User.IsInRole("Gestor"))
            {
                // vou restringir a listagem inicial apenas aos dados do Agente
                //  listaDeAgentes = listaDeAgentes.Where(a => a.UserName == User.Identity.Name).ToList();

                // redirecionar para página dos detalhes
                int idTransportador = db.Transportadora
                               .Where(a => a.Email == User.Identity.Name)
                               .FirstOrDefault()
                               .ID;
                return RedirectToAction("Details", new { id = idTransportador });
            }
            return View(listaDeTransportadores);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            using (var context = new ApplicationDbContext())
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        // colocar aqui as instrucoes para guardar um Agente
                        var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                        ViewBag.Link = callbackUrl;
                        var roleStore = new RoleStore<IdentityRole>(context);
                        var roleManager = new RoleManager<IdentityRole>(roleStore);

                        var userStore = new UserStore<ApplicationUser>(context);
                        var userManager = new UserManager<ApplicationUser>(userStore);
                        userManager.AddToRole(user.Id, "Transportador");
                        var transportadora = new Transportadora { NomeTransportadora = model.NomeEmpresa, Pais = model.Pais, Cidade = model.Cidade, Rua = model.Rua, CodigoPostal = model.CodigoPostal, NumPorta = model.NumPorta, NIF = model.NIF, Contacto = model.Contacto, Email = model.Email};
                        LogisticaDB db = new LogisticaDB();
                        db.Transportadora.Add(transportadora);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    return View(model);
                }

            // If we got this far, something failed, redisplay form
            return View();
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
            var transportadora = db.Transportadora
                                        .Where(a => a.ID == id)
                                        .OrderByDescending(a => a.ID)
                                        .First();
            var user = UserManager.FindByName(transportadora.Email);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
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

                var transportadora = db.Transportadora
                                     .Where(a => a.ID == id)
                                     .OrderByDescending(a => a.ID)
                                     .First();
                var user = UserManager.FindByName(transportadora.Email);

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
                var cotacoes = db.Cotacoes
                    .Where(a => a.Transportadorafk == id)
                    .OrderByDescending(a => a.ID)
                    .ToList();
                foreach (var item in cotacoes)
                {
                    db.Cotacoes.Remove(item);
                    db.SaveChanges();
                }
                db.Transportadora.Remove(transportadora);
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
