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
    public partial class ViewCategoria : Form
    {
        ControlCategoria myCategoria;
        Validar myValidar = new Validar();

        private bool eNovo { get; set; } = false;
        private bool eEditar { get; set; } = false;

        private string action { get; set; }
        private string ativos { get; set; }


        public ViewCategoria()
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
            txtCodigoCategoria.Text = string.Empty;
            txtNomeCategoria.Text = string.Empty;
            txtDescricaoCategoria.Text = string.Empty;
        }

        // Habilitar os text box
        private void Habilitar(bool Valor)
        {
            txtCodigoCategoria.Enabled = false;
            txtNomeCategoria.Enabled = Valor;
            txtDescricaoCategoria.Enabled = Valor;
        }

        // Habilitar os botões
        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovoCategoria.Enabled = false;
                btnSalvarCategoria.Enabled = true;
                btnEditarCategoria.Enabled = false;
                btnCancelarCategoria.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovoCategoria.Enabled = true;
                btnSalvarCategoria.Enabled = false;
                btnEditarCategoria.Enabled = true;
                btnCancelarCategoria.Enabled = false;
            }
        }

        private void OcultarColunas()
        {
            dgvCategoria.Columns[0].Visible = false;
        }

        private void HabilitarDataGridView()
        {
            if (dgvCategoria.Rows.Count == 0)
            {
                chkDeletarCategoria.Enabled = false;
                btnDeletarCategoria.Enabled = false;
                txtBuscarCategoria.Enabled = false;
                btnBuscarCategoria.Enabled = false;
                dgvCategoria.Enabled = false;
            }
            else
            {
                chkDeletarCategoria.Enabled = true;
                btnDeletarCategoria.Enabled = true;
                txtBuscarCategoria.Enabled = true;
                btnBuscarCategoria.Enabled = true;
                dgvCategoria.Enabled = true;
            }
        }

        private void MostrarCategoria()
        {

            myCategoria = new ControlCategoria();
            if (chkInativos.Checked == true)
            {
                ativos = "0";

                dgvCategoria.DataSource = myCategoria.MostrarCategoria(ativos);
                dgvCategoria.Columns[0].HeaderText = "Ativar";
            }
            else
            {
                ativos = "1";

                dgvCategoria.DataSource = myCategoria.MostrarCategoria(ativos);
                dgvCategoria.Columns[0].HeaderText = "Deletar";

            }
            OcultarColunas();
            lblTotalCategoria.Text = "Total de Registros:  " + Convert.ToString(dgvCategoria.Rows.Count);

              dgvCategoria.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvCategoria.Columns[1].HeaderText = "CÓDIGO";
            dgvCategoria.Columns[2].HeaderText = "NOME";
            dgvCategoria.Columns[3].HeaderText = "DESCRIÇÃO";

            dgvCategoria.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridView();
        }

        private void BuscarNomeCategoria()
        {
            myCategoria = new ControlCategoria();

            dgvCategoria.DataSource = myCategoria.BuscarNomeCategoria(txtBuscarCategoria.Text);
            lblTotalCategoria.Text = "Total de Registros:  " + Convert.ToString(dgvCategoria.Rows.Count);
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

        private void ViewCategoria_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            MostrarCategoria();
            Habilitar(false);
            Botoes();
        }

        private void dgvCategoria_DoubleClick(object sender, EventArgs e)
        {

            txtCodigoCategoria.Text = Convert.ToString(dgvCategoria.CurrentRow.Cells["ID_Categoria"].Value);
            txtNomeCategoria.Text = Convert.ToString(dgvCategoria.CurrentRow.Cells["NM_Categoria"].Value);
            txtDescricaoCategoria.Text = Convert.ToString(dgvCategoria.CurrentRow.Cells["DS_Categoria"].Value);

            tctrlCategoria.SelectedIndex = 1;
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCategoria.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvCategoria.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }
       
        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeCategoria();
        }

        private void chkDeletarCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarCategoria.Checked)
            {
                dgvCategoria.Columns[0].Visible = true;
                chkInativos.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                dgvCategoria.Columns[0].Visible = false;
                chkInativos.Enabled = true;
                btnAtivar.Enabled = true;
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            BuscarNomeCategoria();
        }

        private void btnDeletarCategoria_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvCategoria.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há categorias selecionados para excluir");
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
                        int Codigo;
                        string resp = "";
                        action = "excluir";
                        foreach (DataGridViewRow row in dgvCategoria.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToInt32(row.Cells[1].Value);

                                myCategoria = new ControlCategoria(action, Codigo);
                                resp = myCategoria.DS_Mensagem;
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

                        MostrarCategoria();
                        chkDeletarCategoria.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void btnNovoCategoria_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            Habilitar(true);
            txtNomeCategoria.Focus();
        }

        private void btnSalvarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                bool NomeCategoriaOK = false;
                bool DescricaoCategoriaOK = false;

                string resp = "";

                ValidarCampoNulo(txtNomeCategoria);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtNomeCategoria, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        NomeCategoriaOK = true;
                    }
                }

                ValidarCampoNulo(txtDescricaoCategoria);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtDescricaoCategoria, 150);
                    if (myValidar.TamanhoValido == true)
                    {
                        DescricaoCategoriaOK = true;
                    }
                }


                bool CATcadastrada = false;

                foreach (DataGridViewRow row in dgvCategoria.Rows)
                {
                    if (txtCodigoCategoria.Text != Convert.ToString(row.Cells["ID_Categoria"].Value))
                    {
                        if (txtNomeCategoria.Text == Convert.ToString(row.Cells["NM_Categoria"].Value))
                        {
                            CATcadastrada = true;
                        }
                    }
                }

                if (CATcadastrada == true)
                {
                    MensagemErro("Categoria já cadastrada na base de dados");
                }
                else
                {
                    if (NomeCategoriaOK == false ||
                        DescricaoCategoriaOK == false)
                    {
                        MensagemErro("Por favor, preencha corretamente os campos sinalizados");
                    }
                    else
                    {
                        errorIcone.Clear();

                        if (eNovo)
                        {

                            myCategoria = new ControlCategoria(txtNomeCategoria.Text.Trim(),
                            txtDescricaoCategoria.Text.Trim());
                            resp = myCategoria.DS_Mensagem;
                        }
                        else
                        {
                            myCategoria = new ControlCategoria(txtCodigoCategoria.Text, txtNomeCategoria.Text.Trim(),
                            txtDescricaoCategoria.Text.Trim());
                            resp = myCategoria.DS_Mensagem;
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
                        MostrarCategoria();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if (txtNomeCategoria.Text.Equals(""))
            {
                MensagemErro("Selecione um registro para editar");
            }
            else
            {
                txtCodigoCategoria.Enabled = false;
                txtNomeCategoria.Focus();
                eEditar = true;
                Botoes();
                Habilitar(true);
            }
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();
        }

        private void tctrlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlCategoria.SelectedIndex == 0)
            {
                Habilitar(false);
                Limpar();

                btnNovoCategoria.Enabled = true;
                btnSalvarCategoria.Enabled = false;
                btnEditarCategoria.Enabled = true;
                btnCancelarCategoria.Enabled = false;
            }
        }

        private void chkInativos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarCategoria();

            if (chkInativos.Checked == true)
            {
                btnDeletarCategoria.Enabled = false;
                btnAtivar.Enabled = true;
                dgvCategoria.Columns[0].Visible = true;
                chkDeletarCategoria.Enabled = false;


            }
            else
            {
                btnDeletarCategoria.Enabled = true;
                btnAtivar.Enabled = false;
                dgvCategoria.Columns[0].Visible = false;
                chkDeletarCategoria.Enabled = true;
                MostrarCategoria();

            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvCategoria.Rows)
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
                        int Codigo;
                        string resp = "";
                        string action = "ativar";

                        foreach (DataGridViewRow row in dgvCategoria.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToInt32(row.Cells[1].Value);
                                myCategoria = new ControlCategoria(action, Codigo);
                                resp = myCategoria.DS_Mensagem;
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

                        MostrarCategoria();
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
