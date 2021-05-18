using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelVenda
    {



        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Venda { get; set; }
        public int ID_Funcionario { get; set; }
        public int ID_Cliente { get; set; }
        public DateTime DT_Venda { get; set; }
        public string OBS_Venda { get; set; }
        public string DS_TipoPagamento { get; set; }
        public double VL_SubTotal { get; set; }
        public double VL_TaxaEntrega { get; set; }
        public double VL_Total { get; set; }
        public DateTime DT_Buscar { get; set; }
        public string DS_Mensagem { get; set; }

        public ModelVenda()
        {

        }


        public ModelVenda(int id_cliente, int id_funcionario, DateTime dt_venda)
        {
            ID_Cliente = id_cliente;
            ID_Funcionario = id_funcionario;
            DT_Venda = dt_venda;

            InserirVenda();
        }

        public ModelVenda(int id_funcionario, int id_cliente, string obs_venda, string ds_tipoPagamento, double vl_taxaEntrega, double vl_total)
        {
            ID_Funcionario = id_funcionario;
            ID_Cliente = id_cliente;
            OBS_Venda = obs_venda;
            DS_TipoPagamento = ds_tipoPagamento;
            VL_TaxaEntrega = vl_taxaEntrega;
            VL_Total = vl_total;

            EditarVenda();
        }




        // Método inserir
        public void InserirVenda()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Venda ( " +
                "ID_Funcionario, " +
                "ID_Cliente, " +
                "DT_Venda) " +
                "VALUES ( " +
                "'" + ID_Funcionario + "', " +
                "'" + ID_Cliente + "', " +
                "'" + DT_Venda + "') ",
                SqlCon);
                int result = sqlCommand.ExecuteNonQuery();
                DS_Mensagem = result > 0 ? "OK" : "Erro ao cadastrar";
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }


        }


        // Método editar
        public void EditarVenda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Venda SET " +
               "ID_Funcionario =  '" + ID_Funcionario + "', " +
               "ID_Cliente = '" + ID_Cliente + "',  " +
               "DT_Venda =  GETDATE(), " +
               "OBS_Venda =  '" + OBS_Venda + "', " +
               "DS_TipoPagamento = '" + DS_TipoPagamento + "',  " +
               "VL_TaxaEntrega =  '" + VL_TaxaEntrega.ToString(CultureInfo.GetCultureInfo("en-US")) + "', " +
               "VL_Total = '" + VL_Total.ToString(CultureInfo.GetCultureInfo("en-US")) + "'" +
               "WHERE ID_Venda = IDENT_CURRENT  ('TB_Venda') ",
               SqlCon);


                int result = sqlCommand.ExecuteNonQuery();

                DS_Mensagem = result > 0 ? "OK" : "Erro ao alterar";
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }
        }



        // Método excluir
        public void ExcluirVenda()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_Venda  " +
               "WHERE ID_Venda =  IDENT_CURRENT  ('TB_Venda') ",
                SqlCon);
                int result = sqlCommand.ExecuteNonQuery();
                DS_Mensagem = result > 0 ? "OK" : "Erro ao excluir";
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }
        }


        // Método validar vendas não finalizadas
        public void ValidarVenda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_Venda  " +
               "WHERE VL_Total IS NULL ",
                SqlCon);
                int result = sqlCommand.ExecuteNonQuery();
                DS_Mensagem = result > 0 ? "OK" : "Erro ao excluir";
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }

        }

        public int RetorneVendaNull()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
                "SELECT " +
                "ID_Venda " +
                "FROM TB_Venda " +
                "WHERE VL_Total IS NULL ",

                SqlCon);
               ID_Venda = Convert.ToInt32(sqlCommand.ExecuteScalar());
                DS_Mensagem = ID_Venda > 0 ? "OK" : "Erro ao excluir";

            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();

            }

            return ID_Venda;

        }


        // Método mostrar
        public DataTable MostrarVenda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();
            DataTable dataTable = new DataTable();


            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "SELECT " +
                "VEN.ID_Venda, " +
                "FUN.NM_Funcionario, " +
                "CLI.NM_Cliente, " +
                "VEN.DT_Venda, " +
                "VEN.OBS_Venda, " +
                "VEN.DS_TipoPagamento, " +
                "FORMAT(VEN.VL_TaxaEntrega, 'N2') AS VL_TaxaEntrega, " +
                "FORMAT(VEN.VL_Total, 'N2') AS VL_Total " +
                "FROM TB_Venda AS VEN " +
                "INNER JOIN TB_Cliente AS CLI " +
                "ON VEN.ID_Cliente = CLI.ID_Cliente " +
                "INNER JOIN TB_Funcionario AS FUN " +
                "ON VEN.ID_Funcionario = FUN.ID_Funcionario " +
                "ORDER BY ID_Venda DESC ",
                 SqlCon);
                sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }

            return dataTable;
        }

        // Método venda por data
        public DataTable BuscarProdutoVenda(DateTime dtInicial, DateTime dtFinal, string produto)
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();
            DataTable dataTable = new DataTable();


            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
               "SELECT " +
               "VEN.ID_Venda, " +
               "VEN.DT_Venda, " +
               "CLI.NM_Cliente, " +
               "FUN.NM_Funcionario, " +
               "string_agg(PROD.NM_Produto, ',\n' )  as NM_Produtos, " +
               "SUM(ITEM.VL_SubTotal) + VEN.VL_TaxaEntrega AS VL_Total,  "  +
               "SUM((PROD.PR_Custo ) * ITEM.QTDE_ItemVenda) AS TotalCusto " +
               "FROM TB_Venda AS VEN " +
               "INNER JOIN TB_Cliente as CLI " +
               "ON VEN.ID_Cliente = CLI.ID_Cliente " +
               "INNER JOIN TB_Funcionario AS FUN " +
               "ON VEN.ID_Funcionario = FUN.ID_Funcionario " +
               "INNER JOIN TB_ItemVenda AS ITEM " +
               "ON VEN.ID_Venda = ITEM.ID_Venda " +
               "INNER JOIN TB_Produto as PROD " +
               "ON PROD.ID_Produto = ITEM.ID_Produto " +
               "WHERE VEN.DT_Venda BETWEEN '" + dtInicial + "' AND '" + dtFinal + "' " +
               "AND  PROD.NM_Produto LIKE '" + produto + "' + '%' " +
               "GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega, FUN.NM_Funcionario " +
               "ORDER BY VEN.ID_Venda ASC " ,
                 SqlCon);
                sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }

            return dataTable;
        }
        public DataTable BuscarNomeCliente(DateTime dtInicial, DateTime dtFinal, string cliente)
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();
            DataTable dataTable = new DataTable();


            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
               "SELECT " +
               "VEN.ID_Venda, " +
               "VEN.DT_Venda, " +
               "CLI.NM_Cliente, " +
               "FUN.NM_Funcionario, " +
               "string_agg(PROD.NM_Produto,  ',\n')  as NM_Produtos, " +
               "SUM(ITEM.VL_SubTotal) + VEN.VL_TaxaEntrega AS VL_Total,  " +
               "SUM((PROD.PR_Custo ) * ITEM.QTDE_ItemVenda) AS TotalCusto " +
               "FROM TB_Venda AS VEN " +
               "INNER JOIN TB_Cliente as CLI " +
               "ON VEN.ID_Cliente = CLI.ID_Cliente " +
               "INNER JOIN TB_Funcionario AS FUN " +
               "ON VEN.ID_Funcionario = FUN.ID_Funcionario " +
               "INNER JOIN TB_ItemVenda AS ITEM " +
               "ON VEN.ID_Venda = ITEM.ID_Venda " +
               "INNER JOIN TB_Produto as PROD " +
               "ON PROD.ID_Produto = ITEM.ID_Produto " +
               "WHERE VEN.DT_Venda BETWEEN '" + dtInicial + "' AND '" + dtFinal + "' " +
               "AND  CLI.NM_Cliente LIKE '" + cliente + "' + '%' " +
               "GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega, FUN.NM_Funcionario " +
               "ORDER BY VEN.ID_Venda ASC ",
                 SqlCon);
                sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }

            return dataTable;
        }
        public DataTable BuscarNomeFuncionario(DateTime dtInicial, DateTime dtFinal, string funcionario)
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();
            DataTable dataTable = new DataTable();


            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
               "SELECT " +
               "VEN.ID_Venda, " +
               "VEN.DT_Venda, " +
               "CLI.NM_Cliente, " +
               "FUN.NM_Funcionario, " +
               "string_agg(PROD.NM_Produto,  ',\n')  as NM_Produtos, " +
               "SUM(ITEM.VL_SubTotal) + VEN.VL_TaxaEntrega AS VL_Total,  " +
               "SUM((PROD.PR_Custo ) * ITEM.QTDE_ItemVenda) AS TotalCusto " +
               "FROM TB_Venda AS VEN " +
               "INNER JOIN TB_Cliente as CLI " +
               "ON VEN.ID_Cliente = CLI.ID_Cliente " +
               "INNER JOIN TB_Funcionario AS FUN " +
               "ON VEN.ID_Funcionario = FUN.ID_Funcionario " +
               "INNER JOIN TB_ItemVenda AS ITEM " +
               "ON VEN.ID_Venda = ITEM.ID_Venda " +
               "INNER JOIN TB_Produto as PROD " +
               "ON PROD.ID_Produto = ITEM.ID_Produto " +
               "WHERE VEN.DT_Venda BETWEEN '" + dtInicial + "' AND '" + dtFinal + "' " +
               "AND  FUN.NM_Funcionario LIKE '" + funcionario + "' + '%' " +
               "GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega, FUN.NM_Funcionario " +
               "ORDER BY VEN.ID_Venda ASC ",
                 SqlCon);
                sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlCommand.Dispose();
                SqlCon.Close();
            }

            return dataTable;
        }
    }
}
