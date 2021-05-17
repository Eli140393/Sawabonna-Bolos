using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Model
{
    public class ModelCliente
    {

        public int ID_Cliente { get; set; }
        public string NM_Cliente { get; set; }
        public string NR_CPF { get; set; }
        public string NR_Telefone { get; set; }
        public string DS_Email { get; set; }
        public string DS_Sexo { get; set; }

        public DateTime DT_Nascimento { get; set; }
        public string DS_Mensagem { get; set; }


        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;
        public ModelCliente()
        {

        }

        public ModelCliente(int id, string action)
        {
            ID_Cliente = id;

            if (action.Equals("excluir"))
            {
                ExcluirCliente();
            }
            else if (action.Equals("ativar"))
            {
                AtivarCLiente();
            }
        }


        public ModelCliente(string nome, string cpf, string telefone, string email, string sexo, DateTime nascimento)
        {
            NM_Cliente = nome;
            NR_CPF = cpf;
            NR_Telefone = telefone;
            DS_Email = email;
            DS_Sexo = sexo;
            DT_Nascimento = nascimento;
            InserirCliente();
        }


        //Método edtiar
        public ModelCliente(int id, string nome, string cpf, string telefone, string email, string sexo, DateTime nascimento)
        {
            ID_Cliente = id;
            NM_Cliente = nome;
            NR_CPF = cpf;
            NR_Telefone = telefone;
            DS_Email = email;
            DS_Sexo = sexo;
            DT_Nascimento = nascimento;
            EditarCliente();


        }



        // Método inserir
        public void InserirCliente()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Cliente ( " +
                "NM_Cliente, " +
                "NR_CPF, " +
                "NR_Telefone, " +
                "DS_Email, " +
                "DS_Sexo, " +
                "DT_Nascimento, " +
                "Ativo) " +
                "VALUES ( " +
                "'" + NM_Cliente + "', " +
                "REPLACE( REPLACE('" + NR_CPF + "', '.' ,'' ), '-', '' ), " +
                "REPLACE( REPLACE( REPLACE('" + NR_Telefone + "', '(' ,'' ), ')', '' ), '-', '' ), " +
                "'" + DS_Email + "', " +
                "'" + DS_Sexo + "', " +
                "'" + DT_Nascimento + "', " +
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
        public void EditarCliente()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Cliente SET " +
               "NM_Cliente =  '" + NM_Cliente + "', " +
               "NR_CPF = '" + NR_CPF + "', " +
               "NR_Telefone = '" + NR_Telefone + "', " +
               "DS_Email = '" + DS_Email + "', " +
               "DS_Sexo = '" + DS_Sexo + "', " +
               "DT_Nascimento = '" + DT_Nascimento + "' " +
               "WHERE ID_Cliente = '" + ID_Cliente + "'",
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
        public void ExcluirCliente()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Cliente SET " +
               "Ativo = 0 " +
               "WHERE ID_Cliente = '" + ID_Cliente + "'",
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
        private void AtivarCLiente()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Cliente SET " +
               "Ativo = 1 " +
               "WHERE ID_Cliente = '" + ID_Cliente + "'",
               SqlCon);
                int result = sqlCommand.ExecuteNonQuery();
                DS_Mensagem = result > 0 ? "OK" : "Erro ao ativar";
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
        public DataTable MostrarCliente(int status)
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
                "ID_Cliente, " +
                "NM_Cliente, " +
                "NR_CPF, " +
                "NR_Telefone, " +
                "DS_Email, " +
                "DS_Sexo, " +
                "DT_Nascimento " +
                "FROM TB_Cliente " +
                "WHERE Ativo = '" + status + "' " +
                " ORDER BY ID_Cliente DESC ",
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

        // Método buscar cliente por nome
        public DataTable BuscarNomeCliente(int status, string texto)
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
                "ID_Cliente, " +
                "NM_Cliente, " +
                "NR_CPF, " +
                "NR_Telefone, " +
                "DS_Email, " +
                "DS_Sexo, " +
                "DT_Nascimento " +
                "FROM TB_Cliente " +
                "WHERE Ativo = '" + status + "' " +
                "AND  NM_Cliente LIKE '" + texto + "' + '%' " +
               "ORDER BY ID_Cliente ", SqlCon);
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

        // Metodo buscar cliente por cpf
        public DataTable BuscarCPFCliente(int status, string texto)
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
                "ID_Cliente, " +
                "NM_Cliente, " +
                "NR_CPF, " +
                "NR_Telefone, " +
                "DS_Email, " +
                "DS_Sexo, " +
                "DT_Nascimento " +
                "FROM TB_Cliente " +
                "WHERE Ativo = '" + status + "' " +
                "AND  NR_CPF LIKE '" + texto + "' + '%' " +
               "ORDER BY ID_Cliente ", SqlCon);
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
