using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class EntitiesRelatorio
    {


        public  ArrayList Produtos  { get; set; }
        public ArrayList Categorias { get; set; }
        public ArrayList QuantidadeProdutos { get; set; }
        public ArrayList QuantidadeCategorias { get; set; }

        public ArrayList ProdutosVenda { get; set; }

        public ArrayList Vendas { get; set; }
        public ArrayList Gastos { get; set; }
        public ArrayList Lucros { get; set; }

        public string totalVendas { get; set; }

        public string totalProdutos { get; set; }
        public string totalProdutosDiversos { get; set; }
        public string totalCategorias { get; set; }
        public string totalClientes { get; set; }
        public string totalFuncionarios { get; set; }
        public string totalInsumos { get; set; }
        public string totalComprasKG { get; set; }
        public string totalComprasUnidades { get; set; }




        public EntitiesRelatorio()
        {
            Produtos = new ArrayList();
            Categorias = new ArrayList();
            QuantidadeCategorias = new ArrayList();
            QuantidadeProdutos = new ArrayList();


            Vendas = new ArrayList();
            ProdutosVenda = new ArrayList();
            Gastos = new ArrayList();
            Lucros = new ArrayList();
        }








    }
}
