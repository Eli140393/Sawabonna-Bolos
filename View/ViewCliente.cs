using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace View
{
    public partial class ViewCliente : Form
    {
        ControlCliente myCliente;
        Validar myValidar = new Validar();

        private bool eNovo = false;
        private bool eEditar = false;
        private string action = "";

        public ViewCliente()
        {
            InitializeComponent();
        }

        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "SAWABONA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensagemOk(string mensagem)
        {
            MessageBox.Show(mensagem, "SAWABONA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Limpar()
        {
            txtCodigoCliente.Text = string.Empty;
            txtNomeCliente.Text = string.Empty;
            cboxSexoCliente.Text = string.Empty;
            txtCPFCliente.Text = string.Empty;
            dtpNascimentoCliente.Value = dtpNascimentoCliente.MaxDate;
            txtTelefoneCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;


        }

        // Habilitar os text box
        private void Habilitar(bool Valor)
        {
            txtCodigoCliente.Enabled = false;
            txtNomeCliente.Enabled = Valor;
            cboxSexoCliente.Enabled = Valor;
            txtCPFCliente.Enabled = Valor;
            dtpNascimentoCliente.Enabled = Valor;
            txtTelefoneCliente.Enabled = Valor;
            txtEmailCliente.Enabled = Valor;

        }

        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovoCliente.Enabled = false;
                btnSalvarCliente.Enabled = true;
                btnEditarCliente.Enabled = false;
                btnCancelarCliente.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovoCliente.Enabled = true;
                btnSalvarCliente.Enabled = false;
                btnEditarCliente.Enabled = true;
                btnCancelarCliente.Enabled = false;
            }
        }

        private void OcultarColunas()
        {
            dgvCliente.Columns[0].Visible = false;

        }

        private void HabilitarDataGridView()
        {
            if (dgvCliente.Rows.Count == 0)
            {
                chkDeletarCliente.Enabled = false;
                btnDeletarCliente.Enabled = false;
                cboBuscarCliente.Enabled = false;
                txtBuscarCliente.Enabled = false;
                btnBuscarCliente.Enabled = false;
                dgvCliente.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                chkDeletarCliente.Enabled = true;
                btnDeletarCliente.Enabled = true;
                cboBuscarCliente.Enabled = true;
                txtBuscarCliente.Enabled = true;
                btnBuscarCliente.Enabled = true;
                dgvCliente.Enabled = true;
                btnAtivar.Enabled = true;

            }
        }

        private void MostrarCliente()
        {
            string ativos = "1";
            string inativos = "0";

            myCliente = new ControlCliente();

            if (chkInativos.Checked == true)
            {
                dgvCliente.DataSource = myCliente.MostrarCliente(inativos);
                dgvCliente.Columns[0].HeaderText = "Ativar";


            }
            else
            {

                dgvCliente.DataSource = myCliente.MostrarCliente(ativos);
                dgvCliente.Columns[0].HeaderText = "Deletar";

            }


            lblTotalCliente.Text = "Total de Registros:  " + Convert.ToString(dgvCliente.Rows.Count);

            dgvCliente.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvCliente.Columns[1].HeaderText = "CÓDIGO";
            dgvCliente.Columns[2].HeaderText = "NOME";
            dgvCliente.Columns[3].HeaderText = "CPF";
            dgvCliente.Columns[4].HeaderText = "TELEFONE";
            dgvCliente.Columns[5].HeaderText = "E-MAIL";
            dgvCliente.Columns[6].HeaderText = "SEXO";
            dgvCliente.Columns[7].HeaderText = "DATA NASCIMENTO";
            dgvCliente.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            HabilitarDataGridView();
        }

        private void BuscarNomeCliente()
        {
            string ativos = "1";
            string inativos = "0";

            myCliente = new ControlCliente();

            if (chkInativos.Checked == true)
            {
                dgvCliente.DataSource = myCliente.BuscarNomeCliente(inativos, txtBuscarCliente.Text);
                OcultarColunas();
                lblTotalCliente.Text = "Total de Registros:  " + Convert.ToString(dgvCliente.Rows.Count);


            }
            else
            {
                dgvCliente.DataSource = myCliente.BuscarNomeCliente(ativos, txtBuscarCliente.Text);
                OcultarColunas();
                lblTotalCliente.Text = "Total de Registros:  " + Convert.ToString(dgvCliente.Rows.Count);
            }


        }

        private void BuscarCPFCliente()
        {
            string ativos = "1";
            string inativos = "0";

            myCliente = new ControlCliente();

            if (chkInativos.Checked == true)
            {
                dgvCliente.DataSource = myCliente.BuscarCPFCliente(inativos, txtBuscarCliente.Text);
                OcultarColunas();
                lblTotalCliente.Text = "Total de Registros:  " + Convert.ToString(dgvCliente.Rows.Count);


            }
            else
            {
                dgvCliente.DataSource = myCliente.BuscarCPFCliente(ativos, txtBuscarCliente.Text);
                OcultarColunas();
                lblTotalCliente.Text = "Total de Registros:  " + Convert.ToString(dgvCliente.Rows.Count);
            }

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

        private void ValidarCampoNuloMasked(MaskedTextBox campo)
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

        private void ValidarLetra(TextBox campo)
        {
            string letravalida = Convert.ToString(campo.Text);
            myValidar.Letra(letravalida);

            if (myValidar.LetraValida == false)
            {
                errorIcone.SetError(campo, "Este campo deve ser preenchido somente com letras");
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

        private void ViewCliente_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            MostrarCliente();
            Habilitar(false);
            Botoes();
            txtCodigoCliente.Enabled = false;
            OcultarColunas();
            dtpNascimentoCliente.MinDate = DateTime.Today.AddYears(-130);
            dtpNascimentoCliente.MaxDate = DateTime.Today.AddDays(-6574.5);
        }

        private void cboBuscarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarCliente.Text = string.Empty;
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscarCliente.Text.Equals("Nome"))
            {
                BuscarNomeCliente();
            }
            else if (cboBuscarCliente.Text.Equals("CPF"))
            {
                BuscarCPFCliente();
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (cboBuscarCliente.Text.Equals("Nome"))
            {
                BuscarNomeCliente();
            }
            else if (cboBuscarCliente.Text.Equals("CPF"))
            {
                BuscarCPFCliente();
            }
        }

        private void chkDeletarCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarCliente.Checked)
            {
                dgvCliente.Columns[0].Visible = true;
                chkInativos.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                dgvCliente.Columns[0].Visible = false;
                chkInativos.Enabled = true;
                btnAtivar.Enabled = true;


            }
        }

        private void btnDeletarCliente_Click(object sender, EventArgs e)
        {


            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvCliente.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há clientes selecionados para excluir");
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
                        string Codigo;
                        string resp = "";
                        action = "excluir";
                        foreach (DataGridViewRow row in dgvCliente.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myCliente = new ControlCliente(Codigo, action);
                                resp = myCliente.DS_Mensagem;
                            }
                        }

                        if (resp.Equals("OK"))
                        {
                            MensagemOk("Registro(s) excluído(s) com sucesso");
                        }
                        else
                        {
                            MensagemErro(resp);
                        }

                        MostrarCliente();
                        chkDeletarCliente.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCliente.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvCliente.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void dgvCliente_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoCliente.Text = Convert.ToString(dgvCliente.CurrentRow.Cells["ID_Cliente"].Value);
            txtNomeCliente.Text = Convert.ToString(dgvCliente.CurrentRow.Cells["NM_Cliente"].Value);
            txtCPFCliente.Text = Convert.ToString(dgvCliente.CurrentRow.Cells["NR_CPF"].Value);
            txtTelefoneCliente.Text = Convert.ToString(dgvCliente.CurrentRow.Cells["NR_Telefone"].Value);
            txtEmailCliente.Text = Convert.ToString(dgvCliente.CurrentRow.Cells["DS_Email"].Value);
            cboxSexoCliente.Text = Convert.ToString(dgvCliente.CurrentRow.Cells["DS_Sexo"].Value);
            dtpNascimentoCliente.Value = Convert.ToDateTime(dgvCliente.CurrentRow.Cells["DT_Nascimento"].Value);
            tctrlCliente.SelectedIndex = 1;
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            Habilitar(true);
            txtNomeCliente.Focus();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";

                bool NomeClienteOK = false;
                bool CPFClienteOK = false;
                bool TelefoneClienteOK = false;
                bool SexoClienteOK = false;

                bool CPFcadastrado = false;

                ValidarCampoNulo(txtNomeCliente);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtNomeCliente, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        ValidarLetra(txtNomeCliente);
                        if (myValidar.LetraValida == true)
                        {
                            NomeClienteOK = true;
                        }
                    }
                }

                ValidarCampoNuloMasked(txtCPFCliente);
                if (myValidar.CampoValido == true)
                {
                    if (!txtCPFCliente.MaskCompleted)
                    {
                        errorIcone.SetError(txtCPFCliente, "O CPF está incompleto");
                    }
                    else
                    {
                        if (myValidar.ValidaCPF(txtCPFCliente.Text) == false)
                        {
                            errorIcone.SetError(txtCPFCliente, "Número de CPF inválido");
                        }
                        else
                        {
                            errorIcone.SetError(txtCPFCliente, string.Empty);
                            CPFClienteOK = true;
                        }
                    }
                }

                myValidar.DataNascimento(dtpNascimentoCliente);


                if (cboxSexoCliente.Text == string.Empty)
                {
                    cboxSexoCliente.Text = null;
                    errorIcone.SetError(cboxSexoCliente, "Selecione o sexo do cliente");
                }
                else
                {
                    errorIcone.SetError(cboxSexoCliente, string.Empty);
                    SexoClienteOK = true;
                }

                ValidarCampoNuloMasked(txtTelefoneCliente);
                if (myValidar.CampoValido == true)
                {
                    if (!txtTelefoneCliente.MaskCompleted)
                    {
                        errorIcone.SetError(txtTelefoneCliente, "O telefone está incompleto");
                    }
                    else
                    {
                        errorIcone.SetError(txtTelefoneCliente, string.Empty);
                        TelefoneClienteOK = true;
                    }
                }

                if (txtEmailCliente.Text != string.Empty)
                {
                    ValidarTamanhoCampo(txtEmailCliente, 50);
                }



                if (NomeClienteOK == false ||
                    CPFClienteOK == false ||
                    TelefoneClienteOK == false ||
                    SexoClienteOK == false)
                {
                    MensagemErro("Preencha corretamente todos os campos sinalizados");
                }
                else
                {
                    errorIcone.Clear();

                    if (eNovo)
                    {
                        foreach (DataGridViewRow row in dgvCliente.Rows)
                        {
                            if (txtCPFCliente.Text == Convert.ToString(row.Cells["NR_CPF"].Value))
                            {
                                CPFcadastrado = true;
                            }
                        }

                        if (CPFcadastrado == true)
                        {
                            MensagemErro("CPF já cadastrado na base de dados");
                        }
                        else
                        {

                            myCliente = new ControlCliente(txtNomeCliente.Text.Trim(), txtCPFCliente.Text.Trim(), txtTelefoneCliente.Text.Trim(), txtEmailCliente.Text.Trim(),
                                cboxSexoCliente.Text, dtpNascimentoCliente.Value);

                            resp = myCliente.DS_Mensagem;

                        }
                    }
                    else
                    {

                        myCliente = new ControlCliente(txtCodigoCliente.Text.Trim(), txtNomeCliente.Text.Trim(), txtCPFCliente.Text.Trim(), txtTelefoneCliente.Text.Trim(), txtEmailCliente.Text.Trim(),
                            cboxSexoCliente.Text, dtpNascimentoCliente.Value);

                        resp = myCliente.DS_Mensagem;

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

                        eNovo = false;
                        eEditar = false;
                        Botoes();
                        Limpar();
                        MostrarCliente();
                    }
                    else
                    {
                        if (CPFcadastrado == false)
                        {
                            MensagemErro(resp);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text.Equals(""))
            {
                MensagemErro("Selecione um registro para editar");
            }
            else
            {
                eEditar = true;
                Botoes();
                Habilitar(true);

                txtCodigoCliente.Enabled = false;
                txtCPFCliente.Enabled = false;
                txtNomeCliente.Enabled = false;

                if (dtpNascimentoCliente.Value != DateTime.Today)
                {
                    dtpNascimentoCliente.Enabled = false;
                }
            }
        }

        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();
        }

        private void tctrlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlCliente.SelectedIndex == 0)
            {
                Habilitar(false);
                Limpar();

                btnNovoCliente.Enabled = true;
                btnSalvarCliente.Enabled = false;
                btnEditarCliente.Enabled = true;
                btnCancelarCliente.Enabled = false;
            }
        }

        private void chkInativos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarCliente();
            if (chkInativos.Checked == true)
            {
                btnDeletarCliente.Enabled = false;
                btnAtivar.Enabled = true;
                dgvCliente.Columns[0].Visible = true;
                chkDeletarCliente.Enabled = false;


            }
            else
            {
                btnDeletarCliente.Enabled = true;
                btnAtivar.Enabled = false;
                dgvCliente.Columns[0].Visible = false;
                chkDeletarCliente.Enabled = true;
                MostrarCliente();

            }

        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {

            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvCliente.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há clientes selecionados para ativar");
            }
            else
            {
                try
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show(
                        "Realmente deseja ativar os registros?",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {
                        string Codigo;
                        string resp = "";
                        action = "ativar";
                       foreach (DataGridViewRow row in dgvCliente.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myCliente = new ControlCliente(Codigo, action);
                                resp = myCliente.DS_Mensagem;
                            }
                        }

                        if (resp.Equals("OK"))
                        {
                            MensagemOk("Registro(s) Ativado(s) com sucesso");
                        }
                        else
                        {
                            MensagemErro(resp);
                        }

                        MostrarCliente();
                        chkInativos.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
    }
}
