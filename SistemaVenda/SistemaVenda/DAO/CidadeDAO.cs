using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class CidadeDAO : PadraoDAO<CidadesViewModel>
    {
        protected override SqlParameter[] CriaParametros(CidadesViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[3];

            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Descricao", model.Descricao);
            parametros[2] = new SqlParameter("ValorEntrega", model.ValorEntrega);

            return parametros;
        }

        protected override CidadesViewModel MontaModel(DataRow registro)
        {
            CidadesViewModel c = new CidadesViewModel();

            c.Id = Convert.ToInt32(registro["Id"]);
            c.Descricao = registro["Descricao"].ToString();
            c.ValorEntrega = Convert.ToDouble(registro["ValorEntrega"]);
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Cidades";
        }
    }
}
