using System.Web.Mvc;

namespace Logistica.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (User.IsInRole("Transportador")) return RedirectToAction("Encomendas", "Cotacoes");
            if (User.IsInRole("Gestor")) return RedirectToAction("Index", "Transportadoras");
            if (User.IsInRole("Cliente")) return RedirectToAction("Index", "Pedidos");
            return View();

        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
