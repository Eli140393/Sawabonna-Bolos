using Control;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace View
{
    public partial class ViewProduto : Form
    {
        ControlProduto myProduto;
        ControlCategoria myCategoria;
        ControlInsumo myInsumo;
        ControlFichaTecnica myFichaTecnica;

        Validar myValidar = new Validar();

        private bool eNovo { get; set; } = false;
        private bool eEditar { get; set; } = false;
        private byte[] foto1 { get; set; }
        private string foto { get; set; }
        private string ativos { get; set; } 
        private string diversos { get; set; } = "0";

        public ViewProduto()
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
            txtCustoProduto.Text = "0,00";
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
            txtCustoProduto.Enabled = false;
            cboxCategoriaProduto.Enabled = Valor;
            pboxProduto.Visible = Valor;

            dgvInsumoProduto.Enabled = Valor;
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

        private void LimparDadosInsumoProduto()
        {
            txtCodigoInsumoProduto.Text = string.Empty;
            txtNomeInsumoProduto.Text = string.Empty;
            txtArmazenamentoInsumoProduto.Text = string.Empty;
            txtPrecoInsumoProduto.Text = string.Empty;
            txtQuantidadeInsumoProduto.Text = string.Empty;
            lblQuantidade.Text = string.Empty;

        }

        private void LimparDadosFichaTecnica()
        {
            txtCodigoInsumoProdutoFT.Text = string.Empty;
            txtNomeInsumoProdutoFT.Text = string.Empty;
            txtQuantidadeInsumoProdutoFT.Text = string.Empty;
            lblQuantidade.Text = string.Empty;
        }

        private void HabilitarCamposFichaTecnica(bool Valor)
        {
            txtCodigoInsumoProduto.Enabled = false;
            txtNomeInsumoProduto.Enabled = false;
            txtArmazenamentoInsumoProduto.Enabled = false;
            txtPrecoInsumoProduto.Enabled = false;
            txtQuantidadeInsumoProduto.Enabled = false;
            txtBuscarNomeInsumoProduto.Enabled = Valor;
            btnAdicionarInsumoProduto.Enabled = false;

            dgvInsumoProduto.Enabled = Valor;

            txtCodigoInsumoProdutoFT.Enabled = false;
            txtNomeInsumoProdutoFT.Enabled = false;
            txtQuantidadeInsumoProdutoFT.Enabled = false;
            btnAlterarInsumoProdutoFT.Enabled = false;

            dgvFichaTecnicaProduto.Enabled = Valor;
        }

        private void OcultarDeletarProduto()
        {
            dgvProduto.Columns[0].Visible = false;
        }


        private void OcultarDeletarFichaTecnica()
        {
            dgvFichaTecnicaProduto.Columns[0].Visible = false;
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


            if (dgvInsumoProduto.Rows.Count == 0)
            {
                txtBuscarNomeInsumoProduto.Enabled = false;
                dgvInsumoProduto.Enabled = false;
            }
            else
            {
                txtBuscarNomeInsumoProduto.Enabled = true;
                dgvInsumoProduto.Enabled = true;
            }


            if (dgvFichaTecnicaProduto.Rows.Count == 0)
            {
                chkDeletarFT.Enabled = false;
                btnDeletarInsumoFT.Enabled = false;
                dgvFichaTecnicaProduto.Enabled = false;
            }
            else
            {
                chkDeletarFT.Enabled = true;
                btnDeletarInsumoFT.Enabled = true;
                dgvFichaTecnicaProduto.Enabled = true;
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

        private void MostrarInsumo()
        {

            myInsumo = new ControlInsumo();
            dgvInsumoProduto.DataSource = myInsumo.MostrarInsumo();

            dgvInsumoProduto.Columns[0].Visible = false;
            dgvInsumoProduto.Columns[1].HeaderText = "NOME";
            dgvInsumoProduto.Columns[2].HeaderText = "ARMAZENAMENTO";
            dgvInsumoProduto.Columns[3].HeaderText = "PREÇO";

            dgvInsumoProduto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInsumoProduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            HabilitarDataGridView();
        }

        private void MostrarFichaTecnica(string id_produto)
        {
            myFichaTecnica = new ControlFichaTecnica();
            dgvFichaTecnicaProduto.DataSource = myFichaTecnica.MostrarFichaTecnica(id_produto);
            OcultarDeletarFichaTecnica();

            
            dgvFichaTecnicaProduto.Columns[1].Visible = false;
            dgvFichaTecnicaProduto.Columns[2].Visible = false;
            dgvFichaTecnicaProduto.Columns[3].HeaderText = "NOME \nPRODUTO";
            dgvFichaTecnicaProduto.Columns[4].HeaderText = "INSUMO";
            dgvFichaTecnicaProduto.Columns[5].HeaderText = "ARMAZENAMENTO";
            dgvFichaTecnicaProduto.Columns[6].HeaderText = "QUANTIDADE\n UTILIZADA";

            dgvFichaTecnicaProduto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFichaTecnicaProduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            HabilitarDataGridView();
        }

        
        private void CalculoCustoProduto()
        {

            string resp;
            string id_insumo;
            int id_produto;
            double pr_insumo;
            double qtde_insumo;
            string ds_armazenamento;
            double pr_porKg = 0;
            double pr_porUnidade = 0;
            double pr_final;



            id_produto = Convert.ToInt32(txtCodigoProduto.Text);

            

            for (int i = 0; i < dgvFichaTecnicaProduto.Rows.Count; i++)
            {
                id_insumo = Convert.ToString(dgvFichaTecnicaProduto.Rows[i].Cells["ID_Insumo"].Value);
                qtde_insumo = Convert.ToDouble(dgvFichaTecnicaProduto.Rows[i].Cells["QTDE_Utilizada"].Value);
       


                for (int j = 0; j < dgvInsumoProduto.Rows.Count; j++)
                {
                    if (id_insumo == Convert.ToString(dgvInsumoProduto.Rows[j].Cells["ID_Insumo"].Value))
                    {
                        pr_insumo = Convert.ToDouble(dgvInsumoProduto.Rows[j].Cells["PR_Insumo"].Value);
                        ds_armazenamento = Convert.ToString(dgvInsumoProduto.Rows[j].Cells["DS_TipoArmazenamento"].Value);
                        if (ds_armazenamento == "KG(s)")
                        {
                            pr_insumo = pr_insumo / 1000;
                            pr_insumo = pr_insumo * qtde_insumo;
                            pr_porKg += pr_insumo;
                        }
                        else
                        {
                            pr_insumo = pr_insumo * qtde_insumo;
                            pr_porUnidade += pr_insumo;
                            

                        }
                    }
                }
            }
            pr_final = pr_porKg + pr_porUnidade;
            string pr_string = Convert.ToString(pr_final);

            myProduto = new ControlProduto(id_produto, pr_string);
            resp = myProduto.DS_Mensagem;
            string nm_produto= "";
            if (resp == "OK")
            {
                for(int i=0; i < dgvProduto.Rows.Count; i++)
                {
                    if(id_produto == Convert.ToInt32(dgvProduto.Rows[i].Cells["ID_Produto"].Value))
                    {
                        nm_produto = Convert.ToString(dgvProduto.Rows[i].Cells["NM_Produto"].Value);
                    }
                }

                MessageBox.Show("Preço do produto: " + nm_produto +
                    "\n Alterado para: " + pr_final.ToString("N2") ,
                   "SAWABONA",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information) ;
                txtCustoProduto.Text = pr_final.ToString("N2");
                MostrarProduto();

            }
        }

        private void InserirFichaTecnicaProduto()
        {
            try
            {
                string resp = "";
                string action = "inserir";

                if (eNovo)
                {
                    myFichaTecnica = new ControlFichaTecnica(action, txtCodigoProduto.Text,
                        txtCodigoInsumoProduto.Text, txtQuantidadeInsumoProduto.Text);
                    resp = myFichaTecnica.DS_Mensagem;
                }
                else
                {
                    action = "editar";
                    myFichaTecnica = new ControlFichaTecnica(action, txtCodigoProduto.Text,
                    txtCodigoInsumoProduto.Text, txtQuantidadeInsumoProduto.Text);
                    resp = myFichaTecnica.DS_Mensagem;

                }

                if (resp.Equals("OK"))
                {
                    myFichaTecnica = new ControlFichaTecnica();
                    MostrarFichaTecnica(txtCodigoProduto.Text);
                }
                else
                {
                    MensagemErro(resp);
                }

                eNovo = false;
                eEditar = false;
                MostrarProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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

        private void BuscarNomeInsumoProduto()
        {
            myInsumo = new ControlInsumo();
            dgvInsumoProduto.DataSource = myInsumo.BuscarNomeInsumo(txtBuscarNomeInsumoProduto.Text);
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

        private void ViewProduto_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            tctrlProduto.TabPages.Remove(tpgFichaTecnica);
            MostrarProduto();
            Habilitar(false);
            Botoes();
            MostrarCategoria();

            cboxCategoriaProduto.Text = null;

            btnHabilitarFichaTecnica.Enabled = false;
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

            btnHabilitarFichaTecnica.Enabled = false;

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
                btnHabilitarFichaTecnica.Enabled = true;
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
            btnHabilitarFichaTecnica.Enabled = false;
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
                bool CategoriaProdutoOK = false;
                bool DescricaoProdutoOK = false;
                bool FichaTecnicaOK = false;

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

                if (txtCodigoInsumoProduto.Text == string.Empty)
                {
                    FichaTecnicaOK = true;
                }

                if (dgvFichaTecnicaProduto.Rows.Count == 0)
                {
                    if (btnHabilitarFichaTecnica.Enabled == true)
                    {
                        errorIcone.SetError(btnHabilitarFichaTecnica, "Por favor, insira os insumos que compõe \na ficha técnica do produto");
                    }
                    else
                    {
                        tctrlProduto.SelectedIndex = 2;
                        errorIcone.SetError(dgvFichaTecnicaProduto, "Por favor, insira os insumos que compõe \na ficha técnica do produto");
                    }
                }
                else
                {
                    errorIcone.SetError(dgvFichaTecnicaProduto, string.Empty);
                    FichaTecnicaOK = true;
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
                        CategoriaProdutoOK == false ||
                        DescricaoProdutoOK == false ||
                        FichaTecnicaOK == false)
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

                            foreach (DataGridViewRow row in dgvProduto.Rows)
                            {
                                if (txtNomeProduto.Text == Convert.ToString(row.Cells["NM_Produto"].Value))
                                {
                                    txtCodigoProduto.Text = Convert.ToString(row.Cells["ID_Produto"].Value);
                                }
                            }

                            btnHabilitarFichaTecnica.Enabled = true;
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

            HabilitarCamposFichaTecnica(false);
            LimparDadosInsumoProduto();
            LimparDadosFichaTecnica();

            dgvInsumoProduto.DataSource = "";
            dgvFichaTecnicaProduto.DataSource = "";

            btnHabilitarFichaTecnica.Enabled = false;
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
                HabilitarCamposFichaTecnica(false);
                Limpar();
                LimparDadosInsumoProduto();
                LimparDadosFichaTecnica();

                dgvInsumoProduto.DataSource = "";
                dgvFichaTecnicaProduto.DataSource = "";

                btnHabilitarFichaTecnica.Enabled = false;
                tctrlProduto.TabPages.Remove(tpgFichaTecnica);
            }
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            BuscarNomeProduto();
        }

        private void btnHabilitarFichaTecnica_Click(object sender, EventArgs e)
        {
            tctrlProduto.TabPages.Add(tpgFichaTecnica);
            tctrlProduto.SelectedIndex = 2;
            btnHabilitarFichaTecnica.Enabled = false;

            HabilitarCamposFichaTecnica(true);
            MostrarInsumo();
            MostrarFichaTecnica(txtCodigoProduto.Text);
        }

        private void dgvInsumoProduto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                bool insumoInvalido = false;

                foreach (DataGridViewRow row in dgvFichaTecnicaProduto.Rows)
                {
                    if (dgvInsumoProduto.CurrentRow.Cells["NM_Insumo"].Value.Equals(row.Cells["NM_Insumo"].Value))
                    {
                        MensagemErro("Este insumo já foi adicionado na composição");
                        LimparDadosInsumoProduto();
                        insumoInvalido = true;
                    }
                }
                if (insumoInvalido == false)
                {
                    txtCodigoInsumoProduto.Text = Convert.ToString(dgvInsumoProduto.CurrentRow.Cells["ID_Insumo"].Value);
                    txtNomeInsumoProduto.Text = Convert.ToString(dgvInsumoProduto.CurrentRow.Cells["NM_Insumo"].Value);
                    txtArmazenamentoInsumoProduto.Text = Convert.ToString(dgvInsumoProduto.CurrentRow.Cells["DS_TipoArmazenamento"].Value);
                    txtPrecoInsumoProduto.Text = (Convert.ToDouble(dgvInsumoProduto.CurrentRow.Cells["PR_Insumo"].Value)).ToString("N2");
                    lblQuantidade.Text = Convert.ToString(dgvInsumoProduto.CurrentRow.Cells["DS_TipoArmazenamento"].Value);

                   
                    txtQuantidadeInsumoProduto.Enabled = true;
                    btnAdicionarInsumoProduto.Enabled = true;
                }
            }
            catch
            {
                MensagemErro("Ação invalida, por favor click em um dos insumos apresentados!!");
            }
         
        }

        private void btnAdicionarInsumoProduto_Click(object sender, EventArgs e)
        {
            bool QuantidadeInsumoProdutoOk = false;

            ValidarCampoNulo(txtQuantidadeInsumoProduto);
            if (myValidar.CampoValido == true)
            {
                if (txtArmazenamentoInsumoProduto.Text == "Unidade(s)")
                {
                    ValidarNumero(txtQuantidadeInsumoProduto);
                    if (myValidar.NumeroValido == true)
                    {

                        if (Convert.ToDouble(txtQuantidadeInsumoProduto.Text) < 1)
                        {
                            errorIcone.SetError(txtQuantidadeInsumoProduto, "A quantidade não pode ser menor ou igual a 0 (zero)");
                        }
                        else
                        {
                            QuantidadeInsumoProdutoOk = true;
                        }

                    }

                }
                else
                {
                    ValidarValorKg(txtQuantidadeInsumoProduto);
                    if (myValidar.ValorValido == true)
                    {
                        if (Convert.ToDouble(txtQuantidadeInsumoProduto.Text) < 1)
                        {
                            errorIcone.SetError(txtQuantidadeInsumoProduto, "A quantidade não pode ser menor ou igual a 0 (zero)");
                        }
                        else
                        {
                            QuantidadeInsumoProdutoOk = true;
                        }
                    }

                }
            }

            if (QuantidadeInsumoProdutoOk == false)
            {
                MensagemErro("Por favor, preencha corretamente a quantidade a ser adicionada na composição");
            }
            else
            {
                errorIcone.Clear();
                eNovo = true;
                eEditar = false;

                try
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show("Deseja adicionar este insumo na composição?",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {
                        InserirFichaTecnicaProduto();
                        CalculoCustoProduto();


                        LimparDadosInsumoProduto();
                        txtQuantidadeInsumoProduto.Enabled = false;
                        btnAdicionarInsumoProduto.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void txtBuscarNomeInsumoProduto_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeInsumoProduto();
        }

        private void btnAlterarInsumoProdutoFT_Click(object sender, EventArgs e)
        {
            bool QuantidadeInsumoProdutoOk = false;

            ValidarCampoNulo(txtQuantidadeInsumoProdutoFT);
            if (myValidar.CampoValido == true)
            {


                ValidarValor(txtQuantidadeInsumoProdutoFT);
                if (myValidar.ValorValido == true)
                {
                    if (Convert.ToDouble(txtQuantidadeInsumoProdutoFT.Text) < 1)
                    {
                        errorIcone.SetError(txtQuantidadeInsumoProdutoFT, "A quantidade não pode ser menor ou igual a 0 (zero)");
                    }
                    else
                    {
                        QuantidadeInsumoProdutoOk = true;
                    }
                }
            }

            if (QuantidadeInsumoProdutoOk == false)
            {
                MensagemErro("Por favor, preencha corretamente a quantidade a ser adicionada na composição");
            }
            else
            {
                errorIcone.Clear();
                eNovo = false;
                eEditar = true;

                try
                {
                    DialogResult Opcao;
                    Opcao = MessageBox.Show("Deseja alterar este insumo na composição?",
                        "SAWABONA",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (Opcao == DialogResult.Yes)
                    {
                        InserirFichaTecnicaProduto();

                        LimparDadosFichaTecnica();
                        txtQuantidadeInsumoProdutoFT.Enabled = false;
                        btnAlterarInsumoProdutoFT.Enabled = false;
                        CalculoCustoProduto();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        private void dgvFichaTecnicaProduto_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFichaTecnicaProduto.Rows.Count == 0)
            {
                MensagemErro("Ainda não há insumos inseridos nessa ficha técnica");
            }
            else
            {
                txtCodigoInsumoProdutoFT.Text = Convert.ToString(dgvFichaTecnicaProduto.CurrentRow.Cells["ID_Insumo"].Value);
                txtNomeInsumoProdutoFT.Text = Convert.ToString(dgvFichaTecnicaProduto.CurrentRow.Cells["NM_Insumo"].Value);
                txtQuantidadeInsumoProdutoFT.Text = Convert.ToString(dgvFichaTecnicaProduto.CurrentRow.Cells["QTDE_Utilizada"].Value);

                txtQuantidadeInsumoProdutoFT.Enabled = true;
                btnAlterarInsumoProdutoFT.Enabled = true;
            }
        }

        private void dgvFichaTecnicaProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFichaTecnicaProduto.Columns["DeletarFT"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dgvFichaTecnicaProduto.Rows[e.RowIndex].Cells["DeletarFT"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void chkDeletarFT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletarFT.Checked)
            {
                dgvFichaTecnicaProduto.Columns[0].Visible = true;
            }
            else
            {
                dgvFichaTecnicaProduto.Columns[0].Visible = false;
            }
        }

        private void btnDeletarInsumoFT_Click(object sender, EventArgs e)
        {
            bool marcouitem = false;

            foreach (DataGridViewRow row in dgvFichaTecnicaProduto.Rows)
            {
                if (bool.Parse(row.Cells[0].EditedFormattedValue.ToString()))//Pega os valores com checkbox clicados (TRUE)
                {
                    marcouitem = true;
                }
            }

            if (!marcouitem)
            {
                MensagemErro("Não há fichas técnicas selecionadas para excluir");
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

                        foreach (DataGridViewRow row in dgvFichaTecnicaProduto.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = Convert.ToString(row.Cells[1].Value);
                                Insumo = Convert.ToString(row.Cells[2].Value);
                             
                                myFichaTecnica = new ControlFichaTecnica(Codigo, Insumo);
                                resp = myFichaTecnica.DS_Mensagem;
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

                        MostrarFichaTecnica(txtCodigoProduto.Text);
                        chkDeletarFT.Checked = false;

                     
                            CalculoCustoProduto();
                        LimparDadosFichaTecnica();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
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
