using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Controllers
{
    public class HelperController
    {
        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Logado");
            if (logado == null)
                return false;
            else
                return true;
        }

        public static string VerificaNomeLogado(ISession session)
        {
            string nome = session.GetString("Usuario");
            return nome;
        }

        public static string VerificaTipoUsuario(ISession session)
        {
            string Tipo = session.GetString("TipoUsuario");
            return Tipo;
        }
        public static string VerificaIdUsuario(ISession session)
        {
            string Id = session.GetString("IdUsuario");
            return Id;
        }
    }
}
