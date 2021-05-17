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
    public class ModelEstoque
    {

        public int ID_Insumo { get; set; }
        public double QTDE_Estoque { get; set; }
        public string DS_Mensagem { get; set; }

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public ModelEstoque()
        {

        }


        public ModelEstoque(int id_insumo)
        {
            ID_Insumo = id_insumo;

            ExcluirEstoque();
        }
        public ModelEstoque(string action, int id_insumo, double qtde_estoque)
        {
            ID_Insumo = id_insumo;
            QTDE_Estoque = qtde_estoque;

            if(action.Equals("adicionar"))
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
                "INSERT INTO TB_Estoque ( " +
                "ID_Insumo, " +
                "QTDE_Estoque) " +
                "VALUES ( " +
                "'" + ID_Insumo + "', " +
                "'" + QTDE_Estoque.ToString(CultureInfo.GetCultureInfo("en-US")) + "'" ,
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
               "UPDATE TB_Estoque SET " +
               "QTDE_Estoque +=  '" + QTDE_Estoque.ToString(CultureInfo.GetCultureInfo("en-US")) + "'" +
               "WHERE ID_Insumo = '" + ID_Insumo + "'",
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
               "UPDATE TB_Estoque SET " +
               "QTDE_Estoque -=  '" + QTDE_Estoque.ToString(CultureInfo.GetCultureInfo("en-US")) + "'" +
               "WHERE ID_Insumo = '" + ID_Insumo + "'",
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
               "DELETE FROM TB_Estoque  " +
               "WHERE ID_Insumo = '" + ID_Insumo + "'",
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
                "EST.ID_Insumo, " +
                "INS.NM_Insumo, " +
                "FORMAT(EST.QTDE_Estoque, 'N2') AS QTDE_Estoque " +
                "FROM TB_Estoque AS EST " +
                " INNER JOIN TB_Insumo AS INS " +
                " ON EST.ID_Insumo = INS.ID_Insumo " +
                "ORDER BY ID_Insumo DESC",
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

        public DataTable BuscarNomeInsumoEstoque(string textoBuscar)
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
                "EST.ID_Insumo, " +
                "INS.NM_Insumo, " +
                "FORMAT(EST.QTDE_Estoque, 'N2') AS QTDE_Estoque " +
                "FROM TB_Estoque AS EST " +
                " INNER JOIN TB_Insumo AS INS " +
                " ON EST.ID_Insumo = INS.ID_Insumo  " +
                "WHERE  INS.NM_Insumo LIKE '" + textoBuscar + "' + '%' " +
                "ORDER BY ID_Insumo DESC",
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