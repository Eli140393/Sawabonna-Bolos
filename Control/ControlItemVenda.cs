using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlItemVenda
    {
        ModelItemVenda myItemVenda;

        public string DS_Mensagem { get; set; }

        public ControlItemVenda()
        {

        }

        // Método editar / inserir
        public ControlItemVenda(string action, int id_venda, string id_produto, string qtde_itemVenda, double vl_subTotal)
        {
            myItemVenda = new ModelItemVenda(action, id_venda, Convert.ToInt32(id_produto), Convert.ToInt32(qtde_itemVenda),
            vl_subTotal);

            DS_Mensagem = myItemVenda.DS_Mensagem;
        }

    

        // Método excluir todos
        public ControlItemVenda(string id_venda)
        {
            myItemVenda = new ModelItemVenda(Convert.ToInt32(id_venda));
            DS_Mensagem = myItemVenda.DS_Mensagem;

        }

        // Método excluir um
        public ControlItemVenda(string id_venda, string id_produto)
        {
            myItemVenda = new ModelItemVenda(Convert.ToInt32(id_venda), Convert.ToInt32(id_produto));
            DS_Mensagem = myItemVenda.DS_Mensagem;

        }
        // Método mostrar todos
        public DataTable MostrarTodosItemVenda()
        {
            myItemVenda = new ModelItemVenda();

            return myItemVenda.MostrarTodosItemVenda();

        }


        // Método mostrar um

        public DataTable MostrarItemVenda(int id_venda)
        {
            myItemVenda = new ModelItemVenda();

            return myItemVenda.MostrarItemVenda(id_venda);

        }

        // Método buscar
        public DataTable BuscarNomeItemVenda(string textoBuscar)
        {

            myItemVenda = new ModelItemVenda();

            return myItemVenda.BuscarNomeItemVenda(textoBuscar);


        }
    }
}
