namespace CapaPresentacion
{
    partial class frmCreditosPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditosPendientes));
            this.lblTotalReserva = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblAdelanto = new System.Windows.Forms.Label();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.lblClase = new System.Windows.Forms.Label();
            this.lblDctoGral = new System.Windows.Forms.Label();
            this.lblBanderaAnulacion = new System.Windows.Forms.Label();
            this.lblIdComprobante = new System.Windows.Forms.Label();
            this.lblCorrelativo = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblFechaCompr = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnRecoger = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalReserva
            // 
            this.lblTotalReserva.AutoSize = true;
            this.lblTotalReserva.Location = new System.Drawing.Point(1782, 88);
            this.lblTotalReserva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalReserva.Name = "lblTotalReserva";
            this.lblTotalReserva.Size = new System.Drawing.Size(17, 20);
            this.lblTotalReserva.TabIndex = 89;
            this.lblTotalReserva.Text = "0";
            this.lblTotalReserva.Visible = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(1205, 142);
            this.lblSaldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(17, 20);
            this.lblSaldo.TabIndex = 88;
            this.lblSaldo.Text = "0";
            this.lblSaldo.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNombre);
            this.groupBox1.Controls.Add(this.rbCodigo);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1008, 123);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Búsqueda";
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Checked = true;
            this.rbNombre.Location = new System.Drawing.Point(31, 41);
            this.rbNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(74, 24);
            this.rbNombre.TabIndex = 8;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "Cliente";
            this.rbNombre.UseVisualStyleBackColor = true;
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(215, 41);
            this.rbCodigo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(73, 24);
            this.rbCodigo.TabIndex = 9;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(31, 74);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(397, 37);
            this.txtBuscar.TabIndex = 20;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblAdelanto
            // 
            this.lblAdelanto.AutoSize = true;
            this.lblAdelanto.Location = new System.Drawing.Point(1770, 47);
            this.lblAdelanto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdelanto.Name = "lblAdelanto";
            this.lblAdelanto.Size = new System.Drawing.Size(17, 20);
            this.lblAdelanto.TabIndex = 85;
            this.lblAdelanto.Text = "0";
            this.lblAdelanto.Visible = false;
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(1494, 29);
            this.lblIdVenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(17, 20);
            this.lblIdVenta.TabIndex = 83;
            this.lblIdVenta.Text = "0";
            this.lblIdVenta.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(1283, 29);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(17, 20);
            this.lblEstado.TabIndex = 82;
            this.lblEstado.Text = "0";
            this.lblEstado.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotal.Location = new System.Drawing.Point(1426, 93);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 80;
            this.lblTotal.Text = "label3";
            this.lblTotal.Visible = false;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(1167, 60);
            this.lblIdUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(17, 20);
            this.lblIdUsuario.TabIndex = 79;
            this.lblIdUsuario.Text = "0";
            this.lblIdUsuario.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 39);
            this.label1.TabIndex = 78;
            this.label1.Text = "CREDITOS PENDIENTES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(24, 189);
            this.dataListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 24;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1008, 476);
            this.dataListado.TabIndex = 77;
            this.dataListado.Click += new System.EventHandler(this.dataListado_Click);
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Location = new System.Drawing.Point(1283, 96);
            this.lblClase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(17, 20);
            this.lblClase.TabIndex = 90;
            this.lblClase.Text = "0";
            this.lblClase.Visible = false;
            // 
            // lblDctoGral
            // 
            this.lblDctoGral.AutoSize = true;
            this.lblDctoGral.Location = new System.Drawing.Point(1205, 93);
            this.lblDctoGral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDctoGral.Name = "lblDctoGral";
            this.lblDctoGral.Size = new System.Drawing.Size(17, 20);
            this.lblDctoGral.TabIndex = 91;
            this.lblDctoGral.Text = "0";
            this.lblDctoGral.Visible = false;
            // 
            // lblBanderaAnulacion
            // 
            this.lblBanderaAnulacion.AutoSize = true;
            this.lblBanderaAnulacion.Location = new System.Drawing.Point(1205, 47);
            this.lblBanderaAnulacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanderaAnulacion.Name = "lblBanderaAnulacion";
            this.lblBanderaAnulacion.Size = new System.Drawing.Size(17, 20);
            this.lblBanderaAnulacion.TabIndex = 92;
            this.lblBanderaAnulacion.Text = "0";
            this.lblBanderaAnulacion.Visible = false;
            // 
            // lblIdComprobante
            // 
            this.lblIdComprobante.AutoSize = true;
            this.lblIdComprobante.Location = new System.Drawing.Point(1360, 96);
            this.lblIdComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdComprobante.Name = "lblIdComprobante";
            this.lblIdComprobante.Size = new System.Drawing.Size(17, 20);
            this.lblIdComprobante.TabIndex = 93;
            this.lblIdComprobante.Text = "0";
            this.lblIdComprobante.Visible = false;
            // 
            // lblCorrelativo
            // 
            this.lblCorrelativo.AutoSize = true;
            this.lblCorrelativo.Location = new System.Drawing.Point(1336, 150);
            this.lblCorrelativo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorrelativo.Name = "lblCorrelativo";
            this.lblCorrelativo.Size = new System.Drawing.Size(17, 20);
            this.lblCorrelativo.TabIndex = 94;
            this.lblCorrelativo.Text = "0";
            this.lblCorrelativo.Visible = false;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Location = new System.Drawing.Point(1135, 109);
            this.lblTipoComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(17, 20);
            this.lblTipoComprobante.TabIndex = 95;
            this.lblTipoComprobante.Text = "0";
            this.lblTipoComprobante.Visible = false;
            // 
            // lblFechaCompr
            // 
            this.lblFechaCompr.AutoSize = true;
            this.lblFechaCompr.Location = new System.Drawing.Point(1360, 47);
            this.lblFechaCompr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCompr.Name = "lblFechaCompr";
            this.lblFechaCompr.Size = new System.Drawing.Size(17, 20);
            this.lblFechaCompr.TabIndex = 96;
            this.lblFechaCompr.Text = "0";
            this.lblFechaCompr.Visible = false;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(1250, 142);
            this.lblEfectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(17, 20);
            this.lblEfectivo.TabIndex = 97;
            this.lblEfectivo.Text = "0";
            this.lblEfectivo.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.edit4;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(1040, 464);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(97, 80);
            this.btnEditar.TabIndex = 98;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnular.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Image = global::CapaPresentacion.Properties.Resources.if_Cut_728989;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnular.Location = new System.Drawing.Point(1040, 268);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(97, 82);
            this.btnAnular.TabIndex = 86;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCobrar.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Image = global::CapaPresentacion.Properties.Resources.if_cashbox_45016;
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCobrar.Location = new System.Drawing.Point(1040, 356);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(97, 90);
            this.btnCobrar.TabIndex = 84;
            this.btnCobrar.Text = "Confirmar";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnRecoger
            // 
            this.btnRecoger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecoger.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoger.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRecoger.Image = global::CapaPresentacion.Properties.Resources.save2;
            this.btnRecoger.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecoger.Location = new System.Drawing.Point(1040, 550);
            this.btnRecoger.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRecoger.Name = "btnRecoger";
            this.btnRecoger.Size = new System.Drawing.Size(97, 79);
            this.btnRecoger.TabIndex = 81;
            this.btnRecoger.Text = "Atender";
            this.btnRecoger.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecoger.UseVisualStyleBackColor = false;
            this.btnRecoger.Visible = false;
            // 
            // frmCreditosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 703);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblFechaCompr);
            this.Controls.Add(this.lblTipoComprobante);
            this.Controls.Add(this.lblCorrelativo);
            this.Controls.Add(this.lblIdComprobante);
            this.Controls.Add(this.lblBanderaAnulacion);
            this.Controls.Add(this.lblDctoGral);
            this.Controls.Add(this.lblClase);
            this.Controls.Add(this.lblTotalReserva);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.lblAdelanto);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnRecoger);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataListado);
            this.Font = new System.Drawing.Font("Roboto", 9.230769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreditosPendientes";
            this.Text = ".:: CREDITOS PENDIENTES ::.";
            this.Load += new System.EventHandler(this.frmCreditosPendientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTotalReserva;
        public System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.Button btnAnular;
        public System.Windows.Forms.Label lblAdelanto;
        public System.Windows.Forms.Button btnCobrar;
        public System.Windows.Forms.Label lblIdVenta;
        public System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnRecoger;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataListado;
        public System.Windows.Forms.Label lblClase;
        public System.Windows.Forms.Label lblDctoGral;
        public System.Windows.Forms.Label lblBanderaAnulacion;
        public System.Windows.Forms.Label lblIdComprobante;
        public System.Windows.Forms.Label lblCorrelativo;
        public System.Windows.Forms.Label lblTipoComprobante;
        public System.Windows.Forms.Label lblFechaCompr;
        public System.Windows.Forms.Label lblEfectivo;
        public System.Windows.Forms.Button btnEditar;
    }
}