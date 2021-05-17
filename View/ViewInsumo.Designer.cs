namespace View
{
    partial class ViewInsumo
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttmesagem = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcone = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtPrecoInsumo = new System.Windows.Forms.TextBox();
            this.lblPrecoInsumo = new System.Windows.Forms.Label();
            this.gboxInsumo = new System.Windows.Forms.GroupBox();
            this.cbArmazenamentoInsumo = new System.Windows.Forms.ComboBox();
            this.btnCancelarInsumo = new System.Windows.Forms.Button();
            this.btnNovoInsumo = new System.Windows.Forms.Button();
            this.btnEditarInsumo = new System.Windows.Forms.Button();
            this.btnSalvarInsumo = new System.Windows.Forms.Button();
            this.lblNomeInsumo = new System.Windows.Forms.Label();
            this.lblCodigoInsumo = new System.Windows.Forms.Label();
            this.lblArmazenamentoInsumo = new System.Windows.Forms.Label();
            this.txtNomeInsumo = new System.Windows.Forms.TextBox();
            this.txtCodigoInsumo = new System.Windows.Forms.TextBox();
            this.tpgConfiguracoesInsumo = new System.Windows.Forms.TabPage();
            this.btnDeletarInsumo = new System.Windows.Forms.Button();
            this.lblBuscarInsumo = new System.Windows.Forms.Label();
            this.btnBuscarInsumo = new System.Windows.Forms.Button();
            this.tpgListarInsumo = new System.Windows.Forms.TabPage();
            this.chkDeletarInsumo = new System.Windows.Forms.CheckBox();
            this.dgvInsumo = new System.Windows.Forms.DataGridView();
            this.Deletar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBuscarInsumo = new System.Windows.Forms.TextBox();
            this.lblTotalInsumo = new System.Windows.Forms.Label();
            this.tctrlInsumo = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).BeginInit();
            this.gboxInsumo.SuspendLayout();
            this.tpgConfiguracoesInsumo.SuspendLayout();
            this.tpgListarInsumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumo)).BeginInit();
            this.tctrlInsumo.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            // txtPrecoInsumo
            // 
            this.txtPrecoInsumo.ForeColor = System.Drawing.Color.Black;
            this.txtPrecoInsumo.Location = new System.Drawing.Point(583, 103);
            this.txtPrecoInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecoInsumo.Name = "txtPrecoInsumo";
            this.txtPrecoInsumo.Size = new System.Drawing.Size(102, 28);
            this.txtPrecoInsumo.TabIndex = 4;
            // 
            // lblPrecoInsumo
            // 
            this.lblPrecoInsumo.AutoSize = true;
            this.lblPrecoInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoInsumo.ForeColor = System.Drawing.Color.Black;
            this.lblPrecoInsumo.Location = new System.Drawing.Point(504, 110);
            this.lblPrecoInsumo.Name = "lblPrecoInsumo";
            this.lblPrecoInsumo.Size = new System.Drawing.Size(58, 21);
            this.lblPrecoInsumo.TabIndex = 115;
            this.lblPrecoInsumo.Text = "Preço";
            // 
            // gboxInsumo
            // 
            this.gboxInsumo.BackColor = System.Drawing.Color.White;
            this.gboxInsumo.Controls.Add(this.cbArmazenamentoInsumo);
            this.gboxInsumo.Controls.Add(this.txtPrecoInsumo);
            this.gboxInsumo.Controls.Add(this.lblPrecoInsumo);
            this.gboxInsumo.Controls.Add(this.btnCancelarInsumo);
            this.gboxInsumo.Controls.Add(this.btnNovoInsumo);
            this.gboxInsumo.Controls.Add(this.btnEditarInsumo);
            this.gboxInsumo.Controls.Add(this.btnSalvarInsumo);
            this.gboxInsumo.Controls.Add(this.lblNomeInsumo);
            this.gboxInsumo.Controls.Add(this.lblCodigoInsumo);
            this.gboxInsumo.Controls.Add(this.lblArmazenamentoInsumo);
            this.gboxInsumo.Controls.Add(this.txtNomeInsumo);
            this.gboxInsumo.Controls.Add(this.txtCodigoInsumo);
            this.gboxInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gboxInsumo.Location = new System.Drawing.Point(3, 0);
            this.gboxInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxInsumo.Name = "gboxInsumo";
            this.gboxInsumo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gboxInsumo.Size = new System.Drawing.Size(1733, 852);
            this.gboxInsumo.TabIndex = 0;
            this.gboxInsumo.TabStop = false;
            this.gboxInsumo.Text = "Insumo";
            // 
            // cbArmazenamentoInsumo
            // 
            this.cbArmazenamentoInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArmazenamentoInsumo.ForeColor = System.Drawing.Color.Black;
            this.cbArmazenamentoInsumo.FormattingEnabled = true;
            this.cbArmazenamentoInsumo.Items.AddRange(new object[] {
            "KG(s)",
            "Unidade(s)"});
            this.cbArmazenamentoInsumo.Location = new System.Drawing.Point(583, 55);
            this.cbArmazenamentoInsumo.Name = "cbArmazenamentoInsumo";
            this.cbArmazenamentoInsumo.Size = new System.Drawing.Size(195, 29);
            this.cbArmazenamentoInsumo.TabIndex = 116;
            // 
            // btnCancelarInsumo
            // 
            this.btnCancelarInsumo.BackColor = System.Drawing.Color.Orchid;
            this.btnCancelarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarInsumo.ForeColor = System.Drawing.Color.White;
            this.btnCancelarInsumo.Location = new System.Drawing.Point(707, 234);
            this.btnCancelarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarInsumo.Name = "btnCancelarInsumo";
            this.btnCancelarInsumo.Size = new System.Drawing.Size(160, 38);
            this.btnCancelarInsumo.TabIndex = 11;
            this.btnCancelarInsumo.Text = "Cancelar";
            this.btnCancelarInsumo.UseVisualStyleBackColor = false;
            this.btnCancelarInsumo.Click += new System.EventHandler(this.btnCancelarInsumo_Click);
            // 
            // btnNovoInsumo
            // 
            this.btnNovoInsumo.BackColor = System.Drawing.Color.Orchid;
            this.btnNovoInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoInsumo.ForeColor = System.Drawing.Color.White;
            this.btnNovoInsumo.Location = new System.Drawing.Point(157, 234);
            this.btnNovoInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovoInsumo.Name = "btnNovoInsumo";
            this.btnNovoInsumo.Size = new System.Drawing.Size(160, 38);
            this.btnNovoInsumo.TabIndex = 8;
            this.btnNovoInsumo.Text = "Novo";
            this.btnNovoInsumo.UseVisualStyleBackColor = false;
            this.btnNovoInsumo.Click += new System.EventHandler(this.btnNovoInsumo_Click);
            // 
            // btnEditarInsumo
            // 
            this.btnEditarInsumo.BackColor = System.Drawing.Color.Orchid;
            this.btnEditarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarInsumo.ForeColor = System.Drawing.Color.White;
            this.btnEditarInsumo.Location = new System.Drawing.Point(525, 234);
            this.btnEditarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarInsumo.Name = "btnEditarInsumo";
            this.btnEditarInsumo.Size = new System.Drawing.Size(160, 38);
            this.btnEditarInsumo.TabIndex = 10;
            this.btnEditarInsumo.Text = "Editar";
            this.btnEditarInsumo.UseVisualStyleBackColor = false;
            this.btnEditarInsumo.Click += new System.EventHandler(this.btnEditarInsumo_Click);
            // 
            // btnSalvarInsumo
            // 
            this.btnSalvarInsumo.BackColor = System.Drawing.Color.Orchid;
            this.btnSalvarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarInsumo.ForeColor = System.Drawing.Color.White;
            this.btnSalvarInsumo.Location = new System.Drawing.Point(340, 234);
            this.btnSalvarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvarInsumo.Name = "btnSalvarInsumo";
            this.btnSalvarInsumo.Size = new System.Drawing.Size(160, 38);
            this.btnSalvarInsumo.TabIndex = 9;
            this.btnSalvarInsumo.Text = "Salvar";
            this.btnSalvarInsumo.UseVisualStyleBackColor = false;
            this.btnSalvarInsumo.Click += new System.EventHandler(this.btnSalvarInsumo_Click);
            // 
            // lblNomeInsumo
            // 
            this.lblNomeInsumo.AutoSize = true;
            this.lblNomeInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeInsumo.ForeColor = System.Drawing.Color.Black;
            this.lblNomeInsumo.Location = new System.Drawing.Point(85, 110);
            this.lblNomeInsumo.Name = "lblNomeInsumo";
            this.lblNomeInsumo.Size = new System.Drawing.Size(60, 21);
            this.lblNomeInsumo.TabIndex = 108;
            this.lblNomeInsumo.Text = "Nome";
            // 
            // lblCodigoInsumo
            // 
            this.lblCodigoInsumo.AutoSize = true;
            this.lblCodigoInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoInsumo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoInsumo.Location = new System.Drawing.Point(72, 58);
            this.lblCodigoInsumo.Name = "lblCodigoInsumo";
            this.lblCodigoInsumo.Size = new System.Drawing.Size(72, 21);
            this.lblCodigoInsumo.TabIndex = 107;
            this.lblCodigoInsumo.Text = "Código";
            // 
            // lblArmazenamentoInsumo
            // 
            this.lblArmazenamentoInsumo.AutoSize = true;
            this.lblArmazenamentoInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmazenamentoInsumo.ForeColor = System.Drawing.Color.Black;
            this.lblArmazenamentoInsumo.Location = new System.Drawing.Point(413, 58);
            this.lblArmazenamentoInsumo.Name = "lblArmazenamentoInsumo";
            this.lblArmazenamentoInsumo.Size = new System.Drawing.Size(149, 21);
            this.lblArmazenamentoInsumo.TabIndex = 100;
            this.lblArmazenamentoInsumo.Text = "Armazenamento";
            // 
            // txtNomeInsumo
            // 
            this.txtNomeInsumo.ForeColor = System.Drawing.Color.Black;
            this.txtNomeInsumo.Location = new System.Drawing.Point(157, 106);
            this.txtNomeInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeInsumo.Name = "txtNomeInsumo";
            this.txtNomeInsumo.Size = new System.Drawing.Size(293, 28);
            this.txtNomeInsumo.TabIndex = 2;
            // 
            // txtCodigoInsumo
            // 
            this.txtCodigoInsumo.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoInsumo.Location = new System.Drawing.Point(157, 54);
            this.txtCodigoInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoInsumo.Name = "txtCodigoInsumo";
            this.txtCodigoInsumo.Size = new System.Drawing.Size(131, 28);
            this.txtCodigoInsumo.TabIndex = 1;
            this.txtCodigoInsumo.TabStop = false;
            // 
            // tpgConfiguracoesInsumo
            // 
            this.tpgConfiguracoesInsumo.Controls.Add(this.gboxInsumo);
            this.tpgConfiguracoesInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgConfiguracoesInsumo.Location = new System.Drawing.Point(4, 30);
            this.tpgConfiguracoesInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgConfiguracoesInsumo.Name = "tpgConfiguracoesInsumo";
            this.tpgConfiguracoesInsumo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgConfiguracoesInsumo.Size = new System.Drawing.Size(1558, 909);
            this.tpgConfiguracoesInsumo.TabIndex = 1;
            this.tpgConfiguracoesInsumo.Text = "Configurações";
            this.tpgConfiguracoesInsumo.UseVisualStyleBackColor = true;
            // 
            // btnDeletarInsumo
            // 
            this.btnDeletarInsumo.BackColor = System.Drawing.Color.Orchid;
            this.btnDeletarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletarInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletarInsumo.ForeColor = System.Drawing.Color.White;
            this.btnDeletarInsumo.Location = new System.Drawing.Point(632, 22);
            this.btnDeletarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletarInsumo.Name = "btnDeletarInsumo";
            this.btnDeletarInsumo.Size = new System.Drawing.Size(140, 38);
            this.btnDeletarInsumo.TabIndex = 5;
            this.btnDeletarInsumo.Text = "Deletar";
            this.btnDeletarInsumo.UseVisualStyleBackColor = false;
            this.btnDeletarInsumo.Click += new System.EventHandler(this.btnDeletarInsumo_Click);
            // 
            // lblBuscarInsumo
            // 
            this.lblBuscarInsumo.AutoSize = true;
            this.lblBuscarInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarInsumo.ForeColor = System.Drawing.Color.Black;
            this.lblBuscarInsumo.Location = new System.Drawing.Point(51, 30);
            this.lblBuscarInsumo.Name = "lblBuscarInsumo";
            this.lblBuscarInsumo.Size = new System.Drawing.Size(60, 21);
            this.lblBuscarInsumo.TabIndex = 0;
            this.lblBuscarInsumo.Text = "Nome";
            // 
            // btnBuscarInsumo
            // 
            this.btnBuscarInsumo.BackColor = System.Drawing.Color.Orchid;
            this.btnBuscarInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarInsumo.ForeColor = System.Drawing.Color.White;
            this.btnBuscarInsumo.Location = new System.Drawing.Point(443, 22);
            this.btnBuscarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarInsumo.Name = "btnBuscarInsumo";
            this.btnBuscarInsumo.Size = new System.Drawing.Size(140, 38);
            this.btnBuscarInsumo.TabIndex = 2;
            this.btnBuscarInsumo.Text = "Buscar";
            this.btnBuscarInsumo.UseVisualStyleBackColor = false;
            this.btnBuscarInsumo.Click += new System.EventHandler(this.btnBuscarInsumo_Click);
            // 
            // tpgListarInsumo
            // 
            this.tpgListarInsumo.BackColor = System.Drawing.Color.Transparent;
            this.tpgListarInsumo.Controls.Add(this.chkDeletarInsumo);
            this.tpgListarInsumo.Controls.Add(this.dgvInsumo);
            this.tpgListarInsumo.Controls.Add(this.txtBuscarInsumo);
            this.tpgListarInsumo.Controls.Add(this.lblTotalInsumo);
            this.tpgListarInsumo.Controls.Add(this.btnBuscarInsumo);
            this.tpgListarInsumo.Controls.Add(this.btnDeletarInsumo);
            this.tpgListarInsumo.Controls.Add(this.lblBuscarInsumo);
            this.tpgListarInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgListarInsumo.Location = new System.Drawing.Point(4, 30);
            this.tpgListarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgListarInsumo.Name = "tpgListarInsumo";
            this.tpgListarInsumo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpgListarInsumo.Size = new System.Drawing.Size(1558, 909);
            this.tpgListarInsumo.TabIndex = 0;
            this.tpgListarInsumo.Text = "Listar";
            // 
            // chkDeletarInsumo
            // 
            this.chkDeletarInsumo.AutoSize = true;
            this.chkDeletarInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeletarInsumo.ForeColor = System.Drawing.Color.Black;
            this.chkDeletarInsumo.Location = new System.Drawing.Point(28, 101);
            this.chkDeletarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDeletarInsumo.Name = "chkDeletarInsumo";
            this.chkDeletarInsumo.Size = new System.Drawing.Size(94, 25);
            this.chkDeletarInsumo.TabIndex = 3;
            this.chkDeletarInsumo.Text = "Deletar";
            this.chkDeletarInsumo.UseVisualStyleBackColor = true;
            this.chkDeletarInsumo.CheckedChanged += new System.EventHandler(this.chkDeletarInsumo_CheckedChanged);
            // 
            // dgvInsumo
            // 
            this.dgvInsumo.AllowUserToAddRows = false;
            this.dgvInsumo.AllowUserToDeleteRows = false;
            this.dgvInsumo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsumo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvInsumo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvInsumo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(32)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumo.ColumnHeadersHeight = 50;
            this.dgvInsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Deletar});
            this.dgvInsumo.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInsumo.EnableHeadersVisualStyles = false;
            this.dgvInsumo.GridColor = System.Drawing.Color.Black;
            this.dgvInsumo.Location = new System.Drawing.Point(7, 143);
            this.dgvInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvInsumo.MultiSelect = false;
            this.dgvInsumo.Name = "dgvInsumo";
            this.dgvInsumo.ReadOnly = true;
            this.dgvInsumo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(32)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsumo.RowHeadersVisible = false;
            this.dgvInsumo.RowHeadersWidth = 51;
            this.dgvInsumo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orchid;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsumo.RowTemplate.Height = 24;
            this.dgvInsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumo.Size = new System.Drawing.Size(1545, 736);
            this.dgvInsumo.TabIndex = 4;
            this.dgvInsumo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsumo_CellContentClick);
            this.dgvInsumo.DoubleClick += new System.EventHandler(this.dgvInsumo_DoubleClick);
            // 
            // Deletar
            // 
            this.Deletar.HeaderText = "Deletar";
            this.Deletar.MinimumWidth = 6;
            this.Deletar.Name = "Deletar";
            this.Deletar.ReadOnly = true;
            this.Deletar.Width = 125;
            // 
            // txtBuscarInsumo
            // 
            this.txtBuscarInsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarInsumo.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarInsumo.Location = new System.Drawing.Point(131, 26);
            this.txtBuscarInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarInsumo.Name = "txtBuscarInsumo";
            this.txtBuscarInsumo.Size = new System.Drawing.Size(249, 30);
            this.txtBuscarInsumo.TabIndex = 1;
            this.txtBuscarInsumo.TextChanged += new System.EventHandler(this.txtBuscarInsumo_TextChanged);
            // 
            // lblTotalInsumo
            // 
            this.lblTotalInsumo.AutoSize = true;
            this.lblTotalInsumo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInsumo.ForeColor = System.Drawing.Color.Black;
            this.lblTotalInsumo.Location = new System.Drawing.Point(460, 106);
            this.lblTotalInsumo.Name = "lblTotalInsumo";
            this.lblTotalInsumo.Size = new System.Drawing.Size(69, 21);
            this.lblTotalInsumo.TabIndex = 5;
            this.lblTotalInsumo.Text = "lblTotal";
            // 
            // tctrlInsumo
            // 
            this.tctrlInsumo.Controls.Add(this.tpgListarInsumo);
            this.tctrlInsumo.Controls.Add(this.tpgConfiguracoesInsumo);
            this.tctrlInsumo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tctrlInsumo.Location = new System.Drawing.Point(1, 14);
            this.tctrlInsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tctrlInsumo.Name = "tctrlInsumo";
            this.tctrlInsumo.SelectedIndex = 0;
            this.tctrlInsumo.Size = new System.Drawing.Size(1566, 943);
            this.tctrlInsumo.TabIndex = 19;
            this.tctrlInsumo.SelectedIndexChanged += new System.EventHandler(this.tctrlInsumo_SelectedIndexChanged);
            // 
            // ViewInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 985);
            this.Controls.Add(this.tctrlInsumo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewInsumo";
            this.Text = "Insumos";
            this.Load += new System.EventHandler(this.ViewInsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcone)).EndInit();
            this.gboxInsumo.ResumeLayout(false);
            this.gboxInsumo.PerformLayout();
            this.tpgConfiguracoesInsumo.ResumeLayout(false);
            this.tpgListarInsumo.ResumeLayout(false);
            this.tpgListarInsumo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumo)).EndInit();
            this.tctrlInsumo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tctrlInsumo;
        private System.Windows.Forms.TabPage tpgListarInsumo;
        private System.Windows.Forms.CheckBox chkDeletarInsumo;
        private System.Windows.Forms.TextBox txtBuscarInsumo;
        private System.Windows.Forms.Label lblTotalInsumo;
        private System.Windows.Forms.Button btnBuscarInsumo;
        private System.Windows.Forms.Button btnDeletarInsumo;
        private System.Windows.Forms.Label lblBuscarInsumo;
        private System.Windows.Forms.TabPage tpgConfiguracoesInsumo;
        private System.Windows.Forms.GroupBox gboxInsumo;
        private System.Windows.Forms.TextBox txtPrecoInsumo;
        private System.Windows.Forms.Label lblPrecoInsumo;
        private System.Windows.Forms.Button btnCancelarInsumo;
        private System.Windows.Forms.Button btnNovoInsumo;
        private System.Windows.Forms.Button btnEditarInsumo;
        private System.Windows.Forms.Button btnSalvarInsumo;
        private System.Windows.Forms.Label lblNomeInsumo;
        private System.Windows.Forms.Label lblCodigoInsumo;
        private System.Windows.Forms.Label lblArmazenamentoInsumo;
        private System.Windows.Forms.TextBox txtNomeInsumo;
        private System.Windows.Forms.TextBox txtCodigoInsumo;
        private System.Windows.Forms.ToolTip ttmesagem;
        private System.Windows.Forms.ErrorProvider errorIcone;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvInsumo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Deletar;
        private System.Windows.Forms.ComboBox cbArmazenamentoInsumo;
    }
}