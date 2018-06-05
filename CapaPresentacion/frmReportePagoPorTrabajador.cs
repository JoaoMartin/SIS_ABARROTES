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
    public partial class frmReportePagoPorTrabajador : Form
    {
        public static frmReportePagoPorTrabajador f1;
        public frmReportePagoPorTrabajador()
        {
            InitializeComponent();
            frmReportePagoPorTrabajador.f1 = this;
        }
        private void cargarTrabajador()
        {
            cbEmpleado.DataSource = NTrabajador.Mostrar();
            cbEmpleado.ValueMember = "Codigo";
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmReportePagoPorTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

        }

        private void Mostrar()
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


            string fechaInicio = "";
            string fechaFin = "";

            fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
            fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");
            this.dataListado.DataSource = NTrabajador.reportePagoPorTrabajador(idTrabajador, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
            decimal total = 00.00m, totalAdelanto = 00.00m, totalDctos = 00.00m, totalOtrosDctos = 00.00m, totalHorasExtras = 00.00m;
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                totalAdelanto = totalAdelanto + Convert.ToDecimal(dataListado.Rows[i].Cells[4].Value.ToString());
                totalDctos = totalDctos + Convert.ToDecimal(dataListado.Rows[i].Cells[5].Value.ToString());
                totalOtrosDctos = totalOtrosDctos + Convert.ToDecimal(dataListado.Rows[i].Cells[6].Value.ToString());
                totalHorasExtras = totalHorasExtras + Convert.ToDecimal(dataListado.Rows[i].Cells[7].Value.ToString());
                total = total + Convert.ToDecimal(dataListado.Rows[i].Cells[8].Value.ToString());
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

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

            //DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[1].Width = 230;
            this.dataListado.Columns[2].Width = 120;
            this.dataListado.Columns[3].Width = 120;
            this.dataListado.Columns[4].Width = 120;
            this.dataListado.Columns[5].Width = 120;
            this.dataListado.Columns[6].Width = 120;
            this.dataListado.Columns[7].Width = 120;
            this.dataListado.Columns[8].Width = 120;
            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 9);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dataListado.Rows.Count > 0)
            {

                frmRPagoTrabador frm = new frmRPagoTrabador();
                frm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar();
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
    }
}
