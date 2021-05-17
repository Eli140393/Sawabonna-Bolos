using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ViewLoginAcesso : Form
    {

        ControlLogin myLogin;
        Validar myValidar = new Validar();
        DataTable dtlogin;
        DataTable dtRegistroLogin;


        private int ID_Login { get; set; }
        public int ID_Funcionario { get; set; }

        private string DS_Usuario { get; set; }
        private string DS_Senha { get; set; }
        private string DS_Mensagem { get; set; }
        private string action { get; set; }



        public ViewLoginAcesso()
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




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void ArredondaCantosForm()
        {

            GraphicsPath PastaGrafica = new GraphicsPath();
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, Size.Width, Size.Height));

            //Arredondar canto superior esquerdo        
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, 10, 10));
            PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

            //Arredondar canto superior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(Width - 12, 1, 12, 13));
            PastaGrafica.AddPie(Width - 24, 1, 24, 26, 270, 90);

            //Arredondar canto inferior esquerdo
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, Height - 10, 10, 10));
            PastaGrafica.AddPie(1, Height - 20, 20, 20, 90, 90);

            //Arredondar canto inferior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(Width - 12, Height - 13, 13, 13));
            PastaGrafica.AddPie(Width - 24, Height - 26, 24, 26, 0, 90);

            PastaGrafica.SetMarkers();
            Region = new Region(PastaGrafica);
        }

        private void ValidarUsuario(TextBox campo)
        {
            string campovalido = Convert.ToString(campo.Text);
            myValidar.UsuarioVazio(campovalido);

            if (myValidar.UsuarioValido == false)
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
            string campovalido = Convert.ToString(campo.Text);
            myValidar.SenhaVazia(campovalido);

            if (myValidar.SenhaValida == false)
            {
                errorIcone.SetError(campo, "Este campo é obrigatório");
            }
            else
            {
                errorIcone.SetError(campo, string.Empty);
            }
        }



        private void ViewLoginAcesso_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUÁRIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUÁRIO";
                txtUsuario.ForeColor = Color.White;
            }

            txtUsuario.BackColor = Color.Violet;

        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "SENHA")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.White;
                txtSenha.UseSystemPasswordChar = true;
            }
            if (txtSenha.UseSystemPasswordChar == true)
            {
                btnVisualizaPassoword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "SENHA";
                txtSenha.ForeColor = Color.White;
                txtSenha.UseSystemPasswordChar = false;
            }
            if (txtSenha.UseSystemPasswordChar == false)
            {
                btnVisualizaPassoword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            txtSenha.BackColor = Color.Violet;

        }

        private void btnVisualizaPassoword_Click_1(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                btnVisualizaPassoword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                btnVisualizaPassoword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult Opcao;
            Opcao = MessageBox.Show(
                "Realmente deseja fechar o programa ?",
                "SAWABONA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (Opcao == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panelLateral_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ViewLoginAcesso_Load(object sender, EventArgs e)
        {
            ArredondaCantosForm();
        }

        private bool VerificaLogin()
        {
            bool ValidaLogin = false;

            dtlogin = new DataTable();
            myLogin = new ControlLogin(txtUsuario.Text, txtSenha.Text);

            DS_Mensagem = myLogin.DS_Mensagem;
            if (DS_Mensagem == "OK")
            {
                dtlogin = myLogin.ValidaLogin(txtUsuario.Text, txtSenha.Text);


                for (int i = 0; i < dtlogin.Rows.Count; i++)
                {
                    ID_Login = Convert.ToInt32(dtlogin.Rows[i]["ID_Login"]);
                    DS_Senha = Convert.ToString(dtlogin.Rows[i]["DS_Senha"]);
                    ID_Funcionario = Convert.ToInt32(dtlogin.Rows[i]["ID_Funcionario"]);
                    DS_Usuario = Convert.ToString(dtlogin.Rows[i]["DS_usuario"]);
                }
                
                if (DS_Usuario.Equals(txtUsuario.Text) == true)
                {
                    if ((DS_Senha.Equals(txtSenha.Text) == true))
                    {
                        ValidaLogin = true;
                    }
                }

            }
            return ValidaLogin;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool LoginOK = false;
                bool UsuarioLoginOK = false;
                bool SenhaLoginOK = false;
                bool RegistroLoginOk = false;



                ValidarUsuario(txtUsuario);
                if (myValidar.UsuarioValido == true)
                {
                    UsuarioLoginOK = true;
                }

                ValidarSenha(txtSenha);
                if (myValidar.SenhaValida == true)
                {
                    SenhaLoginOK = true;
                }

                if (UsuarioLoginOK == false ||
                SenhaLoginOK == false)
                {
                    MensagemErro("Por favor, preencha corretamente os campos sinalizados");
                }
                else
                {
                    errorIcone.Clear();
                    LoginOK = VerificaLogin();

                    if (LoginOK == true)

                    {
                        MensagemOk("Login efetuado com sucesso");

                        dtRegistroLogin = new DataTable();

                        dtRegistroLogin = myLogin.MostrarRegistroLogin();

                        for (int i = 0; i < dtRegistroLogin.Rows.Count; i++)
                        {
                            if (ID_Login == Convert.ToInt32(dtRegistroLogin.Rows[i]["ID_Login"]))
                            {
                                action = "editar";

                                myLogin = new ControlLogin(action, ID_Login);
                                DS_Mensagem = myLogin.DS_Mensagem;
                                RegistroLoginOk = true;
                                break;
                            }

                        }
                        if (RegistroLoginOk == false)
                        {
                            myLogin = new ControlLogin(ID_Login);
                            DS_Mensagem = myLogin.DS_Mensagem;

                        }
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MensagemErro("Login inválido, por favor, verifique os dados e tente novamente\n Vefique  também a posição de letras maiúsculas e minúsculas");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtSenha_MouseMove(object sender, MouseEventArgs e)
        {

            if (txtUsuario.BackColor != Color.Orchid)
            {
                txtSenha.BackColor = Color.Orchid;

            }
        }


        private void txtUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSenha.BackColor != Color.Orchid)
            {
                txtUsuario.BackColor = Color.Orchid;

            }

        }

        private void txtSenha_MouseLeave(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.Violet;

        }

        private void txtUsuario_MouseLeave(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.Violet;

        }
    }
}
