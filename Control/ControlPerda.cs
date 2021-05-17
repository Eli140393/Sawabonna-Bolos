using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlPerda
    {
   
            ModelPerda myPerdas;

        public string DS_Mensagem { get; set; }

        public ControlPerda()
        {

        }

       
        // Método inserir
        public ControlPerda(string id_insumo, string qtde_perda, string ds_perda)
        {
            myPerdas = new ModelPerda(Convert.ToInt32(id_insumo), Convert.ToDouble(qtde_perda),ds_perda);

            DS_Mensagem = myPerdas.DS_Mensagem;
        }

        // Método excluir
        public ControlPerda(string id_perda,string id_insumo)
        {
            myPerdas = new ModelPerda(Convert.ToInt32(id_perda),Convert.ToInt32(id_insumo));
            DS_Mensagem = myPerdas.DS_Mensagem;

        }

        // Método mostrar
        public DataTable MostrarPerda()
        {
            myPerdas = new ModelPerda();

            return myPerdas.MostrarPerda();

        }

        // Método buscar  por nome
        public DataTable BuscarNomePerda(string textoBuscar)
        {

            myPerdas = new ModelPerda();

            return myPerdas.BuscarPerdaNome(textoBuscar);


        }
        public DataTable BuscarDataPerda(DateTime textoBuscar)
        {

            myPerdas = new ModelPerda();

            return myPerdas.BuscarPerdaData(textoBuscar);


        }
    }
}

