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
    public partial class frmVentaFormaPago : Form
    {
        public frmVentaFormaPago()
        {
            InitializeComponent();
        }

        private void frmVentaFormaPago_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }
        private void Mostrar()
        {
            if (cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de pago");
            }
            else
            {
                string fechaInicio = "";
                string fechaFin = "";
                int totalCan = 0;
                if (rbAperturaCaja.Checked == true)
                {
                    //fecIn = Convert.ToDateTime(frmPrincipal.f1.lblFechaApertura.Text);
                    //fechaInicio = fecIn.ToString("yyyy-MM-dd hh:mm:ss");
                    fechaInicio = frmPrincipal.f1.lblFechaApertura.Text;
                    // fechaFin = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    fechaFin = DateTime.Now.ToString();
                }
                else if (rbElegir.Checked == true)
                {
                    fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                    fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
                }

                this.lblCaja.Text = "0";
                this.dataListado.DataSource = NVenta.reporteVentaForma(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), cbProducto.SelectedItem.ToString());
                decimal total = 00.00m;
                for (int i = 0; i < dataListado.Rows.Count; i++)
                {
                    //totalCan = totalCan + Convert.ToInt32(dataListado.Rows[i].Cells[4].Value.ToString());
                    total = total + Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value.ToString());
                }
                lblCant.Text = total.ToString();
                
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

                if (this.dataListado.Rows.Count == 0)
                {
                    this.dataListado.Visible = false;
                    lblCant.Text = "0";
                    btnImprimir.Enabled = false;
                    //ocultarColumnas();
                }
                else
                {

                    this.dataListado.Visible = true;
                    btnImprimir.Enabled = true;
                    ocultarColumnas();
                }
            }

        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[6].Visible = false;

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 180;
            this.dataListado.Columns[1].Width = 530;
            this.dataListado.Columns[2].Width = 230;
           // this.dataListado.Columns[4].Width = 80;
            //this.dataListado.Columns[5].Width = 80;
         
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            Mostrar();
        }

        private void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
                this.lblBandera.Text = "0";
            }
            else if (rbElegir.Checked == true)
            {
                groupBox1.Enabled = true;
                this.lblBandera.Text = "1";
            }
        }

        private void rbAperturaCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAperturaCaja.Checked == true)
            {
                groupBox1.Enabled = false;
                this.lblBandera.Text = "0";
            }
            else if (rbElegir.Checked == true)
            {
                groupBox1.Enabled = true;
                this.lblBandera.Text = "1";
            }
        }
    }
}
