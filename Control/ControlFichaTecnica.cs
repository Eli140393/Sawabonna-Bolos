using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlFichaTecnica
    {
        ModelFichaTecnica myFichaTecnica;

        public string DS_Mensagem { get; set; }



        public ControlFichaTecnica()
        {

        }

        // Método editar/inserir
        public ControlFichaTecnica(string action, string id_produto, string id_insumo, string qtde_utilizada)
        {
            myFichaTecnica = new ModelFichaTecnica(action, Convert.ToInt32(id_produto), Convert.ToInt32(id_insumo), Convert.ToDouble(qtde_utilizada));

            DS_Mensagem = myFichaTecnica.DS_Mensagem;
        }



        // Método excluir
        public ControlFichaTecnica(string id_produto, string id_insumo)
        {
            myFichaTecnica = new ModelFichaTecnica(Convert.ToInt32(id_produto), Convert.ToInt32(id_insumo));
            DS_Mensagem = myFichaTecnica.DS_Mensagem;

        }

        // Método mostrar
        public DataTable MostrarFichaTecnica(string id_produto)
        {
            myFichaTecnica = new ModelFichaTecnica();

            return myFichaTecnica.MostrarFichaTecnica(Convert.ToInt32(id_produto));

        }

    }
}
