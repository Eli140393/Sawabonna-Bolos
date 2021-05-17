using System;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class ModelCategoria
    {
      
        public int ID_Categoria { get; set; }
        public string NM_Categoria { get; set; }
        public string DS_Categoria { get; set; }
        public string DS_Mensagem { get; set; }


        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;
        public ModelCategoria()
        {

        }

        public ModelCategoria(string action, int id)
        {
            ID_Categoria = id;

            if (action.Equals("excluir"))
            {
                ExcluirCategoria();

            }

            if (action.Equals("ativar"))
            {
                AtivarCategoria();

            }

        }
        public ModelCategoria( string nome, string descricao)
        {
            NM_Categoria = nome;
            DS_Categoria = descricao;

            InserirCategoria();

        }

        public ModelCategoria(int id, string nome, string descricao)
        {
            ID_Categoria = id;
            NM_Categoria = nome;
            DS_Categoria = descricao;

            EditarCategoria();

        }

       

        // Método inserir
        public void InserirCategoria()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Categoria ( " +
                "NM_Categoria, " +
                "DS_Categoria, " +
                "Ativo ) " +
                "VALUES ( " +
                "'" + NM_Categoria + "', " +
                "'" + DS_Categoria + "', " +
                "1)",
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
        public void EditarCategoria()
        {

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Categoria SET " +
               "NM_Categoria =  '" + NM_Categoria + "', " +
               "DS_Categoria = '" + DS_Categoria + "' " +
               "WHERE ID_Categoria = '" + ID_Categoria + "'",
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
        public void ExcluirCategoria()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE  TB_Categoria  SET " +
               " Ativo = 0 " +
               "WHERE ID_Categoria = '" + ID_Categoria + "'",
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

        public void AtivarCategoria()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE  TB_Categoria  SET " +
               " Ativo = 1 " +
               "WHERE ID_Categoria = '" + ID_Categoria + "'",
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
        public DataTable MostrarCategoria(int status)
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
                "ID_Categoria, " +
                "NM_Categoria, " +
                "DS_Categoria  " +
                "FROM TB_Categoria  " +
                "WHERE Ativo = '" + status + "' " +
                "ORDER BY ID_Categoria ASC",
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

        // Método buscar categoria por nome
        public DataTable BuscarNomeCategoria(string texto)
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
                "ID_Categoria, " +
                "NM_Categoria, " +
                "DS_Categoria  " +
                "FROM TB_Categoria " +
                "WHERE NM_Categoria LIKE '" + texto + "' + '%' " +
               "ORDER BY ID_Categoria ", SqlCon);
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
