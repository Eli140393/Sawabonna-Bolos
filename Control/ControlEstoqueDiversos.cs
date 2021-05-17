using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlEstoqueDiversos
    {
        ModelEstoqueDiversos myEstoque;

        public string DS_Mensagem { get; set; }


        public ControlEstoqueDiversos()
        {

        }

        public ControlEstoqueDiversos(string action, string id_produto, string qtde_estoque)
        {
            myEstoque = new ModelEstoqueDiversos(action, Convert.ToInt32(id_produto), Convert.ToInt32(qtde_estoque));

            DS_Mensagem = myEstoque.DS_Mensagem;
        }



        public ControlEstoqueDiversos(string id_produto)
        {
            myEstoque = new ModelEstoqueDiversos(Convert.ToInt32(id_produto));
            DS_Mensagem = myEstoque.DS_Mensagem;

        }

        public DataTable MostrarEstoque()
        {
            myEstoque = new ModelEstoqueDiversos();
            return myEstoque.MostrarEstoque();
        }

        public DataTable BuscarNomeProdutoEstoque(string textobuscar)
        {

            myEstoque = new ModelEstoqueDiversos();

            return myEstoque.BuscarNomeProdutoEstoque(textobuscar);
        }
    }
}

