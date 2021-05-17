using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlUnidadeRede
    {
        ModelUnidadeRede myUnidadeRede = new ModelUnidadeRede();

        // Metodo inserir
        public string InserirUnidadeRede(string ds_unidaderede, double vl_gastocompra, double vl_lucrovenda)
        {
            myUnidadeRede.DescricaoUnidadeRede = ds_unidaderede;
            myUnidadeRede.ValorGastoCompra = vl_gastocompra;
            myUnidadeRede.ValorLucroVenda = vl_lucrovenda;

            return myUnidadeRede.InserirUnidadeRede(myUnidadeRede);
        }

        // Metodo Editar
        public string EditarUnidadeRede(int id_unidaderede, string ds_unidaderede, double vl_gastocompra, double vl_lucrovenda)
        {
            myUnidadeRede.IDUnidadeRede = id_unidaderede;
            myUnidadeRede.DescricaoUnidadeRede = ds_unidaderede;
            myUnidadeRede.ValorGastoCompra = vl_gastocompra;
            myUnidadeRede.ValorLucroVenda = vl_lucrovenda;

            return myUnidadeRede.EditarUnidadeRede(myUnidadeRede);
        }

        // Metodo Deletar
        public string ExcluirUnidadeRede(int id_unidaderede)
        {
            myUnidadeRede.IDUnidadeRede = id_unidaderede;

            return myUnidadeRede.ExcluirUnidadeRede(myUnidadeRede);
        }

        // Metodo Mostrar
        public DataTable MostrarUnidadeRede()
        {
            return myUnidadeRede.MostrarUnidadeRede();
        }

        public DataTable BuscarUnidadeRede(string Textobuscar)
        {
            myUnidadeRede.TextoBuscar = Textobuscar;

            return myUnidadeRede.BuscarUnidadeRede(myUnidadeRede);
        }

        public string CarregaValoresUnidade(int id_unidaderede, double vl_gastocompra, double vl_lucrovenda)
        {
            myUnidadeRede.IDUnidadeRede = id_unidaderede;
            myUnidadeRede.ValorGastoCompra = vl_gastocompra;
            myUnidadeRede.ValorLucroVenda = vl_lucrovenda;

            return myUnidadeRede.CarregaValoresUnidade(myUnidadeRede);
        }
    }
}
