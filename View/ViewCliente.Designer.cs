namespace View
{
    partial class ViewCliente
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
            this.ttmesagem = new System.Windows.Forms.ToolTip(this.components);
            this.cboBuscarCliente = new System.Windows.Forms.ComboBox();
            this.cboxSexoCliente = new System.Windows.Forms.ComboBox();
            this.errorIcone = new System.Windows.Forms.ErrorProvider(this.components);
            this.tctrlCliente = new System.Windows.Forms.TabControl();
            this.tpgListarCliente = new System.Windows.Forms.TabPage();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.chkInativos = new System.Windows.Forms.CheckBox();
            this.chkDeletarCliente = new System.Windows.Forms.CheckBox();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.Deletar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.lblTotalCliente = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnDeletarCliente = new System.Windows.Forms.Button();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.tpgConfiguracoesCliente = new System.Windows.Forms.TabPage();
            this.gboxCliente = new System.Windows.Forms.GroupBox();
            this.dtpNascimentoCliente = new System.Windows.Forms.DateTimePicker();
            this.txtCPFCliente = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefoneCliente = new System.Windows.Forms.MaskedTextBox();
            this.lblNascimentoCliente = new System.Windows.Forms.Label();
            this.lblEmailCliente = new System.Windows.Forms.Label();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.lblTelefoneCliente = new System.Windows.Forms.Label();
            this.lblCPFCliente = new System.Windows.Forms.Label();
            this.lblSexoCliente = new System.Windows.Forms.Label();
            this.btnCancelarCliente = new System.Windows.Forms.Button();
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.btnEditarCliente = new System.Windows.Forms.Button();
            this.btnSalvarCliente = new System.Windows.Forms.Button();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).BeginInit();
            this.tctrlCliente.SuspendLayout();
            this.tpgListarCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.tpgConfiguracoesCliente.SuspendLayout();
            this.gboxCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttmesagem
            // 
            this.ttmesagem.IsBalloon = true;
            // 
            // cboBuscarCliente
            // 
            this.cboBuscarCliente.BackColor = System.Drawing.Color.White;
            this.cboBuscarCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.cboBuscarCliente.FormattingEnabled = true;
            this.cboBuscarCliente.Items.AddRange(new object[] {
            "Nome",
            "CPF"});
            this.cboBuscarCliente.Location = new System.Drawing.Point(159, 26);
            this.cboBuscarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboBuscarCliente.Name = "cboBuscarCliente";
            this.cboBuscarCliente.Size = new System.Drawing.Size(133, 29);
            this.cboBuscarCliente.TabIndex = 1;
            this.ttmesagem.SetToolTip(this.cboBuscarCliente, "Selecione o método de busca desejado");
            this.cboBuscarCliente.SelectedIndexChanged += new System.EventHandler(this.cboBuscarCliente_SelectedIndexChanged);
            // 
            // cboxSexoCliente
            // 
            this.cboxSexoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSexoCliente.ForeColor = System.Drawing.Color.Black;
            this.cboxSexoCliente.FormattingEnabled = true;
            this.cboxSexoCliente.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            "Indefinido"});
            this.cboxSexoCliente.Location = new System.Drawing.Point(1025, 222);
            this.cboxSexoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxSexoCliente.Name = "cboxSexoCliente";
            this.cboxSexoCliente.Size = new System.Drawing.Size(132, 29);
            this.cboxSexoCliente.TabIndex = 4;
            this.ttmesagem.SetToolTip(this.cboxSexoCliente, "Selecione o sexo do cliente");
            // 
            // errorIcone
            // 
            this.errorIcone.ContainerControl = this;
            // 
            // tctrlCliente
            // 
            this.tctrlCliente.Controls.Add(this.tpgListarCliente);
            this.tctrlCliente.Controls.Add(this.tpgConfiguracoesCliente);
            this.tctrlCliente.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tctrlCliente.Location = new System.Drawing.Point(15, 25);
            this.tctrlCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tctrlCliente.Name = "tctrlCliente";
            this.tctrlCliente.SelectedIndex = 0;
            this.tctrlCliente.Size = new System.Drawing.Size(1564, 946);
            this.tctrlCliente.TabIndex = 18;
            this.tctrlCliente.SelectedIndexChanged += new System.EventHandler(this.tctrlCliente_SelectedIndexChanged);
            // 
            // tpgListarCliente
            // 
            this.tpgListarCliente.BackColor = System.Drawing.Color.Transparent;
            this.tpgListarCliente.Controls.Add(this.btnAtivar);
            this.tpgListarCliente.Controls.Add(this.chkInativos);
            this.tpgListarCliente.Controls.Add(this.cboBuscarCliente);
            this.tpgListarCliente.Controls.Add(this.chkDeletarCliente);
            this.tpgListarCliente.Controls.Add(this.dgvCliente);
            this.tpgListarCliente.Controls.Add(this.txtBuscarCliente);
            this.tpgListarCliente.Controls.Add(this.lblTotalCliente);
            this.tpgListarCliente.Controls.Add(this.btnBuscarCliente);
            this.tpgListarCliente.Controls.Add(this.btnDeletarCliente);
            this.tpgListarCliente.Controls.Add(this.lblBuscarCliente);
            this.tpgListarCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgListarCliente.Location = new System.Drawing.Point(4, 30);
            this.tpgListarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgListarCliente.Name = "tpgListarCliente";
            this.tpgListarCliente.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgListarCliente.Size = new System.Drawing.Size(1556, 912);
            this.tpgListarCliente.TabIndex = 0;
            this.tpgListarCliente.Text = "Listar";
            // 
            // btnAtivar
            // 
            this.btnAtivar.BackColor = System.Drawing.Color.Orchid;
            this.btnAtivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtivar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivar.ForeColor = System.Drawing.Color.White;
            this.btnAtivar.Location = new System.Drawing.Point(1003, 22);
            this.btnAtivar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(140, 38);
            this.btnAtivar.TabIndex = 8;
            this.btnAtivar.Text = "Ativar";
            this.btnAtivar.UseVisualStyleBackColor = false;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // chkInativos
            // 
            this.chkInativos.AutoSize = true;
            this.chkInativos.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInativos.ForeColor = System.Drawing.Color.Black;
            this.chkInativos.Location = new System.Drawing.Point(159, 70);
            this.chkInativos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkInativos.Name = "chkInativos";
            this.chkInativos.Size = new System.Drawing.Size(98, 25);
            this.chkInativos.TabIndex = 7;
            this.chkInativos.Text = "Inativos";
            this.chkInativos.UseVisualStyleBackColor = true;
            this.chkInativos.CheckedChanged += new System.EventHandler(this.chkInativos_CheckedChanged);
            // 
            // chkDeletarCliente
            // 
            this.chkDeletarCliente.AutoSize = true;
            this.chkDeletarCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeletarCliente.ForeColor = System.Drawing.Color.Black;
            this.chkDeletarCliente.Location = new System.Drawing.Point(16, 70);
            this.chkDeletarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDeletarCliente.Name = "chkDeletarCliente";
            this.chkDeletarCliente.Size = new System.Drawing.Size(94, 25);
            this.chkDeletarCliente.TabIndex = 4;
            this.chkDeletarCliente.Text = "Deletar";
            this.chkDeletarCliente.UseVisualStyleBackColor = true;
            this.chkDeletarCliente.CheckedChanged += new System.EventHandler(this.chkDeletarCliente_CheckedChanged);
            // 
            // dgvCliente
            // 
            this.dgvCliente.AllowUserToAddRows = false;
            this.dgvCliente.AllowUserToDeleteRows = false;
            this.dgvCliente.AllowUserToResizeColumns = false;
            this.dgvCliente.AllowUserToResizeRows = false;
            this.dgvCliente.BackgroundColor = System.Drawing.Color.White;
            this.dgvCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCliente.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(32)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCliente.ColumnHeadersHeight = 50;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Deletar});
            this.dgvCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCliente.EnableHeadersVisualStyles = false;
            this.dgvCliente.GridColor = System.Drawing.Color.Black;
            this.dgvCliente.Location = new System.Drawing.Point(16, 134);
            this.dgvCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCliente.MultiSelect = false;
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.ReadOnly = true;
            this.dgvCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCliente.RowHeadersVisible = false;
            this.dgvCliente.RowHeadersWidth = 45;
            this.dgvCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliente.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCliente.RowTemplate.Height = 20;
            this.dgvCliente.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCliente.Size = new System.Drawing.Size(1532, 773);
            this.dgvCliente.TabIndex = 5;
            this.dgvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliente_CellContentClick);
            this.dgvCliente.DoubleClick += new System.EventHandler(this.dgvCliente_DoubleClick);
            // 
            // Deletar
            // 
            this.Deletar.FillWeight = 50F;
            this.Deletar.HeaderText = "Deletar";
            this.Deletar.MinimumWidth = 6;
            this.Deletar.Name = "Deletar";
            this.Deletar.ReadOnly = true;
            this.Deletar.Width = 67;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCliente.Location = new System.Drawing.Point(313, 26);
            this.txtBuscarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(249, 28);
            this.txtBuscarCliente.TabIndex = 2;
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);
            // 
            // lblTotalCliente
            // 
            this.lblTotalCliente.AutoSize = true;
            this.lblTotalCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCliente.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCliente.Location = new System.Drawing.Point(640, 70);
            this.lblTotalCliente.Name = "lblTotalCliente";
            this.lblTotalCliente.Size = new System.Drawing.Size(69, 21);
            this.lblTotalCliente.TabIndex = 5;
            this.lblTotalCliente.Text = "lblTotal";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Orchid;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(645, 22);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(140, 38);
            this.btnBuscarCliente.TabIndex = 3;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnDeletarCliente
            // 
            this.btnDeletarCliente.BackColor = System.Drawing.Color.Orchid;
            this.btnDeletarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletarCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletarCliente.ForeColor = System.Drawing.Color.White;
            this.btnDeletarCliente.Location = new System.Drawing.Point(835, 22);
            this.btnDeletarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletarCliente.Name = "btnDeletarCliente";
            this.btnDeletarCliente.Size = new System.Drawing.Size(140, 38);
            this.btnDeletarCliente.TabIndex = 6;
            this.btnDeletarCliente.Text = "Deletar";
            this.btnDeletarCliente.UseVisualStyleBackColor = false;
            this.btnDeletarCliente.Click += new System.EventHandler(this.btnDeletarCliente_Click);
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.AutoSize = true;
            this.lblBuscarCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.lblBuscarCliente.Location = new System.Drawing.Point(76, 30);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new System.Drawing.Size(65, 21);
            this.lblBuscarCliente.TabIndex = 0;
            this.lblBuscarCliente.Text = "Buscar";
            // 
            // tpgConfiguracoesCliente
            // 
            this.tpgConfiguracoesCliente.Controls.Add(this.gboxCliente);
            this.tpgConfiguracoesCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgConfiguracoesCliente.Location = new System.Drawing.Point(4, 30);
            this.tpgConfiguracoesCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgConfiguracoesCliente.Name = "tpgConfiguracoesCliente";
            this.tpgConfiguracoesCliente.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgConfiguracoesCliente.Size = new System.Drawing.Size(1556, 912);
            this.tpgConfiguracoesCliente.TabIndex = 1;
            this.tpgConfiguracoesCliente.Text = "Configurações";
            this.tpgConfiguracoesCliente.UseVisualStyleBackColor = true;
            // 
            // gboxCliente
            // 
            this.gboxCliente.BackColor = System.Drawing.Color.White;
            this.gboxCliente.Controls.Add(this.dtpNascimentoCliente);
            this.gboxCliente.Controls.Add(this.txtCPFCliente);
            this.gboxCliente.Controls.Add(this.txtTelefoneCliente);
            this.gboxCliente.Controls.Add(this.lblNascimentoCliente);
            this.gboxCliente.Controls.Add(this.cboxSexoCliente);
            this.gboxCliente.Controls.Add(this.lblEmailCliente);
            this.gboxCliente.Controls.Add(this.txtEmailCliente);
            this.gboxCliente.Controls.Add(this.lblTelefoneCliente);
            this.gboxCliente.Controls.Add(this.lblCPFCliente);
            this.gboxCliente.Controls.Add(this.lblSexoCliente);
            this.gboxCliente.Controls.Add(this.btnCancelarCliente);
            this.gboxCliente.Controls.Add(this.btnNovoCliente);
            this.gboxCliente.Controls.Add(this.btnEditarCliente);
            this.gboxCliente.Controls.Add(this.btnSalvarCliente);
            this.gboxCliente.Controls.Add(this.lblNomeCliente);
            this.gboxCliente.Controls.Add(this.lblCodigoCliente);
            this.gboxCliente.Controls.Add(this.txtNomeCliente);
            this.gboxCliente.Controls.Add(this.txtCodigoCliente);
            this.gboxCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gboxCliente.Location = new System.Drawing.Point(3, 0);
            this.gboxCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxCliente.Name = "gboxCliente";
            this.gboxCliente.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxCliente.Size = new System.Drawing.Size(1545, 901);
            this.gboxCliente.TabIndex = 0;
            this.gboxCliente.TabStop = false;
            this.gboxCliente.Text = "Cliente";
            // 
            // dtpNascimentoCliente
            // 
            this.dtpNascimentoCliente.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpNascimentoCliente.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNascimentoCliente.Location = new System.Drawing.Point(808, 222);
            this.dtpNascimentoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNascimentoCliente.MaxDate = new System.DateTime(2020, 5, 19, 0, 0, 0, 0);
            this.dtpNascimentoCliente.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpNascimentoCliente.Name = "dtpNascimentoCliente";
            this.dtpNascimentoCliente.Size = new System.Drawing.Size(155, 28);
            this.dtpNascimentoCliente.TabIndex = 3;
            this.dtpNascimentoCliente.Value = new System.DateTime(2020, 5, 19, 0, 0, 0, 0);
            // 
            // txtCPFCliente
            // 
            this.txtCPFCliente.BeepOnError = true;
            this.txtCPFCliente.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtCPFCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCPFCliente.Location = new System.Drawing.Point(509, 222);
            this.txtCPFCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPFCliente.Mask = "000.000.000-00";
            this.txtCPFCliente.Name = "txtCPFCliente";
            this.txtCPFCliente.Size = new System.Drawing.Size(159, 28);
            this.txtCPFCliente.TabIndex = 2;
            this.txtCPFCliente.Text = "99999999999";
            this.txtCPFCliente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtTelefoneCliente
            // 
            this.txtTelefoneCliente.BeepOnError = true;
            this.txtTelefoneCliente.ForeColor = System.Drawing.Color.Black;
            this.txtTelefoneCliente.Location = new System.Drawing.Point(509, 276);
            this.txtTelefoneCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefoneCliente.Mask = "(00) 00000-0000";
            this.txtTelefoneCliente.Name = "txtTelefoneCliente";
            this.txtTelefoneCliente.Size = new System.Drawing.Size(159, 28);
            this.txtTelefoneCliente.TabIndex = 5;
            this.txtTelefoneCliente.Text = "99999999999";
            this.txtTelefoneCliente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblNascimentoCliente
            // 
            this.lblNascimentoCliente.AutoSize = true;
            this.lblNascimentoCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNascimentoCliente.Location = new System.Drawing.Point(687, 226);
            this.lblNascimentoCliente.Name = "lblNascimentoCliente";
            this.lblNascimentoCliente.Size = new System.Drawing.Size(107, 21);
            this.lblNascimentoCliente.TabIndex = 142;
            this.lblNascimentoCliente.Text = "Data Nasc.";
            // 
            // lblEmailCliente
            // 
            this.lblEmailCliente.AutoSize = true;
            this.lblEmailCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailCliente.ForeColor = System.Drawing.Color.Black;
            this.lblEmailCliente.Location = new System.Drawing.Point(736, 283);
            this.lblEmailCliente.Name = "lblEmailCliente";
            this.lblEmailCliente.Size = new System.Drawing.Size(58, 21);
            this.lblEmailCliente.TabIndex = 124;
            this.lblEmailCliente.Text = "E-mail";
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.ForeColor = System.Drawing.Color.Black;
            this.txtEmailCliente.Location = new System.Drawing.Point(808, 276);
            this.txtEmailCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(349, 28);
            this.txtEmailCliente.TabIndex = 6;
            // 
            // lblTelefoneCliente
            // 
            this.lblTelefoneCliente.AutoSize = true;
            this.lblTelefoneCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefoneCliente.ForeColor = System.Drawing.Color.Black;
            this.lblTelefoneCliente.Location = new System.Drawing.Point(416, 281);
            this.lblTelefoneCliente.Name = "lblTelefoneCliente";
            this.lblTelefoneCliente.Size = new System.Drawing.Size(80, 21);
            this.lblTelefoneCliente.TabIndex = 122;
            this.lblTelefoneCliente.Text = "Telefone";
            // 
            // lblCPFCliente
            // 
            this.lblCPFCliente.AutoSize = true;
            this.lblCPFCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPFCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCPFCliente.Location = new System.Drawing.Point(457, 226);
            this.lblCPFCliente.Name = "lblCPFCliente";
            this.lblCPFCliente.Size = new System.Drawing.Size(42, 21);
            this.lblCPFCliente.TabIndex = 120;
            this.lblCPFCliente.Text = "CPF";
            // 
            // lblSexoCliente
            // 
            this.lblSexoCliente.AutoSize = true;
            this.lblSexoCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexoCliente.Location = new System.Drawing.Point(971, 226);
            this.lblSexoCliente.Name = "lblSexoCliente";
            this.lblSexoCliente.Size = new System.Drawing.Size(48, 21);
            this.lblSexoCliente.TabIndex = 118;
            this.lblSexoCliente.Text = "Sexo";
            // 
            // btnCancelarCliente
            // 
            this.btnCancelarCliente.BackColor = System.Drawing.Color.Orchid;
            this.btnCancelarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCliente.ForeColor = System.Drawing.Color.White;
            this.btnCancelarCliente.Location = new System.Drawing.Point(937, 585);
            this.btnCancelarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarCliente.Name = "btnCancelarCliente";
            this.btnCancelarCliente.Size = new System.Drawing.Size(160, 38);
            this.btnCancelarCliente.TabIndex = 17;
            this.btnCancelarCliente.Text = "Cancelar";
            this.btnCancelarCliente.UseVisualStyleBackColor = false;
            this.btnCancelarCliente.Click += new System.EventHandler(this.btnCancelarCliente_Click);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.BackColor = System.Drawing.Color.Orchid;
            this.btnNovoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNovoCliente.Location = new System.Drawing.Point(387, 585);
            this.btnNovoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(160, 38);
            this.btnNovoCliente.TabIndex = 14;
            this.btnNovoCliente.Text = "Novo";
            this.btnNovoCliente.UseVisualStyleBackColor = false;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // btnEditarCliente
            // 
            this.btnEditarCliente.BackColor = System.Drawing.Color.Orchid;
            this.btnEditarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCliente.ForeColor = System.Drawing.Color.White;
            this.btnEditarCliente.Location = new System.Drawing.Point(755, 585);
            this.btnEditarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Size = new System.Drawing.Size(160, 38);
            this.btnEditarCliente.TabIndex = 16;
            this.btnEditarCliente.Text = "Editar";
            this.btnEditarCliente.UseVisualStyleBackColor = false;
            this.btnEditarCliente.Click += new System.EventHandler(this.btnEditarCliente_Click);
            // 
            // btnSalvarCliente
            // 
            this.btnSalvarCliente.BackColor = System.Drawing.Color.Orchid;
            this.btnSalvarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarCliente.ForeColor = System.Drawing.Color.White;
            this.btnSalvarCliente.Location = new System.Drawing.Point(571, 585);
            this.btnSalvarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvarCliente.Name = "btnSalvarCliente";
            this.btnSalvarCliente.Size = new System.Drawing.Size(160, 38);
            this.btnSalvarCliente.TabIndex = 15;
            this.btnSalvarCliente.Text = "Salvar";
            this.btnSalvarCliente.UseVisualStyleBackColor = false;
            this.btnSalvarCliente.Click += new System.EventHandler(this.btnSalvarCliente_Click);
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.ForeColor = System.Drawing.Color.Black;
            this.lblNomeCliente.Location = new System.Drawing.Point(439, 174);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(60, 21);
            this.lblNomeCliente.TabIndex = 108;
            this.lblNomeCliente.Text = "Nome";
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoCliente.Location = new System.Drawing.Point(425, 108);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(72, 21);
            this.lblCodigoCliente.TabIndex = 107;
            this.lblCodigoCliente.Text = "Código";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.ForeColor = System.Drawing.Color.Black;
            this.txtNomeCliente.Location = new System.Drawing.Point(511, 169);
            this.txtNomeCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(681, 28);
            this.txtNomeCliente.TabIndex = 1;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoCliente.Location = new System.Drawing.Point(511, 103);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(131, 28);
            this.txtCodigoCliente.TabIndex = 1;
            this.txtCodigoCliente.TabStop = false;
            // 
            // ViewCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 985);
            this.Controls.Add(this.tctrlCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewCliente";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.ViewCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).EndInit();
            this.tctrlCliente.ResumeLayout(false);
            this.tpgListarCliente.ResumeLayout(false);
            this.tpgListarCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.tpgConfiguracoesCliente.ResumeLayout(false);
            this.gboxCliente.ResumeLayout(false);
            this.gboxCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ttmesagem;
        private System.Windows.Forms.ErrorProvider errorIcone;
        private System.Windows.Forms.TabControl tctrlCliente;
        private System.Windows.Forms.TabPage tpgListarCliente;
        private System.Windows.Forms.CheckBox chkDeletarCliente;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label lblTotalCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnDeletarCliente;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.TabPage tpgConfiguracoesCliente;
        private System.Windows.Forms.GroupBox gboxCliente;
        private System.Windows.Forms.Button btnCancelarCliente;
        private System.Windows.Forms.Button btnNovoCliente;
        private System.Windows.Forms.Button btnEditarCliente;
        private System.Windows.Forms.Button btnSalvarCliente;
        private System.Windows.Forms.ComboBox cboBuscarCliente;
        private System.Windows.Forms.MaskedTextBox txtCPFCliente;
        private System.Windows.Forms.MaskedTextBox txtTelefoneCliente;
        private System.Windows.Forms.Label lblNascimentoCliente;
        private System.Windows.Forms.ComboBox cboxSexoCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label lblTelefoneCliente;
        private System.Windows.Forms.Label lblCPFCliente;
        private System.Windows.Forms.Label lblSexoCliente;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.DateTimePicker dtpNascimentoCliente;
        private System.Windows.Forms.CheckBox chkInativos;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Deletar;
    }
}