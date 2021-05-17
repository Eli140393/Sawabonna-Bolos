using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlEstoque
    {
        ModelEstoque myEstoque;

        public string DS_Mensagem { get; set; }


        public ControlEstoque()
        {

        }

        public ControlEstoque(string action, string id_insumo, string qtde_estoque)
        {
            myEstoque = new ModelEstoque(action, Convert.ToInt32(id_insumo), Convert.ToDouble(qtde_estoque));

            DS_Mensagem = myEstoque.DS_Mensagem;
        }



        public ControlEstoque(string id_insumo)
        {
            myEstoque = new ModelEstoque(Convert.ToInt32(id_insumo));
            DS_Mensagem = myEstoque.DS_Mensagem;

        }

        public DataTable MostrarEstoque()
        {
            myEstoque = new ModelEstoque();
            return myEstoque.MostrarEstoque();
        }

        public DataTable BuscarNomeInsumoEstoque(string Textobuscar)
        {

            myEstoque = new ModelEstoque();

            return myEstoque.BuscarNomeInsumoEstoque(Textobuscar);
        }
    }
}
