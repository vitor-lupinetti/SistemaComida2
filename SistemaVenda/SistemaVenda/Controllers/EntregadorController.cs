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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaVenda.Controllers
{
    public class EntregadorController : PadraoController<EntregadorViewModel>
    {
        public EntregadorController()
        {
            GeraProximoId = true;
            DAO = new EntregadorDAO();
        }
        protected override void ValidaDados(EntregadorViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha corretamente");
            if (model.IdCidadeEntrega < 0)
                ModelState.AddModelError("Id", "Preencha o id correto");

        }

        private void PreparaListaCidadesParaCombo()
        {
            CidadeDAO cidadeDao = new CidadeDAO();
            var cidades = cidadeDao.Listagem();
            List<SelectListItem> listaCidades = new List<SelectListItem>();
            listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));
            foreach (var cidade in cidades)
            {
                SelectListItem item = new SelectListItem(cidade.Descricao, cidade.Id.ToString());
                listaCidades.Add(item);
            }
            ViewBag.Cidades = listaCidades;
        }

        public override IActionResult Create(int id)
        {
            PreparaListaCidadesParaCombo();
            return base.Create(id);
        }

        public override IActionResult Edit(int id)
        {
            PreparaListaCidadesParaCombo();
            return base.Edit(id);
        }
        public override IActionResult Salvar(EntregadorViewModel model, string Operacao)
        {

            try
            {
                ValidaDados(model, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao; PreencheDadosParaView(Operacao, model);
                    PreparaListaCidadesParaCombo();
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
                PreparaListaCidadesParaCombo();
                PreencheDadosParaView(Operacao, model);
                return View("Form", model);
            }

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
