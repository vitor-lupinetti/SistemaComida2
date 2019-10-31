using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class EmbalagemDAO : PadraoDAO<EmbalagemViewModel>
    {
        protected override SqlParameter[] CriaParametros(EmbalagemViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Descricao", model.Descricao);
            parametros[2] = new SqlParameter("QtdEstoque", model.QtdEstoque);

            return parametros;
        }

        protected override EmbalagemViewModel MontaModel(DataRow registro)
        {
            EmbalagemViewModel e = new EmbalagemViewModel();
            e.Id = Convert.ToInt32(registro["Id"]);
            e.Descricao = registro["Descricao"].ToString();
            e.QtdEstoque = Convert.ToInt32(registro["QtdEstoque"]);

            return e;
        }

        protected override void SetTabela()
        {
            Tabela = "Embalagem";
        }
    }
}
