using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace View
{
    public partial class ViewFuncionario : Form
    {
        ControlFuncionario myFuncionario;
        Validar myValidar = new Validar();

        private bool eNovo = false;
        private bool eEditar = false;

        private string status { get; set; }
        private string action { get; set; }


        public ViewFuncionario()
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
            txtCodigoFuncionario.Text = string.Empty;
            txtNomeFuncionario.Text = string.Empty;
            cboxSexoFuncionario.Text = null;
            txtCPFFuncionario.Text = string.Empty;
            dtpNascimentoFuncionario.Value = dtpNascimentoFuncionario.MaxDate;
            txtTelefoneFuncionario.Text = string.Empty;
            txtEmailFuncionario.Text = string.Empty;

            txtCargoFuncionario.Text = string.Empty;
            txtSalarioFuncionario.Text = string.Empty;
            dtpAdmissaoFuncionario.Value = dtpAdmissaoFuncionario.MaxDate;

            txtCEPFuncionario.Text = string.Empty;
            txtRuaFuncionario.Text = string.Empty;
            txtNumCasaFuncionario.Text = string.Empty;
            txtBairroFuncionario.Text = string.Empty;
            txtComplementoFuncionario.Text = string.Empty;
            txtCidadeFuncionario.Text = string.Empty;
            cboxUFFuncionario.Text = null;
        }

        // Habilitar os text box
        private void Habilitar(bool Valor)
        {
            txtCodigoFuncionario.Enabled = false;
            txtNomeFuncionario.Enabled = Valor;
            cboxSexoFuncionario.Enabled = Valor;
            txtCPFFuncionario.Enabled = Valor;
            dtpNascimentoFuncionario.Enabled = Valor;
            txtTelefoneFuncionario.Enabled = Valor;
            txtEmailFuncionario.Enabled = Valor;

            txtCargoFuncionario.Enabled = Valor;
            txtSalarioFuncionario.Enabled = Valor;
            dtpAdmissaoFuncionario.Enabled = Valor;

            txtCEPFuncionario.Enabled = Valor;
            txtRuaFuncionario.Enabled = Valor;
            txtNumCasaFuncionario.Enabled = Valor;
            txtBairroFuncionario.Enabled = Valor;
            txtComplementoFuncionario.Enabled = Valor;
            txtCidadeFuncionario.Enabled = Valor;
            cboxUFFuncionario.Enabled = Valor;
        }

        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovoFuncionario.Enabled = false;
                btnSalvarFuncionario.Enabled = true;
                btnEditarFuncionario.Enabled = false;
                btnCancelarFuncionario.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovoFuncionario.Enabled = true;
                btnSalvarFuncionario.Enabled = false;
                btnEditarFuncionario.Enabled = true;
                btnCancelarFuncionario.Enabled = false;
            }
        }

        private void OcultarColunas()
        {
            dgvFuncionario.Columns[0].Visible = false;
        }

        private void HabilitarDataGridView()
        {
            if (dgvFuncionario.Rows.Count == 0)
            {
                chkDeletarFuncionario.Enabled = false;
                btnDeletarFuncionario.Enabled = false;
                cboBuscarFuncionario.Enabled = false;
                txtBuscarFuncionario.Enabled = false;
                btnBuscarFuncionario.Enabled = false;
                dgvFuncionario.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                chkDeletarFuncionario.Enabled = true;
                btnDeletarFuncionario.Enabled = true;
                cboBuscarFuncionario.Enabled = true;
                txtBuscarFuncionario.Enabled = true;
                btnBuscarFuncionario.Enabled = true;
                dgvFuncionario.Enabled = true;
                btnAtivar.Enabled = false;
            }
        }

        private void MostrarFuncionario()
        {
            myFuncionario = new ControlFuncionario();


            if (chkInativos.Checked == false)
            {
                status = "1";

                dgvFuncionario.DataSource = myFuncionario.MostrarFuncionario(status);
                dgvFuncionario.Columns[0].HeaderText = "Deletar";
                dgvFuncionario.Columns[18].Visible = false;

            }
            else
            {
                status = "0";


                dgvFuncionario.DataSource = myFuncionario.MostrarFuncionario(status);
                dgvFuncionario.Columns[0].HeaderText = "Ativar";
                dgvFuncionario.Columns[18].Visible = true;

            }


            OcultarColunas();
            lblTotalFuncionario.Text = "Total de Registros:  " + Convert.ToString(dgvFuncionario.Rows.Count);

            dgvFuncionario.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvFuncionario.Columns[1].HeaderText = "CÓDIGO";
            dgvFuncionario.Columns[2].HeaderText = "NOME";
            dgvFuncionario.Columns[3].HeaderText = "SEXO";
            dgvFuncionario.Columns[4].HeaderText = "CPF";
            dgvFuncionario.Columns[5].HeaderText = "DATA\nNASCIMENTO";
            dgvFuncionario.Columns[6].HeaderText = "TELEFONE";
            dgvFuncionario.Columns[7].HeaderText = "E-MAIL";
            dgvFuncionario.Columns[8].HeaderText = "CARGO";
            dgvFuncionario.Columns[9].HeaderText = "SALÁRIO";
            dgvFuncionario.Columns[10].HeaderText = "DATA\nADMISSÃO";
            dgvFuncionario.Columns[11].HeaderText = "RUA";
            dgvFuncionario.Columns[12].HeaderText = "Nº";
            dgvFuncionario.Columns[13].HeaderText = "COMPLEMENTO";
            dgvFuncionario.Columns[14].HeaderText = "BAIRRO";
            dgvFuncionario.Columns[15].HeaderText = "CEP";
            dgvFuncionario.Columns[16].HeaderText = "CIDADE";
            dgvFuncionario.Columns[17].HeaderText = "UF";
            dgvFuncionario.Columns[18].HeaderText = "DATA\nDEMISSÃO";

            dgvFuncionario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFuncionario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            HabilitarDataGridView();
        }

        private void BuscarNomeFuncionario()
        {
            myFuncionario = new ControlFuncionario();

            if (chkInativos.Checked == false)
            {
                status = "1";
                dgvFuncionario.DataSource = myFuncionario.BuscarNomeFuncionario(status, txtBuscarFuncionario.Text);
            }
            else
            {
                status = "0";
                dgvFuncionario.DataSource = myFuncionario.BuscarNomeFuncionario(status, txtBuscarFuncionario.Text);
            }
            OcultarColunas();
            lblTotalFuncionario.Text = "Total de Registros:  " + Convert.ToString(dgvFuncionario.Rows.Count);
        }

        private void BuscarCPFFuncionario()
        {
            myFuncionario = new ControlFuncionario();

            if (chkInativos.Checked == false)
            {
                status = "1";
                dgvFuncionario.DataSource = myFuncionario.BuscarCPFFuncionario(status, txtBuscarFuncionario.Text);
            }
            else
            {
                status = "0";
                dgvFuncionario.DataSource = myFuncionario.BuscarCPFFuncionario(status, txtBuscarFuncionario.Text);
            }
            OcultarColunas();
            lblTotalFuncionario.Text = "Total de Registros:  " + Convert.ToString(dgvFuncionario.Rows.Count);
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

        private void ValidarNascimento(DateTimePicker campo)
        {
            myValidar.DataNascimentoObrigatorio(campo);

            if (myValidar.DtNascimentoValido == false)
            {
                errorIcone.SetError(campo, "O funcionário deve ter mais de 18 anos para ser cadastrado");
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

        private void ViewFuncionario_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            MostrarFuncionario();
            Habilitar(false);
            Botoes();
            txtCodigoFuncionario.Enabled = false;

            dtpAdmissaoFuncionario.MaxDate = DateTime.Now;
            dtpAdmissaoFuncionario.Value = dtpAdmissaoFuncionario.MaxDate;

            dtpNascimentoFuncionario.MinDate = DateTime.Today.AddYears(-60);
            dtpNascimentoFuncionario.MaxDate = DateTime.Today.AddDays(-6574.5);
        }

        private void cboBuscarFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarFuncionario.Text = string.Empty;
        }

        private void txtBuscarFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscarFuncionario.Text.Equals("Nome"))
            {
                BuscarNomeFuncionario();
            }
            else if (cboBuscarFuncionario.Text.Equals("CPF"))
            {
                BuscarCPFFuncionario();
            }
        }

        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            if (cboBuscarFuncionario.Text.Equals("Nome"))
            {
                BuscarNomeFuncionario();
            }
            else if (cboBuscarFuncionario.Text.Equals("CPF"))
            {
                BuscarCPFFuncionario();
            }
        }

        private void chkDeletarFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarFuncionario.Checked)
            {
                dgvFuncionario.Columns[0].Visible = true;
                chkInativos.Enabled = false;
            }
            else
            {
                dgvFuncionario.Columns[0].Visible = false;
                chkInativos.Enabled = true;

            }
        }

        private void btnDeletarFuncionario_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvFuncionario.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há funcionários selecionados para excluir");
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

                        foreach (DataGridViewRow row in dgvFuncionario.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myFuncionario = new ControlFuncionario(action, Codigo);
                                resp = myFuncionario.DS_Mensagem;
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

                        MostrarFuncionario();
                        chkDeletarFuncionario.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void dgvFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFuncionario.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvFuncionario.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void dgvFuncionario_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFuncionario.Rows.Count == 0)
            {
                MensagemErro("Não há funcionários cadastrados");
            }
            else
            {
                txtCodigoFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["ID_Funcionario"].Value);
                txtNomeFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NM_Funcionario"].Value);
                cboxSexoFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["DS_Sexo"].Value);
                txtCPFFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NR_CPF"].Value);
                dtpNascimentoFuncionario.Value = Convert.ToDateTime(dgvFuncionario.CurrentRow.Cells["DT_Nascimento"].Value);
                txtTelefoneFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NR_Telefone"].Value);
                txtEmailFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["DS_Email"].Value);
                txtCEPFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NR_CEP"].Value);
                txtRuaFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NM_Rua"].Value);
                txtNumCasaFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NR_Casa"].Value);
                txtBairroFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NM_Bairro"].Value);
                txtComplementoFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["DS_Complemento"].Value);
                txtCidadeFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["NM_Cidade"].Value);
                cboxUFFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["DS_UF"].Value);
                txtCargoFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["DS_Cargo"].Value);
                txtSalarioFuncionario.Text = Convert.ToString(dgvFuncionario.CurrentRow.Cells["VL_Salario"].Value);
                dtpAdmissaoFuncionario.Value = Convert.ToDateTime(dgvFuncionario.CurrentRow.Cells["DT_Admissao"].Value);

                tctrlFuncionario.SelectedIndex = 1;
            }
        }

        private void btnNovoFuncionario_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            Habilitar(true);
            txtNomeFuncionario.Focus();
        }

        private void btnSalvarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                bool NomeFuncionarioOK = false;
                bool CPFFuncionarioOK = false;
                bool NascimentoFuncionarioOK = false;
                bool TelefoneFuncionarioOK = false;
                bool CargoFuncionarioOK = false;
                bool SalarioFuncionarioOK = false;
                bool RuaFuncionarioOK = false;
                bool NumCasaFuncionarioOK = false;
                bool BairroFuncionarioOK = false;

                bool CPFcadastrado = false;

                string resp = "";

                ValidarCampoNulo(txtNomeFuncionario);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtNomeFuncionario, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        ValidarLetra(txtNomeFuncionario);
                        if (myValidar.LetraValida == true)
                        {
                            NomeFuncionarioOK = true;
                        }
                    }
                }

                ValidarCampoNuloMasked(txtCPFFuncionario);
                if (myValidar.CampoValido == true)
                {
                    if (!txtCPFFuncionario.MaskCompleted)
                    {
                        errorIcone.SetError(txtCPFFuncionario, "O CPF está incompleto");
                    }
                    else
                    {
                        if (myValidar.ValidaCPF(txtCPFFuncionario.Text) == false)
                        {
                            errorIcone.SetError(txtCPFFuncionario, "Número de CPF inválido");
                        }
                        else
                        {
                            errorIcone.SetError(txtCPFFuncionario, string.Empty);
                            CPFFuncionarioOK = true;
                        }
                    }
                }

                ValidarNascimento(dtpNascimentoFuncionario);
                if (myValidar.DtNascimentoValido == true)
                {
                    NascimentoFuncionarioOK = true;
                }

                if (cboxSexoFuncionario.Text == null)
                {
                    cboxSexoFuncionario.Text = null;
                }

                ValidarCampoNuloMasked(txtTelefoneFuncionario);
                if (myValidar.CampoValido == true)
                {
                    if (!txtTelefoneFuncionario.MaskCompleted)
                    {
                        errorIcone.SetError(txtTelefoneFuncionario, "O telefone está incompleto");
                    }
                    else
                    {
                        errorIcone.SetError(txtTelefoneFuncionario, string.Empty);
                        TelefoneFuncionarioOK = true;
                    }
                }

                if (txtEmailFuncionario.Text != string.Empty)
                {
                    ValidarTamanhoCampo(txtEmailFuncionario, 50);
                }

                ValidarCampoNulo(txtRuaFuncionario);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtRuaFuncionario, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        RuaFuncionarioOK = true;
                    }
                }

                ValidarCampoNulo(txtNumCasaFuncionario);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtNumCasaFuncionario, 5);
                    if (myValidar.TamanhoValido == true)
                    {
                        ValidarNumero(txtNumCasaFuncionario);
                        if (myValidar.NumeroValido == true)
                        {
                            NumCasaFuncionarioOK = true;
                        }
                    }
                }

                ValidarCampoNulo(txtBairroFuncionario);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtBairroFuncionario, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        BairroFuncionarioOK = true;
                    }
                }

                if (txtComplementoFuncionario.Text != string.Empty)
                {
                    ValidarTamanhoCampo(txtComplementoFuncionario, 50);
                }

                if (txtCidadeFuncionario.Text != string.Empty)
                {
                    ValidarTamanhoCampo(txtCidadeFuncionario, 30);
                }

                if (cboxUFFuncionario.Text == null)
                {
                    cboxUFFuncionario.Text = null;
                }

                ValidarCampoNulo(txtCargoFuncionario);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtCargoFuncionario, 30);
                    if (myValidar.TamanhoValido == true)
                    {
                        ValidarLetra(txtCargoFuncionario);
                        if (myValidar.LetraValida == true)
                        {
                            CargoFuncionarioOK = true;
                        }
                    }
                }

                ValidarCampoNulo(txtSalarioFuncionario);
                if (myValidar.CampoValido == true)
                {
                    ValidarValor(txtSalarioFuncionario);
                    if (myValidar.ValorValido == true)
                    {
                        SalarioFuncionarioOK = true;
                        
                    }
                }

                if (NomeFuncionarioOK == false ||
                    CPFFuncionarioOK == false ||
                    NascimentoFuncionarioOK == false ||
                    TelefoneFuncionarioOK == false ||
                    CargoFuncionarioOK == false ||
                    SalarioFuncionarioOK == false ||
                    RuaFuncionarioOK == false ||
                    NumCasaFuncionarioOK == false ||
                    BairroFuncionarioOK == false)
                {
                    MensagemErro("Preencha corretamente todos os campos sinalizados");
                }
                else
                {
                    errorIcone.Clear();

                    if (eNovo)
                    {

                        foreach (DataGridViewRow row in dgvFuncionario.Rows)
                        {
                            if (txtCPFFuncionario.Text == Convert.ToString(row.Cells["NR_CPF"].Value))
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
                            myFuncionario = new ControlFuncionario(txtNomeFuncionario.Text.Trim(), cboxSexoFuncionario.Text, txtCPFFuncionario.Text, dtpNascimentoFuncionario.Value, txtTelefoneFuncionario.Text,
                            txtEmailFuncionario.Text.Trim(), txtCEPFuncionario.Text, txtRuaFuncionario.Text.Trim(), txtNumCasaFuncionario.Text, txtBairroFuncionario.Text.Trim(), txtComplementoFuncionario.Text.Trim(),
                            txtCidadeFuncionario.Text.Trim(), cboxUFFuncionario.Text, txtCargoFuncionario.Text.Trim(), txtSalarioFuncionario.Text, dtpAdmissaoFuncionario.Value.ToShortDateString());
                            resp = myFuncionario.DS_Mensagem;

                        }
                    }
                    else
                    {
     
                        myFuncionario = new ControlFuncionario(txtCodigoFuncionario.Text, txtNomeFuncionario.Text.Trim(), cboxSexoFuncionario.Text, txtCPFFuncionario.Text, dtpNascimentoFuncionario.Value.ToShortDateString(), txtTelefoneFuncionario.Text,
                         txtEmailFuncionario.Text.Trim(), txtCEPFuncionario.Text, txtRuaFuncionario.Text.Trim(), txtNumCasaFuncionario.Text, txtBairroFuncionario.Text.Trim(), txtComplementoFuncionario.Text.Trim(),
                         txtCidadeFuncionario.Text.Trim(), cboxUFFuncionario.Text, txtCargoFuncionario.Text.Trim(), txtSalarioFuncionario.Text , dtpAdmissaoFuncionario.Value.ToShortDateString());
                         resp = myFuncionario.DS_Mensagem;
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
                        MostrarFuncionario();
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

        private void btnEditarFuncionario_Click(object sender, EventArgs e)
        {
            if (txtNomeFuncionario.Text.Equals(""))
            {
                MensagemErro("Selecione um registro para editar");
            }
            else
            {
                txtCodigoFuncionario.Enabled = false;
                eEditar = true;
                Botoes();
                Habilitar(true);

                txtCodigoFuncionario.Enabled = false;
                txtCPFFuncionario.Enabled = false;
                txtNomeFuncionario.Enabled = false;
                dtpNascimentoFuncionario.Enabled = false;
                dtpAdmissaoFuncionario.Enabled = false;
            }
        }

        private void btnCancelarFuncionario_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();
        }

        private void tctrlFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlFuncionario.SelectedIndex == 0)
            {
                Habilitar(false);
                Limpar();

                btnNovoFuncionario.Enabled = true;
                btnSalvarFuncionario.Enabled = false;
                btnEditarFuncionario.Enabled = true;
                btnCancelarFuncionario.Enabled = false;
            }
        }

        private void chkInativos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarFuncionario();

            if (chkInativos.Checked == true)
            {
                btnDeletarFuncionario.Enabled = false;
                btnAtivar.Enabled = true;
                dgvFuncionario.Columns[0].Visible = true;
                chkDeletarFuncionario.Enabled = false;


            }
            else
            {
                btnDeletarFuncionario.Enabled = true;
                btnAtivar.Enabled = false;
                dgvFuncionario.Columns[0].Visible = false;
                chkDeletarFuncionario.Enabled = true;
                MostrarFuncionario();

            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvFuncionario.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há produtos selecionados para ativar");
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

                        foreach (DataGridViewRow row in dgvFuncionario.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myFuncionario = new ControlFuncionario(action, Codigo);
                                resp = myFuncionario.DS_Mensagem;
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

                        MostrarFuncionario();
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
