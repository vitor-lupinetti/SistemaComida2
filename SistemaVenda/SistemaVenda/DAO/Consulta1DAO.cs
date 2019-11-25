using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SistemaVenda.Models;

namespace SistemaVenda.DAO
{
    public class Consulta1DAO : PadraoDAO<Consulta1ViewModel>
    {
        protected override SqlParameter[] CriaParametros(Consulta1ViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[10];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Descricao", model.Descricao);
            parametros[2] = new SqlParameter("Preco", model.Preco);
            parametros[3] = new SqlParameter("IdCategoria", model.IdCategoria);
            parametros[4] = new SqlParameter("IdEmbalagem", model.IdEmbalagem);
            parametros[5] = new SqlParameter("DataVenda", model.DataVenda);
            parametros[6] = new SqlParameter("Filtro1", model.Filtro1);
            parametros[7] = new SqlParameter("Filtro2", model.Filtro2);
            parametros[8] = new SqlParameter("Filtro3", model.Filtro3);
            parametros[9] = new SqlParameter("Cidade", model.Cidade);

            return parametros;
        }

        protected override Consulta1ViewModel MontaModel(DataRow registro)
        {
            Consulta1ViewModel consulta = new Consulta1ViewModel();
            //consulta.Id = Convert.ToInt32(registro["Id"]);
            if(registro["Descricao"].ToString() != null)
                consulta.Descricao = registro["Descricao"].ToString();
            if((registro["Preco"]) != DBNull.Value)
                consulta.Preco = Convert.ToDouble(registro["Preco"]);
            //consulta.IdCategoria = Convert.ToInt32(registro["IdCategoria"]);
            //consulta.IdEmbalagem = Convert.ToInt32(registro["IdEmbalagem"]);
            if (registro["DataVenda"] != DBNull.Value)
                consulta.DataVenda = Convert.ToDateTime(registro["DataVenda"]);
            else
                consulta.DataVenda = null;
            consulta.Cidade = registro["Cidade"].ToString();
            if (registro["qtd"] != DBNull.Value)
                consulta.Qtd = Convert.ToInt32(registro["qtd"]);

            return consulta;
        }
       

        public List<Consulta1ViewModel> Consulta1(string filtro1, string filtro2, string filtro3)
        {
            var p = new SqlParameter[]
             {
             new SqlParameter("Filtro1", filtro1),
             new SqlParameter("Filtro2", filtro2),
             new SqlParameter("Filtro3",filtro3)
             };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta1", p);
            List<Consulta1ViewModel> lista = new List<Consulta1ViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }


        protected override void SetTabela()
        {
            Tabela = "Consulta";
        }
    }

}
