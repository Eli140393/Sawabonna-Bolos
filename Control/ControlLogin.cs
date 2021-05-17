using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlLogin
    {
        ModelLogin mylogin;
        public string DS_Mensagem { get; set; }

        public ControlLogin()
        {

        }

        public ControlLogin(int id_login)
        {
            mylogin = new ModelLogin(id_login);
        }


        // Método inserir/editar
        public ControlLogin(string action, string id, string id_nivelacesso, string ds_usuario, string ds_senha)
        {
            mylogin = new ModelLogin(action, Convert.ToInt32(id), Convert.ToInt32(id_nivelacesso), ds_usuario, ds_senha);

            DS_Mensagem = mylogin.DS_Mensagem;
        }

     

        // Método Validar
        public ControlLogin(string ds_usuario, string ds_senha)
        {
            mylogin = new ModelLogin(ds_usuario, ds_senha);

            DS_Mensagem = mylogin.DS_Mensagem;
        }

        // Método Excluir/Ativar/Editar-registro
        public ControlLogin(string action, int id_login)
        {
            mylogin = new ModelLogin(action, id_login);

            DS_Mensagem = mylogin.DS_Mensagem;
        }


        // Método mostrar

        public DataTable MostrarLogin(string status)
        {
            mylogin = new ModelLogin();

            return mylogin.MostrarLogin(Convert.ToInt32(status));
        }


        // Método mostrar

        public DataTable MostrarRegistroLogin()
        {
            mylogin = new ModelLogin();

            return mylogin.MostrarRegistroLogin();
        }

        // metodo buscar 
        public DataTable BuscarNomeFuncionarioLogin(string status, string texto)
        {
            mylogin = new ModelLogin();

            return mylogin.BuscarNomeFuncionarioLogin(Convert.ToInt32(status), texto);
        }



        public DataTable ValidaLogin(string ds_usuario, string ds_senha)
        {
            mylogin = new ModelLogin();

            return mylogin.ValidaLogin(ds_usuario, ds_senha);
        }

     }
}
