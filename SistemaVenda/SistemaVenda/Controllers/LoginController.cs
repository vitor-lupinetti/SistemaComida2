using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAO;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FazLogin(string Email, string senha)
        {
            //Este é apenas um exemplo, aqui você deve consultar na sua tabela de usuários
            //se existem esse usuário e senha

            UsuarioDAO dao = new UsuarioDAO();

           /* var usuario = dao.ConsultaEmail(Email);

            if(usuario == null)
            {
                ViewBag.Erro = "Email não cadastrado.";
                return View("Index");
            }*/

            if (Email == "vi.lupinetti@hotmail.com.br" && senha == "abc")
            {
                HttpContext.Session.SetString("Logado", "true");
                ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}