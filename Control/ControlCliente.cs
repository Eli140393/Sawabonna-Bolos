using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Control
{
    public class ControlCliente
    {
        ModelCliente myCliente;
        public string DS_Mensagem { get; set; }

        public ControlCliente()
        {
        }



        // Método inserir
        public ControlCliente(string nome,string cpf,string telefone,string email, string sexo, DateTime nascimento)
        {
            myCliente = new ModelCliente(nome, cpf, telefone, email, sexo, nascimento);

            DS_Mensagem = myCliente.DS_Mensagem;
        }

        // Método editar
        public ControlCliente(string id, string nome, string cpf, string telefone, string email, string sexo, DateTime nascimento)
        {
            myCliente = new ModelCliente(Convert.ToInt32(id), nome, cpf, telefone, email,sexo, nascimento);

            DS_Mensagem = myCliente.DS_Mensagem;
        }

        // Método Excluir/ativar
        public ControlCliente(string id, string action)
        {
            myCliente = new ModelCliente(Convert.ToInt32(id), action);

            DS_Mensagem = myCliente.DS_Mensagem;
        }

        // Método mostrar

        public DataTable MostrarCliente(string status)
        {
            myCliente = new ModelCliente();

            return myCliente.MostrarCliente(Convert.ToInt32(status));
        }

        // metodo buscar 
        public DataTable BuscarNomeCliente(string status, string texto)
        {
            myCliente = new ModelCliente();

            return myCliente.BuscarNomeCliente(Convert.ToInt32(status), texto);
        }
        public DataTable BuscarCPFCliente (string status, string texto)
        {
            myCliente = new ModelCliente();

            return myCliente.BuscarCPFCliente(Convert.ToInt32(status), texto);
        }



    }
}
