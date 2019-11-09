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
    public class CarrinhoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var carrinho = ObtemCarrinhoNaSession();
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return View(carrinho);
        }

        public IActionResult Detalhes(int idComida)
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();

            ComidaDAO dao = new ComidaDAO();
            var model = dao.Consulta(idComida);

            CarrinhoViewModel carrinhoModel = carrinho.Find(c => c.IdComida == idComida);
            if (carrinhoModel == null)
            {
                carrinhoModel = new CarrinhoViewModel();
                carrinhoModel.IdComida = idComida;
                carrinhoModel.Nome = model.Descricao;
                carrinhoModel.Quantidade = 0;
                carrinhoModel.Preco = model.Preco;
            }

            // preenche a imagem
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            carrinhoModel.ImagemEmBase64 = model.ImageBase64;
            return View(carrinhoModel);
        }

        private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        {
            List<CarrinhoViewModel> carrinho = new List<CarrinhoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            if (carrinhoJson != null)
                carrinho = JsonConvert.DeserializeObject<List<CarrinhoViewModel>>(carrinhoJson);

            return carrinho;
        }

        public IActionResult AdicionarCarrinho(int idComida, int Quantidade)
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();

            CarrinhoViewModel carrinhoModel = carrinho.Find(c => c.IdComida == idComida);

            if (carrinhoModel != null && Quantidade == 0)
            {
                //tira do carrinho
                carrinho.Remove(carrinhoModel);
            }
            else if (carrinhoModel == null && Quantidade > 0)
            {
                //não havia no carrinho, vamos adicionar
                ComidaDAO dao = new ComidaDAO();
                var model = dao.Consulta(idComida);

                carrinhoModel = new CarrinhoViewModel();
                carrinhoModel.IdComida = idComida;
                carrinhoModel.Nome = model.Descricao;
                carrinhoModel.Preco = model.Preco;
                carrinho.Add(carrinhoModel);
            }

            if (carrinhoModel != null)
                carrinhoModel.Quantidade = Quantidade;

            string carrinhoJson = JsonConvert.SerializeObject(carrinho);
            HttpContext.Session.SetString("carrinho", carrinhoJson);
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return RedirectToAction("Index");
        }
        public IActionResult Remover(int idComida)
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();

            CarrinhoViewModel carrinhoModel = carrinho.Find(c => c.IdComida == idComida);

            if(carrinhoModel != null)
            {
                carrinho.Remove(carrinhoModel);
            }
            string carrinhoJson = JsonConvert.SerializeObject(carrinho);
            HttpContext.Session.SetString("carrinho", carrinhoJson);
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Tipo = HelperController.VerificaTipoUsuario(HttpContext.Session);
            return RedirectToAction("index");
        }
    }
}
