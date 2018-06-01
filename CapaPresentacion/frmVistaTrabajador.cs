using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmVistaTrabajador : Form
    {
        public frmVistaTrabajador()
        {
            InitializeComponent();
        }
        private void ocultarColumnas()
        {
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            //this.dataListado.Columns[14].Visible = false;
           // this.dataListado.Columns[15].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 265;
            this.dataListado.Columns[3].Width = 160;
            this.dataListado.Columns[4].Width = 110;
            //this.dataListado.Columns[14].Width = 110;
            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
            }
        }

        private void frmVistaTrabajador_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Select();
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNombre(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NTrabajador.BuscarApellido(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarDni()
        {
            this.dataListado.DataSource = NTrabajador.BuscarDni(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            
            decimal sueldo = 00.00m;
            if(Convert.ToString(this.dataListado.CurrentRow.Cells["Sueldo"].Value) == "" || Convert.ToString(this.dataListado.CurrentRow.Cells["Sueldo"].Value) == null)
            {
                sueldo = 00.00m;
            }
            else
            {
                sueldo = Convert.ToDecimal(Convert.ToString(this.dataListado.CurrentRow.Cells["Sueldo"].Value));
            }

            if (sueldo <= 0)
            {
                MessageBox.Show("Ingrese un sueldo mayor a 0");
                frmPagoTrabajador.f1.cbFactor.SelectedIndex = -1;
                this.Close();
                
            }else
            {
                frmPagoTrabajador.f1.lblIdTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                if(frmPagoTrabajador.f1.Validar()== true)
                {
                    frmPagoTrabajador.f1.txtTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);

                    frmPagoTrabajador.f1.txtSueldo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sueldo"].Value);
                    frmPagoTrabajador.f1.lblDNI.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
                    frmPagoTrabajador.f1.mostrarDctos();
                    frmPagoTrabajador.f1.mostrarAdelantos();
                    frmPagoTrabajador.f1.cbFactor.SelectedIndex = 1;
                    frmPagoTrabajador.f1.btnGuardar.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya se registró un pago a este traajador en este mes");
                    frmPagoTrabajador.f1.txtNroDoc.Focus();
                    frmPagoTrabajador.f1.btnGuardar.Enabled = false;
                    this.Close();
                }



            }
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbNombre.Checked == true)
            {
                this.BuscarNombre();
            }
            else if (this.rbTipoDoc.Checked == true)
            {
                this.BuscarDni();
            }
        }
    }
}
