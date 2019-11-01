using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class ComidaDAO : PadraoDAO<ComidasViewModel>
    {
        protected override SqlParameter[] CriaParametros(ComidasViewModel model)
        {
            object imgByte = model.ImageByte();
            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Descricao", model.Descricao);
            parametros[2] = new SqlParameter("Preco", model.Preco);
            parametros[3] = new SqlParameter("IdCategoria", model.IdCategoria);
            parametros[4] = new SqlParameter("IdEmbalagem", model.IdEmbalagem);
            parametros[5] = new SqlParameter("imagem", imgByte);
            return parametros;

        }

        protected override ComidasViewModel MontaModel(DataRow registro)
        {
            ComidasViewModel comida = new ComidasViewModel();
            comida.Id = Convert.ToInt32(registro["Id"]);
            comida.Descricao = registro["Descricao"].ToString();
            comida.Preco = Convert.ToDouble(registro["Preco"]);
            comida.IdCategoria = Convert.ToInt32(registro["IdCategoria"]);
            comida.IdEmbalagem = Convert.ToInt32(registro["IdEmbalagem"]);

            if (registro["imagem"] != DBNull.Value)
            {
                comida.ImageBase64 = Convert.ToBase64String(registro["imagem"] as byte[]);
            }


            return comida;

        }

        protected override void SetTabela()
        {
            Tabela = "Comidas";
        }

        public List<ComidasViewModel> ListagemCategorias(int id)
        {
            var p = new SqlParameter[]
           {
                new SqlParameter("idCategoria", id)
           };
            var tabela = HelperDAO.ExecutaProcSelect("spListagemCategorias", p);
            List<ComidasViewModel> lista = new List<ComidasViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
    }
}
