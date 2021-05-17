using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ViewCompra : Form
    {
        ControlCompra myCompra;
        ControlCompraDiversos myCompraDiversos;
        ControlProduto myProduto;
        ControlEstoque myEstoque;
        ControlEstoqueDiversos myEstoqueDiversos;
        ControlInsumo myInsumo;
        Validar myValidar = new Validar();
        DataTable dtInsumo;
        DataTable dtEstoque;
        private bool eNovo = false;
        private bool eEditar = false;
        public string action { get; set; }
        public string ID_Compra { get; set; }
        public string ID_Produto { get; set; }

        public double QTDE_Insumo { get; set; }

        public string ID_Insumo { get; set; }



        public ViewCompra()
        {
            InitializeComponent();
        }


        private void MensagemOk(string mensagem)
        {
            MessageBox.Show(mensagem, "SAWABONA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "SAWABONA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Limpar campos
        private void Limpar()
        {
            txtCodigoCompra.Text = string.Empty;
            cboxInsumoCompra.DataSource = null;
            cbSelecioneInsumoProduto.Text = null;

            dtCompra.Value = DateTime.Today;
            txtQuantidadeInsumoCompra.Text = string.Empty;
        }

        // Habilitar os text box
        private void Habilitar(bool Valor)
        {
            if (eNovo)
            {
                txtCodigoCompra.Enabled = false;
                cboxInsumoCompra.Enabled = Valor;
                dtCompra.Enabled = false;
                txtQuantidadeInsumoCompra.Enabled = Valor;
            }
            if (eEditar)
            {
                txtCodigoCompra.Enabled = false;
                cboxInsumoCompra.Enabled = false;
                dtCompra.Enabled = false;
                txtQuantidadeInsumoCompra.Enabled = Valor;
            }
            else
            {
                txtCodigoCompra.Enabled = false;
                cboxInsumoCompra.Enabled = Valor;
                dtCompra.Enabled = false;
                txtQuantidadeInsumoCompra.Enabled = Valor;
                cbSelecioneInsumoProduto.Enabled = Valor;
            }

        }

        // Habilitar os botões
        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovaCompra.Enabled = false;
                btnSalvarCompra.Enabled = true;
                btnCancelarCompra.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovaCompra.Enabled = true;
                btnSalvarCompra.Enabled = false;
                btnCancelarCompra.Enabled = false;
            }
        }

        private void OcultarColunas()
        {
            dgvCompra.Columns[0].Visible = false;
        }


        private void OcultarColunasDiversos()
        {
            dgvCompraDiversos.Columns[0].Visible = false;
        }

        private void MostrarCompra()
        {
            myCompra = new ControlCompra();
            dgvCompra.DataSource = myCompra.MostrarCompra();
            OcultarColunas();
            lblTotalCompra.Text = "Total de Registros:  " + Convert.ToString(dgvCompra.Rows.Count);

            dgvCompra.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvCompra.Columns[1].HeaderText = "CODIGO";
            dgvCompra.Columns[2].HeaderText = "INSUMO";
            dgvCompra.Columns[3].Visible = false;
            dgvCompra.Columns[4].HeaderText = "DATA";
            dgvCompra.Columns[5].HeaderText = "QUANTIDADE";


            dgvCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HabilitarDataGridView();
        }

        private void MostrarCompraDiversos()
        {
            myCompraDiversos = new ControlCompraDiversos();
            dgvCompraDiversos.DataSource = myCompraDiversos.MostrarCompra();
            OcultarColunasDiversos();
            lblTotalCompraDiversos.Text = "Total de Registros:  " + Convert.ToString(dgvCompraDiversos.Rows.Count);

            dgvCompraDiversos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvCompraDiversos.Columns[1].HeaderText = "CODIGO";
            dgvCompraDiversos.Columns[2].HeaderText = "PRODUTO";
            dgvCompraDiversos.Columns[3].Visible = false;
            dgvCompraDiversos.Columns[4].HeaderText = "DATA";
            dgvCompraDiversos.Columns[5].HeaderText = "QUANTIDADE";


            dgvCompraDiversos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompraDiversos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HabilitarDataGridViewDiversos();
        }

        private void HabilitarDataGridView()
        {
            if (dgvCompra.Rows.Count == 0)
            {
                chkDeletarCompra.Enabled = false;
                btnDeletarCompra.Enabled = false;
                cboBuscarCompra.Enabled = false;
                txtBuscarNomeProduto.Enabled = false;
                btnBuscarCompra.Enabled = false;
                dgvCompra.Enabled = false;
                dtBuscarCompra.Enabled = false;
            }
            else
            {
                chkDeletarCompra.Enabled = true;
                btnDeletarCompra.Enabled = true;
                cboBuscarCompra.Enabled = true;
                txtBuscarNomeProduto.Enabled = true;
                btnBuscarCompra.Enabled = true;
                dgvCompra.Enabled = true;
                dtBuscarCompra.Enabled = true;

            }
        }

        private void HabilitarDataGridViewDiversos()
        {
            if (dgvCompraDiversos.Rows.Count == 0)
            {
                chkDeletarComprasDiversos.Enabled = false;
                btnDeletarCompraDiversos.Enabled = false;
                cbBuscarCompraDiversos.Enabled = false;
                txtBuscarNomeProduto.Enabled = false;
                btnBuscarCompraDiversos.Enabled = false;
                dgvCompraDiversos.Enabled = false;
                dtBuscarCompraDiversos.Enabled = false;
            }
            else
            {
                chkDeletarComprasDiversos.Enabled = true;
                btnDeletarCompraDiversos.Enabled = true;
                cbBuscarCompraDiversos.Enabled = true;
                txtBuscarNomeProduto.Enabled = true;
                btnBuscarCompraDiversos.Enabled = true;
                dgvCompraDiversos.Enabled = true;
                dtBuscarCompraDiversos.Enabled = true;

            }
        }
        private void MostrarInsumo()
        {
            myInsumo = new ControlInsumo();
            cboxInsumoCompra.DataSource = myInsumo.MostrarInsumo();
            cboxInsumoCompra.DisplayMember = "NM_Insumo";
            cboxInsumoCompra.ValueMember = "ID_Insumo";
        }


        private string ValidarArmazenamentoInsumo(string id_insumo)
        {
            myInsumo = new ControlInsumo();
            dtInsumo = new DataTable();
            dtInsumo = myInsumo.MostrarInsumo();
            string armazenamento = "";
            for (int i = 0; i <= dtInsumo.Rows.Count; i++)
            {
                if (Convert.ToString(dtInsumo.Rows[i]["ID_Insumo"]).Equals(id_insumo))
                {
                    armazenamento = Convert.ToString(dtInsumo.Rows[i]["DS_TipoArmazenamento"]);
                    break;
                }
            }
            return armazenamento;
        }
        private void MostrarProduto()
        {
            string status = "1";
            myProduto = new ControlProduto();
            cboxInsumoCompra.DataSource = myProduto.MostrarProduto(status, status);
            cboxInsumoCompra.DisplayMember = "NM_Produto";
            cboxInsumoCompra.ValueMember = "ID_Produto";
        }
        private void MostrarEstoque()
        {
            myEstoque = new ControlEstoque();
            dtEstoque = new DataTable();
            dtEstoque = myEstoque.MostrarEstoque();
        }

        private void MostrarEstoqueDiversos()
        {
            myEstoqueDiversos = new ControlEstoqueDiversos();
            dtEstoque = new DataTable();
            dtEstoque = myEstoqueDiversos.MostrarEstoque();
        }
        private void BuscarDataCompra()
        {
            myCompra = new ControlCompra();
            dgvCompra.DataSource = myCompra.BuscarDataCompra(dtBuscarCompra.Value.Date);
            OcultarColunas();
            lblTotalCompra.Text = "Total de Registros:  " + Convert.ToString(dgvCompra.Rows.Count);

            dgvCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void BuscarNomeCompra()
        {
            myCompra = new ControlCompra();
            dgvCompra.DataSource = myCompra.BuscarNomeCompra(txtBuscarNomeInsumo.Text);
            OcultarColunas();
            lblTotalCompra.Text = "Total de Registros:  " + Convert.ToString(dgvCompra.Rows.Count);

            dgvCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void BuscarDataCompraDiversos()
        {
            myCompraDiversos = new ControlCompraDiversos();
            dgvCompraDiversos.DataSource = myCompraDiversos.BuscarDataCompra(dtBuscarCompraDiversos.Value.Date);
            OcultarColunas();
            lblTotalCompraDiversos.Text = "Total de Registros:  " + Convert.ToString(dgvCompra.Rows.Count);

            dgvCompraDiversos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompraDiversos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void BuscarNomeCompraDiversos()
        {
            myCompraDiversos = new ControlCompraDiversos();
            dgvCompraDiversos.DataSource = myCompraDiversos.BuscarNomeCompra(txtBuscarNomeProduto.Text);
            OcultarColunas();
            lblTotalCompra.Text = "Total de Registros:  " + Convert.ToString(dgvCompra.Rows.Count);

            dgvCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void ValidarValor(TextBox campo)
        {
            string valorvalido = Convert.ToString(campo.Text);
            myValidar.Valor(valorvalido);

            if (myValidar.ValorValido == false)
            {
                errorIcone.SetError(campo, "Este campo deve ser preenchido somente com números, vírgulas e pontos." +
                                            "\nVerifique também a disposição dos números conforme Ex: 999.999,00");
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }

        private void ValidarNumero(TextBox campo)
        {
            string valorvalido = Convert.ToString(campo.Text);
            myValidar.Numero(valorvalido);

            if (myValidar.ValorValido == false)
            {
                errorIcone.SetError(campo, "Este campo deve ser preenchido somente com números");
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }

        private void ViewCompra_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            MostrarCompra();
            MostrarCompraDiversos();
            Habilitar(false);
            Botoes();
            cboxInsumoCompra.Text = null;
        }

        private void dtBuscarCompra_ValueChanged(object sender, EventArgs e)
        {
            if (cboBuscarCompra.Text.Equals("Data de compra"))
            {
                BuscarDataCompra();
            }
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            if (cboBuscarCompra.Text.Equals("Nome insumo"))
            {
                BuscarNomeCompra();
            }
            else if (cboBuscarCompra.Text.Equals("Data de compra"))
            {
                BuscarDataCompra();

            }
        }

        private void btnDeletarCompra_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvCompra.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há compras selecionadas para excluir");
            }
            else
            {
                try
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show(
                        "Realmente deseja apagar os registros?",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {
                        string Codigo = "";
                        string resp = "";
                        DateTime datetime = DateTime.Now;

                        foreach (DataGridViewRow row in dgvCompra.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                QTDE_Insumo = Convert.ToDouble(dgvCompra.CurrentRow.Cells["QTDE_InsumoCompra"].Value);
                                ID_Insumo = Convert.ToString(dgvCompra.CurrentRow.Cells["ID_Insumo"].Value);

                                datetime = Convert.ToDateTime(dgvCompra.CurrentRow.Cells["DT_Compra"].Value);
                                break;
                            }
                        }
                        if (DateTime.Now.ToShortDateString() != datetime.ToShortDateString())
                        {
                            MensagemErro("Está compra não pode ser excluida, somente compras do mesmo dia podem ser excluidas\n Data da compra:  " +
                               datetime.ToShortDateString() + "\n  Data de hoje:  " + DateTime.Now.ToShortDateString());

                        }
                        else
                        {
                            double qtde_estoque = 0;
                            bool QuantidadeValida = true;

                            MostrarEstoque();
                            for (int i = 0; i < dtEstoque.Rows.Count; i++)
                            {
                                if (ID_Insumo.Equals(Convert.ToString(dtEstoque.Rows[i]["ID_Insumo"])))
                                {
                                    qtde_estoque = Convert.ToDouble(dtEstoque.Rows[i]["QTDE_Estoque"]);
                                    if (qtde_estoque < QTDE_Insumo)
                                    {
                                        resp = "Quantidade invalida, a quantidade de insumo inserida anteriomente já está sendo utilizada\n" +
                                            "Quantidade em estoque: " + dtEstoque.Rows[i]["QTDE_Estoque"];
                                        QuantidadeValida = false;
                                        break;
                                    }
                                }
                            }
                            if (QuantidadeValida == true)
                            {
                                myCompra = new ControlCompra(Codigo);
                                action = "baixa";
                                string qtde_baixa = Convert.ToString(QTDE_Insumo);
                                myEstoque = new ControlEstoque(action, ID_Insumo, qtde_baixa);
                                resp = myEstoque.DS_Mensagem;
                            }

                        }




                        if (resp.Equals("OK"))
                        {
                            MensagemOk("Registro(s) excluído(s) com sucesso");
                        }
                        else
                        {
                            if (resp != "")
                            {
                                MensagemErro(resp);

                            }
                        }

                        MostrarCompra();
                        chkDeletarCompra.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void chkDeletarCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarCompra.Checked)
            {
                dgvCompra.Columns[0].Visible = true;
            }
            else
            {
                dgvCompra.Columns[0].Visible = false;
            }
        }

        private void dgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCompra.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvCompra.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }


        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            cbSelecioneInsumoProduto.Focus();

            cbSelecioneInsumoProduto.Enabled = true;
        }

        private void btnSalvarCompra_Click(object sender, EventArgs e)
        {
            bool VerificaInsumo = false;
            bool VerificaEstoque = false;

            try
            {
                bool InsumoCompraOK = false;
                bool QuantidadeInsumoCompraOK = false;

                string resp = "";

                if (cboxInsumoCompra.Text == string.Empty)
                {

                    if (cbSelecioneInsumoProduto.Text.Equals("Produto"))
                    {
                        errorIcone.SetError(cboxInsumoCompra, "Selecione o produto da compra");

                    }
                    else if (cbSelecioneInsumoProduto.Text.Equals("Insumo"))
                    {
                        errorIcone.SetError(cboxInsumoCompra, "Selecione o insumo da compra");

                    }
                    else
                    {
                        errorIcone.SetError(cbSelecioneInsumoProduto, "Selecione insumo ou produto");
                    }
                }
                else
                {
                    errorIcone.SetError(cboxInsumoCompra, string.Empty);
                    InsumoCompraOK = true;
                }

                ValidarCampoNulo(txtQuantidadeInsumoCompra);
                if (myValidar.CampoValido == true)
                {

                    if (cbSelecioneInsumoProduto.Text.Equals("Insumo"))
                    {
                        string armazenamento = ValidarArmazenamentoInsumo(cboxInsumoCompra.SelectedValue.ToString());

                        if (armazenamento.Equals("KG(s)"))
                        {
                            ValidarValor(txtQuantidadeInsumoCompra);
                            if (myValidar.ValorValido == true)
                            {
                                QuantidadeInsumoCompraOK = true;
                            }
                            else
                            {
                                ValidarNumero(txtQuantidadeInsumoCompra);
                                if (myValidar.NumeroValido == true)
                                {
                                    QuantidadeInsumoCompraOK = true;

                                }
                            }
                        }

                    }
                    else if (cbSelecioneInsumoProduto.Text.Equals("Produto"))
                    {
                        ValidarNumero(txtQuantidadeInsumoCompra);
                        if (myValidar.NumeroValido == true)
                        {
                            QuantidadeInsumoCompraOK = true;

                        }
                    }

                }

                if (InsumoCompraOK == false ||
                    QuantidadeInsumoCompraOK == false)
                {
                    MensagemErro("Por favor, preencha corretamente os campos sinalizados");
                }
                else
                {
                    errorIcone.Clear();

                    if (eNovo)
                    {
                        if (cbSelecioneInsumoProduto.Text.Equals("Insumo"))
                        {



                            foreach (DataGridViewRow row in dgvCompra.Rows)
                            {
                                if (Convert.ToInt32(cboxInsumoCompra.SelectedValue) == Convert.ToInt32(row.Cells["ID_Insumo"].Value))
                                {
                                    ID_Compra = Convert.ToString(row.Cells["ID_Compra"].Value);
                                    VerificaInsumo = true;

                                }

                            }
                            MostrarEstoque();

                            for (int i = 0; i < dtEstoque.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(cboxInsumoCompra.SelectedValue) == Convert.ToInt32(dtEstoque.Rows[i]["ID_Insumo"]))
                                {
                                    VerificaEstoque = true;

                                }



                            }
                            if (VerificaInsumo == false && VerificaEstoque == false)
                            {
                                action = "adicionar";
                                myEstoque = new ControlEstoque(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoque.DS_Mensagem;


                                myCompra = new ControlCompra(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);

                            }
                            else if (VerificaInsumo == false && VerificaEstoque == true)
                            {
                                action = "entrada";
                                myEstoque = new ControlEstoque(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoque.DS_Mensagem;


                                myCompra = new ControlCompra(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);

                            }
                            else if (VerificaInsumo == true && VerificaEstoque == false)
                            {
                                action = "adicionar";
                                myEstoque = new ControlEstoque(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoque.DS_Mensagem;

                                myCompra = new ControlCompra(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);
                            }
                            else
                            {
                                action = "entrada";
                                myEstoque = new ControlEstoque(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoque.DS_Mensagem;


                                myCompra = new ControlCompra(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);
                            }


                            if (resp.Equals("OK"))
                            {
                                if (eNovo)
                                {
                                    MensagemOk("Registro salvo com sucesso");
                                }
                                else
                                {
                                    MensagemOk("Registro editado com sucesso");
                                }
                            }
                            else
                            {
                                MensagemErro(resp);
                            }
                        }
                        else if (cbSelecioneInsumoProduto.Text.Equals("Produto"))
                        {
                            foreach (DataGridViewRow row in dgvCompraDiversos.Rows)
                            {
                                if (Convert.ToInt32(cboxInsumoCompra.SelectedValue) == Convert.ToInt32(row.Cells["ID_Produto"].Value))
                                {
                                    ID_Compra = Convert.ToString(row.Cells["ID_CompraDiversos"].Value);
                                    VerificaInsumo = true;

                                }

                            }
                            MostrarEstoqueDiversos();

                            for (int i = 0; i < dtEstoque.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(cboxInsumoCompra.SelectedValue) == Convert.ToInt32(dtEstoque.Rows[i]["ID_Produto"]))
                                {
                                    VerificaEstoque = true;
                                    break;
                                }



                            }
                            if (VerificaInsumo == false && VerificaEstoque == false)
                            {
                                action = "adicionar";
                                myEstoqueDiversos = new ControlEstoqueDiversos(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoqueDiversos.DS_Mensagem;


                                myCompraDiversos = new ControlCompraDiversos(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);

                            }
                            else if (VerificaInsumo == false && VerificaEstoque == true)
                            {
                                action = "entrada";
                                myEstoqueDiversos = new ControlEstoqueDiversos(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoqueDiversos.DS_Mensagem;


                                myCompraDiversos = new ControlCompraDiversos(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);

                            }
                            else if (VerificaInsumo == true && VerificaEstoque == false)
                            {
                                action = "adicionar";
                                myEstoqueDiversos = new ControlEstoqueDiversos(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoqueDiversos.DS_Mensagem;

                                myCompraDiversos = new ControlCompraDiversos(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);
                            }
                            else
                            {
                                action = "entrada";
                                myEstoqueDiversos = new ControlEstoqueDiversos(action, cboxInsumoCompra.SelectedValue.ToString(), txtQuantidadeInsumoCompra.Text);
                                resp = myEstoqueDiversos.DS_Mensagem;


                                myCompraDiversos = new ControlCompraDiversos(cboxInsumoCompra.SelectedValue.ToString(), dtCompra.Value.ToShortDateString(), txtQuantidadeInsumoCompra.Text);
                            }

                            if (resp.Equals("OK"))
                            {
                                if (eNovo)
                                {
                                    MensagemOk("Registro salvo com sucesso");
                                }
                                else
                                {
                                    MensagemOk("Registro editado com sucesso");
                                }
                            }
                            else
                            {
                                MensagemErro(resp);
                            }
                        }

                    }
                    eNovo = false;
                    eEditar = false;
                    Botoes();
                    Limpar();
                    MostrarCompra();
                    MostrarCompraDiversos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();
        }

        private void tctrlCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlCompra.SelectedIndex == 0)
            {
                Habilitar(false);
                Limpar();

                btnNovaCompra.Enabled = true;
                btnSalvarCompra.Enabled = false;
                btnCancelarCompra.Enabled = false;
            }
        }



        private void cboBuscarCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarNomeInsumo.Text = string.Empty;

            if (cboBuscarCompra.Text.Equals("Nome insumo"))
            {
                dtBuscarCompra.Enabled = false;
                txtBuscarNomeInsumo.Enabled = true;

            }

            else if (cboBuscarCompra.Text.Equals("Data de compra"))
            {
                txtBuscarNomeInsumo.Enabled = false;
                dtBuscarCompra.Enabled = true;

            }
        }

        private void txtBuscarNomeInsumo_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscarCompra.Text.Equals("Nome insumo"))
            {
                BuscarNomeCompra();
            }
            else if (cboBuscarCompra.Text.Equals(""))
            {
                cboBuscarCompra.Text = "Selecione";
            }
        }

        private void cbBuscarCompraDiversos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarNomeProduto.Text = string.Empty;

            if (cbBuscarCompraDiversos.Text.Equals("Nome produto"))
            {
                dtBuscarCompraDiversos.Enabled = false;
                txtBuscarNomeProduto.Enabled = true;

            }

            else if (cboBuscarCompra.Text.Equals("Data de compra"))
            {
                txtBuscarNomeProduto.Enabled = false;
                dtBuscarCompraDiversos.Enabled = true;

            }
        }

        private void txtBuscarNomeProduto_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscarCompraDiversos.Text.Equals("Nome produto"))
            {
                BuscarNomeCompraDiversos();
            }
            else if (cboBuscarCompra.Text.Equals(""))
            {
                cbBuscarCompraDiversos.Text = "Selecione";
            }
        }

        private void btnBuscarCompraDiversos_Click(object sender, EventArgs e)
        {
            if (cbBuscarCompraDiversos.Text.Equals("Nome produto"))
            {
                BuscarNomeCompraDiversos();
            }
            else if (cbBuscarCompraDiversos.Text.Equals("Data de compra"))
            {
                BuscarDataCompraDiversos();

            }
        }

        private void btnDeletarCompraDiversos_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvCompraDiversos.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há compras selecionadas para excluir");
            }
            else
            {
                try
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show(
                        "Realmente deseja apagar os registros?",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {
                        string Codigo = "";
                        string resp = "";
                        DateTime datetime = DateTime.Now;

                        foreach (DataGridViewRow row in dgvCompraDiversos.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                QTDE_Insumo = Convert.ToDouble(dgvCompraDiversos.CurrentRow.Cells["QTDE_Compra"].Value);
                                ID_Produto = Convert.ToString(dgvCompraDiversos.CurrentRow.Cells["ID_Produto"].Value);

                                datetime = Convert.ToDateTime(dgvCompraDiversos.CurrentRow.Cells["DT_Compra"].Value);
                            }
                        }
                        if (DateTime.Now.ToShortDateString() != datetime.ToShortDateString())
                        {
                            MensagemErro("Está compra não pode ser excluida, somente compras do mesmo dia podem ser excluidas\n Data da compra:  " +
                               datetime.ToShortDateString() + "\n  Data de hoje:  " + DateTime.Now.ToShortDateString());

                        }
                        else
                        {
                            int qtde_estoque = 0;
                            bool QuantidadeValida = true;

                            MostrarEstoqueDiversos();
                            for (int i = 0; i < dtEstoque.Rows.Count; i++)
                            {
                                if (ID_Produto.Equals(Convert.ToString(dtEstoque.Rows[i]["ID_Produto"])))
                                {
                                    qtde_estoque = Convert.ToInt32(dtEstoque.Rows[i]["QTDE_Estoque"]);
                                    if (qtde_estoque < QTDE_Insumo)
                                    {
                                        resp = "Quantidade invalida, a quantidade de produtos  inserida anteriomente já está sendo utilizada\n" +
                                            "Quantidade em estoque: " + dtEstoque.Rows[i]["QTDE_Estoque"];
                                        QuantidadeValida = false;
                                        break;
                                    }
                                }
                            }
                            if (QuantidadeValida == true)
                            {
                                myCompraDiversos = new ControlCompraDiversos(Codigo);
                                action = "baixa";
                                string qtde_baixa = Convert.ToString(QTDE_Insumo);
                                myEstoqueDiversos = new ControlEstoqueDiversos(action, ID_Produto, qtde_baixa);
                                resp = myEstoqueDiversos.DS_Mensagem;
                            }

                        }




                        if (resp.Equals("OK"))
                        {
                            MensagemOk("Registro(s) excluído(s) com sucesso");
                        }
                        else
                        {
                            if (resp != "")
                            {
                                MensagemErro(resp);

                            }
                        }
                        MostrarCompraDiversos();
                        chkDeletarComprasDiversos.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void chkDeletarComprasDiversos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarComprasDiversos.Checked)
            {
                dgvCompraDiversos.Columns[0].Visible = true;
            }
            else
            {
                dgvCompraDiversos.Columns[0].Visible = false;
            }
        }



        private void cbSelecioneInsumoProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelecioneInsumoProduto.Text.Equals("Produto"))
            {

                MostrarProduto();

            }

            else if (cbSelecioneInsumoProduto.Text.Equals("Insumo"))
            {

                MostrarInsumo();
            }
        }

        private void dgvCompraDiversos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCompraDiversos.Columns["DeletarDiversos"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletarDiversos = (DataGridViewCheckBoxCell)dgvCompraDiversos.Rows[e.RowIndex].Cells["DeletarDiversos"];
                ChkDeletarDiversos.Value = !Convert.ToBoolean(ChkDeletarDiversos.Value);
            }
        }
    }
}


