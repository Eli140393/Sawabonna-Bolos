using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

namespace Model
{
    public class ModelProduto
    {

        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;

        public int ID_Produto { get; set; }
        public int ID_Categoria { get; set; }
        public string NM_Produto { get; set; }
        public double PR_Unitario { get; set; }
        public double PR_Custo { get; set; }
        public string DS_Produto { get; set; }
        public byte[] IMG_Produto { get; set; }
        public string DS_Mensagem { get; set; }

        public int Diversos { get; set; }

        public ModelProduto()
        {

        }

        public ModelProduto(int id_produto, double pr_custo)
        {
            ID_Produto = id_produto;
            PR_Custo = pr_custo;

            EditarPreco();
        }
        public ModelProduto(string action, int id_produto)
        {
            ID_Produto = id_produto;

            if (action.Equals("ativar"))
            {
                AtivarProduto();
            }
            if (action.Equals("excluir"))
            {
                ExcluirProduto();
            }

        }

        public ModelProduto(int id_produto, int id_categoria, string nm_produto,
        double pr_unitario, double pr_custo, string ds_produto, byte[] img_produto)
        {
            ID_Produto = id_produto;
            ID_Categoria = id_categoria;
            NM_Produto = nm_produto;
            PR_Custo = pr_custo;
            PR_Unitario = pr_unitario;
            DS_Produto = ds_produto;
            IMG_Produto = img_produto;



            EditarProduto();
        }
        public ModelProduto(int id_categoria, string nm_produto,
        double pr_unitario, double pr_custo, string ds_produto, byte[] img_produto, int diversos)
        {
            ID_Categoria = id_categoria;
            NM_Produto = nm_produto;
            PR_Custo = pr_custo;
            PR_Unitario = pr_unitario;
            DS_Produto = ds_produto;
            IMG_Produto = img_produto;
            Diversos = diversos;
            InserirProduto();
        }

        // Método inserir
        public void InserirProduto()
        {
            SqlConnection SqlCon = new SqlConnection();
            DS_Mensagem = "";
            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID_Produto";
                ParID.SqlDbType = SqlDbType.Int;
                ParID.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParID);

                SqlParameter ParCategoria = new SqlParameter();
                ParCategoria.ParameterName = "@ID_Categoria";
                ParCategoria.SqlDbType = SqlDbType.Int;
                ParCategoria.Value = ID_Categoria;
                SqlCmd.Parameters.Add(ParCategoria);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@NM_Produto";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = NM_Produto;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParPreco = new SqlParameter();
                ParPreco.ParameterName = "@PR_Unitario";
                ParPreco.SqlDbType = SqlDbType.Decimal;
                ParPreco.Value = PR_Unitario;
                SqlCmd.Parameters.Add(ParPreco);

                SqlParameter ParCusto = new SqlParameter();
                ParCusto.ParameterName = "@PR_Custo";
                ParCusto.SqlDbType = SqlDbType.Decimal;
                ParCusto.Value = PR_Custo;
                SqlCmd.Parameters.Add(ParCusto);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@DS_Produto";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 150;
                ParDescricao.Value = DS_Produto;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParImagem = new SqlParameter();
                ParImagem.ParameterName = "@IMG_Produto";
                ParImagem.SqlDbType = SqlDbType.Image;
                ParImagem.Value = IMG_Produto;
                SqlCmd.Parameters.Add(ParImagem);

                SqlParameter ParDiversos = new SqlParameter();
                ParDiversos.ParameterName = "@Diversos";
                ParDiversos.SqlDbType = SqlDbType.Int;
                ParDiversos.Value = Diversos;
                SqlCmd.Parameters.Add(ParDiversos);

                DS_Mensagem = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "O registro não foi inserido";

                SqlCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                DS_Mensagem = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            

        }

        // Método Editar
        public void EditarProduto()
        {
            SqlConnection SqlCon = new SqlConnection();
            DS_Mensagem = "";

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID_Produto";
                ParID.SqlDbType = SqlDbType.Int;
                ParID.Value = ID_Produto;
                SqlCmd.Parameters.Add(ParID);

                SqlParameter ParCategoria = new SqlParameter();
                ParCategoria.ParameterName = "@ID_Categoria";
                ParCategoria.SqlDbType = SqlDbType.Int;
                ParCategoria.Value = ID_Categoria;
                SqlCmd.Parameters.Add(ParCategoria);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@NM_Produto";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = NM_Produto;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParPreco = new SqlParameter();
                ParPreco.ParameterName = "@PR_Unitario";
                ParPreco.SqlDbType = SqlDbType.Decimal;
                ParPreco.Value = PR_Unitario;
                SqlCmd.Parameters.Add(ParPreco);

                SqlParameter ParCusto = new SqlParameter();
                ParCusto.ParameterName = "@PR_Custo";
                ParCusto.SqlDbType = SqlDbType.Decimal;
                ParCusto.Value = PR_Custo;
                SqlCmd.Parameters.Add(ParCusto);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@DS_Produto";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 150;
                ParDescricao.Value = DS_Produto;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParImagem = new SqlParameter();
                ParImagem.ParameterName = "@IMG_Produto";
                ParImagem.SqlDbType = SqlDbType.Image;
                ParImagem.Value = IMG_Produto;
                SqlCmd.Parameters.Add(ParImagem);

 


                DS_Mensagem = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição não foi realizada";

                SqlCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                DS_Mensagem = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }

        // Método excluir
        public void ExcluirProduto()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Produto SET " +
               "Ativo = 0 " +
               "WHERE ID_Produto = '" + ID_Produto + "'",
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


        // Método preco
        public void EditarPreco()
        {
            SqlConnection SqlCon = new SqlConnection();

            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Produto SET " +
               "PR_Custo =   '" + PR_Custo.ToString(CultureInfo.GetCultureInfo("en-US")) + "'" +
               "WHERE ID_Produto = '" + ID_Produto + "'",
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
        private void AtivarProduto()
        {
            DS_Mensagem = "";

            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
               "UPDATE TB_Produto SET " +
               "Ativo = 1 " +
               "WHERE ID_Produto = '" + ID_Produto + "'",
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
        public DataTable MostrarProduto(int status)
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
                "PROD.ID_Produto,  " +
                "CAT.NM_Categoria, " +
                "PROD.NM_Produto, " +
                "FORMAT(PROD.PR_Unitario, 'N2') AS PR_Unitario,  " +
                "FORMAT(PROD.PR_Custo, 'N2') AS PR_Custo, " +
                "PROD.DS_Produto,  " +
                "PROD.IMG_Produto,  " +
                "PROD.Diversos  " +
                "FROM TB_Produto AS PROD " +
                "INNER JOIN TB_Categoria AS CAT " +
                "ON PROD.ID_Categoria = CAT.ID_Categoria  " +
                "WHERE PROD.Ativo = '" + status + "' " +
                " ORDER BY ID_Produto  ",
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




        // Método mostrar
        public DataTable MostrarProduto(int status, int diversos)
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
                  "PROD.ID_Produto,  " +
                  "CAT.NM_Categoria, " +
                  "PROD.NM_Produto, " +
                  "FORMAT(PROD.PR_Unitario, 'N2') AS PR_Unitario,  " +
                  "FORMAT(PROD.PR_Custo, 'N2') AS PR_Custo, " +
                  "PROD.DS_Produto,  " +
                  "PROD.IMG_Produto,  " +
                  "PROD.Diversos  " +
                  "FROM TB_Produto AS PROD " +
                  "INNER JOIN TB_Categoria AS CAT " +
                  "ON PROD.ID_Categoria = CAT.ID_Categoria  " +
                  "WHERE PROD.Ativo = '" + status + "' " +
                  "AND PROD.Diversos = '" + diversos + "' " +
                  " ORDER BY ID_Produto  ",
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



        // Método buscar produto por nome
        public DataTable BuscarNomeProduto(int status, string texto, int diversos)
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
                 "PROD.ID_Produto,  " +
                 "CAT.NM_Categoria, " +
                 "PROD.NM_Produto, " +
                 "FORMAT(PROD.PR_Unitario, 'N2') AS PR_Unitario,  " +
                 "FORMAT(PROD.PR_Custo, 'N2') AS PR_Custo,  " +
                 "PROD.DS_Produto,  " +
                 "PROD.IMG_Produto,  " +
                 "PROD.Diversos  " +
                 "FROM TB_Produto AS PROD " +
                 "INNER JOIN TB_Categoria AS CAT " +
                 "ON PROD.ID_Categoria = CAT.ID_Categoria  " +
                 "WHERE PROD.Ativo = '" + status + "' " +
                 "AND PROD.Diversos = '" + diversos + "' " +
                 "AND  NM_Produto LIKE '" + texto + "' + '%'  " +
                 "ORDER BY ID_Produto ", SqlCon);
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
        // Método buscar produto por nome
        public DataTable BuscarNomeProduto(int status, string texto)
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
                 "PROD.ID_Produto,  " +
                 "CAT.NM_Categoria, " +
                 "PROD.NM_Produto, " +
                 "FORMAT(PROD.PR_Unitario, 'N2') AS PR_Unitario,  " +
                 "FORMAT(PROD.PR_Custo, 'N2') AS PR_Custo,  " +
                 "PROD.DS_Produto,  " +
                 "PROD.IMG_Produto,  " +
                 "PROD.Diversos  " +
                 "FROM TB_Produto AS PROD " +
                 "INNER JOIN TB_Categoria AS CAT " +
                 "ON PROD.ID_Categoria = CAT.ID_Categoria  " +
                 "WHERE PROD.Ativo = '" + status + "' " +
                 "AND  NM_Produto LIKE '" + texto + "' + '%'  " +
                 "ORDER BY ID_Produto ", SqlCon);
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
