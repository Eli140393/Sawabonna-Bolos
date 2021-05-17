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
    public class ModelItemVenda
    {


        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Venda { get; set; }
        public int ID_Produto { get; set; }
        public int QTDE_ItemVenda { get; set; }
        public double VL_SubTotal { get; set; }
        public string DS_Mensagem { get; set; }



        public ModelItemVenda()
        {

        }


        public ModelItemVenda(string action, int id_venda, int id_produto, int qtde_itemVenda, double vl_subTotal)
        {
            ID_Venda = id_venda;
            ID_Produto = id_produto;
            QTDE_ItemVenda = qtde_itemVenda;
            VL_SubTotal = vl_subTotal;

            if(action == "inserir")
            {
                InserirItemVenda();

            }

            if(action == "editar")
            {
                EditarItemVenda();
            }

        }

        public ModelItemVenda(int id_venda, int id_produto)
        {
            ID_Venda = id_venda;
            ID_Produto = id_produto;

            ExcluirUmItemVenda();
        }
        public ModelItemVenda(int id_venda)
        {
            ID_Venda = id_venda;
            ExcluirTodosItemVenda();
        }


        // Metodo inserir item venda
        public void InserirItemVenda()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_ItemVenda ( " +
                "ID_Venda, " +
                "ID_Produto, " +
                "QTDE_ItemVenda, " +
                "VL_SubTotal) " +
                "VALUES ( " +
                "'" + ID_Venda + "', " +
                "'" + ID_Produto + "', " +
                "'" + QTDE_ItemVenda + "', " +
                "'" + VL_SubTotal.ToString(CultureInfo.GetCultureInfo("en-US"))  + "') ",
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


        // Metodo editar item venda
        public void EditarItemVenda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_ItemVenda SET " +
               "ID_Produto =  '" + ID_Produto + "', " +
               "QTDE_ItemVenda = '" + QTDE_ItemVenda + "',  " +
               "VL_SubTotal =  '" + VL_SubTotal.ToString(CultureInfo.GetCultureInfo("en-US")) + "'  " + 
               "WHERE ID_Venda = '" + ID_Venda + "'  " +
               "AND ID_Produto ='" + ID_Produto + "'",
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



        // Metodo excluir todos item venda
        public void ExcluirUmItemVenda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_ItemVenda  " +
               "WHERE ID_Venda = '" + ID_Venda + "' " +
               "AND ID_Produto ='" + ID_Produto + "'",
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


        // Metodo excluir um item venda
        public void ExcluirTodosItemVenda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_ItemVenda  " +
               "WHERE ID_Venda = '" + ID_Venda + "' ",
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
        // Metodo mostrar item venda
        public DataTable MostrarItemVenda(int id_venda)
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
                "ITEM.ID_Venda, " +
                "ITEM.ID_Produto, " +
                "PROD.NM_Produto, " +
                "ITEM.QTDE_ItemVenda, " +
                "FORMAT(ITEM.VL_SubTotal, 'N2') AS VL_SubTotal " +
                "FROM  TB_ItemVenda AS ITEM " +
                "INNER JOIN TB_Produto AS PROD " +
                "ON ITEM.ID_Produto = PROD.ID_Produto " +
                "WHERE ID_Venda = '" + id_venda + "' " +
                "ORDER BY ITEM.ID_Venda DESC",
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
        public DataTable MostrarTodosItemVenda()
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
                "ITEM.ID_Venda, " +
                "ITEM.ID_Produto, " +
                "PROD.NM_Produto, " +
                "ITEM.QTDE_ItemVenda, " +
                "FORMAT(ITEM.VL_SubTotal, 'N2') AS VL_SubTotal " +
                "FROM  TB_ItemVenda AS ITEM " +
                "INNER JOIN TB_Produto AS PROD " +
                "ON ITEM.ID_Produto = PROD.ID_Produto " +
                "ORDER BY ITEM.ID_Venda DESC",
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

        // Metodo buscar nome item venda
        public DataTable BuscarNomeItemVenda(string textoBuscar)
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
                "PD.ID_Venda, " +
                "PROD.NM_Produto, " +
                "PD.QTDE_ItemVenda, " +
                "FORMAT(ITEM.VL_SubTotal, 'N2') AS VL_SubTotal " +
                "FROM  TB_ItemVenda AS PD " +
                "INNER JOIN TB_Produto AS PROD  " +
                "ON PD.ID_Produto =PROD.ID_Produto " +
                "WHERE  PROD.NM_Produto LIKE '" + textoBuscar + "' + '%' " +
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
