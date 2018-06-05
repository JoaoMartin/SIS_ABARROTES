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
    public partial class frmReporteDctoTrabajador : Form
    {
        public static frmReporteDctoTrabajador f1;
        public frmReporteDctoTrabajador()
        {
            InitializeComponent();
            frmReporteDctoTrabajador.f1 = this;
        }

        private void cargarTrabajador()
        {
            cbEmpleado.DataSource = NTrabajador.Mostrar();
            cbEmpleado.ValueMember = "Codigo";
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmReporteDctoTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cbEmpleado.SelectedIndex = -1;
        }

        private void cbTrabajador_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrabajador.Checked == true)
            {
                cargarTrabajador();
                cbEmpleado.Enabled = true;
                cbEmpleado.SelectedIndex = -1;
            }
            else
            {
                cbEmpleado.SelectedIndex = -1;
                cbEmpleado.Enabled = false;
            }
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[5].Visible = false;
            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 280;
            this.dataListado.Columns[1].Width = 150;
            this.dataListado.Columns[2].Width = 350;
            this.dataListado.Columns[3].Width = 220;
            this.dataListado.Columns[4].Width = 150;

            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idTrabajador = 0;
            if (cbTrabajador.Checked == true && cbEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un trabajador");
                return;
            }
            else if (cbTrabajador.Checked == true)
            {
                idTrabajador = Convert.ToInt32(cbEmpleado.SelectedValue);
            }
            else if (cbTrabajador.Checked == false)
            {
                idTrabajador = 0;
            }

            if (cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado");
                return;
            }
            else
            {
                string fechaInicio = "";
                string fechaFin = "";
                decimal totalAd = 00.00m;
                fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
                this.dataListado.DataSource = NDescuentoTrabajador.reporteDctos(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), cbEstado.Text, idTrabajador);

                //lblCant.Text = totalCan.ToString();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

                if (this.dataListado.Rows.Count == 0)
                {
                    this.dataListado.Visible = false;

                    btnImprimir.Enabled = false;
                    //ocultarColumnas();
                }
                else
                {
                    decimal montoTotal = 00.00m;
                    for (int i = 0; i < dataListado.Rows.Count; i++)
                    {
                        montoTotal = montoTotal + Convert.ToDecimal(dataListado.Rows[i].Cells[3].Value);
                    }
                    lblSumaTotal.Text = montoTotal.ToString();
                    this.dataListado.Visible = true;
                    btnImprimir.Enabled = true;
                    ocultarColumnas();


                }
            }
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            lblIdVenta.Text = Convert.ToString((this.dataListado.CurrentRow.Cells["obs"].Value));
            lblMotivo.Text = Convert.ToString((this.dataListado.CurrentRow.Cells["Motivo"].Value));
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
           if(lblMotivo.Text == "CONSUMO_")
            {
                frmReporteDetalleVenta frm = new frmReporteDetalleVenta();
                frm.lblIdVenta.Text = this.lblIdVenta.Text;
                frm.Show();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRDctoTrabajador frm = new frmRDctoTrabajador();
            frm.Show();
        }
    }
}
