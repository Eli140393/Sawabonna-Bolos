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
    public partial class ViewProdutoDiverso : Form
    {
 

        ControlProduto myProduto;
        ControlCategoria myCategoria;
        Validar myValidar = new Validar();

        private bool eNovo { get; set; } = false;
        private bool eEditar { get; set; } = false;
        private byte[] foto1 { get; set; }

        private string foto { get; set; }
        private string ativos { get; set; }
        private string diversos { get; set; } = "1";


        public ViewProdutoDiverso()
        {
            InitializeComponent();
        }

  

        public static Image ConverteByteArrayEmImagem(byte[] _BytesDaImagem)
        {
            MemoryStream _Memoria = new MemoryStream(_BytesDaImagem);
            Image _Imagem = Image.FromStream(_Memoria);

            return (_Imagem);
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
            txtCodigoProduto.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtDescricaoProduto.Text = string.Empty;
            txtPrecoProduto.Text = string.Empty;
            txtCustoProduto.Text = string.Empty;
            cboxCategoriaProduto.Text = null;
            pboxProduto.Image = null;
        }

        // Habilitar os text box
        private void Habilitar(bool Valor)
        {
            txtCodigoProduto.Enabled = false;
            txtNomeProduto.Enabled = Valor;
            txtDescricaoProduto.Enabled = Valor;
            txtPrecoProduto.Enabled = Valor;
            txtCustoProduto.Enabled = Valor;
            cboxCategoriaProduto.Enabled = Valor;
            pboxProduto.Visible = Valor;

        }

        // Habilitar os botões
        private void Botoes()
        {
            if (eNovo || eEditar)
            {
                Habilitar(true);
                btnNovoProduto.Enabled = false;
                btnSalvarProduto.Enabled = true;
                btnEditarProduto.Enabled = false;
                btnCancelarProduto.Enabled = true;
                btnCarregarFotoProduto.Enabled = true;
                btnExcluirFotoProduto.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNovoProduto.Enabled = true;
                btnSalvarProduto.Enabled = false;
                btnEditarProduto.Enabled = true;
                btnCancelarProduto.Enabled = false;
                btnCarregarFotoProduto.Enabled = false;
                btnExcluirFotoProduto.Enabled = false;
            }
        }

       

        private void OcultarDeletarProduto()
        {
            dgvProduto.Columns[0].Visible = false;
        }


    

        private void HabilitarDataGridView()
        {
            if (dgvProduto.Rows.Count == 0)
            {
                chkDeletarProduto.Enabled = false;
                btnDeletarProduto.Enabled = false;
                txtBuscarProduto.Enabled = false;
                btnBuscarProduto.Enabled = false;
                dgvProduto.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                chkDeletarProduto.Enabled = true;
                btnDeletarProduto.Enabled = true;
                txtBuscarProduto.Enabled = true;
                btnBuscarProduto.Enabled = true;
                dgvProduto.Enabled = true;
                btnAtivar.Enabled = true;
            }
         
        }

        private void MostrarProduto()
        {
       
            myProduto = new ControlProduto();

            if (chkInativos.Checked == true)
            {
                ativos = "0";
                dgvProduto.DataSource = myProduto.MostrarProduto(ativos, diversos);
                dgvProduto.Columns[0].HeaderText = "Ativar";




            }
            else
            {

                ativos = "1";
                dgvProduto.DataSource = myProduto.MostrarProduto(ativos, diversos);
                dgvProduto.Columns[0].HeaderText = "Deletar";

            }



            lblTotalProduto.Text = "Total de Registros:  " + Convert.ToString(dgvProduto.Rows.Count);

            dgvProduto.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvProduto.Columns[1].HeaderText = "CÓDIGO";
            dgvProduto.Columns[2].HeaderText = "CATEGORIA";
            dgvProduto.Columns[3].HeaderText = "NOME";
            dgvProduto.Columns[4].HeaderText = "PREÇO";
            dgvProduto.Columns[5].HeaderText = "CUSTO";
            dgvProduto.Columns[6].HeaderText = "DESCRIÇÃO";
            dgvProduto.Columns[7].Visible = false;
            dgvProduto.Columns[8].Visible = false;

            dgvProduto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridView();
            OcultarDeletarProduto();
        }

        private void MostrarCategoria()
        {
            myCategoria = new ControlCategoria();
            ativos = "1";
            cboxCategoriaProduto.DataSource = myCategoria.MostrarCategoria(ativos);
            cboxCategoriaProduto.DisplayMember = "NM_Categoria";
            cboxCategoriaProduto.ValueMember = "ID_Categoria";
        }

        private void BuscarNomeProduto()
        {

            myProduto = new ControlProduto();

            if (chkInativos.Checked == true)
            {
                ativos = "0";
                dgvProduto.DataSource = myProduto.BuscarNomeProduto(ativos, txtBuscarProduto.Text, diversos);
                dgvProduto.Columns[0].HeaderText = "Ativar";


            }
            else
            {
                ativos = "1";
                dgvProduto.DataSource = myProduto.BuscarNomeProduto(ativos, txtBuscarProduto.Text, diversos);
                dgvProduto.Columns[0].HeaderText = "Deletar";

            }


            OcultarDeletarProduto();

            lblTotalProduto.Text = "Total de Registros:  " + Convert.ToString(dgvProduto.Rows.Count);
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

        private void ValidarValorKg(TextBox campo)
        {
            string valorvalido = Convert.ToString(campo.Text);
            myValidar.ValorKg(valorvalido);

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

            if (myValidar.NumeroValido == false)
            {
                errorIcone.SetError(campo, "Este campo deve ser preenchido somente com números." +
                                            "\nUnidades utilizam numeros inteiros sem virgulas e pontos");
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

        private void ViewProdutoDiverso_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            MostrarProduto();
            Habilitar(false);
            Botoes();
            MostrarCategoria();

            cboxCategoriaProduto.Text = null;

        }

        private void dgvProduto_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoProduto.Text = Convert.ToString(dgvProduto.CurrentRow.Cells["ID_Produto"].Value);
            cboxCategoriaProduto.Text = Convert.ToString(dgvProduto.CurrentRow.Cells["NM_Categoria"].Value);
            txtNomeProduto.Text = Convert.ToString(dgvProduto.CurrentRow.Cells["NM_Produto"].Value);
            txtPrecoProduto.Text = Convert.ToString(dgvProduto.CurrentRow.Cells["PR_Unitario"].Value);
            txtCustoProduto.Text = Convert.ToString(dgvProduto.CurrentRow.Cells["PR_Custo"].Value);
            txtDescricaoProduto.Text = Convert.ToString(dgvProduto.CurrentRow.Cells["DS_Produto"].Value);
            foto = Convert.ToString(dgvProduto.CurrentRow.Cells["IMG_Produto"].Value);
            byte[] imag;

            try
            {
                if (dgvProduto.CurrentRow.Cells["IMG_Produto"].Value != DBNull.Value)
                {
                    imag = (byte[])dgvProduto.CurrentRow.Cells["IMG_Produto"].Value;


                    ImageConverter converter = new ImageConverter();
                    pboxProduto.Image = ConverteByteArrayEmImagem(imag);
                    pboxProduto.Visible = true;
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


            tctrlProduto.SelectedIndex = 1;
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProduto.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvProduto.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void txtBuscarProduto_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeProduto();

        }

        private void btnCarregarFotoProduto_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog od = new OpenFileDialog();
                od.Filter = "JPG Files (*.jpg) |*.jpg|GIF Files (*.gif) |*.gif|All Files (*.*) |*.*";
                od.Title = "Selecione a imagem a ser inserida";
                if (od.ShowDialog() == DialogResult.OK)
                {
                    foto = od.FileName.ToString();
                    pboxProduto.ImageLocation = foto;
                    string nome = od.FileName;

                    pboxProduto.Image = Image.FromFile(od.FileName);
                    pboxProduto.Name = "IMAGEM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirFotoProduto_Click(object sender, EventArgs e)
        {
            foto = "";

            pboxProduto.Image = null;
        }

        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text.Equals(""))
            {
                MensagemErro("Selecione um registro para editar");
            }
            else
            {
                eNovo = false;
                eEditar = true;
                Botoes();
                Habilitar(true);
            }
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            eNovo = true;
            eEditar = false;
            Botoes();
            Limpar();
            Habilitar(true);
            txtNomeProduto.Focus();
        }

        private void chkDeletarProduto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarProduto.Checked)
            {
                dgvProduto.Columns[0].Visible = true;
                chkInativos.Enabled = false;
                btnAtivar.Enabled = false;
            }
            else
            {
                dgvProduto.Columns[0].Visible = false;
                chkInativos.Enabled = true;
                btnAtivar.Enabled = true;
            }
        }

        private void btnDeletarProduto_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvProduto.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há produtos selecionados para excluir");
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
                        string action = "excluir";
                        foreach (DataGridViewRow row in dgvProduto.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myProduto = new ControlProduto(Codigo, action);
                                resp = myProduto.DS_Mensagem;
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

                        MostrarProduto();
                        chkDeletarProduto.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            foto1 = null;
            if (pboxProduto.Image != null)
            {
                Image img = pboxProduto.Image;
                ImageConverter converter = new ImageConverter();
                foto1 = (byte[])converter.ConvertTo(img, typeof(byte[]));

            }
            else
            {

                pboxProduto.Image = Properties.Resources.no_image;

                Image img2 = pboxProduto.Image;
                ImageConverter converter = new ImageConverter();
                foto1 = (byte[])converter.ConvertTo(img2, typeof(byte[]));
            }




            try
            {
                bool NomeProdutoOK = false;
                bool PrecoProdutoOK = false;
                bool PrecoProdutoCustoOK = false;

                bool CategoriaProdutoOK = false;
                bool DescricaoProdutoOK = false;

                string resp = "";

                ValidarCampoNulo(txtNomeProduto);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtNomeProduto, 50);
                    if (myValidar.TamanhoValido == true)
                    {
                        NomeProdutoOK = true;
                    }
                }

                ValidarCampoNulo(txtPrecoProduto);
                if (myValidar.CampoValido == true)
                {
                    ValidarValor(txtPrecoProduto);
                    if (myValidar.ValorValido == true)
                    {
                        PrecoProdutoOK = true;
                    }
                }
                ValidarCampoNulo(txtCustoProduto);
                if (myValidar.CampoValido == true)
                {
                    ValidarValor(txtCustoProduto);
                    if (myValidar.ValorValido == true)
                    {
                        PrecoProdutoCustoOK = true;
                    }
                }

                if (cboxCategoriaProduto.Text == string.Empty)
                {
                    errorIcone.SetError(cboxCategoriaProduto, "Selecione a categoria do produto");
                }
                else
                {
                    errorIcone.SetError(cboxCategoriaProduto, string.Empty);
                    CategoriaProdutoOK = true;
                }

                ValidarCampoNulo(txtDescricaoProduto);
                if (myValidar.CampoValido == true)
                {
                    ValidarTamanhoCampo(txtDescricaoProduto, 150);
                    if (myValidar.TamanhoValido == true)
                    {
                        DescricaoProdutoOK = true;
                    }
                }
                                           
                bool PRODcadastrado = false;

                foreach (DataGridViewRow row in dgvProduto.Rows)
                {
                    if (txtCodigoProduto.Text != Convert.ToString(row.Cells["ID_Produto"].Value))
                    {
                        if (txtNomeProduto.Text == Convert.ToString(row.Cells["NM_Produto"].Value))
                        {
                            PRODcadastrado = true;
                        }
                    }
                }

                if (PRODcadastrado == true)
                {
                    MensagemErro("Produto já cadastrado na base de dados");
                }
                else
                {
                    if (NomeProdutoOK == false ||
                        PrecoProdutoOK == false ||
                        PrecoProdutoCustoOK == false ||
                        CategoriaProdutoOK == false ||
                        DescricaoProdutoOK == false)
                    {
                        MensagemErro("Por favor, preencha corretamente os campos sinalizados");
                    }
                    else
                    {
                        errorIcone.Clear();
                        if (eNovo)
                        {
                            myProduto = new ControlProduto(cboxCategoriaProduto.SelectedValue.ToString(),
                                txtNomeProduto.Text.Trim(), txtPrecoProduto.Text, txtCustoProduto.Text,
                                txtDescricaoProduto.Text.Trim(), foto1, diversos);
                            resp = myProduto.DS_Mensagem;
                        }
                        else
                        {
                            myProduto = new ControlProduto(txtCodigoProduto.Text, cboxCategoriaProduto.SelectedValue.ToString(),
                                txtNomeProduto.Text.Trim(), txtPrecoProduto.Text, txtCustoProduto.Text,
                                txtDescricaoProduto.Text.Trim(), foto1);
                            resp = myProduto.DS_Mensagem;
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
                            MostrarProduto();
                            MostrarCategoria();
                            tctrlProduto.SelectedIndex = 0;


                        }
                        else
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

        private void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            errorIcone.Clear();

            eNovo = false;
            eEditar = false;
            Botoes();
            Habilitar(false);
            Limpar();

            tctrlProduto.SelectedIndex = 0;

        }

        private void tctrlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcone.Clear();

            if (tctrlProduto.SelectedIndex == 0)
            {
                eNovo = false;
                eEditar = false;
                Botoes();
                Habilitar(false);
                Limpar();

            }
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            BuscarNomeProduto();

        }

        private void chkInativos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarProduto();

            if (chkInativos.Checked == true)
            {
                btnDeletarProduto.Enabled = false;
                btnAtivar.Enabled = true;
                dgvProduto.Columns[0].Visible = true;
                chkDeletarProduto.Enabled = false;


            }
            else
            {
                btnDeletarProduto.Enabled = true;
                btnAtivar.Enabled = false;
                dgvProduto.Columns[0].Visible = false;
                chkDeletarProduto.Enabled = true;
                MostrarProduto();

            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvProduto.Rows)
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
                        string action = "ativar";

                        foreach (DataGridViewRow row in dgvProduto.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                myProduto = new ControlProduto(Codigo, action);
                                resp = myProduto.DS_Mensagem;
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

                        MostrarProduto();
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
