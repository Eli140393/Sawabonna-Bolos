namespace View
{
    partial class ViewProdutoDiverso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tctrlProduto = new System.Windows.Forms.TabControl();
            this.tpgListarProduto = new System.Windows.Forms.TabPage();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.chkInativos = new System.Windows.Forms.CheckBox();
            this.chkDeletarProduto = new System.Windows.Forms.CheckBox();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.Deletar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.lblTotalProduto = new System.Windows.Forms.Label();
            this.btnBuscarProduto = new System.Windows.Forms.Button();
            this.btnDeletarProduto = new System.Windows.Forms.Button();
            this.lblBuscarProduto = new System.Windows.Forms.Label();
            this.tpgConfiguracoesProduto = new System.Windows.Forms.TabPage();
            this.gboxProduto = new System.Windows.Forms.GroupBox();
            this.txtCustoProduto = new System.Windows.Forms.TextBox();
            this.lbPrecoDecusto = new System.Windows.Forms.Label();
            this.txtPrecoProduto = new System.Windows.Forms.TextBox();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.pboxProduto = new System.Windows.Forms.PictureBox();
            this.btnCancelarProduto = new System.Windows.Forms.Button();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.btnCarregarFotoProduto = new System.Windows.Forms.Button();
            this.btnExcluirFotoProduto = new System.Windows.Forms.Button();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.lblCodigoProduto = new System.Windows.Forms.Label();
            this.cboxCategoriaProduto = new System.Windows.Forms.ComboBox();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.lblCategoriaProduto = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.ttmesagem = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcone = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tctrlProduto.SuspendLayout();
            this.tpgListarProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.tpgConfiguracoesProduto.SuspendLayout();
            this.gboxProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tctrlProduto
            // 
            this.tctrlProduto.Controls.Add(this.tpgListarProduto);
            this.tctrlProduto.Controls.Add(this.tpgConfiguracoesProduto);
            this.tctrlProduto.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tctrlProduto.Location = new System.Drawing.Point(8, 11);
            this.tctrlProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tctrlProduto.Name = "tctrlProduto";
            this.tctrlProduto.SelectedIndex = 0;
            this.tctrlProduto.Size = new System.Drawing.Size(1539, 948);
            this.tctrlProduto.TabIndex = 18;
            this.tctrlProduto.SelectedIndexChanged += new System.EventHandler(this.tctrlProduto_SelectedIndexChanged);
            // 
            // tpgListarProduto
            // 
            this.tpgListarProduto.BackColor = System.Drawing.Color.Transparent;
            this.tpgListarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tpgListarProduto.Controls.Add(this.btnAtivar);
            this.tpgListarProduto.Controls.Add(this.chkInativos);
            this.tpgListarProduto.Controls.Add(this.chkDeletarProduto);
            this.tpgListarProduto.Controls.Add(this.dgvProduto);
            this.tpgListarProduto.Controls.Add(this.txtBuscarProduto);
            this.tpgListarProduto.Controls.Add(this.lblTotalProduto);
            this.tpgListarProduto.Controls.Add(this.btnBuscarProduto);
            this.tpgListarProduto.Controls.Add(this.btnDeletarProduto);
            this.tpgListarProduto.Controls.Add(this.lblBuscarProduto);
            this.tpgListarProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgListarProduto.Location = new System.Drawing.Point(4, 30);
            this.tpgListarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgListarProduto.Name = "tpgListarProduto";
            this.tpgListarProduto.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgListarProduto.Size = new System.Drawing.Size(1531, 914);
            this.tpgListarProduto.TabIndex = 0;
            this.tpgListarProduto.Text = "Listar";
            // 
            // btnAtivar
            // 
            this.btnAtivar.BackColor = System.Drawing.Color.Orchid;
            this.btnAtivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtivar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivar.ForeColor = System.Drawing.Color.White;
            this.btnAtivar.Location = new System.Drawing.Point(774, 22);
            this.btnAtivar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(140, 38);
            this.btnAtivar.TabIndex = 10;
            this.btnAtivar.Text = "Ativar";
            this.btnAtivar.UseVisualStyleBackColor = false;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // chkInativos
            // 
            this.chkInativos.AutoSize = true;
            this.chkInativos.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInativos.ForeColor = System.Drawing.Color.Black;
            this.chkInativos.Location = new System.Drawing.Point(145, 91);
            this.chkInativos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkInativos.Name = "chkInativos";
            this.chkInativos.Size = new System.Drawing.Size(98, 25);
            this.chkInativos.TabIndex = 9;
            this.chkInativos.Text = "Inativos";
            this.chkInativos.UseVisualStyleBackColor = true;
            this.chkInativos.CheckedChanged += new System.EventHandler(this.chkInativos_CheckedChanged);
            // 
            // chkDeletarProduto
            // 
            this.chkDeletarProduto.AutoSize = true;
            this.chkDeletarProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeletarProduto.ForeColor = System.Drawing.Color.Black;
            this.chkDeletarProduto.Location = new System.Drawing.Point(20, 92);
            this.chkDeletarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDeletarProduto.Name = "chkDeletarProduto";
            this.chkDeletarProduto.Size = new System.Drawing.Size(94, 25);
            this.chkDeletarProduto.TabIndex = 3;
            this.chkDeletarProduto.Text = "Deletar";
            this.chkDeletarProduto.UseVisualStyleBackColor = true;
            this.chkDeletarProduto.CheckedChanged += new System.EventHandler(this.chkDeletarProduto_CheckedChanged);
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.AllowUserToOrderColumns = true;
            this.dgvProduto.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvProduto.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvProduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(32)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduto.ColumnHeadersHeight = 50;
            this.dgvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Deletar});
            this.dgvProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduto.EnableHeadersVisualStyles = false;
            this.dgvProduto.GridColor = System.Drawing.Color.Black;
            this.dgvProduto.Location = new System.Drawing.Point(6, 121);
            this.dgvProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProduto.MultiSelect = false;
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduto.RowHeadersVisible = false;
            this.dgvProduto.RowHeadersWidth = 51;
            this.dgvProduto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduto.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProduto.RowTemplate.Height = 24;
            this.dgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduto.Size = new System.Drawing.Size(1502, 760);
            this.dgvProduto.TabIndex = 4;
            this.dgvProduto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduto_CellContentClick);
            this.dgvProduto.DoubleClick += new System.EventHandler(this.dgvProduto_DoubleClick);
            // 
            // Deletar
            // 
            this.Deletar.HeaderText = "Deletar";
            this.Deletar.MinimumWidth = 6;
            this.Deletar.Name = "Deletar";
            this.Deletar.ReadOnly = true;
            this.Deletar.Width = 67;
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarProduto.Location = new System.Drawing.Point(96, 26);
            this.txtBuscarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(249, 28);
            this.txtBuscarProduto.TabIndex = 1;
            this.txtBuscarProduto.TextChanged += new System.EventHandler(this.txtBuscarProduto_TextChanged);
            // 
            // lblTotalProduto
            // 
            this.lblTotalProduto.AutoSize = true;
            this.lblTotalProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProduto.ForeColor = System.Drawing.Color.Black;
            this.lblTotalProduto.Location = new System.Drawing.Point(420, 92);
            this.lblTotalProduto.Name = "lblTotalProduto";
            this.lblTotalProduto.Size = new System.Drawing.Size(69, 21);
            this.lblTotalProduto.TabIndex = 5;
            this.lblTotalProduto.Text = "lblTotal";
            // 
            // btnBuscarProduto
            // 
            this.btnBuscarProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnBuscarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProduto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProduto.Location = new System.Drawing.Point(408, 22);
            this.btnBuscarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarProduto.Name = "btnBuscarProduto";
            this.btnBuscarProduto.Size = new System.Drawing.Size(140, 38);
            this.btnBuscarProduto.TabIndex = 2;
            this.btnBuscarProduto.Text = "Buscar";
            this.btnBuscarProduto.UseVisualStyleBackColor = false;
            this.btnBuscarProduto.Click += new System.EventHandler(this.btnBuscarProduto_Click);
            // 
            // btnDeletarProduto
            // 
            this.btnDeletarProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnDeletarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletarProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletarProduto.ForeColor = System.Drawing.Color.White;
            this.btnDeletarProduto.Location = new System.Drawing.Point(597, 22);
            this.btnDeletarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletarProduto.Name = "btnDeletarProduto";
            this.btnDeletarProduto.Size = new System.Drawing.Size(140, 38);
            this.btnDeletarProduto.TabIndex = 5;
            this.btnDeletarProduto.Text = "Deletar";
            this.btnDeletarProduto.UseVisualStyleBackColor = false;
            this.btnDeletarProduto.Click += new System.EventHandler(this.btnDeletarProduto_Click);
            // 
            // lblBuscarProduto
            // 
            this.lblBuscarProduto.AutoSize = true;
            this.lblBuscarProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProduto.ForeColor = System.Drawing.Color.Black;
            this.lblBuscarProduto.Location = new System.Drawing.Point(16, 30);
            this.lblBuscarProduto.Name = "lblBuscarProduto";
            this.lblBuscarProduto.Size = new System.Drawing.Size(60, 21);
            this.lblBuscarProduto.TabIndex = 0;
            this.lblBuscarProduto.Text = "Nome";
            // 
            // tpgConfiguracoesProduto
            // 
            this.tpgConfiguracoesProduto.Controls.Add(this.gboxProduto);
            this.tpgConfiguracoesProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgConfiguracoesProduto.Location = new System.Drawing.Point(4, 30);
            this.tpgConfiguracoesProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgConfiguracoesProduto.Name = "tpgConfiguracoesProduto";
            this.tpgConfiguracoesProduto.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgConfiguracoesProduto.Size = new System.Drawing.Size(1531, 914);
            this.tpgConfiguracoesProduto.TabIndex = 1;
            this.tpgConfiguracoesProduto.Text = "Configurações";
            this.tpgConfiguracoesProduto.UseVisualStyleBackColor = true;
            // 
            // gboxProduto
            // 
            this.gboxProduto.BackColor = System.Drawing.Color.White;
            this.gboxProduto.Controls.Add(this.txtCustoProduto);
            this.gboxProduto.Controls.Add(this.lbPrecoDecusto);
            this.gboxProduto.Controls.Add(this.txtPrecoProduto);
            this.gboxProduto.Controls.Add(this.lblPrecoProduto);
            this.gboxProduto.Controls.Add(this.pboxProduto);
            this.gboxProduto.Controls.Add(this.btnCancelarProduto);
            this.gboxProduto.Controls.Add(this.btnNovoProduto);
            this.gboxProduto.Controls.Add(this.btnEditarProduto);
            this.gboxProduto.Controls.Add(this.btnSalvarProduto);
            this.gboxProduto.Controls.Add(this.btnCarregarFotoProduto);
            this.gboxProduto.Controls.Add(this.btnExcluirFotoProduto);
            this.gboxProduto.Controls.Add(this.lblNomeProduto);
            this.gboxProduto.Controls.Add(this.lblCodigoProduto);
            this.gboxProduto.Controls.Add(this.cboxCategoriaProduto);
            this.gboxProduto.Controls.Add(this.txtDescricaoProduto);
            this.gboxProduto.Controls.Add(this.lblDescricaoProduto);
            this.gboxProduto.Controls.Add(this.lblCategoriaProduto);
            this.gboxProduto.Controls.Add(this.txtNomeProduto);
            this.gboxProduto.Controls.Add(this.txtCodigoProduto);
            this.gboxProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gboxProduto.Location = new System.Drawing.Point(-5, 0);
            this.gboxProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxProduto.Name = "gboxProduto";
            this.gboxProduto.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxProduto.Size = new System.Drawing.Size(1733, 852);
            this.gboxProduto.TabIndex = 0;
            this.gboxProduto.TabStop = false;
            this.gboxProduto.Text = "Produto";
            // 
            // txtCustoProduto
            // 
            this.txtCustoProduto.ForeColor = System.Drawing.Color.Black;
            this.txtCustoProduto.Location = new System.Drawing.Point(257, 371);
            this.txtCustoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustoProduto.Name = "txtCustoProduto";
            this.txtCustoProduto.Size = new System.Drawing.Size(131, 28);
            this.txtCustoProduto.TabIndex = 4;
            // 
            // lbPrecoDecusto
            // 
            this.lbPrecoDecusto.AutoSize = true;
            this.lbPrecoDecusto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecoDecusto.ForeColor = System.Drawing.Color.Black;
            this.lbPrecoDecusto.Location = new System.Drawing.Point(106, 371);
            this.lbPrecoDecusto.Name = "lbPrecoDecusto";
            this.lbPrecoDecusto.Size = new System.Drawing.Size(137, 21);
            this.lbPrecoDecusto.TabIndex = 117;
            this.lbPrecoDecusto.Text = "Preço de custo";
            // 
            // txtPrecoProduto
            // 
            this.txtPrecoProduto.ForeColor = System.Drawing.Color.Black;
            this.txtPrecoProduto.Location = new System.Drawing.Point(257, 428);
            this.txtPrecoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecoProduto.Name = "txtPrecoProduto";
            this.txtPrecoProduto.Size = new System.Drawing.Size(131, 28);
            this.txtPrecoProduto.TabIndex = 5;
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.AutoSize = true;
            this.lblPrecoProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoProduto.ForeColor = System.Drawing.Color.Black;
            this.lblPrecoProduto.Location = new System.Drawing.Point(96, 428);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(147, 21);
            this.lblPrecoProduto.TabIndex = 115;
            this.lblPrecoProduto.Text = "Preço de venda";
            // 
            // pboxProduto
            // 
            this.pboxProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxProduto.Location = new System.Drawing.Point(860, 68);
            this.pboxProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pboxProduto.Name = "pboxProduto";
            this.pboxProduto.Size = new System.Drawing.Size(400, 369);
            this.pboxProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxProduto.TabIndex = 105;
            this.pboxProduto.TabStop = false;
            // 
            // btnCancelarProduto
            // 
            this.btnCancelarProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnCancelarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarProduto.ForeColor = System.Drawing.Color.White;
            this.btnCancelarProduto.Location = new System.Drawing.Point(950, 646);
            this.btnCancelarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarProduto.Name = "btnCancelarProduto";
            this.btnCancelarProduto.Size = new System.Drawing.Size(160, 38);
            this.btnCancelarProduto.TabIndex = 12;
            this.btnCancelarProduto.Text = "Cancelar";
            this.btnCancelarProduto.UseVisualStyleBackColor = false;
            this.btnCancelarProduto.Click += new System.EventHandler(this.btnCancelarProduto_Click);
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnNovoProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProduto.ForeColor = System.Drawing.Color.White;
            this.btnNovoProduto.Location = new System.Drawing.Point(355, 646);
            this.btnNovoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(160, 38);
            this.btnNovoProduto.TabIndex = 9;
            this.btnNovoProduto.Text = "Novo";
            this.btnNovoProduto.UseVisualStyleBackColor = false;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click);
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnEditarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProduto.ForeColor = System.Drawing.Color.White;
            this.btnEditarProduto.Location = new System.Drawing.Point(751, 646);
            this.btnEditarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(160, 38);
            this.btnEditarProduto.TabIndex = 11;
            this.btnEditarProduto.Text = "Editar";
            this.btnEditarProduto.UseVisualStyleBackColor = false;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditarProduto_Click);
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnSalvarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarProduto.ForeColor = System.Drawing.Color.White;
            this.btnSalvarProduto.Location = new System.Drawing.Point(550, 646);
            this.btnSalvarProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(160, 38);
            this.btnSalvarProduto.TabIndex = 10;
            this.btnSalvarProduto.Text = "Salvar";
            this.btnSalvarProduto.UseVisualStyleBackColor = false;
            this.btnSalvarProduto.Click += new System.EventHandler(this.btnSalvarProduto_Click);
            // 
            // btnCarregarFotoProduto
            // 
            this.btnCarregarFotoProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnCarregarFotoProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarregarFotoProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarFotoProduto.ForeColor = System.Drawing.Color.White;
            this.btnCarregarFotoProduto.Location = new System.Drawing.Point(896, 482);
            this.btnCarregarFotoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCarregarFotoProduto.Name = "btnCarregarFotoProduto";
            this.btnCarregarFotoProduto.Size = new System.Drawing.Size(160, 38);
            this.btnCarregarFotoProduto.TabIndex = 7;
            this.btnCarregarFotoProduto.Text = "Carregar foto";
            this.btnCarregarFotoProduto.UseVisualStyleBackColor = false;
            this.btnCarregarFotoProduto.Click += new System.EventHandler(this.btnCarregarFotoProduto_Click);
            // 
            // btnExcluirFotoProduto
            // 
            this.btnExcluirFotoProduto.BackColor = System.Drawing.Color.Orchid;
            this.btnExcluirFotoProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirFotoProduto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirFotoProduto.ForeColor = System.Drawing.Color.White;
            this.btnExcluirFotoProduto.Location = new System.Drawing.Point(1078, 482);
            this.btnExcluirFotoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcluirFotoProduto.Name = "btnExcluirFotoProduto";
            this.btnExcluirFotoProduto.Size = new System.Drawing.Size(160, 38);
            this.btnExcluirFotoProduto.TabIndex = 8;
            this.btnExcluirFotoProduto.Text = "Excluir foto";
            this.btnExcluirFotoProduto.UseVisualStyleBackColor = false;
            this.btnExcluirFotoProduto.Click += new System.EventHandler(this.btnExcluirFotoProduto_Click);
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeProduto.ForeColor = System.Drawing.Color.Black;
            this.lblNomeProduto.Location = new System.Drawing.Point(185, 126);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(60, 21);
            this.lblNomeProduto.TabIndex = 108;
            this.lblNomeProduto.Text = "Nome";
            // 
            // lblCodigoProduto
            // 
            this.lblCodigoProduto.AutoSize = true;
            this.lblCodigoProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProduto.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoProduto.Location = new System.Drawing.Point(172, 72);
            this.lblCodigoProduto.Name = "lblCodigoProduto";
            this.lblCodigoProduto.Size = new System.Drawing.Size(72, 21);
            this.lblCodigoProduto.TabIndex = 107;
            this.lblCodigoProduto.Text = "Código";
            // 
            // cboxCategoriaProduto
            // 
            this.cboxCategoriaProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCategoriaProduto.ForeColor = System.Drawing.Color.Black;
            this.cboxCategoriaProduto.FormattingEnabled = true;
            this.cboxCategoriaProduto.Location = new System.Drawing.Point(257, 471);
            this.cboxCategoriaProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxCategoriaProduto.Name = "cboxCategoriaProduto";
            this.cboxCategoriaProduto.Size = new System.Drawing.Size(319, 29);
            this.cboxCategoriaProduto.TabIndex = 6;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.ForeColor = System.Drawing.Color.Black;
            this.txtDescricaoProduto.Location = new System.Drawing.Point(257, 172);
            this.txtDescricaoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricaoProduto.Multiline = true;
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoProduto.Size = new System.Drawing.Size(319, 171);
            this.txtDescricaoProduto.TabIndex = 3;
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoProduto.ForeColor = System.Drawing.Color.Black;
            this.lblDescricaoProduto.Location = new System.Drawing.Point(149, 176);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(94, 21);
            this.lblDescricaoProduto.TabIndex = 100;
            this.lblDescricaoProduto.Text = "Descrição";
            // 
            // lblCategoriaProduto
            // 
            this.lblCategoriaProduto.AutoSize = true;
            this.lblCategoriaProduto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriaProduto.ForeColor = System.Drawing.Color.Black;
            this.lblCategoriaProduto.Location = new System.Drawing.Point(147, 475);
            this.lblCategoriaProduto.Name = "lblCategoriaProduto";
            this.lblCategoriaProduto.Size = new System.Drawing.Size(96, 21);
            this.lblCategoriaProduto.TabIndex = 98;
            this.lblCategoriaProduto.Text = "Categoria";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.ForeColor = System.Drawing.Color.Black;
            this.txtNomeProduto.Location = new System.Drawing.Point(257, 122);
            this.txtNomeProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(319, 28);
            this.txtNomeProduto.TabIndex = 2;
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoProduto.Location = new System.Drawing.Point(257, 68);
            this.txtCodigoProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(131, 28);
            this.txtCodigoProduto.TabIndex = 1;
            this.txtCodigoProduto.TabStop = false;
            // 
            // ttmesagem
            // 
            this.ttmesagem.IsBalloon = true;
            // 
            // errorIcone
            // 
            this.errorIcone.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ViewProdutoDiverso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 985);
            this.Controls.Add(this.tctrlProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewProdutoDiverso";
            this.Text = "Produtos Diversos";
            this.Load += new System.EventHandler(this.ViewProdutoDiverso_Load);
            this.tctrlProduto.ResumeLayout(false);
            this.tpgListarProduto.ResumeLayout(false);
            this.tpgListarProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.tpgConfiguracoesProduto.ResumeLayout(false);
            this.gboxProduto.ResumeLayout(false);
            this.gboxProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctrlProduto;
        private System.Windows.Forms.TabPage tpgListarProduto;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.CheckBox chkInativos;
        private System.Windows.Forms.CheckBox chkDeletarProduto;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Deletar;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.Label lblTotalProduto;
        private System.Windows.Forms.Button btnBuscarProduto;
        private System.Windows.Forms.Button btnDeletarProduto;
        private System.Windows.Forms.Label lblBuscarProduto;
        private System.Windows.Forms.TabPage tpgConfiguracoesProduto;
        private System.Windows.Forms.GroupBox gboxProduto;
        private System.Windows.Forms.TextBox txtPrecoProduto;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.PictureBox pboxProduto;
        private System.Windows.Forms.Button btnCancelarProduto;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnCarregarFotoProduto;
        private System.Windows.Forms.Button btnExcluirFotoProduto;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Label lblCodigoProduto;
        private System.Windows.Forms.ComboBox cboxCategoriaProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.Label lblCategoriaProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.TextBox txtCustoProduto;
        private System.Windows.Forms.Label lbPrecoDecusto;
        private System.Windows.Forms.ToolTip ttmesagem;
        private System.Windows.Forms.ErrorProvider errorIcone;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}