using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelInsumo
    {
    


        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Insumo { get; set; }
        public string NM_Insumo { get; set; }
        public string DS_TipoArmazenamento { get; set; }
        public double PR_Insumo { get; set; }
        public string DS_Mensagem { get; set; }

        public ModelInsumo()
        {

        }


        public ModelInsumo(int id_insumo)
        {
            ID_Insumo = id_insumo;

            ExcluirInsumo();
        }
        public ModelInsumo( string nm_insumo, string ds_tipoArmazenamento, double pr_insumo)
        {
            NM_Insumo = nm_insumo;
            DS_TipoArmazenamento = ds_tipoArmazenamento;
            PR_Insumo = pr_insumo;

            InserirInsumo();
        }
        public ModelInsumo(int id_insumo, string nm_insumo, string ds_tipoArmazenamento, double pr_insumo)
        {
            ID_Insumo = id_insumo;
            NM_Insumo = nm_insumo;
            DS_TipoArmazenamento = ds_tipoArmazenamento;
            PR_Insumo = pr_insumo;

            EditarInsumo();
        }


        // Método inserir
        public void InserirInsumo()
        {

            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Insumo ( " +
                "NM_Insumo, " +
                "DS_TipoArmazenamento, " +
                "PR_Insumo) " +
                "VALUES ( " +
                "'" + NM_Insumo + "', " +
                "'" + DS_TipoArmazenamento + "', " +
                "'" + PR_Insumo + "') ",
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
        public void EditarInsumo()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Insumo SET " +
               "NM_Insumo =  '" + NM_Insumo + "', " +
               "DS_TipoArmazenamento = '" + DS_TipoArmazenamento + "',  " +
               "PR_Insumo =  '" + PR_Insumo + "' " +
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
        public void ExcluirInsumo()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_Insumo  " +
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
        public DataTable MostrarInsumo()
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
                "ID_Insumo, " +
                "NM_Insumo, " +
                "DS_TipoArmazenamento, " +
                "PR_Insumo " +
                " FROM TB_Insumo " +
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

        // Método buscar insumo por nome
        public DataTable BuscarNomeInsumo(string textoBuscar)
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
                "ID_Insumo, " +
                "NM_Insumo, " +
                "DS_TipoArmazenamento, " +
                "FORMAT(PR_Insumo, 'N2') AS PR_Insumo " +
                "FROM TB_Insumo " +
                "WHERE  NM_Insumo LIKE '" + textoBuscar + "' + '%' " +
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
