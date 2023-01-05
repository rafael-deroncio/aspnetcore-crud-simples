using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using CRUDsimples.Models;

namespace CRUDsimples
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TotalCadastros = Usuario.Listagem.Count();

            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && Usuario.Listagem.Any(user => user.Id == id))
            {
                Usuario usuario = Usuario.Listagem.Single(user => user.Id == id);

                return View(usuario);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            Usuario.Salvar(usuario);

            return RedirectToAction("Usuarios");
        }

        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && Usuario.Listagem.Any(user => user.Id == id))
            {
                Usuario usuario = Usuario.Listagem.Single(user => user.Id == id);

                return View(usuario);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Excluir(Usuario usuario)
        {
            Usuario.Excluir(usuario.Id);

            return RedirectToAction("Usuarios");
        }
    }
}