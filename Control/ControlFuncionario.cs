using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Control
{
    public class ControlFuncionario
    {


        ModelFuncionario myFuncionario;
        public string DS_Mensagem { get; set; }

        public ControlFuncionario()
        {
        }



        // Método inserir
        public ControlFuncionario(string nm_funcionario, string ds_sexo, string nr_cpf, DateTime dt_nascimento,
            string nr_telefone, string ds_email, string nr_cep, string nm_rua, string nr_casa, string nm_bairro, string ds_complemento,
            string nm_cidade, string ds_uf, string ds_cargo, string vl_salario, string dt_admissao)
        {
            myFuncionario = new ModelFuncionario(nm_funcionario, ds_sexo, nr_cpf, dt_nascimento,
               nr_telefone, ds_email, nr_cep, nm_rua, nr_casa, nm_bairro, ds_complemento, nm_cidade, ds_uf, ds_cargo, Convert.ToDouble(vl_salario), Convert.ToDateTime(dt_admissao));

            DS_Mensagem = myFuncionario.DS_Mensagem;
        }

        // Método editar
        public ControlFuncionario(string id_funcionario, string nm_funcionario, string ds_sexo, string nr_cpf, string dt_nascimento,
             string nr_telefone, string ds_email, string nr_cep, string nm_rua, string nr_casa, string nm_bairro, string ds_complemento,
             string nm_cidade, string ds_uf, string ds_cargo, string vl_salario, string dt_admissao)
        {
            myFuncionario = new ModelFuncionario(Convert.ToInt32(id_funcionario), nm_funcionario, ds_sexo, nr_cpf, Convert.ToDateTime(dt_nascimento),
               nr_telefone, ds_email, nr_cep, nm_rua, nr_casa, nm_bairro, ds_complemento, nm_cidade, ds_uf, ds_cargo, Convert.ToDouble(vl_salario), Convert.ToDateTime(dt_admissao));

            DS_Mensagem = myFuncionario.DS_Mensagem;
        }

        // Método Excluir/ativar
        public ControlFuncionario(string action, string id_funcionario)
        {
            myFuncionario = new ModelFuncionario(action, Convert.ToInt32(id_funcionario));

            DS_Mensagem = myFuncionario.DS_Mensagem;
        }

        // Método mostrar

        public DataTable MostrarFuncionario(string status)
        {
            myFuncionario = new ModelFuncionario();

            return myFuncionario.MostrarFuncionario(Convert.ToInt32(status));
        }

        // metodo buscar 
        public DataTable BuscarNomeFuncionario(string status, string texto)
        {
            myFuncionario = new ModelFuncionario();

            return myFuncionario.BuscarNomeFuncionario(Convert.ToInt32(status), texto);
        }
        public DataTable BuscarCPFFuncionario(string status, string texto)
        {
            myFuncionario = new ModelFuncionario();

            return myFuncionario.BuscarCPFFuncionario(Convert.ToInt32(status), texto);
        }



    }
}
