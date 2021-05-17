using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Model
{
    public class ModelFuncionario : ModelPessoa
    {

        public int ID_Funcionario { get; set; }
        public string NM_Funcionario { get; set; }
        public string DS_Sexo { get; set; }
        public string NR_CPF { get; set; }
        public DateTime DT_Nascimento { get; set; }
        public string NR_Telefone { get; set; }
        public string DS_Email { get; set; }
        public string NR_CEP { get; set; }
        public string NM_Rua { get; set; }
        public string NR_Casa { get; set; }
        public string DS_Complemento { get; set; }
        public string NM_Bairro { get; set; }
        public string NM_Cidade { get; set; }
        public string DS_UF { get; set; }
        public string DS_Cargo { get; set; }
        public double VL_Salario { get; set; }
        public DateTime DT_Admissao { get; set; }

        public string DS_Mensagem { get; set; }

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;
        public ModelFuncionario()
        {

        }

        public ModelFuncionario(string action, int id_funcionario)
        {
            ID_Funcionario = id_funcionario;

            if(action == "excluir")
            {
                ExcluirFuncionario();
            }
            else if(action == "ativar")
            {
                AtivarFuncionario();
            }


        }

        public ModelFuncionario(int id_funcionario, string nm_funcionario, string ds_sexo, string nr_cpf, DateTime dt_nascimento,
            string nr_telefone, string ds_email, string nr_cep, string nm_rua, string nr_casa, string nm_bairro, string ds_complemento,
            string nm_cidade, string ds_uf, string ds_cargo, double vl_salario, DateTime dt_admissao)
        {
            ID_Funcionario = id_funcionario;
            NM_Funcionario = nm_funcionario;
            DS_Sexo = ds_sexo;
            NR_CPF = nr_cpf;
            DT_Nascimento = dt_nascimento;
            NR_Telefone = nr_telefone;
            DS_Email = ds_email;
            NR_CEP = nr_cep;
            NM_Rua = nm_rua;
            NR_Casa = nr_casa;
            NM_Bairro = nm_bairro;
            DS_Complemento = ds_complemento;
            NM_Cidade = nm_cidade;
            DS_UF = ds_uf;
            DS_Cargo = ds_cargo;
            VL_Salario = vl_salario;
            DT_Admissao = dt_admissao;

            EditarFuncionario();
        }

        public ModelFuncionario(string nm_funcionario, string ds_sexo, string nr_cpf, DateTime dt_nascimento,
         string nr_telefone, string ds_email, string nr_cep, string nm_rua, string nr_casa, string nm_bairro, string ds_complemento,
         string nm_cidade, string ds_uf, string ds_cargo, double vl_salario, DateTime dt_admissao)
        {
            NM_Funcionario = nm_funcionario;
            DS_Sexo = ds_sexo;
            NR_CPF = nr_cpf;
            DT_Nascimento = dt_nascimento;
            NR_Telefone = nr_telefone;
            DS_Email = ds_email;
            NR_CEP = nr_cep;
            NM_Rua = nm_rua;
            NR_Casa = nr_casa;
            NM_Bairro = nm_bairro;
            DS_Complemento = ds_complemento;
            NM_Cidade = nm_cidade;
            DS_UF = ds_uf;
            DS_Cargo = ds_cargo;
            VL_Salario = vl_salario;
            DT_Admissao = dt_admissao;

            InserirFuncionario();
        }

        // Método inserir
        public void InserirFuncionario()
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand(
                "INSERT INTO TB_Funcionario ( " +
                "NM_Funcionario, " +
                "DS_Sexo, " +
                "DT_Nascimento, " +
                "NR_CPF, " +
                "NR_Telefone, " +
                "DS_Email, " +
                "NR_CEP, " +
                "NM_Rua, " +
                "NR_Casa, " +
                "NM_Bairro, " +
                "DS_Complemento, " +
                "NM_Cidade, " +
                "DS_UF, " +
                "DS_Cargo, " +
                "VL_Salario, " +
                "DT_Admissao, " +
                "Ativo) " +
                "VALUES ( " +
                "'" + NM_Funcionario + "', " +
                "'" + DS_Sexo + "', " +
                "'" + DT_Nascimento + "', " +
                "REPLACE( REPLACE('" + NR_CPF + "', '.' ,'' ), '-', '' ), " +
                "REPLACE( REPLACE( REPLACE('" + NR_Telefone + "', '(' ,'' ), ')', '' ), '-', '' ), " +
                "'" + DS_Email + "', " +
                "'" + NR_CEP + "', " +
                "'" + NM_Rua + "', " +
                "'" + NR_Casa + "', " +
                "'" + NM_Bairro + "', " +
                "'" + DS_Complemento + "', " +
                "'" + NM_Cidade + "', " +
                "'" + DS_UF + "', " +
                "'" + DS_Cargo + "', " +
                "'" + VL_Salario.ToString(CultureInfo.GetCultureInfo("en-US")) + "',  " +
                "'" + DT_Admissao + "',  " +
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
        public void EditarFuncionario()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Funcionario SET " +
               "NM_Funcionario =  '" + NM_Funcionario + "',  " +
               "DT_Nascimento = '" + DT_Nascimento + "',  " +
               "NR_CPF = '" + NR_CPF + "',  " +
               "NR_Telefone = '" + NR_Telefone + "',  " +
               "DS_Email = '" + DS_Email + "',  " +
               "NR_CEP =  '" + NR_CEP + "',  " +
               "NM_Rua = '" + NM_Rua + "',  " +
               "NR_Casa = '" + NR_Casa + "',  " +
               "NM_Bairro = '" + NM_Bairro + "',  " +
               "DS_Complemento = '" + DS_Complemento + "',  " +
               "NM_Cidade = '" + NM_Cidade + "',   " +
               "DS_UF = '" + DS_UF + "',  " +
               "DS_Cargo =  '" + DS_Cargo + "',  " +
               "VL_Salario = '" + VL_Salario.ToString(CultureInfo.GetCultureInfo("en-US")) + "',  " +
               "DT_Admissao = '" + DT_Admissao + "'  " +
               "WHERE ID_Funcionario = '" + ID_Funcionario + "'",
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
        public void ExcluirFuncionario()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Funcionario SET " +
               "DT_Demissao =  GETDATE(),  " +
               "Ativo = 0 " +
               "WHERE ID_Funcionario = '" + ID_Funcionario + "'",
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
        public void AtivarFuncionario()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Funcionario SET " +
               "DT_Demissao =  NULL ,  " +
               "DT_Admissao = GETDATE(), " +
               "Ativo = 1 " +
               "WHERE ID_Funcionario = '" + ID_Funcionario + "'",
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
        public DataTable MostrarFuncionario(int status)
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
                "ID_Funcionario, " +
                "NM_Funcionario, " +
                "DS_Sexo, " +
                "NR_CPF,  " +
                "DT_Nascimento, " +
                "NR_Telefone,  " +
                "DS_Email,  " +
                "DS_Cargo, " +
                "FORMAT(VL_Salario, 'N2') AS VL_Salario,  " +
                "DT_Admissao, " +
                "NM_Rua, " +
                "NR_Casa,  " +
                "DS_Complemento, " +
                "NM_Bairro,  " +
                "NR_CEP,  " +
                "NM_Cidade, " +
                "DS_UF,  " +
                "DT_Demissao " +
                "FROM TB_Funcionario " +
                "WHERE Ativo = '" + status + "' " +
                " ORDER BY ID_Funcionario DESC ",
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

        // Metodo buscar funcionário por nome
        public DataTable BuscarNomeFuncionario(int status, string texto)
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
                "ID_Funcionario, " +
                "NM_Funcionario, " +
                "DS_Sexo, " +
                "NR_CPF,  " +
                "DT_Nascimento, " +
                "NR_Telefone,  " +
                "DS_Email,  " +
                "DS_Cargo, " +
                " VL_Salario, " +
                "DT_Admissao, " +
                "NM_Rua, " +
                "NR_Casa,  " +
                "DS_Complemento, " +
                "NM_Bairro,  " +
                "NR_CEP,  " +
                "NM_Cidade, " +
                "DS_UF,  " +
                "DT_Demissao " +
                "FROM TB_Funcionario " +
                "WHERE Ativo = '" + status + "' " +
                "AND  NM_Funcionario LIKE '" + texto + "' + '%' " +
                "ORDER BY ID_Funcionario DESC ",
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

        // Método buscar funcionário por cpf
        public DataTable BuscarCPFFuncionario(int status, string texto)
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
                "ID_Funcionario, " +
                "NM_Funcionario, " +
                "DS_Sexo, " +
                "NR_CPF,  " +
                "DT_Nascimento, " +
                "NR_Telefone,  " +
                "DS_Email,  " +
                "DS_Cargo, " +
                "VL_Salario, " +
                "DT_Admissao, " +
                "NM_Rua, " +
                "NR_Casa,  " +
                "DS_Complemento, " +
                "NM_Bairro,  " +
                "NR_CEP,  " +
                "NM_Cidade, " +
                "DS_UF,  " +
                "DT_Demissao " +
                "FROM TB_Funcionario " +
                "WHERE Ativo = '" + status + "' " +
                "AND  NR_CPF LIKE '" + texto + "' + '%' " +
                "ORDER BY ID_Funcionario DESC ",
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
