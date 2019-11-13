using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(UsuarioViewModel model)
        {
            /*object imgByte = model.ImageByte();
            if (imgByte == null)
                imgByte = DBNull.Value;*/

            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Nome", model.Nome);
            //parametros[2] = new SqlParameter("Imagem", imgByte);
            parametros[2] = new SqlParameter("Email", model.Email);
            parametros[3] = new SqlParameter("Senha", model.Senha);
            parametros[4] = new SqlParameter("Endereco", model.Endereco);
            parametros[5] = new SqlParameter("TipoUsuario", model.TipoUsuario);
            parametros[6] = new SqlParameter("ValorGasto", model.ValorGasto);

            return parametros;
        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.Id = Convert.ToInt32(registro["Id"]);
            usuario.TipoUsuario = registro["TipoUsuario"].ToString();
            usuario.Nome = registro["Nome"].ToString();
            usuario.Email = registro["Email"].ToString();
            usuario.Senha = registro["Senha"].ToString();
            usuario.Endereco = registro["Endereco"].ToString();
            usuario.ValorGasto = Convert.ToDouble(registro["ValorGasto"]);

            /*if (registro["Imagem"] != DBNull.Value)
            {
                //usuario.ImageBase64 = Convert.ToBase64String(registro["Imagem"] as byte[]);
                //usuario.ImageByte = registro["imagem"] as byte[];
            }*/

            return usuario;
        }

        public UsuarioViewModel ConsultaEmail(string email)
        {
            var p = new SqlParameter[]
           {
                new SqlParameter("Email", email)
           };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaEmail", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        protected override void SetTabela()
        {
            Tabela = "Usuarios";
        }
    }
}
