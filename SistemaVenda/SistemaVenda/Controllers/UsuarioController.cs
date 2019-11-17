using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaVenda.DAO;
using SistemaVenda.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaVenda.Controllers
{
    public class UsuarioController : PadraoController<UsuarioViewModel>
    {

        public UsuarioController()
        {
            GeraProximoId = true;
            DAO = new UsuarioDAO();
        }

        protected override void ValidaDados(UsuarioViewModel model, string operacao)
        {
            UsuarioViewModel u = new UsuarioViewModel();
            UsuarioDAO d = new UsuarioDAO();
            u = d.ConsultaEmail(model.Email);
            base.ValidaDados(model, operacao);

            if(string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Digite um email");
            if (string.IsNullOrEmpty(model.Endereco))
                ModelState.AddModelError("Endereco", "Endereço inválido");
            if (string.IsNullOrEmpty(model.Senha))
                ModelState.AddModelError("Senha", "Senha em branco.");
            if (u != null)
                ModelState.AddModelError("Email", "Esse e-mail já está em uso");
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (!rg.IsMatch(model.Email))
                ModelState.AddModelError("Email", "Email inválido");

            
        }

        
    }
}
