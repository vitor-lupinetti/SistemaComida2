using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SistemaVenda.DAO;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class ComidaController : PadraoController<ComidasViewModel>
    {

        public ComidaController()
        {
            GeraProximoId = true;
            DAO = new ComidaDAO();
        }

        protected override void ValidaDados(ComidasViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Descricao))
                ModelState.AddModelError("Descricao", "Preencha corretamente");
            if(model.IdCategoria<= 0)
                ModelState.AddModelError("IdCategoria", "Preencha o id correto");
            if (model.IdEmbalagem <= 0)
                ModelState.AddModelError("IdEmbalagem", "Preencha o id correto");
            if (model.Imagem == null)
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");
            else if (model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");

        }
        public override IActionResult Create(int id)
        {
            PreparaListaCategoriasParaCombo();
            PreparaListaEmbalagemParaCombo();
            return base.Create(id);
        }

        public override IActionResult Edit(int id)
        {
            PreparaListaCategoriasParaCombo();
            PreparaListaEmbalagemParaCombo();
            return base.Edit(id);
        }
        public override IActionResult Salvar(ComidasViewModel model, string Operacao)
        {

            try
            {
                ValidaDados(model, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao; PreencheDadosParaView(Operacao, model);
                    PreparaListaCategoriasParaCombo();
                    PreparaListaEmbalagemParaCombo();
                    return View("Form", model);
                }
                else
                {
                    if (Operacao == "I")
                        DAO.Insert(model);
                    else
                        DAO.Update(model);
                    return RedirectToAction("index");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                PreparaListaCategoriasParaCombo();
                PreparaListaEmbalagemParaCombo();
                PreencheDadosParaView(Operacao, model);
                return View("Form", model);
            }
           
        }
        public IActionResult Login()
        {
            UsuarioViewModel u = new UsuarioViewModel();
            return View(u);
        }

        private void PreparaListaCategoriasParaCombo()
        {
            CategoriaDAO cdao = new CategoriaDAO();
            var categorias = cdao.Listagem();
            List<SelectListItem> listaCategorias = new List<SelectListItem>();
            listaCategorias.Add(new SelectListItem("Selecione uma categoria...", "0"));
            foreach (var cat in categorias)
            {
                SelectListItem item = new SelectListItem(cat.Descricao, cat.Id.ToString());
                listaCategorias.Add(item);
            }
            ViewBag.Categorias = listaCategorias;
        }

        private void PreparaListaEmbalagemParaCombo()
        {
            EmbalagemDAO edao = new EmbalagemDAO();
            var embalagens = edao.Listagem();
            List<SelectListItem> listaEmbalagens = new List<SelectListItem>();
            listaEmbalagens.Add(new SelectListItem("Selecione uma embalagem...", "0"));
            foreach (var em in embalagens)
            {
                SelectListItem item = new SelectListItem(em.Descricao, em.Id.ToString());
                listaEmbalagens.Add(item);
            }
            ViewBag.Embalagens = listaEmbalagens;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UsuarioViewModel u = new UsuarioViewModel();
            string usuarioJson = HttpContext.Session.GetString("usuario");
            if (usuarioJson != null)
                u = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);

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