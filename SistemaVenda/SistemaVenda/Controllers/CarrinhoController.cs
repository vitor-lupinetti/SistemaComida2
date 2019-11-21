using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            PreparaListaCidadesParaCombo();
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

        public IActionResult ConcluirCompra(int idcidade, string endereco)
        {
            if(idcidade == 0)
            {
                TempData["Erro"] = "Escolha uma cidade para finalizar seu pedido.";
                return RedirectToAction("index");
            }
            if(!HelperController.VerificaUserLogado(HttpContext.Session))
            {
                TempData["Erro"] = "Você precisa estar logado para concluir sua compra.";
                return RedirectToAction("index");
            }

            CidadeDAO ciDao = new CidadeDAO();
            CidadesViewModel c = new CidadesViewModel();
            c = ciDao.Consulta(idcidade);
            VendaDAO dao = new VendaDAO();
            UsuarioDAO userDAO = new UsuarioDAO();
            int idPedido = dao.ProximoId();
            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);
            VendaViewModel venda = new VendaViewModel();
            var entregador = EscolherEntregador(idcidade);
            var carrinho = ObtemCarrinhoNaSession();
            try
            {
                using (var transacao = new System.Transactions.TransactionScope())
                {

                    double? preco = 0;

                    venda.IdCidade = idcidade;
                    venda.DataVenda = DateTime.Now;
                    venda.Id = idPedido;
                    venda.IdEntregador = entregador.Id;
                    venda.IdUsuario = u.Id;
                    venda.EnderecoEntrega = endereco;

                    dao.Insert(venda);
                    ItensVendaDAO itemDAO = new ItensVendaDAO();

                    foreach (var elemento in carrinho)
                    {
                        ItensVendaViewModel item = new ItensVendaViewModel();
                        item.Id = idPedido;
                        item.IdComida = elemento.IdComida;
                        item.Qtd = elemento.Quantidade;
                        preco += (elemento.Quantidade * elemento.Preco) + c.ValorEntrega;

                       
                            itemDAO.Insert(item);
                        
                      
                    }
                    double? valorgasto = u.ValorGasto + preco;
                    u.ValorGasto = valorgasto;
                    userDAO.Update(u);
                    string usuarioJson2 = JsonConvert.SerializeObject(u);
                    HttpContext.Session.SetString("usuario", usuarioJson2);
                    transacao.Complete();
                }
            }
            catch (Exception erro)
            {
                TempData["Erro"] = erro.Message;
                return RedirectToAction("Index");
            }
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            RemoverTodos();
            return RedirectToAction("VendaConcluida", "Venda", new {idPed = venda.Id, nomeEntregador = entregador.Nome, carrinhoJ = carrinhoJson});
        }
        private void PreparaListaCidadesParaCombo()
        {
            CidadeDAO cidadeDao = new CidadeDAO();
            var cidades = cidadeDao.Listagem();
            List<SelectListItem> listaCidades = new List<SelectListItem>();
            listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));
            List<string> Fretes = new List<string>();
            foreach (var cidade in cidades)
            {
                SelectListItem item = new SelectListItem(cidade.Descricao + " - Frete: R$" + cidade.ValorEntrega, cidade.Id.ToString());
                listaCidades.Add(item);
               // Fretes.Add(cidade.Descricao + "Frete: R$"+cidade.ValorEntrega);
            }
            ViewBag.Cidades = listaCidades;
            ViewBag.Fretes = Fretes;
        }

        private void RemoverTodos()
        {
            List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
            carrinho.Clear();
            string carrinhoJson = JsonConvert.SerializeObject(carrinho);
            HttpContext.Session.SetString("carrinho", carrinhoJson);
        }

        private EntregadorViewModel EscolherEntregador(int idcidade)
        {
            EntregadorDAO dao = new EntregadorDAO();
            var entregadores = dao.Listagem();
            List<EntregadorViewModel> listaentregadores = new List<EntregadorViewModel>();

            foreach(var entregador in entregadores)
            {
                if (entregador.IdCidadeEntrega == idcidade)
                    listaentregadores.Add(entregador);
            }

            if (listaentregadores.Count > 1)
            {
                int tamanho = listaentregadores.Count();

                Random r = new Random();
                int n = r.Next(0, tamanho - 1);
                return listaentregadores[n];
            }
            else
                return listaentregadores[0];
        }
    }
}
