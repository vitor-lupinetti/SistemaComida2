using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SistemaVenda.DAO;
using SistemaVenda.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        
        public IActionResult VendaConcluida(int idPed, string nomeEntregador,string carrinhoJ)
        {
            VendaDAO dao = new VendaDAO();

            var venda = new VendaViewModel();
               venda =  dao.Consulta(idPed);

            var carrinho = JsonConvert.DeserializeObject<List<CarrinhoViewModel>>(carrinhoJ);
            ViewBag.Itens = carrinho;
            ViewBag.Entregador = nomeEntregador;
             
            return View(venda);
        }

        public IActionResult Index()
        {
            if (!HelperController.VerificaUserLogado(HttpContext.Session))
            {
                RedirectToAction("Index", "Home");
            }

            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);

            VendaDAO dao = new VendaDAO();

            var vendas = dao.Listagem();

            List<VendaViewModel> lista = new List<VendaViewModel>();

            foreach (var venda in vendas)
            {
                if (venda.IdUsuario == u.Id)
                    lista.Add(venda);
            }

            return View(lista);
        }

        public IActionResult ConsultasProdutos()
        {
            return View();
        }

        public IActionResult RealizaBuscaFiltro(string filtro1, string filtro2, string filtro3)
        {
            Consulta1DAO dao = new Consulta1DAO();
            List<Consulta1ViewModel> c = new List<Consulta1ViewModel>();
            c = dao.Consulta1(filtro1, filtro2, filtro3);
            return View("ResultadoFiltro", c);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Nome = u.Nome;
            ViewBag.Tipo = u.TipoUsuario;

            if (!HelperController.VerificaUserLogado(HttpContext.Session))
                context.Result = RedirectToAction("Index", "Login");
            else if (u.TipoUsuario != "Adm")
            {
                context.Result = RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Logado = true;
                base.OnActionExecuting(context);
            }
        }
    }
}
