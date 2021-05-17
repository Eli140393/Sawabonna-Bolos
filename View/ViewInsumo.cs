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
    public partial class ViewInsumo : Form
    {
        ControlInsumo myInsumo;
        Validar myValidar = new Validar();

        private bool eNovo = false;
        private bool eEditar = false;

        public ViewInsumo()
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

        private void Limpar()
        {
            txtCodigoInsumo.Text = string.Empty;
            txtNomeInsumo.Text = string.Empty;
            txtPrecoInsumo.Text = string.Empty;
            cbArmazenamentoInsumo.Text = null;


        }


        private void Habilitar(bool Valor)
        {
            txtCodigoInsumo.Enabled = false;
            txtNomeInsumo.Enabled = Valor;
            txtPrecoInsumo.Enabled = Valor;
            cbArmazenamentoInsumo.Enabled = Valor;
        }
        // Habilitar os botões
        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovoInsumo.Enabled = false;
                btnSalvarInsumo.Enabled = true;
                btnEditarInsumo.Enabled = false;
                btnCancelarInsumo.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovoInsumo.Enabled = true;
                btnSalvarInsumo.Enabled = false;
                btnEditarInsumo.Enabled = true;
                btnCancelarInsumo.Enabled = false;
            }
        }

        private void OcultarColunasInsumo()
        {
            dgvInsumo.Columns[0].Visible = false;
        }


        private void HabilitarDataGridViewInsumo()
        {
            if (dgvInsumo.Rows.Count == 0)
            {
                chkDeletarInsumo.Enabled = false;
                btnDeletarInsumo.Enabled = false;
                txtBuscarInsumo.Enabled = false;
                btnBuscarInsumo.Enabled = false;
                dgvInsumo.Enabled = false;
            }
            else
            {
                chkDeletarInsumo.Enabled = true;
                btnDeletarInsumo.Enabled = true;
                txtBuscarInsumo.Enabled = true;
                btnBuscarInsumo.Enabled = true;
                dgvInsumo.Enabled = true;
            }
        }

        private void MostrarInsumo()
        {
            myInsumo = new ControlInsumo();

            dgvInsumo.DataSource = myInsumo.MostrarInsumo();
            OcultarColunasInsumo();
            lblTotalInsumo.Text = "Total de Registros:  " + Convert.ToString(dgvInsumo.Rows.Count);

            dgvInsumo.Columns[1].HeaderText = "CÓDIGO";
            dgvInsumo.Columns[2].HeaderText = "NOME";
            dgvInsumo.Columns[3].HeaderText = "TIPO\nARMAZENAMENTO";
            dgvInsumo.Columns[4].HeaderText = "PREÇO";

            dgvInsumo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInsumo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridViewInsumo();
        }

      

        private void BuscarNomeInsumo()

        {
            myInsumo = new ControlInsumo();

            dgvInsumo.DataSource = myInsumo.BuscarNomeInsumo(txtBuscarInsumo.Text);
            lblTotalInsumo.Text = "Total de Registros:  " + Convert.ToString(dgvInsumo.Rows.Count);
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

        private void ValidarCampoNulo(ComboBox campo)
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

        private void ViewInsumo_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            MostrarInsumo();
            Habilitar(false);
            Botoes();
        }

        private void txtBuscarInsumo_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeInsumo();
        }

        private void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            BuscarNomeInsumo();
        }

        private void btnDeletarInsumo_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvInsumo.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há insumos selecionados para excluir");
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

                        foreach (DataGridViewRow row in dgvInsumo.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myInsumo = new ControlInsumo(Codigo);

                                resp = myInsumo.DS_Mensagem;
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

                        MostrarInsumo();
                        chkDeletarInsumo.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void chkDeletarInsumo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarInsumo.Checked)
            {
                dgvInsumo.Columns[0].Visible = true;
            }
            else
            {
                dgvInsumo.Columns[0].Visible = false;
            }
        }

        private void dgvInsumo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvInsumo.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvInsumo.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void dgvInsumo_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoInsumo.Text = Convert.ToString(dgvInsumo.CurrentRow.Cells["ID_Insumo"].Value);
            txtNomeInsumo.Text = Convert.ToString(dgvInsumo.CurrentRow.Cells["NM_Insumo"].Value);

            cbArmazenamentoInsumo.Text = Convert.ToString(dgvInsumo.CurrentRow.Cells["DS_TipoArmazenamento"].Value);

            txtPrecoInsumo.Text = Convert.ToString(dgvInsumo.CurrentRow.Cells["PR_Insumo"].Value);

            tctrlInsumo.SelectedIndex = 1;
        }

        private void btnNovoInsumo_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            Habilitar(true);
            txtNomeInsumo.Focus();
        }

        private void btnSalvarInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                bool NomeInsumoOK = false;
                bool ArmazenamentoInsumoOK = false;
                bool PrecoInsumoOK = false;

                string resp = "";

                ValidarCampoNulo(txtNomeInsumo);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtNomeInsumo, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        NomeInsumoOK = true;
                    }
                }

                ValidarCampoNulo(cbArmazenamentoInsumo);
                if (myValidar.CampoValido == true)
                {
                    ArmazenamentoInsumoOK = true;
                }


                ValidarCampoNulo(txtPrecoInsumo);
                if (myValidar.CampoValido == true)
                {
                    ValidarValor(txtPrecoInsumo);
                    if (myValidar.ValorValido == true)
                    {
                        PrecoInsumoOK = true;
                    }
                }

                bool INScadastrado = false;

                foreach (DataGridViewRow row in dgvInsumo.Rows)
                {
                    if (txtCodigoInsumo.Text != Convert.ToString(row.Cells["ID_Insumo"].Value))
                    {
                        if (txtNomeInsumo.Text == Convert.ToString(row.Cells["NM_Insumo"].Value))
                        {
                            INScadastrado = true;
                        }
                    }
                }

                if (INScadastrado == true)
                {
                    MensagemErro("Insumo já cadastrado na base de dados");
                }
                else
                {
                    if (NomeInsumoOK == false ||
                        ArmazenamentoInsumoOK == false ||
                        PrecoInsumoOK == false)
                    {
                        MensagemErro("Por favor, preencha todos os campos corretamente");
                    }
                    else
                    {
                        errorIcone.Clear();

                        if (eNovo)
                        {
                            myInsumo = new ControlInsumo(txtNomeInsumo.Text, cbArmazenamentoInsumo.Text, txtPrecoInsumo.Text);
                            resp = myInsumo.DS_Mensagem;
                        }
                        else
                        {
                            myInsumo = new ControlInsumo(txtCodigoInsumo.Text, txtNomeInsumo.Text, cbArmazenamentoInsumo.Text, txtPrecoInsumo.Text);
                            resp = myInsumo.DS_Mensagem;
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

                        eNovo = false;
                        eEditar = false;
                        Botoes();
                        Limpar();
                        MostrarInsumo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditarInsumo_Click(object sender, EventArgs e)
        {
            if (txtCodigoInsumo.Text.Equals(""))
            {
                MensagemErro("Selecione um registro para editar");
            }
            else
            {
                txtNomeInsumo.Focus();
                eEditar = true;
                Botoes();
                Habilitar(true);
            }
        }

        private void btnCancelarInsumo_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();
        }

        private void tctrlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlInsumo.SelectedIndex == 0)
            {
                Habilitar(false);
                Limpar();

                btnNovoInsumo.Enabled = true;
                btnSalvarInsumo.Enabled = false;
                btnEditarInsumo.Enabled = true;
                btnCancelarInsumo.Enabled = false;
            }
        }

      

    }
}
