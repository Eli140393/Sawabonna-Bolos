using Model;
using System;
using System.Data;
using System.Globalization;

namespace Control
{
    public class ControlProduto
    {
        ModelProduto myProduto;

        public string DS_Mensagem { get; set; }

        public ControlProduto()
        {

        }

        public ControlProduto(int id_produto, string pr_custo)
        {
            double final = Convert.ToDouble(pr_custo);

            myProduto = new ModelProduto(id_produto, final);

            DS_Mensagem = myProduto.DS_Mensagem;
        }


        // Método inserir
        public ControlProduto(string id_produto, string id_categoria, string nm_produto,
        string pr_unitario, string pr_custo, string ds_produto, byte[] img_produto)
        {
            myProduto = new ModelProduto(Convert.ToInt32(id_produto), Convert.ToInt32(id_categoria), nm_produto,
            Convert.ToDouble(pr_unitario), Convert.ToDouble(pr_custo), ds_produto , img_produto);

            DS_Mensagem = myProduto.DS_Mensagem;
        }

        // Método editar
        public ControlProduto(string id_categoria, string nm_produto,
         string pr_unitario, string pr_custo, string ds_produto, byte[] img_produto, string diversos)
        {
            myProduto = new ModelProduto(Convert.ToInt32(id_categoria), nm_produto,
            Convert.ToDouble(pr_unitario), Convert.ToDouble(pr_custo), ds_produto, img_produto, Convert.ToInt32(diversos));

            DS_Mensagem = myProduto.DS_Mensagem;
        }

        // Método Excluir/ativar
        public ControlProduto(string id_produto, string action)
        {
            myProduto = new ModelProduto(action , Convert.ToInt32(id_produto));

            DS_Mensagem = myProduto.DS_Mensagem;
        }

        // Método mostrar

        public DataTable MostrarProduto(string status, string diversos)
        {
            myProduto = new ModelProduto();

            return myProduto.MostrarProduto(Convert.ToInt32(status), Convert.ToInt32(diversos));
        }

        public DataTable MostrarProduto(string status)
        {
            myProduto = new ModelProduto();

            return myProduto.MostrarProduto(Convert.ToInt32(status));
        }

        // metodo buscar 
        public DataTable BuscarNomeProduto(string status, string texto, string diversos)
        {
            myProduto = new ModelProduto();

            return myProduto.BuscarNomeProduto(Convert.ToInt32(status), texto, Convert.ToInt32(diversos));
        }
        public DataTable BuscarNomeProduto(string status, string texto)
        {
            myProduto = new ModelProduto();

            return myProduto.BuscarNomeProduto(Convert.ToInt32(status), texto);
        }

    }
}
