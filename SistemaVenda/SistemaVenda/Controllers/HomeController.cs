using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAO;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Nome = HelperController.VerificaNomeLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return View();
        }

        public IActionResult Categorias(int id)
        {
            ComidaDAO dao = new ComidaDAO();

            var lista = dao.ListagemCategorias(id);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return View("Menu", lista);
        }

        public IActionResult Menu()
        {
            ComidaDAO DAO = new ComidaDAO();
            var lista = DAO.Listagem();
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Nome = HelperController.VerificaNomeLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return View("Menu", lista);
        }
        public IActionResult Sobre()
        {
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return View();
        }
    }
}
