using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class ItensVendaDAO : PadraoDAO<ItensVendaViewModel>
    {
        protected override SqlParameter[] CriaParametros(ItensVendaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("IdVenda", model.Id);
            parametros[1] = new SqlParameter("IdComida", model.IdComida);
            parametros[2] = new SqlParameter("Qtd", model.Qtd);
          
            return parametros;
        }

        protected override ItensVendaViewModel MontaModel(DataRow registro)
        {
            ItensVendaViewModel itens = new ItensVendaViewModel();
            itens.Id = Convert.ToInt32(registro["IdVenda"]);
            itens.IdComida = Convert.ToInt32(registro["IdComida"]);
            itens.Qtd = Convert.ToInt32(registro["Qtd"]);
            return itens;
        }

        protected override void SetTabela()
        {
            Tabela = "ItensVenda";
        }
    }
}
