using Model;
using System;
using System.Data;

namespace Control
{
    public class ControlCategoria
    {
        ModelCategoria myCategoria;

        public string DS_Mensagem { get; set; }

        // Metodo inserir
        public ControlCategoria()
        {
        }



        // Método inserir
        public ControlCategoria(string nome, string descricao)
        {
            myCategoria = new ModelCategoria(nome, descricao);

            DS_Mensagem = myCategoria.DS_Mensagem;
        }

        // Método editar
        public ControlCategoria(string id, string nome, string descricao)
        {
            myCategoria = new ModelCategoria(Convert.ToInt32(id), nome, descricao);

            DS_Mensagem = myCategoria.DS_Mensagem;
        }

        // Método Excluir/ Ativar
        public ControlCategoria(string action,int id)
        {
            myCategoria = new ModelCategoria(action, id);

            DS_Mensagem = myCategoria.DS_Mensagem;
        }

        // Método mostrar

        public DataTable MostrarCategoria(string status)
        {
            myCategoria = new ModelCategoria();


            return myCategoria.MostrarCategoria(Convert.ToInt32(status));
        }

        // metodo buscar 
        public DataTable BuscarNomeCategoria(string texto)
        {
            myCategoria = new ModelCategoria();

            return myCategoria.BuscarNomeCategoria(texto);
        }

       
    }
}
