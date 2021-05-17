using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Globalization;

namespace View
{
    public partial class ViewRelatorio : Form
    {
        public ViewRelatorio()
        {
            InitializeComponent();
        }

        DateTime fromDate;
        DateTime toDate;
        ControlRelatorios relatorios;
        ControlVenda vendas;



        private static GraphicsPath SuArredondaRect(Rectangle pRect, int pCanto, bool pTopo, bool pBase)
        {
            GraphicsPath gp = new GraphicsPath();

            if (pTopo)
            {
                gp.AddArc(pRect.X - 1, pRect.Y - 1, pCanto, pCanto, 180, 90);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y - 1, pCanto, pCanto, 270, 90);
            }
            else
            {
                // Se não arredondar o topo, adiciona as linhas para poder fechar o retangulo junto com
                // a base arredondada
                gp.AddLine(pRect.X - 1, pRect.Y - 1, pRect.X + pRect.Width, pRect.Y - 1);
            }

            if (pBase)
            {
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 0, 90);
                gp.AddArc(pRect.X - 1, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 90, 90);
            }
            else
            {
                // Se não arredondar a base, adiciona as linhas para poder fechar o retangulo junto com
                // o topo arredondado. Adiciona da direita para esquerda pois é na ordem contrária que 
                // foi adicionado os arcos do topo. E pra fechar o retangulo tem que desenhar na ordem :
                //  1 - Canto Superior Esquerdo
                //  2 - Canto Superior Direito
                //  3 - Canto Inferior Direito 
                //  4 - Canto Inferior Esquerdo.
                gp.AddLine(pRect.X + pRect.Width, pRect.Y + pRect.Height, pRect.X - 1, pRect.Y + pRect.Height);
            }

            return gp;
        }
        public static void Arredonda(Panel pPainel, int pCanto, bool pTopo, bool pBase)
        {
            // pCanto -> Tamanho do Canto
            // pTopo -> Arredonda o Topo
            // pBase -> Arredonda a Base
            Rectangle r = new Rectangle();
            r = pPainel.ClientRectangle;

            pPainel.Region = new System.Drawing.Region(SuArredondaRect(r, pCanto, pTopo, pBase));
        }
        public static void Arredonda(PictureBox pPicture, int pCanto, bool pTopo, bool pBase)
        {
            // pCanto -> Tamanho do Canto
            // pTopo -> Arredonda o Topo
            // pBase -> Arredonda a Base
            Rectangle r = new Rectangle();
            r = pPicture.ClientRectangle;

            pPicture.Region = new System.Drawing.Region(SuArredondaRect(r, pCanto, pTopo, pBase));
        }

        private void GraficoCategorias()
        {
            relatorios = new ControlRelatorios();
            EntitiesRelatorio obj = new EntitiesRelatorio();
            relatorios.DashboardDados(obj);
            chProdutosCategoria.Series[0].Points.DataBindXY(obj.Categorias, obj.QuantidadeCategorias);

        }

        private void GraficoVenda()
        {
            relatorios = new ControlRelatorios();
            EntitiesRelatorio obj = new EntitiesRelatorio();
            relatorios.DashboardDados(obj);




            chVendas.Series[0].Points.DataBindXY(obj.Produtos, obj.Gastos);

        }
        private void GraficoProdutos()
        {
            relatorios = new ControlRelatorios();
            EntitiesRelatorio obj = new EntitiesRelatorio();
            relatorios.DashboardDados(obj);
            chProdutosPreferidos.Series[0].Points.DataBindXY(obj.Produtos, obj.QuantidadeProdutos);


        }

        private void DashBoardDados()
        {
            relatorios = new ControlRelatorios();
            EntitiesRelatorio obj = new EntitiesRelatorio();
            relatorios.DashboardDados(obj);

            double casaDecimalCompra = Convert.ToDouble(obj.totalCompras);
            double casaDecimalVenda = Convert.ToDouble(obj.totalVendas);


            lblTotalVendas.Text = casaDecimalVenda.ToString("C", CultureInfo.CurrentCulture);

            lblTotalClientes.Text = obj.totalClientes;
            lbTotalCategorias.Text = obj.totalCategorias;
            lbTotalFuncionarios.Text = obj.totalFuncionarios;
            lbTotalProdutos.Text = obj.totalProdutos;
            lblTotalProdutosD.Text = obj.totalProdutosDiversos;
            lblTotalInsumos.Text = obj.totalInsumos;
            lbTotalCompras.Text = casaDecimalCompra.ToString("C", CultureInfo.CurrentCulture);

        }

        private void BuscarFuncionarioVendas()
        {
            vendas = new ControlVenda();

            dgvVendaList.DataSource = vendas.BuscarFuncionarioVenda(fromDate, toDate, txtBuscarVenda.Text);

        }

        private void BuscarClienteVendas()
        {
            vendas = new ControlVenda();

            dgvVendaList.DataSource = vendas.BuscarClienteVenda(fromDate, toDate, txtBuscarVenda.Text);

        }
        private void BuscarProdutoVendas()
        {
            vendas = new ControlVenda();

            dgvVendaList.DataSource = vendas.BuscarProdutoVenda(fromDate, toDate, txtBuscarVenda.Text);

        }




        private void editarDataGrid()
        {


            dgvVendaList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            dgvVendaList.Columns[0].HeaderText = "CÓDIGO";
            dgvVendaList.Columns[1].HeaderText = "DATA\n VENDA";
            dgvVendaList.Columns[2].HeaderText = "NOME\n CLIENTE";
            dgvVendaList.Columns[3].HeaderText = "NOME\nFUNCIONARIO";
            dgvVendaList.Columns[4].HeaderText = "TOTAL\n VENDA";
            dgvVendaList.Columns[5].HeaderText = "NOME\n PRODUTO";
            dgvVendaList.Columns[6].HeaderText = "TOTAL\n CUSTO";
            dgvVendaList.Columns[7].Visible = false;


            dgvVendaList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVendaList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }

        private void getRelatorioVendas(DateTime startDate, DateTime endDate)
        {
            relatorios = new ControlRelatorios();
            relatorios.createSalesOrderReport(startDate, endDate);
            dgvVendaList.DataSource = relatorios.saleList;
            editarDataGrid();


            ControlRelatorios relatoriosVendas = new ControlRelatorios();
            EntitiesRelatorio obj = new EntitiesRelatorio();
            relatorios.DashboardDados(obj);


            List<string> listProdutos = new List<string> ();
            List<double> listVenda = new List<double> ();
            List<double> listGastos = new List<double> ();
            double totalVendas = 0;




            foreach (DataGridViewRow row in dgvVendaList.Rows)
            {
                listProdutos.Add(Convert.ToString(row.Cells[5].Value));
                listVenda.Add(Convert.ToDouble(row.Cells[4].Value));
                listGastos.Add(Convert.ToDouble(row.Cells[6].Value));
            }

            foreach (DataGridViewRow row in dgvVendaList.Rows)
            {
                totalVendas += Convert.ToDouble(row.Cells[4].Value);
                double totalVenda = Convert.ToDouble(row.Cells[4].Value);
                row.Cells[4].Value = totalVenda.ToString("C", CultureInfo.CurrentCulture);

                double totalGasto = Convert.ToDouble(row.Cells[6].Value);
                row.Cells[6].Value = totalGasto.ToString("C", CultureInfo.CurrentCulture);

                

            }
            lbTotalVendasPeriodo.Text = totalVendas.ToString("C", CultureInfo.CurrentCulture);



            chRelatorioVendas.Series[0].Points.DataBindXY(listProdutos, listVenda);
            chRelatorioVendas.Series[1].Points.DataBindXY(listProdutos, listGastos);

        }


        private void ViewRelatório_Load(object sender, EventArgs e)
        {
            GraficoVenda();
            GraficoCategorias();
            GraficoProdutos();
            DashBoardDados();
            Arredonda(pbInsumo, 50, true, true);
            Arredonda(pbFuncionario, 50, true, true);
            Arredonda(pbProdutos, 50, true, true);
            Arredonda(pbCategoria, 50, true, true);
            Arredonda(pbVenda, 50, true, true);
            Arredonda(pbProdutosD, 50, true, true);
            Arredonda(pbCompra, 50, true, true);
            Arredonda(pbCliente, 50, true, true);
            Arredonda(pnCategoria, 50, true, true);
            Arredonda(pnProdutos, 50, true, true);


        }


        private void cbSelecioneData_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbSelecioneData.Text != "Custom")
            {
                dtInicio.Enabled = false;
                dtFinal.Enabled = false;
            }
            if (cbSelecioneData.Text.Equals("Hoje"))
            {
                 fromDate = DateTime.Today;
                 toDate = DateTime.Now.AddMinutes(+ 60);

                getRelatorioVendas(fromDate, toDate);
            }
            else if (cbSelecioneData.Text.Equals("Últimos 7 dias"))
            {
                 fromDate = DateTime.Today.AddDays(-7);
                 toDate = DateTime.Now.AddMinutes(+60); 

                getRelatorioVendas(fromDate, toDate);
            }
            else if (cbSelecioneData.Text.Equals("Este mês"))
            {
                 fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                 toDate = DateTime.Now.AddMinutes(+60);

                getRelatorioVendas(fromDate, toDate);
            }
            else if (cbSelecioneData.Text.Equals("Este ano"))
            {
                 fromDate = new DateTime(DateTime.Now.Year, 1, 1);
                 toDate = DateTime.Now.AddMinutes(+60);

                getRelatorioVendas(fromDate, toDate);
            }
            else if (cbSelecioneData.Text.Equals("Últimos 30 dias"))
            {

                 fromDate = DateTime.Today.AddDays(-30);
                 toDate = DateTime.Now.AddMinutes(+60) ;

                getRelatorioVendas(fromDate, toDate);
            }
            else if (cbSelecioneData.Text.Equals("Custom"))
            {
                dtInicio.Enabled = true;
                dtFinal.Enabled = true;


            }


        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
             fromDate = dtInicio.Value;
             toDate = dtFinal.Value;

            getRelatorioVendas(fromDate, new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59));
        }

        private void txtBuscarVenda_TextChanged(object sender, EventArgs e)
        {
 


                if (cboBuscarVenda.Text.Equals("Nome funcionario"))
                {
                    BuscarFuncionarioVendas();
                }
                else if (cboBuscarVenda.Text.Equals("Nome cliente"))
                {
                    BuscarClienteVendas();
                }
                else if (cboBuscarVenda.Text.Equals("Produtos"))
                {
                    BuscarProdutoVendas();
                }
      
        }
    }
}
