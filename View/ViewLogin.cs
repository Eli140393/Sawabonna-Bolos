using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ViewLogin : Form
    {
        ControlLogin myLogin;
        ControlFuncionario myFuncionario;
        ControlNivelAcesso myNivelAcesso;
        Validar myValidar = new Validar();

        private bool eNovo = false;

        private bool eEditar = false;
        private string status { get; set; }
        private string action { get; set; }


        public ViewLogin()
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
            txtCodigoLogin.Text = string.Empty;
            cboxNomeFuncionarioLogin.Text = null;
            txtUsuarioLogin.Text = string.Empty;
            txtSenhaLogin.Text = string.Empty;
            cboxNivelAcessoLogin.Text = null;
        }

        private void ValidaCampoSenha(TextBox text)
        {
            string campo = text.Text;
            int count = 0;
            foreach (char c in campo)
            {
                count++;

            }
            if (count >= 8)
            {
                btnCaracteres.IconColor = Color.LimeGreen;
            }
            else
            {
                btnCaracteres.IconColor = Color.Red;

            }


            int maiusculas = campo.Count(char.IsUpper);

            if (maiusculas >= 1)
            {
                btnMaiuscula.IconColor = Color.LimeGreen;

            }
            else
            {
                btnMaiuscula.IconColor = Color.Red;

            }
        }

        // Habilitar os text box
        private void Habilitar(bool Valor)
        {
            txtCodigoLogin.Enabled = false;

            if (eEditar == true)
            {
                cboxNomeFuncionarioLogin.Enabled = false;

            }
            else
            {
                cboxNomeFuncionarioLogin.Enabled = Valor;

            }
            txtUsuarioLogin.Enabled = Valor;
            txtSenhaLogin.Enabled = Valor;
            cboxNivelAcessoLogin.Enabled = Valor;
        }

        // Habilitar os botões
        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovoLogin.Enabled = false;
                btnSalvarLogin.Enabled = true;
                btnEditarLogin.Enabled = false;
                btnCancelarLogin.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovoLogin.Enabled = true;
                btnSalvarLogin.Enabled = false;
                btnEditarLogin.Enabled = true;
                btnCancelarLogin.Enabled = false;
            }
        }

        private void OcultarDeletarLogin()
        {
            dgvLogin.Columns[0].Visible = false;
        }

        private void HabilitarDataGridView()
        {
            if (dgvLogin.Rows.Count == 0)
            {
                chkDeletarLogin.Enabled = false;
                btnDeletarLogin.Enabled = false;
                txtBuscarLogin.Enabled = false;
                btnBuscarLogin.Enabled = false;
                dgvLogin.Enabled = false;
                btnAtivar.Enabled = false;

            }
            else
            {
                chkDeletarLogin.Enabled = true;
                btnDeletarLogin.Enabled = true;
                txtBuscarLogin.Enabled = true;
                btnBuscarLogin.Enabled = true;
                dgvLogin.Enabled = true;
                btnAtivar.Enabled = true;
                chkInativos.Enabled = true;
            }
        }

        private void MostrarLogin()
        {
            string ativos = "1";
            string inativos = "0";

            myLogin = new ControlLogin();

            if (chkInativos.Checked == true)
            {
                dgvLogin.DataSource = myLogin.MostrarLogin(inativos);
                dgvLogin.Columns[0].HeaderText = "Ativar";




            }
            else
            {

                dgvLogin.DataSource = myLogin.MostrarLogin(ativos);

                dgvLogin.Columns[0].HeaderText = "Deletar";

            }

            OcultarDeletarLogin();
            lblTotalLogin.Text = "Total de Registros:  " + Convert.ToString(dgvLogin.Rows.Count);

            dgvLogin.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvLogin.Columns[1].HeaderText = "CÓDIGO";
            dgvLogin.Columns[2].Visible = false;
            dgvLogin.Columns[3].HeaderText = "FUNCIONÁRIO";
            dgvLogin.Columns[4].Visible = false;
            dgvLogin.Columns[5].HeaderText = "NÍVEL\nACESSO";
            dgvLogin.Columns[6].HeaderText = "USUÁRIO";
            dgvLogin.Columns[7].HeaderText = "SENHA";

            dgvLogin.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLogin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridView();
        }

        private void MostrarNivelAcesso()
        {
            myNivelAcesso = new ControlNivelAcesso();
            cboxNivelAcessoLogin.DataSource = myNivelAcesso.MostrarNivelAcesso();
            cboxNivelAcessoLogin.DisplayMember = "DS_NivelAcesso";
            cboxNivelAcessoLogin.ValueMember = "ID_NivelAcesso";
        }

        private void MostrarFuncionarioLogin()
        {
            status = "1";
            myFuncionario = new ControlFuncionario();
            cboxNomeFuncionarioLogin.DataSource = myFuncionario.MostrarFuncionario(status);
            cboxNomeFuncionarioLogin.DisplayMember = "NM_Funcionario";
            cboxNomeFuncionarioLogin.ValueMember = "ID_Funcionario";
        }



        private void BuscarNomeFuncionarioLogin()
        {
            myLogin = new ControlLogin();

            if (chkInativos.Checked == true)
            {
                status = "0";
                dgvLogin.DataSource = myLogin.BuscarNomeFuncionarioLogin(status, txtBuscarLogin.Text);
            }
            else
            {
                status = "1";
                dgvLogin.DataSource = myLogin.BuscarNomeFuncionarioLogin(status, txtBuscarLogin.Text);
            }

            OcultarDeletarLogin();
            lblTotalLogin.Text = "Total de Registros:  " + Convert.ToString(dgvLogin.Rows.Count);
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

        private void ValidarSenha(TextBox campo)
        {
            string senhavalida = Convert.ToString(campo.Text);
            myValidar.SenhaCompleta(senhavalida);

            if (myValidar.SenhaOk == false)
            {
                errorIcone.SetError(campo, "A senha Precisa ter pelo menos 8 caracteres \n e no minímo uma letra maiscula");
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

        private void ViewLogin_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            
            Habilitar(false);
            Botoes();
            MostrarLogin();

            MostrarNivelAcesso();
            MostrarFuncionarioLogin();

            cboxNomeFuncionarioLogin.Text = null;
            cboxNivelAcessoLogin.Text = null;
        }

        private void txtBuscarLogin_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeFuncionarioLogin();
        }

        private void btnBuscarLogin_Click(object sender, EventArgs e)
        {
            BuscarNomeFuncionarioLogin();
        }

        private void btnDeletarLogin_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvLogin.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há logins selecionados para excluir");
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

                        foreach (DataGridViewRow row in dgvLogin.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToInt32(row.Cells[1].Value);
                                myLogin = new ControlLogin(action, Codigo);
                                resp = myLogin.DS_Mensagem;
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

                        MostrarLogin();
                        chkDeletarLogin.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void chkDeletarLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarLogin.Checked)
            {
                dgvLogin.Columns[0].Visible = true;
                chkInativos.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                dgvLogin.Columns[0].Visible = false;
                chkInativos.Enabled = true;
                btnAtivar.Enabled = true;
            }
        }

        private void dgvLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLogin.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvLogin.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void dgvLogin_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoLogin.Text = Convert.ToString(dgvLogin.CurrentRow.Cells["ID_Login"].Value);
            cboxNomeFuncionarioLogin.Text = Convert.ToString(dgvLogin.CurrentRow.Cells["NM_Funcionario"].Value);
            txtUsuarioLogin.Text = Convert.ToString(dgvLogin.CurrentRow.Cells["DS_Usuario"].Value);
            txtSenhaLogin.Text = Convert.ToString(dgvLogin.CurrentRow.Cells["DS_Senha"].Value);
            cboxNivelAcessoLogin.Text = Convert.ToString(dgvLogin.CurrentRow.Cells["DS_NivelAcesso"].Value);

            tctrlLogin.SelectedIndex = 1;
        }

        private void btnNovoLogin_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            Habilitar(true);
            cboxNomeFuncionarioLogin.Focus();
        }

        private void btnSalvarLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool FuncionarioLoginOK = false;
                bool UsuarioLoginOK = false;
                bool SenhaLoginOK = false;
                bool NivelAcessoLoginOK = false;

                string resp = "";

                if (cboxNomeFuncionarioLogin.Text == string.Empty)
                {
                    errorIcone.SetError(cboxNomeFuncionarioLogin, "Selecione o funcionário deste login");
                }
                else
                {
                    errorIcone.SetError(cboxNomeFuncionarioLogin, string.Empty);
                    FuncionarioLoginOK = true;
                }

                ValidarCampoNulo(txtUsuarioLogin);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtUsuarioLogin, 20);
                    if (myValidar.TamanhoValido == true)
                    {
                        UsuarioLoginOK = true;
                    }
                }

                ValidarCampoNulo(txtSenhaLogin);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtSenhaLogin, 20);
                    if (myValidar.TamanhoValido == true)
                    {
                        SenhaLoginOK = true;
                    }
                }

                ValidarSenha(txtSenhaLogin);
                if (myValidar.SenhaOk == false)
                {
                    SenhaLoginOK = false;
                }



                if (cboxNivelAcessoLogin.Text == string.Empty)
                {
                    errorIcone.SetError(cboxNivelAcessoLogin, "Selecione o nível de acesso deste login");
                }
                else
                {
                    errorIcone.SetError(cboxNivelAcessoLogin, string.Empty);
                    NivelAcessoLoginOK = true;
                }

                bool FunLoginCadastrado = false;

                foreach (DataGridViewRow row in dgvLogin.Rows)
                {
                    if (txtCodigoLogin.Text != Convert.ToString(row.Cells["ID_Login"].Value))
                    {
                        if (cboxNomeFuncionarioLogin.Text == Convert.ToString(row.Cells["NM_Funcionario"].Value))
                        {
                            FunLoginCadastrado = true;
                        }
                    }
                }

                if (FunLoginCadastrado == true)
                {
                    MensagemErro("Funcionário já tem um login cadastrado na base de dados");
                }
                else
                {
                    bool UserLoginCadastrado = false;

                    foreach (DataGridViewRow row in dgvLogin.Rows)
                    {
                        if (txtCodigoLogin.Text != Convert.ToString(row.Cells["ID_Login"].Value))
                        {
                            if (txtUsuarioLogin.Text == Convert.ToString(row.Cells["DS_Usuario"].Value))
                            {
                                UserLoginCadastrado = true;
                            }
                        }
                    }

                    if (UserLoginCadastrado == true)
                    {
                        MensagemErro("Este nome de usuário já pertence a um login cadastrado na base de dados");
                    }
                    else
                    {
                        if (FuncionarioLoginOK == false ||
                            UsuarioLoginOK == false ||
                            SenhaLoginOK == false ||
                            NivelAcessoLoginOK == false)
                        {
                            MensagemErro("Por favor, preencha corretamente os campos sinalizados");
                        }
                        else
                        {
                            errorIcone.Clear();

                            if (eNovo)
                            {
                                action = "inserir";
                                myLogin = new ControlLogin(action, cboxNomeFuncionarioLogin.SelectedValue.ToString(), cboxNivelAcessoLogin.SelectedValue.ToString(), txtUsuarioLogin.Text,
                                txtSenhaLogin.Text);
                                resp = myLogin.DS_Mensagem;
                            }
                            else
                            {
                                action = "editar";

                                myLogin = new ControlLogin(action, txtCodigoLogin.Text, cboxNivelAcessoLogin.SelectedValue.ToString(),
                                    txtUsuarioLogin.Text, txtSenhaLogin.Text);
                                resp = myLogin.DS_Mensagem;
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
                                Habilitar(false);
                                Limpar();
                                MostrarLogin();
                            }
                            else
                            {
                                MensagemErro(resp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditarLogin_Click(object sender, EventArgs e)
        {
            if (txtCodigoLogin.Text.Equals(""))
            {
                MensagemErro("Selecione um registro para editar");
            }
            else
            {
                cboxNomeFuncionarioLogin.Focus();
                eEditar = true;
                Botoes();
                Habilitar(true);
            }
        }

        private void btnCancelarLogin_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();
        }

        private void tctrlLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlLogin.SelectedIndex == 0)
            {
                Habilitar(false);
                Limpar();

                btnNovoLogin.Enabled = true;
                btnSalvarLogin.Enabled = false;
                btnEditarLogin.Enabled = true;
                btnCancelarLogin.Enabled = false;
            }
        }

        private void chkInativos_CheckedChanged(object sender, EventArgs e)
        {


            if (chkInativos.Checked == true)
            {
                MostrarLogin();

                btnDeletarLogin.Enabled = false;
                btnAtivar.Enabled = true;
                dgvLogin.Columns[0].Visible = true;
                chkDeletarLogin.Enabled = false;


            }
            else
            {
                btnDeletarLogin.Enabled = true;
                btnAtivar.Enabled = false;
                dgvLogin.Columns[0].Visible = false;
                chkDeletarLogin.Enabled = true;
                MostrarLogin();

            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvLogin.Rows)
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
                        action = "ativar";

                        foreach (DataGridViewRow row in dgvLogin.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToInt32(row.Cells[1].Value);
                                myLogin = new ControlLogin(action, Codigo);
                                resp = myLogin.DS_Mensagem;
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

                        MostrarLogin();
                        chkInativos.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void txtSenhaLogin_TextChanged(object sender, EventArgs e)
        {
            ValidaCampoSenha(txtSenhaLogin);
        }
    }
}
