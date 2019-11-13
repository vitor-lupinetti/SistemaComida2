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
    public class PromocaoController : PadraoController<PromocaoViewModel>
    {
        public PromocaoController()
        {
            GeraProximoId = true;
            DAO = new PromocaoDAO();
        }

        protected override void ValidaDados(PromocaoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (model.IdCategoria < 0)
                ModelState.AddModelError("IdCategoria", "Preencha o id correto");
            if (model.Porcentagem < 0)
                ModelState.AddModelError("Porcentagem", "Valor incorreto"); 
            
        }

        public override IActionResult Create(int id)
        {
            PreparaListaCategoriasParaCombo();
            return base.Create(id);
        }

        public override IActionResult Edit(int id)
        {
            PreparaListaCategoriasParaCombo();
            return base.Edit(id);
        }
        public override IActionResult Salvar(PromocaoViewModel model, string Operacao)
        {

            try
            {
                ValidaDados(model, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao; PreencheDadosParaView(Operacao, model);
                    PreparaListaCategoriasParaCombo();
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
                PreencheDadosParaView(Operacao, model);
                return View("Form", model);
            }

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