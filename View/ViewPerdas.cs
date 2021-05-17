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
    public partial class ViewPerdas : Form
    {
        Validar myValidar = new Validar();

        ControlEstoque myEstoque;
        ControlPerda myPerda;

        TabPage TabRemove = new TabPage();

        private bool eNovo = false;



        public ViewPerdas()
        {
            InitializeComponent();
        }

        public ViewPerdas(int id_unidade)
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

     

        private void MostrarTabValidar()
        {
            tctrlUnidadeRede.Controls.Add(TabRemove);
        }




        private void Limpar()
        {
            txtCodigoInsumoPerda.Text = string.Empty;
            txtNomeInsumoPerda.Text = string.Empty;
            txtQuantidadeInsumoPerda.Text = string.Empty;
            txtQuantidadePerda.Text = string.Empty;
        }
        // Habilitar os text box
        private void Habilitar(bool Valor)
        {

            txtQuantidadePerda.Enabled = Valor;
            txtMotivoPerdaInsumo.Enabled = Valor;

        }
        private void Botoes()
        {
            if (eNovo)
            {
                btnSalvarPerdas.Enabled = true;
                btnCancelarPerdas.Enabled = true;

            }
            else
            {
                btnSalvarPerdas.Enabled = false;
                btnCancelarPerdas.Enabled = false;
            }
        }
        private void HabilitarDataGridView()
        {
            if (dgvPerdas.Rows.Count == 0)
            {
                chkDeletarPerda.Enabled = false;
                btnDeletarPerda.Enabled = false;
                txtBuscarPerdas.Enabled = false;
                dgvPerdas.Enabled = false;
            }
            else
            {
                chkDeletarPerda.Enabled = true;
                btnDeletarPerda.Enabled = true;
                txtBuscarPerdas.Enabled = true;
                dgvPerdas.Enabled = true;
            }
        }


        private void HabilitarDataGridViewEstoque()
        {
            if (dgvEstoque.Rows.Count == 0)
            {

                txtBuscarEstoque.Enabled = false;
                btnBuscarEstoque.Enabled = false;
                dgvEstoque.Enabled = false;
            }
            else
            {

                txtBuscarEstoque.Enabled = true;
                btnBuscarEstoque.Enabled = true;
                dgvEstoque.Enabled = true;
            }
        }

        private void MostrarPerdas()
        {
            myPerda = new ControlPerda();
            dgvPerdas.DataSource = myPerda.MostrarPerda();
            lblTotalPerdas.Text = "Total de Registros:  " + Convert.ToString(dgvPerdas.Rows.Count);

            dgvPerdas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvPerdas.Columns[1].HeaderText = "CÓDIGO";
            dgvPerdas.Columns[3].HeaderText = "INSUMO"; 
            dgvPerdas.Columns[4].HeaderText = "QUANTIDADE";  
            dgvPerdas.Columns[5].HeaderText = "MOTIVO";  
            dgvPerdas.Columns[6].HeaderText = "DATA";
            dgvPerdas.Columns[0].Visible = false;
            dgvPerdas.Columns[2].Visible = false;


            dgvPerdas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPerdas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridView();
        }

        private void MostrarEstoque()
        {
            myEstoque = new ControlEstoque();
            dgvEstoque.DataSource = myEstoque.MostrarEstoque();
            lblTotalEstoque.Text = "Total de Registros:  " + Convert.ToString(dgvEstoque.Rows.Count);

            dgvEstoque.Columns[0].HeaderText = "CODIGO";
            dgvEstoque.Columns[1].HeaderText = "INSUMO";
            dgvEstoque.Columns[2].HeaderText = "QTDE.TOTAL\nESTOQUE";


            dgvEstoque.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridViewEstoque();
        }
        private void BuscarPerda()

        {
            myPerda = new ControlPerda();

            dgvPerdas.DataSource = myPerda.BuscarNomePerda(txtBuscarPerdas.Text);
            lblTotalPerdas.Text = "Total de Registros:  " + Convert.ToString(dgvPerdas.Rows.Count);
        }

        private void BuscarNomeInsumoEstoque()
        {
            myEstoque = new ControlEstoque();

            dgvEstoque.DataSource = myEstoque.BuscarNomeInsumoEstoque(txtBuscarEstoque.Text);
            lblTotalEstoque.Text = "Total de Registros:  " + Convert.ToString(dgvEstoque.Rows.Count);
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
        private void ViewPerdas_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            Habilitar(false);
            Botoes();
            Limpar();
            MostrarPerdas();
            MostrarEstoque();
        }

        private void btnBuscarPerdas_Click(object sender, EventArgs e)
        {

            BuscarPerda();
        }

        private void btnDeletarPerda_Click(object sender, EventArgs e)
        {


            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvPerdas.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;



                }
            }
            if (!marcouitem)
            {
                MensagemErro("Não há perdas selecionadas para excluir");
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
                        string Insumo;
                        string resp = "";
                        string DataValida;

                        foreach (DataGridViewRow row in dgvPerdas.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                Insumo = Convert.ToString(row.Cells[2].Value);
                                DataValida = Convert.ToString(row.Cells[6].Value);

                                if (DataValida == DateTime.Now.ToShortDateString())
                                {
                                    myPerda = new ControlPerda(Codigo, Insumo);
                                    resp = myPerda.DS_Mensagem;
                                }
                                else
                                {
                                    resp = "Este Registro não pode ser apagado \n A data de perda é: " + DataValida + " \n Somente perdas do dia podem ser excluidas";
                                                           
                                }
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

                        MostrarPerdas();
                        chkDeletarPerda.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }



        private void txtBuscarPerdas_TextChanged(object sender, EventArgs e)
        {
            BuscarPerda();
        }

     

        private void btnCancelarPerdas_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            Habilitar(false);
            Limpar();
        }

        private void btnSalvarPerdas_Click(object sender, EventArgs e)
        {
            try
            {
                bool QuantidadePerdasOK = false;
                bool MotivoPerda = false;
                string resp = "";

                ValidarCampoNulo(txtMotivoPerdaInsumo);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtMotivoPerdaInsumo, 150);
                    if (myValidar.TamanhoValido == true)
                    {
                        MotivoPerda = true;
                    }
                }

                ValidarCampoNulo(txtQuantidadePerda);
                if (myValidar.CampoValido == true)
                {
                    ValidarValor(txtQuantidadePerda);
                    if (myValidar.ValorValido == true)
                    {
                        QuantidadePerdasOK = true;
                    }

                }



                bool QuantidadePerdaValida = false;
                double QtdeEmEstoque = Convert.ToDouble(txtQuantidadeInsumoPerda.Text);
                double QtdePerda = Convert.ToDouble(txtQuantidadePerda.Text);

                if (QtdePerda < QtdeEmEstoque)
                {

                    QuantidadePerdaValida = true;

                }

                else
                {
                    errorIcone.SetError(txtQuantidadePerda, "A Quantidade em estoque \n é menor que a quantidade da perda \n Digite um valor válido");
                }

                if (QuantidadePerdasOK == false ||
                    MotivoPerda == false ||
                    QuantidadePerdaValida == false)
                {
                    MensagemErro("Por favor, preencha todos os campos corretamente");
                }
                else
                {
                    errorIcone.Clear();

                    myPerda = new ControlPerda(txtCodigoInsumoPerda.Text, txtQuantidadePerda.Text, txtMotivoPerdaInsumo.Text);
                    resp = myPerda.DS_Mensagem;


                    if (resp.Equals("OK"))
                    {
                        string action = "baixa";
                        myEstoque = new ControlEstoque(action, txtCodigoInsumoPerda.Text, txtQuantidadePerda.Text);
                        MensagemOk("Registro salvo com sucesso");

                    }
                    else
                    {
                        MensagemErro(resp);
                    }

                    Habilitar(false);
                    Limpar();
                    MostrarPerdas();
                    MostrarEstoque();
                    eNovo = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtBuscarEstoque_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeInsumoEstoque();
        }

        private void btnBuscarEstoque_Click(object sender, EventArgs e)
        {
            BuscarNomeInsumoEstoque();
        }

        private void dgvEstoque_DoubleClick(object sender, EventArgs e)
        {
            Limpar();

            txtCodigoInsumoPerda.Text = Convert.ToString(dgvEstoque.CurrentRow.Cells["ID_Insumo"].Value);
            txtNomeInsumoPerda.Text = Convert.ToString(dgvEstoque.CurrentRow.Cells["NM_Insumo"].Value);
            txtQuantidadeInsumoPerda.Text = Convert.ToString(dgvEstoque.CurrentRow.Cells["QTDE_Estoque"].Value);
            eNovo = true;
            Habilitar(true);
            Botoes();
        }

        private void chkDeletarPerda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarPerda.Checked)
            {
                dgvPerdas.Columns[0].Visible = true;
            }
            else
            {
                dgvPerdas.Columns[0].Visible = false;
            }
        }

        private void dgvPerdas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPerdas.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvPerdas.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }
    }
}
