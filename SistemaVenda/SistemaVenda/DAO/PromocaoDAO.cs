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
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("IdCategoria", model.IdCategoria);
            parametros[2] = new SqlParameter("Porcentagem", model.Porcentagem);

            return parametros;
        }

        protected override PromocaoViewModel MontaModel(DataRow registro)
        {
            PromocaoViewModel entrega = new PromocaoViewModel();
            entrega.Id = Convert.ToInt32(registro["Id"]);
            entrega.IdCategoria = Convert.ToInt32(registro["IdCategoria"]);
            entrega.Porcentagem = Convert.ToDouble(registro["Porcentagem"]);

            return entrega;
        }

        protected override void SetTabela()
        {
            Tabela = "Promocao";
        }
    }
}
