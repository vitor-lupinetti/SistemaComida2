using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class AjustePrecoDAO : PadraoDAO<AjustePrecoViewModel>
    {
        protected override SqlParameter[] CriaParametros(AjustePrecoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("IdCategoria", model.IdCategoria);
            parametros[2] = new SqlParameter("Porcentagem", model.Porcentagem);
            parametros[3] = new SqlParameter("Opcao", model.Opcao);

            return parametros;
        }

        protected override AjustePrecoViewModel MontaModel(DataRow registro)
        {
            AjustePrecoViewModel entrega = new AjustePrecoViewModel();
            entrega.Id = Convert.ToInt32(registro["Id"]);
            entrega.IdCategoria = Convert.ToInt32(registro["IdCategoria"]);
            entrega.Porcentagem = Convert.ToDouble(registro["Porcentagem"]);
            entrega.Opcao = Convert.ToString(registro["Opcao"]);
            
            return entrega;
        }

        protected override void SetTabela()
        {
            Tabela = "AjustePreco";
        }
    }
}
