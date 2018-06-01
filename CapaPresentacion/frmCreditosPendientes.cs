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
    public partial class frmCreditosPendientes : Form
    {
        public static frmCreditosPendientes f1;
        public frmCreditosPendientes()
        {
            InitializeComponent();
            frmCreditosPendientes.f1 = this;
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NVenta.BuscarCreditoPendiente(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCliente()
        {
            this.dataListado.DataSource = NVenta.BuscarCreditoPendienteCliente(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void ocultarColumnas()
        {

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 60;
            this.dataListado.Columns[1].Width = 180;
            this.dataListado.Columns[2].Width = 280;
            this.dataListado.Columns[3].Width = 100;
            this.dataListado.Columns[4].Width = 100;
            this.dataListado.Columns[5].Width = 195;


            this.dataListado.RowTemplate.Height = 28;
            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListado.Font = new Font("Roboto", 8);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        public void Mostrar()
        {
            this.dataListado.DataSource = NVenta.MostrarCreditosPendientes();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
                //ocultarColumnas();
            }
            else
            {
                this.dataListado.Visible = true;
                ocultarColumnas();
            }
        }

        private void frmCreditosPendientes_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
            Mostrar();
            this.txtBuscar.Select();
            this.btnRecoger.Enabled = false;
            this.btnCobrar.Enabled = false;
            this.btnAnular.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (txtBuscar.Text.Trim().Length == 0)
            {
                Mostrar();
            }

            if (rbCodigo.Checked == true)
            {
                this.Mostrar();
                this.Buscar();
            }
            else
            {
                this.Mostrar();
                this.BuscarCliente();
            }
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            this.lblEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.lblIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.lblTotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoCliente"].Value);
            this.lblDctoGral.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Dcto"].Value);
            //this.lblSaldo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Saldo"].Value);

            DataTable dtConsulta = NComprobante.consultaComprobanteCredito(Convert.ToInt32(lblIdVenta.Text));
            if(dtConsulta.Rows.Count <= 0)
            {
                btnAnular.Enabled = true;
                lblBanderaAnulacion.Text = "0";
            }else if (dtConsulta.Rows[0][2].ToString() == "BOLETA")
            {
                btnAnular.Enabled = false;
            }else if (dtConsulta.Rows[0][2].ToString() == "FACTURA")
            {
                btnAnular.Enabled = true;
                lblBanderaAnulacion.Text = "1";
                lblIdComprobante.Text = dtConsulta.Rows[0][0].ToString();
                lblCorrelativo.Text = dtConsulta.Rows[0][1].ToString();
                lblTipoComprobante.Text = dtConsulta.Rows[0][2].ToString();
                lblFechaCompr.Text = dtConsulta.Rows[0][5].ToString();
                lblEfectivo.Text = dtConsulta.Rows[0][6].ToString();
            }
            btnRecoger.Enabled = true;
            btnCobrar.Enabled = true;
            

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            frmConfirmarCredito frm = new frmConfirmarCredito();
            frm.lblEstado.Text = this.lblEstado.Text;
            frm.lblIdVenta.Text = this.lblIdVenta.Text;
            frm.lblMonto.Text = this.lblTotal.Text;
            frm.lblClase.Text = this.lblClase.Text;
            frm.lblDctoGral.Text = this.lblDctoGral.Text;
            frm.Show();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            frmAnularComprobante frm = new frmAnularComprobante();
            frm.lblBandera.Text = "5";
            frm.Show();
        }
    }
}
