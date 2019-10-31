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
            return View();
        }

        public IActionResult Menu()
        {
            ComidaDAO DAO = new ComidaDAO();
            var lista = DAO.Listagem();
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            return View("Menu", lista);
        }
        public IActionResult Sobre()
        {
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            return View();
        }
    }
}
