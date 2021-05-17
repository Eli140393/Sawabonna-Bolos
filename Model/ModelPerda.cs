using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelPerda
    {


        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Perda { get; set; }

        public int ID_Insumo { get; set; }
        public double QTDE_Perdida { get; set; }
        public string DS_Perda { get; set; }
        public DateTime DT_Perda { get; set; }
        public string DS_Mensagem { get; set; }

        public ModelPerda()
        {

        }


        public ModelPerda(int id_perda, int id_insumo)
        {
            ID_Perda = id_insumo;
            ID_Insumo = id_insumo;

            ExcluirPerda();
        }

        public ModelPerda(int id_insumo, double qtde_perda, string ds_perda)
        {
            ID_Insumo = id_insumo;
            DS_Perda = ds_perda;
            QTDE_Perdida = qtde_perda;
            DT_Perda = DateTime.Now;

            InserirPerda();
        }


        // Método inserir
        public void InserirPerda()
        {

            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Perda ( " +
                "ID_Insumo, " +
                "QTDE_Perdida, " +
                "DS_Perda, " +
                "DT_Perda) " +
                "VALUES ( " +
                "'" + ID_Insumo + "', " +
                "'" + QTDE_Perdida + "', " +
                "'" + DS_Perda + "', " +
                "'" + DT_Perda + "') ",
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



        // Método excluir
        public void ExcluirPerda()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_Perda  " +
               "WHERE ID_Perda = '" + ID_Perda + "' " +
               "AND  ID_Insumo = '" + ID_Insumo + "'" ,
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
        public DataTable MostrarPerda()
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
                "PER.ID_Perda, " +
                "PER.ID_Insumo, " +
                "INS.NM_Insumo, " +
                "FORMAT(PER.QTDE_Perdida, 'N2') AS QTDE_Perdida, " +
                "PER.DS_Perda, " +
                "PER.DT_Perda  " +
                "FROM TB_Perda AS PER  " +
                "INNER JOIN TB_Insumo AS INS " +
                "ON PER.ID_Insumo = INS.ID_Insumo  " +
                "ORDER BY ID_Perda DESC",
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

        // Método buscar insumo por nome
        public DataTable BuscarPerdaNome(string textoBuscar)
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
                "PER.ID_Perda, " +
                "INS.NM_Insumo, " +
                "FORMAT(PER.QTDE_Perdida, 'N2') AS QTDE_Perdida, " +
                "PER.DS_Perda, " +
                "PER.DT_Perda  " +
                "FROM TB_Perda AS PER  " +
                "INNER JOIN TB_Insumo AS INS " +
                "ON PER.ID_Insumo = INS.ID_Insumo  " +
                "WHERE  NM_Insumo LIKE '" + textoBuscar + "' + '%'  " +
                "ORDER BY ID_Perda DESC" ,
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

        public DataTable BuscarPerdaData(DateTime textoBuscar)
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
                "PER.ID_Perda, " +
                "PER.ID_Insumo, " +
                "INS.NM_Insumo, " +
                "FORMAT(PER.QTDE_Perdida, 'N2') AS QTDE_Perdida, " +
                "PER.DS_Perda, " +
                "PER.DT_Perda " +
                "FROM TB_Perda AS PER " +
                "INNER JOIN TB_Insumo AS INS " +
                "ON PER.ID_Insumo = INS.ID_Insumo  " +
                "WHERE  DT_Perda LIKE '" + textoBuscar + "' + '%' " +
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
