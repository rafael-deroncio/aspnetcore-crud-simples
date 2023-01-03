using Microsoft.AspNetCore.Mvc;

namespace CRUDsimples
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View("FormUsuario");
        }
    }
}