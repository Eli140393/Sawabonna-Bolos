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
    public class ModelFichaTecnica
    {

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Produto { get; set; }
        public int ID_Insumo { get; set; }
        public double QTDE_Utilizada { get; set; }
        public string DS_Mensagem { get; set; }
        public ModelFichaTecnica()
        {

        }

        public ModelFichaTecnica(int id_produto, int id_insumo)
        {
            ID_Produto = id_produto;
            ID_Insumo = id_insumo;

            ExcluirFichaTecnica();

        }

        public ModelFichaTecnica(string action, int id_produto, int id_insumo, double qtde_utilizada)
        {
            ID_Produto = id_produto;
            ID_Insumo = id_insumo;
            QTDE_Utilizada = qtde_utilizada;

            if (action.Equals("inserir"))
            {
                InserirFichaTecnica();
            }

            if (action.Equals("editar"))
            {
                EditarFichaTecnica();
            }

        }

        public void InserirFichaTecnica()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_FichaTecnica ( " +
                "ID_Produto, " +
                "ID_Insumo, " +
                "QTDE_Utilizada) " +
                "VALUES ( " +
                "'" + ID_Produto + "', " +
                "'" + ID_Insumo + "', " +
                "'" + QTDE_Utilizada.ToString(CultureInfo.GetCultureInfo("en-US")) + "') ",
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

        public void EditarFichaTecnica()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_FichaTecnica SET " +
               "QTDE_Utilizada = '" + QTDE_Utilizada.ToString(CultureInfo.GetCultureInfo("en-US")) + "'  " +
               "WHERE ID_Produto = '" + ID_Produto + "'  " +
               "AND ID_Insumo = '" + ID_Insumo + "'  ",
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

        public void ExcluirFichaTecnica()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_FichaTecnica  " +
               "WHERE ID_Produto = '" + ID_Produto + "'  " +
               "AND ID_Insumo = '" + ID_Insumo + "'  ",
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

        public DataTable MostrarFichaTecnica(int id_produto)
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
                "FTEC.ID_Produto, " +
                "INS.ID_Insumo, " +
                "PROD.NM_Produto,  " +
                "INS.NM_Insumo, " +
                "INS.DS_TipoArmazenamento,  " +
                "FORMAT(FTEC.QTDE_Utilizada, 'N2') AS QTDE_Utilizada " +
                "FROM TB_FichaTecnica AS FTEC  " +
                " INNER JOIN TB_Insumo AS INS  " +
                " ON FTEC.ID_Insumo = INS.ID_Insumo  " +
                " INNER JOIN TB_Produto AS PROD  " +
                " ON FTEC.ID_Produto = PROD.ID_Produto  " +
                " WHERE FTEC.ID_Produto = '" + id_produto + " '  " +
                " ORDER BY FTEC.ID_Produto DESC",
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