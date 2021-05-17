using System;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class ModelCompra
    {


        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Compra { get; set; }
        public int ID_Insumo { get; set; }
        public DateTime DT_Compra { get; set; }
        public double QTDE_InsumoCompra { get; set; }
        public string DS_Mensagem { get; set; }

        public ModelCompra()
        {

        }


        public ModelCompra(int id_compra)
        {
            ID_Compra = id_compra;

            ExcluirCompra();
        }
        public ModelCompra( int id_insumo, DateTime dt_compra, double qtde_insumocompra)
        {
            ID_Insumo = id_insumo;
            DT_Compra = dt_compra;
            QTDE_InsumoCompra = qtde_insumocompra;

            InserirCompra();
        }
        public ModelCompra(int id_compra, int id_insumo, DateTime dt_compra, double qtde_insumocompra)
        {
            ID_Compra = id_compra;
            ID_Insumo = id_insumo;
            DT_Compra = dt_compra;
            QTDE_InsumoCompra = qtde_insumocompra;

            EditarCompra();
        }

        // Método inserir
        public void InserirCompra()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Compra ( " +
                "ID_Insumo, " +
                "DT_Compra, " +
                "QTDE_InsumoCompra)  " +
                "VALUES ( " +
                "'" + ID_Insumo + "', " +
                "'" + DT_Compra + "', " +
                "'" + QTDE_InsumoCompra + "') ",
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
        public void EditarCompra()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Compra SET " +
               "ID_Insumo =  '" + ID_Insumo + "', " +
               "DT_Compra = '" + DT_Compra + "',  " +
               "QTDE_InsumoCompra =  '" + QTDE_InsumoCompra + "'  " +
               "WHERE ID_Compra = '" + ID_Compra + "'",
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
        public void ExcluirCompra()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "DELETE FROM TB_Compra  " +
               "WHERE ID_Compra = '" + ID_Compra + "'",
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
        public DataTable MostrarCompra()
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
                "COM.ID_Compra, " +
                "INS.NM_Insumo, " +
                "COM.ID_Insumo, " +
                "COM.DT_Compra, " +
                "FORMAT(COM.QTDE_InsumoCompra, 'N2') AS QTDE_InsumoCompra " +
                " FROM TB_Compra AS COM " +
                " INNER JOIN TB_Insumo AS INS " +
                " ON COM.ID_Insumo = INS.ID_Insumo " +
                "ORDER BY ID_Compra ASC",
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

        // Método buscar compra por data
        public DataTable BuscarDataCompra(DateTime dt_buscar)
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
                "COM.ID_Compra, " +
                "INS.NM_Insumo, " +
                "COM.ID_Insumo, " +
                "COM.DT_Compra, " +
                "FORMAT(COM.QTDE_InsumoCompra, 'N2') AS QTDE_InsumoCompra " +
                " FROM TB_Compra AS COM " +
                " INNER JOIN TB_Insumo AS INS " +
                " ON COM.ID_Insumo = INS.ID_Insumo " +
               "WHERE  DT_Compra LIKE '" + dt_buscar.ToString("yyyy-MM-dd") + "' + '%'  " +
               "ORDER BY ID_Compra ASC",
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
        // Método buscar compra por nome do insumo
        public DataTable BuscarNomeCompra(string nm_insumo)
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
                "COM.ID_Compra, " +
                "INS.NM_Insumo, " +
                "COM.ID_Insumo, " +
                "COM.DT_Compra, " +
                "FORMAT(COM.QTDE_InsumoCompra, 'N2') AS QTDE_InsumoCompra " +
                " FROM TB_Compra AS COM " +
                " INNER JOIN TB_Insumo AS INS " +
                " ON COM.ID_Insumo = INS.ID_Insumo " +
               "WHERE  INS.NM_Insumo LIKE '" + nm_insumo + "' + '%'  " +
               "ORDER BY ID_Compra ASC",
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
