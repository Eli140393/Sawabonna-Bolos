using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Model
{
    public class ModelRelatorios
    {
        public string DS_Mensagem { get; set; }





        // Variaveis de Conexão
        SqlConnection SqlCon;                            // Conexão do SGBD
        SqlCommand sqlCommand;                                  // Command que envia um 'comando' para o SGBD
        SqlDataReader sqlDataReader;


        public ModelRelatorios()
        {

        }


        public void GraficoCategorias(EntitiesRelatorio obj)
        {
            SqlCon = new SqlConnection();


            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand("ProdutosPorCategorias", SqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    obj.Categorias.Add(sqlDataReader.GetString(0));
                    obj.QuantidadeCategorias.Add(sqlDataReader.GetInt32(1));

                }


            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlDataReader.Close();
                sqlCommand.Dispose();
                SqlCon.Close();
            }


        }


        public void GraficoProdutos(EntitiesRelatorio obj)
        {
            SqlCon = new SqlConnection();


            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand("MaisVendidos", SqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    obj.Produtos.Add(sqlDataReader.GetString(0));
                    obj.QuantidadeProdutos.Add(sqlDataReader.GetInt32(1));

                }


            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlDataReader.Close();
                sqlCommand.Dispose();
                SqlCon.Close();
            }


        }

        public void GraficoVendas(EntitiesRelatorio obj)
        {
            SqlCon = new SqlConnection();


            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                sqlCommand = new SqlCommand("PrecoDeCusto", SqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    obj.ProdutosVenda.Add(sqlDataReader.GetString(0));
                    obj.Gastos.Add(sqlDataReader.GetDecimal(1));
                    obj.Vendas.Add(sqlDataReader.GetDecimal(2));
                    obj.Lucros.Add(sqlDataReader.GetDecimal(3));

                }


            }
            catch (Exception e)
            {
                DS_Mensagem = e.Message;
            }
            finally
            {
                sqlDataReader.Close();
                sqlCommand.Dispose();
                SqlCon.Close();
            }


        }

        public DataTable Vendas(DateTime dt_vendaInicial, DateTime dt_vendaFinal)
        {
            SqlConnection SqlCon = new SqlConnection();

            DS_Mensagem = "";
            DataTable dataTable = new DataTable();
            SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();
                DS_Mensagem = "";

                sqlCommand = new SqlCommand(
                @" 
					SELECT 
                VEN.ID_Venda,
                VEN.DT_Venda,
                CLI.NM_Cliente,
				FUN.NM_Funcionario,
				string_agg(PROD.NM_Produto, ',
') as NM_Produtos,
                SUM(ITEM.QTDE_ItemVenda* PROD.PR_Unitario ) + VEN.VL_TaxaEntrega AS VL_Total,
				SUM((PROD.PR_Custo ) * ITEM.QTDE_ItemVenda) AS TotalCusto
                FROM TB_Venda AS VEN
                INNER JOIN TB_Cliente as CLI
                ON VEN.ID_Cliente = CLI.ID_Cliente
				INNER JOIN TB_Funcionario AS FUN
				ON VEN.ID_Funcionario = FUN.ID_Funcionario
                INNER JOIN TB_ItemVenda AS ITEM
                ON VEN.ID_Venda = ITEM.ID_Venda
                INNER JOIN TB_Produto as PROD
                ON PROD.ID_Produto = ITEM.ID_Produto
                WHERE VEN.DT_Venda BETWEEN @DT_VendaInicial AND GETDATE() 
                GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega, FUN.NM_Funcionario
                ORDER BY VEN.ID_Venda ASC",
                SqlCon);

             

                sqlCommand.Parameters.Add("@DT_VendaInicial", SqlDbType.Date).Value = dt_vendaInicial;
                sqlCommand.Parameters.Add("@DT_VendaFinal", SqlDbType.Date).Value = dt_vendaFinal;
                sqlCommand.CommandType = CommandType.Text;

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


        public void DashBoardDados(EntitiesRelatorio obj)
        {
            SqlCon = new SqlConnection();

            try
            {
                DS_Mensagem = "";

                SqlCon.ConnectionString = ModelConexao.Conexao;
                sqlCommand = new SqlCommand("RelatoriosTotais", SqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter totalVendas = new SqlParameter("@TotalVendas", 0);
                totalVendas.Direction = ParameterDirection.Output;

                SqlParameter totalProdutos = new SqlParameter("@TotalProdutos", 0);
                totalProdutos.Direction = ParameterDirection.Output;

                SqlParameter totalProdutosDiversos = new SqlParameter("@TotalProdutosDiversos", 0);
                totalProdutosDiversos.Direction = ParameterDirection.Output;

                SqlParameter totalCategorias = new SqlParameter("@TotalCategorias", 0);
                totalCategorias.Direction = ParameterDirection.Output;

                SqlParameter totalClientes = new SqlParameter("@TotalClientes", 0);
                totalClientes.Direction = ParameterDirection.Output;

                SqlParameter totalFuncionarios = new SqlParameter("@TotalFuncionarios", 0);
                totalFuncionarios.Direction = ParameterDirection.Output;

                SqlParameter totalInsumos = new SqlParameter("@TotalInsumos", 0);
                totalInsumos.Direction = ParameterDirection.Output;

                SqlParameter totalCompras = new SqlParameter("@TotalCompras", 0);
                totalCompras.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(totalVendas);
                sqlCommand.Parameters.Add(totalProdutos);
                sqlCommand.Parameters.Add(totalProdutosDiversos);
                sqlCommand.Parameters.Add(totalCategorias);
                sqlCommand.Parameters.Add(totalClientes);
                sqlCommand.Parameters.Add(totalFuncionarios);
                sqlCommand.Parameters.Add(totalInsumos);
                sqlCommand.Parameters.Add(totalCompras);


                SqlCon.Open();
                sqlCommand.ExecuteNonQuery();



                obj.totalVendas = sqlCommand.Parameters["@TotalVendas"].Value.ToString();
                obj.totalProdutos = sqlCommand.Parameters["@TotalProdutos"].Value.ToString();
                obj.totalProdutosDiversos = sqlCommand.Parameters["@TotalProdutosDiversos"].Value.ToString();
                obj.totalCategorias = sqlCommand.Parameters["@TotalCategorias"].Value.ToString();
                obj.totalClientes = sqlCommand.Parameters["@TotalClientes"].Value.ToString();
                obj.totalFuncionarios = sqlCommand.Parameters["@TotalFuncionarios"].Value.ToString();
                obj.totalInsumos = sqlCommand.Parameters["@TotalInsumos"].Value.ToString();
                obj.totalCompras = sqlCommand.Parameters["@TotalCompras"].Value.ToString();
            


            
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
    }
}


