using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class PromocaoDAO : PadraoDAO<PromocaoViewModel>
    {
        protected override SqlParameter[] CriaParametros(PromocaoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("IdCategoria", model.IdCategoria);
            parametros[2] = new SqlParameter("Porcentagem", model.Porcentagem);
            parametros[3] = new SqlParameter("DataInicio", model.DataInicio);
            parametros[4] = new SqlParameter("DataFim", model.DataFim);

            return parametros;
        }

        protected override PromocaoViewModel MontaModel(DataRow registro)
        {
            PromocaoViewModel entrega = new PromocaoViewModel();
            entrega.Id = Convert.ToInt32(registro["Id"]);
            entrega.IdCategoria = Convert.ToInt32(registro["IdCategoria"]);
            entrega.Porcentagem = Convert.ToDouble(registro["Porcentagem"]);
            entrega.DataInicio = Convert.ToDateTime(registro["DataInicio"]);
            entrega.DataFim = Convert.ToDateTime(registro["DataFim"]);
            return entrega;
        }

        protected override void SetTabela()
        {
            Tabela = "Promocao";
        }
    }
}
