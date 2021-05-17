using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlInsumo
    {
        ModelInsumo myInsumo;

        public string DS_Mensagem { get; set; }

        public ControlInsumo()
        {

        }

        // Método inserir
        public ControlInsumo(string nm_insumo, string ds_tipoArmazenamento, string pr_insumo)
        {
            myInsumo = new ModelInsumo(nm_insumo, ds_tipoArmazenamento,Convert.ToDouble(pr_insumo));

            DS_Mensagem = myInsumo.DS_Mensagem;
        }

        // Método editar

        public ControlInsumo(string id_insumo, string nm_insumo, string ds_tipoArmazenamento, string pr_insumo)
        {
            myInsumo = new ModelInsumo(Convert.ToInt32(id_insumo),nm_insumo, ds_tipoArmazenamento,Convert.ToDouble(pr_insumo));

            DS_Mensagem = myInsumo.DS_Mensagem;
        }

        // Método excluir
        public ControlInsumo(string id_insumo)
        {
            myInsumo = new ModelInsumo(Convert.ToInt32(id_insumo));
            DS_Mensagem = myInsumo.DS_Mensagem;

        }

        // Método mostrar
        public DataTable MostrarInsumo()
        {
            myInsumo = new ModelInsumo();

            return myInsumo.MostrarInsumo();

        }

        // Método buscar compra por data
        public DataTable BuscarNomeInsumo(string textoBuscar)
        {

            myInsumo = new ModelInsumo();

            return myInsumo.BuscarNomeInsumo(textoBuscar);


        }
    }
}
