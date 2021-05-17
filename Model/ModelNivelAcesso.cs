using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelNivelAcesso
    {
        public string DS_Mensagem { get; set; }

        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public ModelNivelAcesso()
        {

        }

        public DataTable MostrarNivelAcesso()
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
                 "ID_NivelAcesso,  " +
                 "DS_NivelAcesso   " +
                 "FROM TB_NivelAcesso ", SqlCon);
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
