using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlCompraDiversos
    {
        ModelCompraDiversos myCompra;
        public string DS_Mensagem { get; set; }



        public ControlCompraDiversos()
        {

        }
        // Método editar
        public ControlCompraDiversos(string id_compraDiversos, string id_produto, string dt_compra, string qtde_compra)
        {
            myCompra = new ModelCompraDiversos(Convert.ToInt32(id_compraDiversos), Convert.ToInt32(id_produto), Convert.ToDateTime(dt_compra), Convert.ToInt32(qtde_compra));

            DS_Mensagem = myCompra.DS_Mensagem;
        }

        // Método inserir
        public ControlCompraDiversos( string id_produto, string dt_compra, string qtde_compra)
        {
            myCompra = new ModelCompraDiversos(Convert.ToInt32(id_produto), Convert.ToDateTime(dt_compra), Convert.ToInt32(qtde_compra));

            DS_Mensagem = myCompra.DS_Mensagem;
        }
        // Método excluir
        public ControlCompraDiversos(string id_compraDiversos)
        {
            myCompra = new ModelCompraDiversos(Convert.ToInt32(id_compraDiversos));
            DS_Mensagem = myCompra.DS_Mensagem;

        }

        // Método mostrar
        public DataTable MostrarCompra()
        {
            myCompra = new ModelCompraDiversos();

            return myCompra.MostrarCompra();

        }

        // Método buscar compra por data
        public DataTable BuscarDataCompra(DateTime databuscar)
        {

            myCompra = new ModelCompraDiversos();

            return myCompra.BuscarDataCompra(databuscar);

        }

        // Método buscar compra por nome do insumo
        public DataTable BuscarNomeCompra(string nm_produto)
        {

            myCompra = new ModelCompraDiversos();

            return myCompra.BuscarNomeCompra(nm_produto);

        }
    }
}

