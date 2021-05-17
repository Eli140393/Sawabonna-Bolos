using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelEstoqueDiversos
    {

        public int ID_Produto { get; set; }
        public int QTDE_Estoque { get; set; }
        public string DS_Mensagem { get; set; }

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public ModelEstoqueDiversos()
        {

        }


        public ModelEstoqueDiversos(int id_produto)
        {
            ID_Produto = id_produto;

            ExcluirEstoque();
        }
        public ModelEstoqueDiversos(string action, int id_produto, int qtde_estoque)
        {
            ID_Produto = id_produto;
            QTDE_Estoque = qtde_estoque;

            if (action.Equals("adicionar"))
            {
                InserirEstoque();

            }

            if (action.Equals("baixa"))
            {
                BaixaEstoque();

            }
            if (action.Equals("entrada"))
            {
                EditarEstoque();

            }

        }



        // Método inserir
        public void InserirEstoque()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_EstoqueDiversos ( " +
                "ID_Produto, " +
                "QTDE_Estoque) " +
                "VALUES ( " +
                "'" + ID_Produto + "', " +
                "'" + QTDE_Estoque +  "' )" ,
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

        public void EditarEstoque()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_EstoqueDiversos SET " +
               "QTDE_Estoque +=  '" + QTDE_Estoque + "' " +
               "WHERE ID_Produto = '" + ID_Produto + "'",
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

        public void BaixaEstoque()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_EstoqueDiversos SET " +
               "QTDE_Estoque -=  '" + QTDE_Estoque + "' " +
               "WHERE ID_Produto = '" + ID_Produto + "'",
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
        public void ExcluirEstoque()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_EstoqueDiversos  " +
               "WHERE ID_Produto = '" + ID_Produto + "'",
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

        // Método mostrar
        public DataTable MostrarEstoque()
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
                "EST.ID_Produto, " +
                "PROD.NM_Produto, " +
                "EST.QTDE_Estoque " +
                "FROM TB_EstoqueDiversos AS EST " +
                " INNER JOIN TB_Produto AS PROD " +
                " ON EST.ID_Produto = PROD.ID_Produto " +
                "ORDER BY EST.ID_Produto DESC",
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

        public DataTable BuscarNomeProdutoEstoque(string textoBuscar)
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
                "EST.ID_Produto, " +
                "PROD.NM_Produto, " +
                "EST.QTDE_Estoque " +
                "FROM TB_EstoqueDiversos AS EST " +
                " INNER JOIN TB_Produto AS PROD " +
                " ON EST.ID_Produto = PROD.ID_Produto " +
                "WHERE  PROD.NM_Produto LIKE '" + textoBuscar + "' + '%' " +
                "ORDER BY EST.ID_Produto DESC",
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

