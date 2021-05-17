using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ViewVenda : Form
    {
        ControlVenda myVenda;
        ControlProduto myProduto;
        ControlItemVenda myItemVenda;
        ControlCliente myCliente;
        ControlFichaTecnica myFichaTecnica;
        ControlEstoque myEstoque;
        ControlEstoqueDiversos myEstoqueDiversos;


        Validar myValidar = new Validar();

        TabPage[] TabRemove = new TabPage[3];

        // DataTable povoados para estoque e afins
        DataTable dtFcihaTecnica;
        DataTable dtEstoque;
        DataTable dtEstoqueDiversos;

        // DataTable povoado para náo criar a venda antes
        DataTable dtItemVenda;


        private bool eNovo { get; set; } = false;
        private bool eEditar { get; set; } = false;
        private bool ValidarInsumoOK { get; set; } = false;
        public string status { get; set; }
        public string diversos { get; set; }

        public string action { get; set; }
        public string ID_Insumo { get; set; }

        public int ID_Venda { get; set; }
        public int ID_Funcionario { get; set; }
        public string NM_Funcionario { get; set; }
        public int ID_Cliente { get; set; }
        public DateTime DT_Venda { get; set; }

        public ViewVenda()
        {
            InitializeComponent();
        }

        public ViewVenda(int id_funcionario, string nm_funcionario)
        {
            InitializeComponent();
            ID_Funcionario = id_funcionario;
            NM_Funcionario = nm_funcionario;
        }

        private void MensagemOk(string mensagem)
        {
            MessageBox.Show(mensagem, "SAWABONA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mostrar mensagem de Erro
        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "SAWABONA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OcultarTabProdutos()
        {
            TabRemove[0] = tpgAdicionarProdutos;
            tctrlVenda.TabPages.Remove(tpgAdicionarProdutos);
        }

        private void OcultarTabVenda()
        {
            TabRemove[1] = tpgFinalizarVenda;
            tctrlVenda.TabPages.Remove(tpgFinalizarVenda);
        }



        private void MostrarTabProdutos()
        {
            tctrlVenda.TabPages.Add(TabRemove[0]);
        }

        private void MostrarTabVenda()
        {
            tctrlVenda.TabPages.Add(TabRemove[1]);
        }



        private void HabilitarDataGridViewCliente()
        {
            if (dgvClienteVenda.Rows.Count == 0)
            {
                cboxBuscarClienteVenda.Enabled = false;
                txtBuscarClienteVenda.Enabled = false;
                btnBuscarClienteVenda.Enabled = false;
                dgvClienteVenda.Enabled = false;
            }
            else
            {
                cboxBuscarClienteVenda.Enabled = true;
                txtBuscarClienteVenda.Enabled = true;
                btnBuscarClienteVenda.Enabled = true;
                dgvClienteVenda.Enabled = true;
            }
        }

        private void HabilitarDataGridViewProduto()
        {
            if (dgvProdutoVenda.Rows.Count == 0)
            {
                txtBuscarProdutoVenda.Enabled = false;
                btnBuscarProdutoVenda.Enabled = false;
                dgvProdutoVenda.Enabled = false;
            }
            else
            {
                txtBuscarProdutoVenda.Enabled = true;
                btnBuscarProdutoVenda.Enabled = true;
                dgvProdutoVenda.Enabled = true;
            }
        }

        private void HabilitarDataGridViewItemVenda()
        {
            if (dgvItensVenda.Rows.Count == 0)
            {
                chkDeletarItemVenda.Enabled = false;
                dgvItensVenda.Enabled = false;
            }
            else
            {
                chkDeletarItemVenda.Enabled = true;
                dgvItensVenda.Enabled = true;
            }
        }

        //Buscar produto pelo nome
        private void BuscarNomeProduto()
        {
            myProduto = new ControlProduto();
            dgvProdutoVenda.DataSource = myProduto.BuscarNomeProduto(status, txtBuscarProdutoVenda.Text);
        }

        //Buscar cliente pelo nome
        private void BuscarNomeCliente()
        {
            myCliente = new ControlCliente();
            dgvClienteVenda.DataSource = myCliente.BuscarNomeCliente(status, txtBuscarClienteVenda.Text);
        }

        // Buscar pelo documento
        private void BuscasCPFCliente()
        {
            myCliente = new ControlCliente();

            dgvClienteVenda.DataSource = myCliente.BuscarCPFCliente(status, txtBuscarClienteVenda.Text);
        }

        // Limpar campos com dados do cliente
        private void LimparDadosCliente()
        {
            txtCodigoClienteVenda.Text = string.Empty;
            txtNomeClienteVenda.Text = string.Empty;
            txtSexoClienteVenda.Text = string.Empty;
            txtCPFClienteVenda.Text = string.Empty;
            txtNascimentoClienteVenda.Text = string.Empty;
            txtTelefoneClienteVenda.Text = string.Empty;
            txtEmailClienteVenda.Text = string.Empty;

        }

        // Limpar campos com dados do produto
        private void LimparDadosProduto()
        {
            txtNomeProdutoVenda.Text = string.Empty;
            txtCodigoProdutoVenda.Text = string.Empty;
            pbProdutoVenda.Image = null;
            txtCategoriaProdutoVenda.Text = string.Empty;
            txtDescricaoProdutoVenda.Text = string.Empty;
            txtQuantidadeProdutoVenda.Text = string.Empty;
            txtPrecoProdutoVenda.Text = string.Empty;
        }

        private void LimparDadosVenda()
        {
            txtCodigoFuncionarioVendaF.Text = string.Empty;
            txtNomeFuncionarioVendaF.Text = string.Empty;
            txtCodigoFuncionarioVenda.Text = string.Empty;
            txtNomeFuncionario.Text = string.Empty;

            txtCodigoClienteVendaF.Text = string.Empty;
            txtNomeClienteVendaF.Text = string.Empty;
            txtSexoClienteVendaF.Text = string.Empty;
            txtCPFClienteVendaF.Text = string.Empty;
            txtNascimentoClienteVendaF.Text = string.Empty;
            txtTelefoneClienteVendaF.Text = string.Empty;
            txtEmailClienteVendaF.Text = string.Empty;



            dgvItensVendaF.Text = string.Empty;
            txtObservacoesVendaF.Text = string.Empty;
            cboxTipoPagamentoVendaF.Text = null;
            txtTaxaEntregaVendaF.Text = string.Empty;
            txtValorTotalVendaF.Text = string.Empty;
            cbVisualizarProdutos.Text = null;

        }

        private void AllClear()
        {
            eNovo = false;
            eEditar = false;
            OcultarTabProdutos();
            OcultarTabVenda();
            LimparDadosCliente();
            LimparDadosProduto();
            LimparDadosVenda();
            HabilitarCamposAdicionarCliente(false);
            HabilitarCamposAdicionarProduto(false);
            HabilitarCamposFinalizarVenda(false);
            dgvClienteVenda.DataSource = "";
            dgvProdutoVenda.DataSource = "";
            dgvItensVenda.DataSource = "";
            dgvItensVendaF.DataSource = "";
            dtEstoque = null;
            dtFcihaTecnica = null;
            dtItemVenda = null;
            cbVisualizarProdutos.Text = null;

            BotoesCliente();
            BotoesProdutos();

            tctrlVenda.SelectedIndex = 0;
        }

        // Transferir dados do cliente confirmado
        private void TranferirDadosCliente()
        {
            txtCodigoClienteVendaF.Text = txtCodigoClienteVenda.Text;
            txtNomeClienteVendaF.Text = txtNomeClienteVenda.Text;
            txtSexoClienteVendaF.Text = txtSexoClienteVenda.Text;
            txtCPFClienteVendaF.Text = txtCPFClienteVenda.Text;
            txtNascimentoClienteVendaF.Text = txtNascimentoClienteVenda.Text;
            txtTelefoneClienteVendaF.Text = txtTelefoneClienteVenda.Text;
            txtEmailClienteVendaF.Text = txtEmailClienteVenda.Text;

        }

        private void HabilitarCamposAdicionarCliente(bool Valor)
        {

            txtCodigoClienteVenda.Enabled = false;
            txtNomeClienteVenda.Enabled = false;
            txtSexoClienteVenda.Enabled = false;
            txtCPFClienteVenda.Enabled = false;
            txtNascimentoClienteVenda.Enabled = false;
            txtTelefoneClienteVenda.Enabled = false;
            txtEmailClienteVenda.Enabled = false;


            cboxBuscarClienteVenda.Enabled = Valor;
            txtBuscarClienteVenda.Enabled = Valor;
            btnBuscarClienteVenda.Enabled = Valor;

            dgvClienteVenda.Enabled = Valor;
        }


        private void HabilitarCamposAdicionarProduto(bool Valor)
        {

            txtBuscarProdutoVenda.Enabled = Valor;
            btnBuscarProdutoVenda.Enabled = Valor;
            dgvProdutoVenda.Enabled = Valor;

            txtCodigoProdutoVenda.Enabled = false;
            txtNomeProdutoVenda.Enabled = false;
            txtDescricaoProdutoVenda.Enabled = false;
            txtPrecoProdutoVenda.Enabled = false;
            txtCategoriaProdutoVenda.Enabled = false;
            txtQuantidadeProdutoVenda.Enabled = false;

            btnConfirmarProdutoVenda.Enabled = false;
            btnCancelarProdutoVenda.Enabled = false;

            chkDeletarItemVenda.Enabled = false;
            dgvItensVenda.Enabled = Valor;
            btnExcluirItemVenda.Enabled = false;

            btnRealizarPagamentoVenda.Enabled = Valor;

            dgvItensVenda.Columns[0].Visible = false;
        }

        // Habilitar os text box
        private void HabilitarCamposFinalizarVenda(bool Valor)
        {
            txtCodigoFuncionarioVendaF.Text = "1";
            txtCodigoFuncionarioVendaF.Enabled = false;
            txtNomeFuncionarioVendaF.Enabled = false;

            txtCodigoClienteVendaF.Enabled = false;
            txtNomeClienteVendaF.Enabled = false;
            txtSexoClienteVendaF.Enabled = false;
            txtCPFClienteVendaF.Enabled = false;
            txtNascimentoClienteVendaF.Enabled = false;
            txtTelefoneClienteVendaF.Enabled = false;
            txtEmailClienteVendaF.Enabled = false;


            dgvItensVendaF.Enabled = false;
            txtObservacoesVendaF.Enabled = Valor;
            cboxTipoPagamentoVendaF.Enabled = Valor;
            txtTaxaEntregaVendaF.Enabled = Valor;
            txtValorTotalVendaF.Enabled = false;

            btnCancelarVenda.Enabled = Valor;
            btnFinalizarVenda.Enabled = Valor;
        }

        // Habilitar os botões cliente
        private void BotoesCliente()
        {
            if (eNovo || eEditar)
            {
                btnConfirmarClienteVenda.Enabled = false;
                btnAlterarClienteVenda.Enabled = false;
                btnNovaVenda.Enabled = false;
            }
            else
            {
                btnConfirmarClienteVenda.Enabled = false;
                btnAlterarClienteVenda.Enabled = false;
                btnNovaVenda.Enabled = true;
            }
        }

        // Habilitar os botões produto
        private void BotoesProdutos()
        {
            if (eNovo || eEditar)
            {
                HabilitarCamposFinalizarVenda(true);
                btnFinalizarVenda.Enabled = true;
                btnCancelarProdutoVenda.Enabled = true;
                btnConfirmarProdutoVenda.Enabled = true;
            }
            else
            {
                HabilitarCamposFinalizarVenda(false);
                btnFinalizarVenda.Enabled = false;
                btnCancelarProdutoVenda.Enabled = false;
                btnConfirmarProdutoVenda.Enabled = false;
            }
        }

        private void InserirVenda()
        {
            try
            {
                string resp = "";

                if (txtNomeClienteVenda.Text == string.Empty)
                {
                    MensagemErro("Selecione um cliente");
                }
                else
                {
                    resp = "OK";
                    if (txtObservacoesVendaF.Text == string.Empty)
                    {
                        txtObservacoesVendaF.Text = "Sem Observações";
                    }

                    if (cboxTipoPagamentoVendaF.Text == string.Empty)
                    {
                        cboxTipoPagamentoVendaF.Text = null;
                    }

                    if (txtTaxaEntregaVendaF.Text == string.Empty)
                    {
                        txtTaxaEntregaVendaF.Text = "0,00";
                    }


                    if (eNovo)
                    {
                        btnConfirmarProdutoVenda.Enabled = false;
                    }

                    if (eEditar)
                    {
                        myVenda = new ControlVenda(txtCodigoClienteVenda.Text, txtCodigoFuncionarioVenda.Text, lbData.Text);

                        ID_Venda = myVenda.RetorneVendaNull();
                        action = "inserir";
                        foreach (DataGridViewRow row in dgvItensVendaF.Rows)
                        {

                            double vl_SubTotal = Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[3].Value);
                            myItemVenda = new ControlItemVenda(action, ID_Venda, Convert.ToString(row.Cells[1].Value), Convert.ToString(row.Cells[3].Value), vl_SubTotal);
                            resp = myItemVenda.DS_Mensagem;
                        }

                        myVenda = new ControlVenda(txtCodigoFuncionarioVenda.Text,txtCodigoClienteVenda.Text, txtObservacoesVendaF.Text,
                        cboxTipoPagamentoVendaF.Text, txtTaxaEntregaVendaF.Text, txtValorTotalVendaF.Text);
                        resp = myVenda.DS_Mensagem;
                        MostrarEstoque();
                        MostrarEstoqueDiversos();


                        if (resp.Equals("OK"))
                        {
                            foreach (DataGridViewRow row in dgvItensVendaF.Rows)
                            {
                                ValidarQuantidadeInsumo(Convert.ToString(row.Cells[1].Value), Convert.ToInt32(row.Cells[3].Value), Convert.ToString(row.Cells[5].Value));
                            }
                        }

                    }

                    if (resp != "OK")
                    {
                        MensagemErro(resp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void InserirItemVenda()
        {
            try
            {
                string resp = "";

                if (eNovo)
                {
                    errorIcone.Clear();
                    dtItemVenda.Rows.Add(ID_Venda, txtCodigoProdutoVenda.Text, txtNomeProdutoVenda.Text, txtQuantidadeProdutoVenda.Text, txtPrecoProdutoVenda.Text, txtDiversos.Text);



                    resp = "OK";
                }

                if (resp.Equals("OK"))
                {
                    myItemVenda = new ControlItemVenda();
                    MostrarItemVenda();
                }
                else
                {
                    MensagemErro(resp);
                }

                eNovo = false;
                eEditar = false;
                BotoesCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void MostrarClientes()
        {
            myCliente = new ControlCliente();
            status = "1";
            dgvClienteVenda.DataSource = myCliente.MostrarCliente(status);

            dgvClienteVenda.Columns[0].HeaderText = "CÓDIGO";
            dgvClienteVenda.Columns[1].HeaderText = "NOME";
            dgvClienteVenda.Columns[2].HeaderText = "CPF";
            dgvClienteVenda.Columns[3].HeaderText = "TELEFONE";
            dgvClienteVenda.Columns[4].Visible = false;
            dgvClienteVenda.Columns[5].Visible = false;
            dgvClienteVenda.Columns[6].HeaderText = "DATA NASCIMENTO";



            dgvClienteVenda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvClienteVenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            HabilitarDataGridViewCliente();
        }

        private void CarregarDataTableColumns()
        {



            dtItemVenda = new DataTable();
            dtItemVenda.Columns.Add("ID_Venda");
            dtItemVenda.Columns.Add("ID_Produto");
            dtItemVenda.Columns.Add("NM_Produto");
            dtItemVenda.Columns.Add("QTDE_ItemVenda");
            dtItemVenda.Columns.Add("VL_SubTotal");
            dtItemVenda.Columns.Add("Diversos");


        }

        private void MostrarItemVenda()
        {
            dgvItensVenda.DataSource = dtItemVenda;
            dgvItensVenda.Columns[1].Visible = false;
            dgvItensVenda.Columns[2].HeaderText = "CÓDIGO\nPRODUTO";
            dgvItensVenda.Columns[3].HeaderText = "NOME";
            dgvItensVenda.Columns[4].HeaderText = "QUANTIDADE";
            dgvItensVenda.Columns[5].HeaderText = "PREÇO";
            dgvItensVenda.Columns[6].Visible = false;

            dgvItensVenda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvItensVenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            HabilitarDataGridViewItemVenda();

        }


        private void MostrarProduto(string diversos)
        {
            myProduto = new ControlProduto();

            if (diversos.Equals(""))
            {
                dgvProdutoVenda.DataSource = myProduto.MostrarProduto(status);

            }
            else
            {
                dgvProdutoVenda.DataSource = myProduto.MostrarProduto(status, diversos);
            }


            dgvProdutoVenda.Columns[0].HeaderText = "CÓDIGO";
            dgvProdutoVenda.Columns[1].HeaderText = "CATEGORIA";
            dgvProdutoVenda.Columns[2].HeaderText = "NOME";
            dgvProdutoVenda.Columns[3].HeaderText = "PREÇO";
            dgvProdutoVenda.Columns[4].Visible = false;
            dgvProdutoVenda.Columns[5].HeaderText = "DESCRIÇÃO";
            dgvProdutoVenda.Columns[6].Visible = false;
            dgvProdutoVenda.Columns[7].Visible = false;


            dgvProdutoVenda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProdutoVenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            HabilitarDataGridViewProduto();
        }

        private void MostrarItemVendaFinal()
        {
            dgvItensVendaF.DataSource = dtItemVenda;

            dgvItensVendaF.Columns[0].Visible = false;
            dgvItensVendaF.Columns[1].HeaderText = "CÓDIGO\nPRODUTO";
            dgvItensVendaF.Columns[2].HeaderText = "NOME";
            dgvItensVendaF.Columns[3].HeaderText = "QUANTIDADE";
            dgvItensVendaF.Columns[4].HeaderText = "PREÇO";
            dgvItensVendaF.Columns[5].Visible = false;

            CalcularVenda();

            dgvItensVendaF.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvItensVendaF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarFichaTecnica(string campo)
        {
            myFichaTecnica = new ControlFichaTecnica();
            dtFcihaTecnica = new DataTable();
            dtFcihaTecnica = myFichaTecnica.MostrarFichaTecnica(campo);


        }


        private void MostrarEstoqueDiversos()
        {
            myEstoqueDiversos = new ControlEstoqueDiversos();
            dtEstoqueDiversos = new DataTable();
            dtEstoqueDiversos = myEstoqueDiversos.MostrarEstoque();


        }

        private void MostrarEstoque()
        {
            myEstoque = new ControlEstoque();
            dtEstoque = new DataTable();
            dtEstoque = myEstoque.MostrarEstoque();
        }

        private void ValidarTamanhoCampo(TextBox campo, int tamanho)
        {
            string tamanhovalido = Convert.ToString(campo.Text);
            myValidar.TamanhoCampo(tamanhovalido, tamanho);

            if (myValidar.TamanhoValido == false)
            {
                errorIcone.SetError(campo, "Limite de caracteres excedido" +
                                            "\nO limite para este campo é: " + tamanho + " caracteres" +
                                            "\nQuantidade utilizada: " + campo.TextLength);
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }

        private void ValidarCampoNulo(TextBox campo)
        {
            string campovalido = Convert.ToString(campo.Text);
            myValidar.CampoNulo(campovalido);

            if (myValidar.CampoValido == false)
            {
                errorIcone.SetError(campo, "Este campo é obrigatório");
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }

        private void ValidarValorComZero(TextBox campo)
        {
            string valorcomzerovalido = Convert.ToString(campo.Text);
            myValidar.ValorComZero(valorcomzerovalido);

            if (myValidar.ValorValido == false)
            {
                errorIcone.SetError(campo, "Este campo deve ser preenchido somente com números, vírgulas e pontos." +
                                            "\nVerifique também a disposição dos números conforme Ex: 000.000,00");
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }

        private void ValidarNumero(TextBox campo)
        {
            string numerovalido = Convert.ToString(campo.Text);
            myValidar.Numero(numerovalido);

            if (myValidar.NumeroValido == false)
            {
                errorIcone.SetError(campo, "Este campo deve ser preenchido somente com números");
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }

        private void CalcularVenda()
        {
            double subtotalVenda = 0;
            double quantidade = 0;
            double subTotal = 0;

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                subtotalVenda = Convert.ToDouble(row.Cells["VL_SubTotal"].Value);
                quantidade = Convert.ToDouble(row.Cells["QTDE_ItemVenda"].Value);

                subTotal += subtotalVenda * quantidade;

                txtSubTotalVenda.Text = subTotal.ToString("N2");

            }

            if (dgvItensVenda.Rows.Count < 1)
            {
                txtSubTotalVenda.Text = string.Empty;
            }

            double totalVenda = 0;
            double totalVendaF = 0;

            foreach (DataGridViewRow row in dgvItensVendaF.Rows)
            {
                totalVenda = Convert.ToDouble(row.Cells["VL_SubTotal"].Value);
                quantidade = Convert.ToDouble(row.Cells["QTDE_ItemVenda"].Value);
                totalVendaF += totalVenda * quantidade;


            }
            ValidarValorComZero(txtTaxaEntregaVendaF);
            if (myValidar.ValorValido == true)
            {
                totalVendaF += Convert.ToDouble(txtTaxaEntregaVendaF.Text);
                txtValorTotalVendaF.Text = totalVendaF.ToString("N2");
            }
        }

        private void ValidarQuantidadeInsumo(string id_produto, int qtde_itemvenda, string diversos)
        {
            bool ExisteEstoque = false;
            MostrarFichaTecnica(id_produto);
            if (dtFcihaTecnica.Rows.Count > 0)
            {
                for (int i = 0; i < dtFcihaTecnica.Rows.Count; i++)
                {
                    for (int j = 0; j < dtEstoque.Rows.Count; j++)
                    {
                        if (dtFcihaTecnica.Rows[i]["ID_Insumo"].Equals(dtEstoque.Rows[j]["ID_Insumo"]))
                        {
                            ID_Insumo = Convert.ToString(dtFcihaTecnica.Rows[i]["ID_Insumo"]);

                            double QuantidadeUtilizada = Convert.ToDouble(dtFcihaTecnica.Rows[i]["QTDE_Utilizada"]);
                            QuantidadeUtilizada *= qtde_itemvenda;

                            double QuantidadeTotalEstoque = Convert.ToDouble(dtEstoque.Rows[j]["QTDE_Estoque"]);

                            if (QuantidadeUtilizada > QuantidadeTotalEstoque)
                            {
                                double insumoInsuficiente = QuantidadeUtilizada - QuantidadeTotalEstoque;

                                MensagemErro("Insumo insuficiente" +
                                    "\nInsumo : " + dtFcihaTecnica.Rows[i]["NM_Insumo"] +
                                    "\nFaltaram " + insumoInsuficiente.ToString("N2") + " " +
                                    dtFcihaTecnica.Rows[i]["DS_TipoArmazenamento"]);

                                ValidarInsumoOK = false;
                                j = dtEstoque.Rows.Count;
                                i = dtFcihaTecnica.Rows.Count;
                            }


                            else
                            {
                                ValidarInsumoOK = true;

                                if (eNovo)
                                {
                                    QuantidadeTotalEstoque = QuantidadeTotalEstoque - QuantidadeUtilizada;
                                    dtEstoque.Columns["QTDE_Estoque"].ReadOnly = false;
                                    dtEstoque.Rows[j]["QTDE_Estoque"] = QuantidadeTotalEstoque;

                                    MensagemOk("Estoque de:  " + dtFcihaTecnica.Rows[i]["NM_Insumo"] + "\n Esta com: " + dtEstoque.Rows[j]["QTDE_Estoque"] + " " + dtFcihaTecnica.Rows[i]["DS_TipoArmazenamento"]);
                                }
                                if (eEditar)
                                {
                                    QuantidadeTotalEstoque = QuantidadeTotalEstoque - QuantidadeUtilizada;
                                    dtEstoque.Columns["QTDE_Estoque"].ReadOnly = false;
                                    dtEstoque.Rows[j]["QTDE_Estoque"] = QuantidadeTotalEstoque;

                                    string qtde_utilizada = Convert.ToString(QuantidadeUtilizada);
                                    action = "baixa";
                                    myEstoque = new ControlEstoque(action, ID_Insumo, qtde_utilizada);
                                }

                            }
                        }
                    }
                }
            }
            else
            {

                if (diversos == "True")
                {
                    MostrarEstoqueDiversos();



                    for (int i = 0; i < dtEstoqueDiversos.Rows.Count; i++)
                    {


                        if (Convert.ToString(dtEstoqueDiversos.Rows[i]["ID_Produto"]).Equals(id_produto))
                        {
                            ExisteEstoque = true;
                            double QuantidadeTotalEstoque = Convert.ToDouble(dtEstoqueDiversos.Rows[i]["QTDE_Estoque"]);

                            double QuantidadeVenda = Convert.ToDouble(qtde_itemvenda);

                            if (QuantidadeVenda > QuantidadeTotalEstoque)
                            {
                                double UnidadeInsuficiente = QuantidadeVenda - QuantidadeTotalEstoque;

                                MensagemErro("Produto insuficiente" +
                                    "\nProduto :  " + dtEstoqueDiversos.Rows[i]["NM_Produto"] +
                                    "\nFaltaram:  " + UnidadeInsuficiente + " " + " Unidades");

                                ValidarInsumoOK = false;
                            }
                            else
                            {
                                ValidarInsumoOK = true;

                                if (eNovo)
                                {
                                    QuantidadeTotalEstoque = QuantidadeTotalEstoque - QuantidadeVenda;
                                    dtEstoqueDiversos.Columns["QTDE_Estoque"].ReadOnly = false;
                                    dtEstoqueDiversos.Rows[i]["QTDE_Estoque"] = QuantidadeTotalEstoque;

                                    MensagemOk("Estoque de:  " + dtEstoqueDiversos.Rows[i]["NM_Produto"] + "\n Esta com: " + dtEstoqueDiversos.Rows[i]["QTDE_Estoque"] + " Unidades ");
                                    break;

                                }
                                if (eEditar)
                                {
                                    QuantidadeTotalEstoque = QuantidadeTotalEstoque - QuantidadeVenda;
                                    dtEstoqueDiversos.Columns["QTDE_Estoque"].ReadOnly = false;
                                    dtEstoqueDiversos.Rows[i]["QTDE_Estoque"] = QuantidadeTotalEstoque;
                                    string qtde_utilizada = Convert.ToString(QuantidadeVenda);
                                    action = "baixa";
                                    myEstoqueDiversos = new ControlEstoqueDiversos(action, id_produto, qtde_utilizada);
                                    break;

                                }

                            }
                        }

                    }

                    if (ExisteEstoque == false)
                    {
                        DialogResult Opcao;
                        Opcao = MessageBox.Show(
                            "Não existe estoque deste produto : " + " " + txtNomeProdutoVenda.Text + "\n Deseja realizar a venda deste produto? Não ocorrera baixa em estoque",
                            "SAWABONA",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (Opcao == DialogResult.Yes)
                        {
                            ValidarInsumoOK = true;

                        }
                    }
                }
                else
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show(
                        "Este produto não tem ficha técnica: " + " " + txtNomeProdutoVenda.Text + "\n Deseja realizar a venda deste produto? Não ocorrera baixa em estoque",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {
                        ValidarInsumoOK = true;

                    }

                }
            }
        }
        private void RetornoEstoque()
        {
            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    MostrarFichaTecnica(Convert.ToString(row.Cells["ID_Produto"].Value));
                    double QTDE_ItemVenda = Convert.ToDouble(row.Cells["QTDE_ItemVenda"].Value);

                    for (int i = 0; i < dtFcihaTecnica.Rows.Count; i++)
                    {

                        double QuantidadeUtilizada = Convert.ToDouble(dtFcihaTecnica.Rows[i]["QTDE_Utilizada"]);

                        QuantidadeUtilizada = QuantidadeUtilizada * QTDE_ItemVenda;
                        dtEstoque.Columns["QTDE_Estoque"].ReadOnly = false;

                        for (int j = 0; j < dtEstoque.Rows.Count; j++)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                if (dtFcihaTecnica.Rows[i]["ID_Insumo"].Equals(dtEstoque.Rows[j]["ID_Insumo"]))
                                {
                                    dtEstoque.Rows[j]["QTDE_Estoque"] = Convert.ToDouble(dtEstoque.Rows[j]["QTDE_Estoque"]) + QuantidadeUtilizada;
                                    MensagemOk("Estoque de:  " + dtFcihaTecnica.Rows[i]["NM_Insumo"] + "\n Esta com: " + dtEstoque.Rows[j]["QTDE_Estoque"] + dtFcihaTecnica.Rows[i]["DS_TipoArmazenamento"]);
                                }
                            }
                        }

                    }
                }
            }
        }

        public void ValidarVenda()
        {
            myVenda = new ControlVenda();
            myVenda.ValidarVenda();
        }

        private void ViewVenda_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            OcultarTabProdutos();
            OcultarTabVenda();
            LimparDadosCliente();
            LimparDadosProduto();
            LimparDadosVenda();
            HabilitarCamposAdicionarCliente(false);
            HabilitarCamposAdicionarProduto(false);
            HabilitarCamposFinalizarVenda(false);
            dgvClienteVenda.DataSource = "";
            dgvProdutoVenda.DataSource = "";
            dgvItensVenda.DataSource = "";
            dgvItensVendaF.DataSource = "";
            BotoesCliente();
            BotoesProdutos();
            CarregarDataTableColumns();
            MostrarEstoque();

        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            ValidarVenda();
            txtNomeFuncionario.Text = NM_Funcionario;
            txtCodigoFuncionarioVenda.Text = Convert.ToString(ID_Funcionario);
            OcultarTabVenda();
            OcultarTabProdutos();
            MensagemOk("Nova venda iniciada");
            HabilitarCamposAdicionarCliente(true);
            eEditar = false;
            BotoesCliente();
            btnNovaVenda.Enabled = false;
            MostrarClientes();
            CarregarDataTableColumns();
            MostrarEstoque();

        }

        private void cboBuscarClienteVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarClienteVenda.Text = string.Empty;
        }

        private void txtBuscarClienteVenda_TextChanged(object sender, EventArgs e)
        {
            if (cboxBuscarClienteVenda.Text.Equals("Nome"))
            {
                BuscarNomeCliente();
            }
            else if (cboxBuscarClienteVenda.Text.Equals("CPF"))
            {
                BuscasCPFCliente();
            }
        }

        private void btnBuscarClienteVenda_Click(object sender, EventArgs e)
        {
            if (cboxBuscarClienteVenda.Text.Equals("Nome"))
            {
                BuscarNomeCliente();
            }
            else if (cboxBuscarClienteVenda.Text.Equals("CPF"))
            {
                BuscasCPFCliente();
            }
        }

        private void dgvClienteVenda_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["ID_Cliente"].Value);
            txtNomeClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["NM_Cliente"].Value);
            txtNascimentoClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["DT_Nascimento"].Value);
            txtSexoClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["DS_Sexo"].Value);
            txtCPFClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["NR_CPF"].Value);
            txtTelefoneClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["NR_Telefone"].Value);
            txtEmailClienteVenda.Text = Convert.ToString(dgvClienteVenda.CurrentRow.Cells["DS_Email"].Value);

            btnConfirmarClienteVenda.Enabled = true;
            btnAlterarClienteVenda.Enabled = true;
        }

        private void btnConfirmarClienteVenda_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show(
                    "Deseja selecionar o cliente:\n" + txtNomeClienteVenda.Text + "\npara realizar a venda?",
                    "SAWABONA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (Opcao == DialogResult.Yes)
                {
                    TranferirDadosCliente();

                    btnAlterarClienteVenda.Enabled = false;
                    btnConfirmarClienteVenda.Enabled = false;
                    HabilitarCamposAdicionarCliente(false);

                    eNovo = true;
                    InserirVenda();
                    HabilitarCamposAdicionarProduto(true);
                    MostrarTabProdutos();
                    tctrlVenda.SelectedIndex = 1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAlterarClienteVenda_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult Opcao;
                Opcao = MessageBox.Show(
                    "Deseja alterar o cliente selecionado?",
                    "SAWABONA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (Opcao == DialogResult.Yes)
                {
                    LimparDadosCliente();

                    btnAlterarClienteVenda.Enabled = false;
                    btnConfirmarClienteVenda.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtBuscarProdutoVenda_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeProduto();
        }

        private void btnBuscarProdutoVenda_Click(object sender, EventArgs e)
        {
            BuscarNomeProduto();
        }

        private void dgvProdutoVenda_DoubleClick(object sender, EventArgs e)
        {
            bool produtoInvalido = false;

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                if (dgvProdutoVenda.CurrentRow.Cells["NM_Produto"].Value.Equals(row.Cells["NM_Produto"].Value))
                {
                    MensagemErro("Este produto já foi adicionado na venda");
                    LimparDadosProduto();
                    produtoInvalido = true;
                }
            }
            if (produtoInvalido == false)
            {
                txtQuantidadeProdutoVenda.Enabled = true;
                txtCodigoProdutoVenda.Text = Convert.ToString(dgvProdutoVenda.CurrentRow.Cells["ID_Produto"].Value);
                txtNomeProdutoVenda.Text = Convert.ToString(dgvProdutoVenda.CurrentRow.Cells["NM_Produto"].Value);
                txtDescricaoProdutoVenda.Text = Convert.ToString(dgvProdutoVenda.CurrentRow.Cells["DS_Produto"].Value);
                txtPrecoProdutoVenda.Text = (Convert.ToDouble(dgvProdutoVenda.CurrentRow.Cells["PR_Unitario"].Value)).ToString("F2");
                txtCategoriaProdutoVenda.Text = Convert.ToString(dgvProdutoVenda.CurrentRow.Cells["NM_Categoria"].Value);
                txtDiversos.Text = Convert.ToString(dgvProdutoVenda.CurrentRow.Cells["Diversos"].Value);
                byte[] imag;
                try
                {
                    if (dgvProdutoVenda.CurrentRow.Cells["IMG_Produto"].Value != DBNull.Value)
                    {
                        imag = (byte[])dgvProdutoVenda.CurrentRow.Cells["IMG_Produto"].Value;

                        MemoryStream ms = new MemoryStream(imag);

                        Image Imagem = Image.FromStream(ms);
                        pbProdutoVenda.Image = Imagem;
                        pbProdutoVenda.Visible = true;
                    }
                    else
                    {
                        imag = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                txtQuantidadeProdutoVenda.Enabled = true;
                btnCancelarProdutoVenda.Enabled = true;
                btnConfirmarProdutoVenda.Enabled = true;
            }
        }

        private void btnConfirmarProdutoVenda_Click(object sender, EventArgs e)
        {
            bool QuantidadeProdutoVendaOk = false;

            ValidarCampoNulo(txtQuantidadeProdutoVenda);
            if (myValidar.CampoValido == true)
            {
                ValidarNumero(txtQuantidadeProdutoVenda);
                if (myValidar.NumeroValido == true)
                {
                    if (Convert.ToInt32(txtQuantidadeProdutoVenda.Text) < 1)
                    {
                        errorIcone.SetError(txtQuantidadeProdutoVenda, "A quantidade não pode ser menor ou igual a 0 (zero)");
                    }
                    else
                    {
                        QuantidadeProdutoVendaOk = true;
                    }
                }
            }

            if (QuantidadeProdutoVendaOk == false)
            {
                MensagemErro("Por favor, preencha corretamente a quantidade a ser adicionada na venda");
            }
            else
            {
                errorIcone.Clear();
                eNovo = true;

                try
                {
                    ValidarQuantidadeInsumo(txtCodigoProdutoVenda.Text, Convert.ToInt32(txtQuantidadeProdutoVenda.Text), txtDiversos.Text);
                    if (ValidarInsumoOK == true)
                    {
                        DialogResult Opcao;
                        Opcao = MessageBox.Show("Deseja adicionar este produto na venda?",
                            "SAWABONA",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (Opcao == DialogResult.Yes)
                        {
                            InserirItemVenda();

                            LimparDadosProduto();
                            btnConfirmarProdutoVenda.Enabled = false;
                            btnCancelarProdutoVenda.Enabled = false;
                            txtQuantidadeProdutoVenda.Enabled = false;
                            chkDeletarItemVenda.Enabled = true;

                            CalcularVenda();
                            MostrarItemVenda();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void btnCancelarProdutoVenda_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Deseja cancelar o produto selecionado?",
                    "SAWABONA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (Opcao == DialogResult.Yes)
                {
                    errorIcone.SetError(txtQuantidadeProdutoVenda, string.Empty);

                    LimparDadosProduto();

                    txtQuantidadeProdutoVenda.Enabled = false;

                    btnCancelarProdutoVenda.Enabled = false;
                    btnConfirmarProdutoVenda.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnExcluirItemVenda_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há itens selecionados para excluir");
            }
            else
            {
                try
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show("Realmente deseja excluir o item da venda?",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {

                        string resp = "";

                        RetornoEstoque();

                        foreach (DataGridViewRow row in dgvItensVenda.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {

                                dgvItensVenda.Rows.Remove(row);
                                resp = "OK";
                            }
                        }

                        if (resp.Equals("OK"))
                        {
                            MensagemOk("Item excluído com sucesso");

                        }
                        else
                        {
                            MensagemErro(resp);
                        }
                        MostrarItemVenda();
                        CalcularVenda();
                        chkDeletarItemVenda.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void dgvItensVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvItensVenda.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvItensVenda.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void chkDeletarItemVenda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarItemVenda.Checked)
            {
                dgvItensVenda.Columns[0].Visible = true;
                btnExcluirItemVenda.Enabled = true;
            }
            else
            {
                dgvItensVenda.Columns[0].Visible = false;
                btnExcluirItemVenda.Enabled = false;
            }
        }

        private void btnRealizarPagamentoVenda_Click(object sender, EventArgs e)
        {

            if (dgvItensVenda.Rows.Count == 0)
            {
                MensagemErro("Não há itens adicionados na venda");
            }
            else
            {
                CalcularVenda();
                btnRealizarPagamentoVenda.Enabled = false;
                HabilitarCamposFinalizarVenda(true);
                MostrarTabVenda();
                tctrlVenda.SelectedIndex = 2;

                MostrarItemVendaFinal();
                txtNomeFuncionarioVendaF.Text = NM_Funcionario;
                txtCodigoFuncionarioVendaF.Text = Convert.ToString(ID_Funcionario);
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Realmente deseja excluir esta venda? \nTodos os dados serão apagados.",
                    "SAWABONA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (Opcao == DialogResult.Yes)
                {
                    AllClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            MostrarItemVendaFinal();

            if (dgvItensVendaF.Rows.Count < 1)
            {
                MensagemErro("Não há itens na venda");
            }
            else
            {
                bool ObservacoesVendaFOK = false;
                bool TipoPagamentoVendaFOK = false;
                bool TaxaEntregaVendaFOK = false;

                if (txtObservacoesVendaF.Text != string.Empty)
                {
                    ValidarTamanhoCampo(txtObservacoesVendaF, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        ObservacoesVendaFOK = true;
                    }
                }

                if (cboxTipoPagamentoVendaF.SelectedIndex < 0)
                {
                    errorIcone.SetError(cboxTipoPagamentoVendaF, "Selecione o tipo de pagamento");
                }
                else
                {
                    errorIcone.SetError(cboxTipoPagamentoVendaF, string.Empty);
                    TipoPagamentoVendaFOK = true;
                }

                ValidarCampoNulo(txtTaxaEntregaVendaF);
                if (myValidar.CampoValido == true)
                {
                    ValidarValorComZero(txtTaxaEntregaVendaF);
                    if (myValidar.ValorValido == true)
                    {
                        TaxaEntregaVendaFOK = true;
                    }
                }

                if (ObservacoesVendaFOK == false ||
                    TipoPagamentoVendaFOK == false ||
                    TaxaEntregaVendaFOK == false)
                {
                    MensagemErro("Por favor, preencha corretamente os campos sinalizados");
                }
                else
                {
                    try
                    {
                        errorIcone.Clear();
                        eNovo = false;
                        eEditar = true;
                        InserirVenda();
                        MensagemOk("Venda realizada! Retornando a tela inicial...");

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }

                    AllClear();


                }
            }
        }

        private void txtTaxaEntregaVendaF_TextChanged(object sender, EventArgs e)
        {
            ValidarValorComZero(txtTaxaEntregaVendaF);
            if (myValidar.ValorValido == true)
            {
                CalcularVenda();
            }
        }

        private void btnAtualizarItemVendaF_Click(object sender, EventArgs e)
        {
            dgvItensVendaF.DataSource = "";

            MostrarItemVendaFinal();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbData.Text = DateTime.Now.ToLongTimeString();
        }

        private void cbVisualizarProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVisualizarProdutos.Text.Equals("Produtos manipulados"))
            {
                diversos = "0";
                MostrarProduto(diversos);
            }
            if (cbVisualizarProdutos.Text.Equals("Produtos diversos"))
            {
                diversos = "1";
                MostrarProduto(diversos);
            }
            if (cbVisualizarProdutos.Text.Equals("Ambos"))
            {
                diversos = "";
                MostrarProduto(diversos);
            }
        }
    }
}
