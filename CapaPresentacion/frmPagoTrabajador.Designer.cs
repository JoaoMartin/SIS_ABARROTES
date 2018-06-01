namespace CapaPresentacion
{
    partial class frmPagoTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoTrabajador));
            this.dataListadoDcto = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTrabajador = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbCaja = new System.Windows.Forms.CheckBox();
            this.cbFactor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.dataListadoAdelanto = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDctos = new System.Windows.Forms.TextBox();
            this.txtAdelantos = new System.Windows.Forms.TextBox();
            this.txtDiasTrabajados = new System.Windows.Forms.TextBox();
            this.txtOtrosDctos = new System.Windows.Forms.TextBox();
            this.txtMontoPagado = new System.Windows.Forms.TextBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMontoBruto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblIdTrabajador = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDNI = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPagosExtras = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDcto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoAdelanto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataListadoDcto
            // 
            this.dataListadoDcto.AllowUserToAddRows = false;
            this.dataListadoDcto.AllowUserToDeleteRows = false;
            this.dataListadoDcto.AllowUserToOrderColumns = true;
            this.dataListadoDcto.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListadoDcto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataListadoDcto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDcto.Location = new System.Drawing.Point(12, 21);
            this.dataListadoDcto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataListadoDcto.MultiSelect = false;
            this.dataListadoDcto.Name = "dataListadoDcto";
            this.dataListadoDcto.ReadOnly = true;
            this.dataListadoDcto.RowTemplate.Height = 28;
            this.dataListadoDcto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoDcto.Size = new System.Drawing.Size(692, 225);
            this.dataListadoDcto.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(482, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 28);
            this.label4.TabIndex = 37;
            this.label4.Text = "PAGO A TRABAJADOR";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtTrabajador);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtSueldo);
            this.groupBox2.Controls.Add(this.btnBuscarProveedor);
            this.groupBox2.Controls.Add(this.txtNroDoc);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(24, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 160);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterio de Búsqueda";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 89);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 20);
            this.label20.TabIndex = 43;
            this.label20.Text = "Trabajador";
            // 
            // txtTrabajador
            // 
            this.txtTrabajador.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrabajador.ForeColor = System.Drawing.Color.Navy;
            this.txtTrabajador.Location = new System.Drawing.Point(6, 113);
            this.txtTrabajador.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrabajador.Name = "txtTrabajador";
            this.txtTrabajador.ReadOnly = true;
            this.txtTrabajador.Size = new System.Drawing.Size(418, 34);
            this.txtTrabajador.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 20);
            this.label18.TabIndex = 41;
            this.label18.Text = "Nro Doc";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(426, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 20);
            this.label17.TabIndex = 40;
            this.label17.Text = "Sueldo";
            // 
            // txtSueldo
            // 
            this.txtSueldo.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSueldo.ForeColor = System.Drawing.Color.Navy;
            this.txtSueldo.Location = new System.Drawing.Point(430, 113);
            this.txtSueldo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.ReadOnly = true;
            this.txtSueldo.Size = new System.Drawing.Size(129, 34);
            this.txtSueldo.TabIndex = 23;
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.BackColor = System.Drawing.Color.White;
            this.btnBuscarProveedor.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscarProveedor.Image = global::CapaPresentacion.Properties.Resources.search5;
            this.btnBuscarProveedor.Location = new System.Drawing.Point(253, 45);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(37, 40);
            this.btnBuscarProveedor.TabIndex = 21;
            this.btnBuscarProveedor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarProveedor.UseVisualStyleBackColor = false;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.ForeColor = System.Drawing.Color.Navy;
            this.txtNroDoc.Location = new System.Drawing.Point(7, 51);
            this.txtNroDoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(240, 34);
            this.txtNroDoc.TabIndex = 1;
            this.txtNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.cbCaja);
            this.groupBox3.Controls.Add(this.cbFactor);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtFecha);
            this.groupBox3.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(626, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(619, 160);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Compra";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(473, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 20);
            this.label19.TabIndex = 19;
            this.label19.Text = "Origen Dinero";
            // 
            // cbCaja
            // 
            this.cbCaja.AutoSize = true;
            this.cbCaja.Checked = true;
            this.cbCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCaja.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCaja.Location = new System.Drawing.Point(477, 89);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(71, 30);
            this.cbCaja.TabIndex = 39;
            this.cbCaja.Text = "Caja";
            this.cbCaja.UseVisualStyleBackColor = true;
            // 
            // cbFactor
            // 
            this.cbFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFactor.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFactor.FormattingEnabled = true;
            this.cbFactor.Items.AddRange(new object[] {
            "28",
            "30",
            "31"});
            this.cbFactor.Location = new System.Drawing.Point(127, 107);
            this.cbFactor.Name = "cbFactor";
            this.cbFactor.Size = new System.Drawing.Size(220, 34);
            this.cbFactor.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Factor Días";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha";
            // 
            // dtFecha
            // 
            this.dtFecha.Enabled = false;
            this.dtFecha.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(127, 51);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(220, 34);
            this.dtFecha.TabIndex = 10;
            // 
            // dataListadoAdelanto
            // 
            this.dataListadoAdelanto.AllowUserToAddRows = false;
            this.dataListadoAdelanto.AllowUserToDeleteRows = false;
            this.dataListadoAdelanto.AllowUserToOrderColumns = true;
            this.dataListadoAdelanto.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataListadoAdelanto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataListadoAdelanto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoAdelanto.Location = new System.Drawing.Point(7, 21);
            this.dataListadoAdelanto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataListadoAdelanto.MultiSelect = false;
            this.dataListadoAdelanto.Name = "dataListadoAdelanto";
            this.dataListadoAdelanto.ReadOnly = true;
            this.dataListadoAdelanto.RowTemplate.Height = 28;
            this.dataListadoAdelanto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoAdelanto.Size = new System.Drawing.Size(479, 219);
            this.dataListadoAdelanto.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "DIAS TRABAJADOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(784, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "OTROS DESCUENTOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 84;
            this.label3.Text = "OBS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(837, 650);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 85;
            this.label5.Text = "MONTO PAGADO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(419, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 86;
            this.label7.Text = "TOTAL DCTOS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(597, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "TOTAL ADELANTOS";
            // 
            // txtDctos
            // 
            this.txtDctos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDctos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDctos.Font = new System.Drawing.Font("Roboto", 17.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDctos.ForeColor = System.Drawing.Color.Red;
            this.txtDctos.Location = new System.Drawing.Point(423, 511);
            this.txtDctos.Name = "txtDctos";
            this.txtDctos.ReadOnly = true;
            this.txtDctos.Size = new System.Drawing.Size(126, 39);
            this.txtDctos.TabIndex = 6;
            this.txtDctos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAdelantos
            // 
            this.txtAdelantos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAdelantos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdelantos.Font = new System.Drawing.Font("Roboto", 17.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdelantos.ForeColor = System.Drawing.Color.Red;
            this.txtAdelantos.Location = new System.Drawing.Point(601, 511);
            this.txtAdelantos.Name = "txtAdelantos";
            this.txtAdelantos.ReadOnly = true;
            this.txtAdelantos.Size = new System.Drawing.Size(141, 39);
            this.txtAdelantos.TabIndex = 7;
            this.txtAdelantos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDiasTrabajados
            // 
            this.txtDiasTrabajados.BackColor = System.Drawing.Color.White;
            this.txtDiasTrabajados.Font = new System.Drawing.Font("Roboto", 17.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiasTrabajados.ForeColor = System.Drawing.Color.Navy;
            this.txtDiasTrabajados.Location = new System.Drawing.Point(31, 511);
            this.txtDiasTrabajados.Name = "txtDiasTrabajados";
            this.txtDiasTrabajados.Size = new System.Drawing.Size(126, 46);
            this.txtDiasTrabajados.TabIndex = 4;
            this.txtDiasTrabajados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiasTrabajados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasTrabajados_KeyPress);
            this.txtDiasTrabajados.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiasTrabajados_KeyUp);
            // 
            // txtOtrosDctos
            // 
            this.txtOtrosDctos.BackColor = System.Drawing.Color.White;
            this.txtOtrosDctos.Font = new System.Drawing.Font("Roboto", 17.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtrosDctos.ForeColor = System.Drawing.Color.Red;
            this.txtOtrosDctos.Location = new System.Drawing.Point(788, 511);
            this.txtOtrosDctos.Name = "txtOtrosDctos";
            this.txtOtrosDctos.Size = new System.Drawing.Size(156, 46);
            this.txtOtrosDctos.TabIndex = 8;
            this.txtOtrosDctos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOtrosDctos.TextChanged += new System.EventHandler(this.txtOtrosDctos_TextChanged);
            this.txtOtrosDctos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOtrosDctos_KeyPress);
            this.txtOtrosDctos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOtrosDctos_KeyUp);
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMontoPagado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoPagado.Font = new System.Drawing.Font("Roboto", 22.15385F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPagado.ForeColor = System.Drawing.Color.Navy;
            this.txtMontoPagado.Location = new System.Drawing.Point(968, 628);
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.ReadOnly = true;
            this.txtMontoPagado.Size = new System.Drawing.Size(206, 48);
            this.txtMontoPagado.TabIndex = 10;
            this.txtMontoPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.White;
            this.txtObs.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtObs.Location = new System.Drawing.Point(30, 589);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(377, 74);
            this.txtObs.TabIndex = 93;
            this.txtObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(374, 511);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 26);
            this.label10.TabIndex = 94;
            this.label10.Text = "(-)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(561, 511);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 26);
            this.label11.TabIndex = 95;
            this.label11.Text = "(-)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(748, 511);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 26);
            this.label12.TabIndex = 96;
            this.label12.Text = "(-)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(181, 511);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 26);
            this.label13.TabIndex = 97;
            this.label13.Text = "(+)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(220, 488);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 20);
            this.label14.TabIndex = 98;
            this.label14.Text = "MONTO BRUTO";
            // 
            // txtMontoBruto
            // 
            this.txtMontoBruto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMontoBruto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoBruto.Font = new System.Drawing.Font("Roboto", 17.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoBruto.ForeColor = System.Drawing.Color.Navy;
            this.txtMontoBruto.Location = new System.Drawing.Point(224, 511);
            this.txtMontoBruto.Name = "txtMontoBruto";
            this.txtMontoBruto.ReadOnly = true;
            this.txtMontoBruto.Size = new System.Drawing.Size(126, 39);
            this.txtMontoBruto.TabIndex = 5;
            this.txtMontoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(964, 589);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(201, 20);
            this.label16.TabIndex = 101;
            this.label16.Text = "--------------------------------";
            // 
            // lblIdTrabajador
            // 
            this.lblIdTrabajador.AutoSize = true;
            this.lblIdTrabajador.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTrabajador.Location = new System.Drawing.Point(253, 17);
            this.lblIdTrabajador.Name = "lblIdTrabajador";
            this.lblIdTrabajador.Size = new System.Drawing.Size(18, 20);
            this.lblIdTrabajador.TabIndex = 41;
            this.lblIdTrabajador.Text = "0";
            this.lblIdTrabajador.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardar.Font = new System.Drawing.Font("Roboto Black", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.save21;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(1217, 602);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 74);
            this.btnGuardar.TabIndex = 102;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto Black", 9.230769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.cancel2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(1217, 502);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 74);
            this.btnCancelar.TabIndex = 103;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(390, 17);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(18, 20);
            this.lblDNI.TabIndex = 104;
            this.lblDNI.Text = "0";
            this.lblDNI.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataListadoDcto);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 252);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DESCUENTOS";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataListadoAdelanto);
            this.groupBox4.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(735, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 252);
            this.groupBox4.TabIndex = 106;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ADELANTOS";
            // 
            // txtPagosExtras
            // 
            this.txtPagosExtras.BackColor = System.Drawing.Color.White;
            this.txtPagosExtras.Font = new System.Drawing.Font("Roboto", 17.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagosExtras.ForeColor = System.Drawing.Color.Navy;
            this.txtPagosExtras.Location = new System.Drawing.Point(996, 511);
            this.txtPagosExtras.Name = "txtPagosExtras";
            this.txtPagosExtras.Size = new System.Drawing.Size(126, 46);
            this.txtPagosExtras.TabIndex = 9;
            this.txtPagosExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPagosExtras.TextChanged += new System.EventHandler(this.txtPagosExtras_TextChanged);
            this.txtPagosExtras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagosExtras_KeyPress);
            this.txtPagosExtras.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPagosExtras_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(992, 486);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 20);
            this.label15.TabIndex = 108;
            this.label15.Text = "PAGO H. EXTRAS";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Roboto", 12.30769F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label21.Location = new System.Drawing.Point(953, 511);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 26);
            this.label21.TabIndex = 107;
            this.label21.Text = "(+)";
            // 
            // frmPagoTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1339, 688);
            this.Controls.Add(this.txtPagosExtras);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblIdTrabajador);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtMontoBruto);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.txtMontoPagado);
            this.Controls.Add(this.txtOtrosDctos);
            this.Controls.Add(this.txtDiasTrabajados);
            this.Controls.Add(this.txtAdelantos);
            this.Controls.Add(this.txtDctos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagoTrabajador";
            this.Text = ".:: PAGO TRABAJADOR ::.";
            this.Load += new System.EventHandler(this.frmPagoTrabajador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDcto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoAdelanto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataListadoDcto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbCaja;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.DataGridView dataListadoAdelanto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtDctos;
        public System.Windows.Forms.TextBox txtAdelantos;
        public System.Windows.Forms.TextBox txtDiasTrabajados;
        public System.Windows.Forms.TextBox txtOtrosDctos;
        public System.Windows.Forms.TextBox txtMontoPagado;
        public System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtMontoBruto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnBuscarProveedor;
        public System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtSueldo;
        public System.Windows.Forms.Label lblIdTrabajador;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtTrabajador;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ComboBox cbFactor;
        public System.Windows.Forms.TextBox txtPagosExtras;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Button btnGuardar;
    }
}