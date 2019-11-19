using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
