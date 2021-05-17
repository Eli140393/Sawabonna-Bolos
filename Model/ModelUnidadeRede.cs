using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelUnidadeRede
    {
        private int _IDUnidadeRede;
        private string _DescricaoUnidadeRede;
        private double _ValorGastoCompra;
        private double _ValorLucroVenda;
        private string _TextoBuscar;

        public int IDUnidadeRede { get => _IDUnidadeRede; set => _IDUnidadeRede = value; }
        public string DescricaoUnidadeRede { get => _DescricaoUnidadeRede; set => _DescricaoUnidadeRede = value; }
        public double ValorGastoCompra { get => _ValorGastoCompra; set => _ValorGastoCompra = value; }
        public double ValorLucroVenda { get => _ValorLucroVenda; set => _ValorLucroVenda = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public ModelUnidadeRede()
        {

        }

        public ModelUnidadeRede(int id_unidaderede, string ds_unidaderede, double vl_gastocompra, double vl_lucrovenda)
        {
            IDUnidadeRede = id_unidaderede;
            DescricaoUnidadeRede = ds_unidaderede;
            ValorGastoCompra = vl_gastocompra;
            ValorLucroVenda = vl_lucrovenda;
        }

        public string InserirUnidadeRede(ModelUnidadeRede UnidadeRede)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_unidaderede";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDUnidadeRede = new SqlParameter();
                ParIDUnidadeRede.ParameterName = "@ID_UnidadeRede";
                ParIDUnidadeRede.SqlDbType = SqlDbType.Int;
                ParIDUnidadeRede.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIDUnidadeRede);

                SqlParameter ParDSUnidadeRede = new SqlParameter();
                ParDSUnidadeRede.ParameterName = "@DS_UnidadeRede";
                ParDSUnidadeRede.SqlDbType = SqlDbType.Int;
                ParDSUnidadeRede.Value = UnidadeRede.DescricaoUnidadeRede;
                SqlCmd.Parameters.Add(ParDSUnidadeRede);

                SqlParameter ParVLGastoCompra = new SqlParameter();
                ParVLGastoCompra.ParameterName = "@VL_GastoCompra";
                ParVLGastoCompra.SqlDbType = SqlDbType.Decimal;
                ParVLGastoCompra.Value = UnidadeRede.ValorGastoCompra;
                SqlCmd.Parameters.Add(ParVLGastoCompra);

                SqlParameter ParVLLucroVenda = new SqlParameter();
                ParVLLucroVenda.ParameterName = "@VL_LucroVenda";
                ParVLLucroVenda.SqlDbType = SqlDbType.Decimal;
                ParVLLucroVenda.Value = UnidadeRede.ValorLucroVenda;
                SqlCmd.Parameters.Add(ParVLLucroVenda);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "O registro não foi inserido";

                SqlCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        public string EditarUnidadeRede(ModelUnidadeRede UnidadeRede)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_unidade_rede";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDUnidadeRede = new SqlParameter();
                ParIDUnidadeRede.ParameterName = "@ID_UnidadeRede";
                ParIDUnidadeRede.SqlDbType = SqlDbType.Int;
                ParIDUnidadeRede.Value = UnidadeRede.IDUnidadeRede;
                SqlCmd.Parameters.Add(ParIDUnidadeRede);

                SqlParameter ParDSUnidadeRede = new SqlParameter();
                ParDSUnidadeRede.ParameterName = "@DS_UnidadeRede";
                ParDSUnidadeRede.SqlDbType = SqlDbType.VarChar;
                ParDSUnidadeRede.Value = UnidadeRede.DescricaoUnidadeRede;
                SqlCmd.Parameters.Add(ParDSUnidadeRede);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição não foi realizada";

                SqlCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        public string ExcluirUnidadeRede(ModelUnidadeRede UnidadeRede)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_unidade_rede";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDUnidadeRede = new SqlParameter();
                ParIDUnidadeRede.ParameterName = "@ID_UnidadeRede";
                ParIDUnidadeRede.SqlDbType = SqlDbType.Int;
                ParIDUnidadeRede.Value = UnidadeRede.IDUnidadeRede;
                SqlCmd.Parameters.Add(ParIDUnidadeRede);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusão não foi realizada";

                SqlCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        public DataTable MostrarUnidadeRede()
        {
            DataTable DtResultado = new DataTable("TB_UnidadeRede");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_unidade_rede";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public DataTable BuscarUnidadeRede(ModelUnidadeRede UnidadeRede)
        {
            DataTable DtResultado = new DataTable("TB_UnidadeRede");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_unidade_rede";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 10;
                ParTextoBuscar.Value = UnidadeRede.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

                SqlCmd.Parameters.Clear();
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public string CarregaValoresUnidade(ModelUnidadeRede UnidadeRede)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = ModelConexao.Conexao;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spcarrega_valores_unidaderede";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUnidaderede = new SqlParameter();
                ParIdUnidaderede.ParameterName = "@ID_UnidadeRede";
                ParIdUnidaderede.SqlDbType = SqlDbType.Int;
                ParIdUnidaderede.Value = UnidadeRede.IDUnidadeRede;
                SqlCmd.Parameters.Add(ParIdUnidaderede);

                SqlParameter ParVlGastoCompra = new SqlParameter();
                ParVlGastoCompra.ParameterName = "@VL_GastoCompra";
                ParVlGastoCompra.SqlDbType = SqlDbType.Decimal;
                ParVlGastoCompra.Value = UnidadeRede.ValorGastoCompra;
                SqlCmd.Parameters.Add(ParVlGastoCompra);

                SqlParameter ParVlLucroVenda = new SqlParameter();
                ParVlLucroVenda.ParameterName = "@VL_LucroVenda";
                ParVlLucroVenda.SqlDbType = SqlDbType.Decimal;
                ParVlLucroVenda.Value = UnidadeRede.ValorLucroVenda;
                SqlCmd.Parameters.Add(ParVlLucroVenda);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Os valores não foram carregados";

                SqlCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }
    }
}
