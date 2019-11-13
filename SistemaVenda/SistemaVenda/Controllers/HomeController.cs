using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaVenda.DAO;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UsuarioViewModel u = new UsuarioViewModel();
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);
            ViewBag.Nome = u.Nome;
            //ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            ViewBag.Tipo = u.TipoUsuario;
            return View();
        }

        public IActionResult Categorias(int id)
        {
            ComidaDAO dao = new ComidaDAO();

            var lista = dao.ListagemCategorias(id);
            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Nome = u.Nome;
            ViewBag.Tipo = u.TipoUsuario;
            return View("Menu", lista);
        }

        public IActionResult Menu()
        {
            ComidaDAO DAO = new ComidaDAO();
            var lista = DAO.Listagem();
            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Nome = u.Nome;
            ViewBag.Tipo = u.TipoUsuario;
            return View("Menu", lista);
        }
        public IActionResult Sobre()
        {
            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Nome = u.Nome;
            ViewBag.Tipo = u.TipoUsuario;
            return View();
        }
    }
}
