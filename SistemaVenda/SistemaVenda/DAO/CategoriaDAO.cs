using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class CategoriaDAO : PadraoDAO<CategoriasViewModel>
    {
        protected override SqlParameter[] CriaParametros(CategoriasViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Descricao", model.Descricao);

            return parametros;
        }

        protected override CategoriasViewModel MontaModel(DataRow registro)
        {
            CategoriasViewModel c = new CategoriasViewModel();
            c.Id = Convert.ToInt32(registro["Id"]);
            c.Descricao = registro["Descricao"].ToString();

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Categorias";
        }
    }
}
