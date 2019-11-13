using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class EntregadorDAO : PadraoDAO<EntregadorViewModel>
    {
        protected override SqlParameter[] CriaParametros(EntregadorViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Nome", model.Nome);
            parametros[2] = new SqlParameter("IdCidadeEntrega", model.IdCidadeEntrega);
            
            return parametros;
        }

        protected override EntregadorViewModel MontaModel(DataRow registro)
        {
            EntregadorViewModel entrega = new EntregadorViewModel();
            entrega.Id = Convert.ToInt32(registro["Id"]);
            entrega.Nome = registro["Nome"].ToString();
            entrega.IdCidadeEntrega = Convert.ToInt32(registro["IdCidadeEntrega"]);
           
            return entrega;
        }

        protected override void SetTabela()
        {
            Tabela = "Entregador";
        }
    }
}
