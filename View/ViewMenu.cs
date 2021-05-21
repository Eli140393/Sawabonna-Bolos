using Control;
using FontAwesome.Sharp;
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
using System.Windows.Forms.VisualStyles;

namespace View
{
    public partial class ViewMenu : Form
    {
        private IconButton iconBtn;
        private Panel pnlLeft;
        private Panel pnlLeftGerencia;
        private Form frmAtual;
        ControlLogin mylogin;
        DataTable dtLogin;


        public int ID_Funcionario { get; set; }
        public string NM_Funcionario { get; set; }
        public string DS_NiVelAcesso { get; set; }



        public ViewMenu()
        {
            InitializeComponent();

            pnlLeft = new Panel();
            pnlLeftGerencia = new Panel();
            pnlLeft.Size = new Size(7, 55);
            pnlLeftGerencia.Size = new Size(7, 55);
            pnlMenuItens.Controls.Add(pnlLeft);
            pnlGerenciaBtn.Controls.Add(pnlLeftGerencia);
            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;

            WindowState = FormWindowState.Maximized;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        }


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

        public static void Arredonda(IconButton pButton, int pCanto, bool pTopo, bool pBase)
        {
            // pCanto -> Tamanho do Canto
            // pTopo -> Arredonda o Topo
            // pBase -> Arredonda a Base
            Rectangle r = new Rectangle();
            r = pButton.ClientRectangle;

            pButton.Region = new System.Drawing.Region(SuArredondaRect(r, pCanto, pTopo, pBase));
        }

      


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

        private struct RGBcolors
        {
            public static Color color1 = Color.FromArgb(251, 68, 68); //VERMELHO CLARO
            public static Color color2 = Color.FromArgb(24, 161, 251); //AZUL
            public static Color color3 = Color.FromArgb(185, 0, 253); //ROXO
            public static Color color4 = Color.FromArgb(253, 253, 1); //AMARELO
            public static Color color5 = Color.FromArgb(30, 0, 255); //AZUL ESCURO
            public static Color color6 = Color.FromArgb(88, 242, 68); //VERDE CLARO
            public static Color color7 = Color.FromArgb(255,64, 159); //ROSA 

        }

        private void desativaBtn()
        {
            if (iconBtn != null)
            {


                if (iconBtn.Text != "Bolos     " && iconBtn.Text != "Diversos")
                {

                    iconBtn.BackColor = Color.FromArgb(255,255,255);
                    iconBtn.ForeColor = Color.FromArgb(26, 32, 40);
                    iconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    iconBtn.IconColor = Color.FromArgb(26, 32, 40);
                    iconBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    iconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }
                if (iconBtn.Text == "Bolos     " || iconBtn.Text == "Diversos")
                {
                    iconBtn.BackColor = Color.FromArgb(255, 255, 255);
                    iconBtn.ForeColor = Color.FromArgb(26, 32, 40);
                    iconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    iconBtn.IconColor = Color.FromArgb(26, 32, 40);
                    iconBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    iconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                }
            }
        }

        private void RecolherBtn()
        {
            if (btnViewProduto.Visible == true && btnViewProduto.Capture == false && btnDiversos.Capture == false)
            {
                pnlView.Controls.Clear();

                btnViewProduto.Visible = false;
                btnDiversos.Visible = false;



            }
            if (btnViewProduto.Visible == false && btnProdutos.Capture == true)
            {

                btnViewProduto.Visible = true;
                btnDiversos.Visible = true;




            }
        }



        private void ativaBtn(object senderBtn, Color color)
        {
            desativaBtn();

            iconBtn = (IconButton)senderBtn;
            iconBtn.BackColor = Color.FromArgb(37, 36, 81);
            iconBtn.ForeColor = color;
            iconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            iconBtn.IconColor = color;
            iconBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;

            pnlLeft.BackColor = color;
            pnlLeft.Location = new Point(0, iconBtn.Location.Y);
            pnlLeft.Visible = true;
            pnlLeft.BringToFront();
            iconeFrmFilho.IconChar = iconBtn.IconChar;
            lblTituloFrmFilho.Text = iconBtn.Text;
            iconeFrmFilho.IconColor = Color.FromArgb(26, 32, 40);

        }


        private void ativaBtnGerencia(object senderBtn, Color color)
        {
            desativaBtn();

            iconBtn = (IconButton)senderBtn;
            iconBtn.BackColor = Color.FromArgb(37, 36, 81);
            iconBtn.ForeColor = color;
            iconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            iconBtn.IconColor = color;
            iconBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;

            pnlLeftGerencia.BackColor = color;
            pnlLeftGerencia.Location = new Point(0, iconBtn.Location.Y);
            pnlLeftGerencia.Visible = true;
            pnlLeftGerencia.BringToFront();
            iconeFrmFilho.IconChar = iconBtn.IconChar;
            iconeFrmFilho.IconColor = Color.FromArgb(26, 32, 40);
        }

        private void abrirFormulario(Form frmFilho)
        {
            if (frmAtual != null)
            {
                frmAtual.Close();
            }

            frmAtual = frmFilho;
            frmFilho.TopLevel = false;
            frmFilho.FormBorderStyle = FormBorderStyle.None;
            frmFilho.Dock = DockStyle.Fill;
            pnlView.Controls.Add(frmFilho);
            pnlView.Tag = frmFilho;
            frmFilho.BringToFront();
            frmFilho.Show();
            lblTituloFrmFilho.Text = frmFilho.Text;
        }

        private void reiniciarFrm()
        {
            desativaBtn();
            pnlLeft.Visible = false;
            iconeFrmFilho.IconChar = IconChar.Home;
            iconeFrmFilho.IconColor = Color.FromArgb(26, 32, 40);
            lblTituloFrmFilho.Text = "Início";
        }

        private void pboxMinimizar_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pboxEncerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();

            pnlMenuItens.Controls.Add(lblHora);
            pnlMenuItens.Controls.Add(lblData);
            RecolherBtn();
            reiniciarFrm();
        }

        private void btnViewCliente_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();
            pnlLeftGerencia.Visible = false;
            RecolherBtn();

            ativaBtn(sender, RGBcolors.color7);
            abrirFormulario(new ViewCliente());

            if (pnlGerencia.Height >= 600)
            {
                pnlGerencia.Height = 60;
            }
        }

        private void btnViewVenda_Click(object sender, EventArgs e)
        {

            pnlView.Controls.Clear();
            pnlLeftGerencia.Visible = false;
            RecolherBtn();

            ativaBtn(sender, RGBcolors.color7);
            abrirFormulario(new ViewVenda(ID_Funcionario, NM_Funcionario));

            if (pnlGerencia.Height >= 600)
            {
                pnlGerencia.Height = 60;
            }
        }

        private void btnGerencia_Click(object sender, EventArgs e)
        {

            pnlView.Controls.Clear();
            pnlLeft.Visible = false;
            pnlLeftGerencia.Visible = false;
            RecolherBtn();

            if (pnlGerencia.Height < 600)
            {
                ativaBtnGerencia(sender, RGBcolors.color7);
                lblTituloFrmFilho.Text = btnGerencia.Text;
                pnlGerencia.Height = 600;
            }
            else
            {
                
                pnlGerencia.Height = 60;
            }
        }

        private void btnViewProduto_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color7);
            abrirFormulario(new ViewProduto());
        }

        private void btnViewCategoria_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color7);
            abrirFormulario(new ViewCategoria());
        }

        private void btnViewFuncionario_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color2);
            abrirFormulario(new ViewFuncionario());
        }

        private void btnViewRelatorio_Click(object sender, EventArgs e)
        {
          pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color7);
            abrirFormulario(new ViewRelatorio());
        }

        private void btnViewCompra_Click(object sender, EventArgs e)
        {
              pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color7);
            abrirFormulario(new ViewCompra());
        }

        private void btnViewInsumo_Click(object sender, EventArgs e)
        {
          pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color7);
            abrirFormulario(new ViewInsumo());
        }

        private void btnViewLogin_Click(object sender, EventArgs e)
        {
           pnlView.Controls.Clear();
            RecolherBtn();

            ativaBtnGerencia(sender, RGBcolors.color7);
            abrirFormulario(new ViewLogin());
        }

        private void ViewMenu_Load(object sender, EventArgs e)
        {

            using (ViewLoginAcesso myLogin = new ViewLoginAcesso())
            {
                Visible = false;
                DialogResult = myLogin.ShowDialog();
                if (myLogin.DialogResult != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
                else
                {
                    Visible = true;
                }
            }

            mylogin = new ControlLogin();
            dtLogin = mylogin.MostrarRegistroLogin();
            for (int i = 0; i < dtLogin.Rows.Count; i++)
            {
                if (Convert.ToString(dtLogin.Rows[i]["NM_Funcionario"]) != string.Empty)
                {
                    NM_Funcionario = Convert.ToString(dtLogin.Rows[i]["NM_Funcionario"]);
                    DS_NiVelAcesso = Convert.ToString(dtLogin.Rows[i]["DS_NivelAcesso"]);
                    ID_Funcionario = Convert.ToInt32(dtLogin.Rows[i]["ID_Funcionario"]);

                    lblNomeFuncionario.Text = NM_Funcionario;
                    lblNivelAcesso.Text = DS_NiVelAcesso;
                }
            }

            if (lblNivelAcesso.Text != "Gerente")
            {
                pnlGerencia.Visible = false;
            }

            ArredondaCantosForm();
            Arredonda(btnViewVenda, 50, true, true);
            Arredonda(btnViewCliente, 50, true, true);
            Arredonda(btnGerencia, 50, true, true);
            Arredonda(btnProdutos, 50, true, true);
            Arredonda(btnDiversos, 50, true, true);
            Arredonda(btnViewProduto, 50, true, true);
            Arredonda(btnViewRelatorio, 50, true, true);
            Arredonda(btnViewCategoria, 50, true, true);
            Arredonda(btnViewPerdas, 50, true, true);
            Arredonda(btnViewCompra, 50, true, true);
            Arredonda(btnViewLogin, 50, true, true);
            Arredonda(btnViewInsumo, 50, true, true);
            Arredonda(btnViewFuncionario, 50, true, true);



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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnViewUnidadeRede_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();

            ativaBtnGerencia(sender, RGBcolors.color2);
            abrirFormulario(new ViewPerdas());
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToString("dd : MMMM : yyyy");
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();
            RecolherBtn();
            ativaBtnGerencia(sender, RGBcolors.color2);
            lblTituloFrmFilho.Text = btnProdutos.Text;

        }

        private void btnDiversos_Click(object sender, EventArgs e)
        {
            pnlView.Controls.Clear();

            ativaBtnGerencia(sender, RGBcolors.color3);
            abrirFormulario(new ViewProdutoDiverso());
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {

        }
    }
}
