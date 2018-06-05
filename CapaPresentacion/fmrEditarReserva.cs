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
    public partial class fmrEditarReserva : Form
    {
        public fmrEditarReserva()
        {
            InitializeComponent();
        }

        private void mostrarReserva()
        {
            DataTable dtReserva = new DataTable();
            dtReserva = NVenta.mostrarReserva(Convert.ToInt32(frmVentasReservadas.f1.lblIdVenta.Text));
            dtpFecha.Value = Convert.ToDateTime(dtReserva.Rows[0][8].ToString() + "/"+ dtReserva.Rows[0][7].ToString() +"/"+ dtReserva.Rows[0][6].ToString());
            dtpHora.Value = Convert.ToDateTime(dtReserva.Rows[0][4].ToString() + ":" + dtReserva.Rows[0][5].ToString());
            txtCel.Text = dtReserva.Rows[0][1].ToString();
            txtNombre.Text = dtReserva.Rows[0][0].ToString();
            txtMotivo.Text = dtReserva.Rows[0][2].ToString();
            txtObs.Text = dtReserva.Rows[0][3].ToString();
        }

        private void fmrEditarReserva_Load(object sender, EventArgs e)
        {
            mostrarReserva();
            lblIdVenta.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rpta = "";
            rpta = NVenta.EditarReserva(Convert.ToInt32(lblIdVenta.Text),Convert.ToDateTime(dtpFecha.Value.ToShortDateString() + " " + dtpHora.Value.ToLongTimeString()),
                txtObs.Text.Trim(), txtMotivo.Text, txtNombre.Text, txtCel.Text);
            if (rpta == "OK")
            {
                frmVentasReservadas.f1.Mostrar();
                frmVentasReservadas.f1.dataListado.ClearSelection();
                frmVentasReservadas.f1.btnAnular.Enabled = false;
                frmVentasReservadas.f1.btnCobrar.Enabled = false;
                frmVentasReservadas.f1.btnEditar.Enabled = false;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
