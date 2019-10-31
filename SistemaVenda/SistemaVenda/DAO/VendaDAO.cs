﻿using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.DAO
{
    public class VendaDAO : PadraoDAO<VendaViewModel>
    {
        protected override SqlParameter[] CriaParametros(VendaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("IdVenda", model.Id);
            parametros[1] = new SqlParameter("DataVenda", model.DataVenda);
            parametros[2] = new SqlParameter("IdUsuario", model.IdUsuario);
            parametros[3] = new SqlParameter("IdEntregador", model.IdEntregador);
            parametros[4] = new SqlParameter("IdCidade", model.IdCidade);
            return parametros;
        }

        protected override VendaViewModel MontaModel(DataRow registro)
        {
            VendaViewModel venda = new VendaViewModel();
            venda.Id = Convert.ToInt32(registro["IdVenda"]);
            venda.DataVenda = Convert.ToDateTime(registro["DataVenda"]);
            venda.IdUsuario = Convert.ToInt32(registro["IdUsuario"]);
            venda.IdEntregador = Convert.ToInt32(registro["IdEntregador"]);
            venda.IdCidade = Convert.ToInt32(registro["IdCidade"]);
            return venda;
        }

        protected override void SetTabela()
        {
            Tabela = "Vendas";
        }
    }
}
