using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlVenda
    {
        ModelVenda myVenda;

        public string DS_Mensagem { get; set; }

        public ControlVenda()
        {

        }

        // Método  inserir
        public ControlVenda(string id_cliente, string id_funcionario, string dt_venda)
        { 
            myVenda = new ModelVenda (Convert.ToInt32(id_cliente), Convert.ToInt32(id_funcionario), Convert.ToDateTime(dt_venda));

            DS_Mensagem = myVenda.DS_Mensagem;
        }

        // Método editar 
        public ControlVenda(string id_funcionario, string id_cliente, string obs_venda, string ds_tipoPagamento, string vl_taxaEntrega, string vl_total)
        {
            myVenda = new ModelVenda(Convert.ToInt32(id_funcionario), Convert.ToInt32(id_cliente), obs_venda, ds_tipoPagamento, Convert.ToDouble(vl_taxaEntrega),
            Convert.ToDouble(vl_total));

            DS_Mensagem = myVenda.DS_Mensagem;
        }


        // Método excluir todos
        public void ExcluirVenda()
        {
            myVenda = new ModelVenda();
            myVenda.ExcluirVenda();
            DS_Mensagem = myVenda.DS_Mensagem;

        }
       
        // Método mostrar todos
        public DataTable MostrarVenda()
        {
            myVenda = new ModelVenda();

            return myVenda.MostrarVenda();

        }
        // Método buscar
        public DataTable BuscarProdutoVenda(DateTime dtInicial, DateTime dtFinal, string produto)
        {

            myVenda = new ModelVenda();

            return myVenda.BuscarProdutoVenda(dtInicial, dtFinal, produto);


        }
        public DataTable BuscarClienteVenda(DateTime dtInicial, DateTime dtFinal, string cliente)
        {

            myVenda = new ModelVenda();

            return myVenda.BuscarNomeCliente(dtInicial, dtFinal, cliente);



        }
        public DataTable BuscarFuncionarioVenda(DateTime dtInicial, DateTime dtFinal, string funcionario)
        {

            myVenda = new ModelVenda();

            return myVenda.BuscarNomeFuncionario(dtInicial, dtFinal, funcionario);



        }
        public void ValidarVenda()
        {

            myVenda = new ModelVenda();

             myVenda.ValidarVenda();



        }
        public int RetorneVendaNull()
        {

            myVenda = new ModelVenda();

            int id_venda =  myVenda.RetorneVendaNull();

            return id_venda;





        }
    }
}
