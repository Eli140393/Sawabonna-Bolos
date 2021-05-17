using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelLogin
    {

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;



        public int ID_Login { get; set; }
        public int ID_Funcionario { get; set; }
        public int ID_NivelAcesso { get; set; }
        public string DS_Usuario { get; set; }
        public string DS_Senha { get; set; }
        public string DS_Mensagem { get; set; }
        public ModelLogin()
        {

        }

        public ModelLogin(string action, int id, int id_nivelacesso, string ds_usuario, string ds_senha)
        {
            ID_Login = id;
            ID_NivelAcesso = id_nivelacesso;
            DS_Usuario = ds_usuario;
            DS_Senha = ds_senha;

            if (action.Equals("editar"))
            {
                EditarLogin();

            }
            if (action.Equals("inserir"))
            {
                InserirLogin();
            }


        }
      
        public ModelLogin(string usuario, string senha)
        {
            DS_Usuario = usuario;
            DS_Senha = senha;

            ValidaLogin();
        }
        public ModelLogin(string action, int id_login) 
        {
            int acao;
            ID_Login = id_login;

            if(action == "excluir")
            {
                acao = 0;
                AlterarLogin(acao);

            }

            else if (action == "ativar")
            {
                acao = 1;
                AlterarLogin(acao);

            }

            else if (action == "editar")
            {
                EditarRegistroLogin();

            }



        }
        public ModelLogin (int id_login)
        {
            ID_Login = id_login;

            InserirRegistroLogin();
        }

        public void InserirLogin()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Login ( " +
                "ID_Funcionario, " +
                "ID_NivelAcesso, " +
                "DS_Usuario, " +
                "DS_Senha, " +
                "Ativo) " +
                "VALUES ( " +
                "'" + ID_Funcionario + "', " +
                "'" + ID_NivelAcesso + "', " +
                "'" + DS_Usuario + "', " +
                "'" + DS_Senha + "', " +
                " 1 ) ",
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

        public void EditarLogin()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Login SET " +
               "ID_NivelAcesso = '" + ID_NivelAcesso + "',  " +
               "DS_Usuario = '" + DS_Usuario + "', " +
               "DS_Senha = '" + DS_Senha + "'  " +
               "WHERE ID_Login = '" + ID_Login + "'  ",
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


        public void AlterarLogin(int action)
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE  TB_Login SET  " +
                "Ativo = '" + action + "'  " +
               "WHERE ID_Login = '" + ID_Login + "'  ",
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


        public DataTable MostrarLogin(int status)
        {

            DS_Mensagem = "";
            SqlCon = new SqlConnection();
            DataTable dataTable = new DataTable();


            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                 "SELECT  " +
                 "LGN.ID_Login,  " +
                 "LGN.ID_Funcionario, " +
                 "FUN.NM_Funcionario, " +
                 "LGN.ID_NivelAcesso,  " +
                 "NVL.DS_NivelAcesso,  " +
                 "LGN.DS_Usuario, " +
                 "LGN.DS_Senha  " +
                 "FROM TB_Login AS LGN " +
                 "INNER JOIN TB_Funcionario AS FUN " +
                 "ON LGN.ID_Funcionario = FUN.ID_Funcionario  " +
                 "INNER JOIN TB_NivelAcesso AS NVL " +
                 "ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso " +
                 "WHERE LGN.Ativo =  '"  + status + "' " +
                 " ORDER BY  LGN.ID_Login ASC ",
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

        public DataTable BuscarNomeFuncionarioLogin(int status, string texto)
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
                 "LGN.ID_Login,  " +
                 "LGN.ID_Funcionario, " +
                 "FUN.NM_Funcionario, " +
                 "LGN.ID_NivelAcesso,  " +
                 "NVL.DS_NivelAcesso,  " +
                 "LGN.DS_Usuario, " +
                 "LGN.DS_Senha  " +
                 "FROM TB_Login AS LGN " +
                 "INNER JOIN TB_Funcionario AS FUN " +
                 "ON LGN.ID_Funcionario = FUN.ID_Funcionario  " +
                 "INNER JOIN TB_NivelAcesso AS NVL " +
                 "ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso " +
                 "WHERE LGN.Ativo = '" + status + "'  "+
                 "AND FUN.NM_Funcionario LIKE '" + texto + "' + '%'  " +
                 "ORDER BY ID_Login DESC ", SqlCon);
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

        public void InserirRegistroLogin()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
               "UPDATE TB_RegistroLogin SET " +
               "ID_Login = '" + ID_Login + "',  " +
               "DT_RegistroLogin =  GETDATE()  " +
               "WHERE ID_Login != '" + ID_Login + "'  ",


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

        public void EditarRegistroLogin()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_RegistroLogin SET " +
               "DT_RegistroLogin =  GETDATE()  " +
               "WHERE ID_Login = '" + ID_Login + "'  " +
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

        public DataTable MostrarRegistroLogin()
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
                "RLGN.ID_Login, " +
                "LGN.ID_Funcionario, " +
                "FUN.NM_Funcionario,  " +
                "LGN.ID_NivelAcesso, " +
                "NVL.DS_NivelAcesso, " +
                "RLGN.DT_RegistroLogin " +
                "FROM TB_RegistroLogin AS RLGN  " +
                "INNER JOIN TB_Login AS LGN  " +
                "ON RLGN.ID_Login = LGN.ID_Login  " +
                " INNER JOIN TB_Funcionario AS FUN " +
                "ON LGN.ID_Funcionario = FUN.ID_Funcionario  " +
                "INNER JOIN TB_NivelAcesso AS NVL  " +
                " ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso " +
                "ORDER BY RLGN.DT_RegistroLogin DESC",
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

        public DataTable ValidaLogin()
        {
            DS_Mensagem = "";
            DataTable dataTable = new DataTable();

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "SELECT   " +
               "LGN.ID_Login, " +
               "LGN.ID_Funcionario, " +
               "FUN.NM_Funcionario, " +
               "LGN.ID_NivelAcesso, " +
               "NVL.DS_NivelAcesso, " +
               "LGN.DS_Usuario,  " +
               "LGN.DS_Senha " +
               "FROM TB_Login AS LGN " +
               "INNER JOIN TB_Funcionario AS FUN " +
               "ON LGN.ID_Funcionario = FUN.ID_Funcionario " +
               "INNER JOIN TB_NivelAcesso AS NVL " +
               "ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso " +
               "WHERE LGN.Ativo =  1 " +
               "AND DS_Usuario = '" + DS_Usuario + "'  " +
               "AND DS_Senha = '" + DS_Senha + "'  " ,
                SqlCon);
                sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
                if (dataTable.Rows.Count > 0)
                {
                    DS_Mensagem = "OK";

                }
                else
                {
                    DS_Mensagem = "Login Invalido";

                }
              
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

        public DataTable ValidaLogin(string ds_usuario, string ds_senha)
        {
            DS_Mensagem = "";
            DataTable dataTable = new DataTable();

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "SELECT   " +
               "LGN.ID_Login, " +
               "LGN.ID_Funcionario, " +
               "FUN.NM_Funcionario, " +
               "LGN.ID_NivelAcesso, " +
               "NVL.DS_NivelAcesso, " +
               "LGN.DS_Usuario,  " +
               "LGN.DS_Senha " +
               "FROM TB_Login AS LGN " +
               "INNER JOIN TB_Funcionario AS FUN " +
               "ON LGN.ID_Funcionario = FUN.ID_Funcionario " +
               "INNER JOIN TB_NivelAcesso AS NVL " +
               "ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso " +
               "WHERE LGN.Ativo =  1 " +
               "AND DS_Usuario = '" + ds_usuario + "'  " +
               "AND DS_Senha = '" + ds_senha + "'  ",
                SqlCon);
                sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
                if (dataTable.Rows.Count > 1)
                {
                    DS_Mensagem = "OK";

                }
                else
                {
                    DS_Mensagem = "Login Invalido";

                }

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
