﻿using System;
using System.Data.SqlClient;

namespace SistemaVenda.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
           //string strCon = "Data Source=LOCALHOST;Initial Catalog=SistemaVendasBD;user id=sa; password=123456";
            string strCon = "Data Source=DESKTOP-F3L3JV6\\SQLEXPRESS;Initial Catalog=SistemaVendasBD;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
