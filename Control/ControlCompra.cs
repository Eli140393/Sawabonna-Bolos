using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlCompra
    {
        ModelCompra myCompra;
        public string DS_Mensagem { get; set; }



        public ControlCompra()
        {

        }
        // Método editar
        public ControlCompra(string id_compra, string id_insumo, string dt_compra, string qtde_insumocompra)
        {
            myCompra = new ModelCompra(Convert.ToInt32(id_compra), Convert.ToInt32(id_insumo), Convert.ToDateTime(dt_compra), Convert.ToDouble(qtde_insumocompra));

            DS_Mensagem = myCompra.DS_Mensagem;
        }

        // Método inserir
        public ControlCompra (string id_insumo, string dt_compra, string qtde_insumocompra)
        {
            myCompra = new ModelCompra(Convert.ToInt32(id_insumo),Convert.ToDateTime(dt_compra),Convert.ToDouble(qtde_insumocompra));

            DS_Mensagem = myCompra.DS_Mensagem;
        }

        // Método excluir
        public ControlCompra (string id_compra)
        {
            myCompra = new ModelCompra(Convert.ToInt32(id_compra));
            DS_Mensagem = myCompra.DS_Mensagem;

        }

        // Método mostrar
        public DataTable MostrarCompra()
        {
             myCompra = new ModelCompra();

            return myCompra.MostrarCompra();

        }

        // Método buscar compra por data
        public DataTable BuscarDataCompra(DateTime databuscar)
        {

            myCompra = new ModelCompra();

            return myCompra.BuscarDataCompra(databuscar);

        }

        // Método buscar compra por nome do insumo
        public DataTable BuscarNomeCompra(string nm_insumo)
        {

            myCompra = new ModelCompra();

            return myCompra.BuscarNomeCompra(nm_insumo);

        }
    }
}
