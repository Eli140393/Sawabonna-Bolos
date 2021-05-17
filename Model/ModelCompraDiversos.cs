using System;
using System.Data;
using System.Data.SqlClient;


namespace Model
{
    public class ModelCompraDiversos
    {

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_CompraDiversos { get; set; }
        public int ID_Produto { get; set; }
        public DateTime DT_Compra { get; set; }
        public int QTDE_Compra { get; set; }
        public string DS_Mensagem { get; set; }

        public ModelCompraDiversos()
        {

        }


        public ModelCompraDiversos(int id_compraDiversos)
        {
            ID_CompraDiversos = id_compraDiversos;

            ExcluirCompra();
        }
        public ModelCompraDiversos(int id_produto, DateTime dt_compra, int qtde_compra)
        {
            ID_Produto = id_produto;
            DT_Compra = dt_compra;
            QTDE_Compra = qtde_compra;

            InserirCompra();
        }
        public ModelCompraDiversos(int id_compraDiversos, int id_produto, DateTime dt_compra, int qtde_compra)
        {
            ID_CompraDiversos = id_compraDiversos;
            ID_Produto = id_produto;
            DT_Compra = dt_compra;
            QTDE_Compra = qtde_compra;

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
                "INSERT INTO TB_CompraDiversos ( " +
                "ID_Produto, " +
                "DT_Compra, " +
                "QTDE_Compra)  " +
                "VALUES ( " +
                "'" + ID_Produto + "', " +
                "'" + DT_Compra + "', " +
                "'" + QTDE_Compra + "') ",
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
               "UPDATE TB_CompraDiversos SET " +
               "ID_Produto =  '" + ID_Produto + "', " +
               "DT_Compra = '" + DT_Compra + "',  " +
               "QTDE_Compra =  '" + QTDE_Compra + "'  " +
               "WHERE ID_CompraDiversos = '" + ID_CompraDiversos + "'",
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
               "DELETE FROM TB_CompraDiversos  " +
               "WHERE ID_CompraDiversos = '" + ID_CompraDiversos + "'",
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
                "COM.ID_CompraDiversos, " +
                "PROD.NM_Produto, " +
                "COM.ID_Produto, " +
                "COM.DT_Compra, " +
                "COM.QTDE_Compra  " +
                " FROM TB_CompraDiversos AS COM " +
                " INNER JOIN TB_Produto AS PROD " +
                " ON COM.ID_Produto = PROD.ID_Produto " +
                "ORDER BY ID_CompraDiversos ASC",
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
                "COM.ID_CompraDiversos, " +
                "PROD.NM_Produto, " +
                "COM.ID_Produto, " +
                "COM.DT_Compra, " +
                "COM.QTDE_Compra,  " +
                " FROM TB_CompraDiversos AS COM " +
                " INNER JOIN TB_PRoduto AS PROD " +
                " ON COM.ID_Produto = PROD.ID_Produto " +
               "WHERE  DT_Compra LIKE '" + dt_buscar.ToString("yyyy-MM-dd") + "' + '%'  " +
               "ORDER BY ID_CompraDiversos ASC",
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
        public DataTable BuscarNomeCompra(string nm_produto)
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
                "COM.ID_CompraDiversos, " +
                "PROD.NM_Produto, " +
                "COM.ID_Produto, " +
                "COM.DT_Compra, " +
                "COM.QTDE_Compra,  " +
                " FROM TB_CompraDiversos AS COM " +
                " INNER JOIN TB_PRoduto AS PROD " +
                " ON COM.ID_Produto = PROD.ID_Produto " +
               "WHERE  PROD.NM_Produto LIKE '" + nm_produto + "' + '%'  " +
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

