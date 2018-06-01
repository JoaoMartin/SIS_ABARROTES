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
    public partial class frmVistaClientePago_Separado : Form
    {
        public frmVistaClientePago_Separado()
        {
            InitializeComponent();
        }
        private void ocultarColumnas()
        {
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 345;
            this.dataListado.Columns[4].Width = 105;
            this.dataListado.Columns[5].Width = 110;
            // this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.mostrarClienteVenta1();
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

        private void BuscarDni()
        {
            this.dataListado.DataSource = NCliente.BuscarDni_1(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscar()
        {
            this.dataListado.DataSource = NCliente.BuscarCliente_1(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaClientePago_Separado_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Select();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.rbTipoDoc.Checked == true)
            {
                this.BuscarDni();
            }
            else if (this.rbNombre.Checked == true || this.rbTodos.Checked == true)
            {
                this.Buscar();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            frmPagarSeparada.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            frmPagarSeparada.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            frmPagarSeparada.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
            frmPagarSeparada.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
            frmPagarSeparada.f1.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value);
            if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "C")
            {
                string idTipoCliente;
                idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                if (idTipoCliente == "" || idTipoCliente == null)
                {
                    idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                    decimal subtotal = Convert.ToDecimal(frmPagarSeparada.f1.lblSubTotal.Text);
                    decimal igv = Convert.ToDecimal(frmPagarSeparada.f1.lblIgv.Text);
                    decimal montoAd = 00.00m;
                    decimal dctoI = Convert.ToDecimal(frmPagarSeparada.f1.lblDescuento.Text);
                    decimal dctoG = Convert.ToDecimal(frmPagarSeparada.f1.lblDctoGeneral.Text);
                    NDescuento.DescuentoClientes(idTipoCliente, subtotal, igv, montoAd, dctoI, dctoG, frmPagarSeparada.f1.lblDctoGeneral, frmPagarSeparada.f1.lblSubTotal,
                           frmPagarSeparada.f1.lblIgv, frmPagarSeparada.f1.lblTotal, "C");
                    frmPagarSeparada.f1.mostrarTotales();

                    frmPagarSeparada.f1.cbTipoCliente.SelectedIndex = -1;
                    frmPagarSeparada.f1.cbTipoCliente.Enabled = false;
                    frmPagarSeparada.f1.cbPaga.Visible = false;
                    frmPagarSeparada.f1.cbPaga.Checked = false;
                }
                else
                {
                    frmPagarSeparada.f1.cbTipoCliente.SelectedValue = idTipoCliente;
                    decimal subtotal = Convert.ToDecimal(frmPagarSeparada.f1.lblSubTotal.Text);
                    decimal igv = Convert.ToDecimal(frmPagarSeparada.f1.lblIgv.Text);
                    decimal montoAd = 00.00m;
                    decimal dctoI = Convert.ToDecimal(frmPagarSeparada.f1.lblDescuento.Text);
                    decimal dctoG = Convert.ToDecimal(frmPagarSeparada.f1.lblDctoGeneral.Text);
                    NDescuento.DescuentoClientes(idTipoCliente, subtotal, igv, montoAd, dctoI, dctoG, frmPagarSeparada.f1.lblDctoGeneral, frmPagarSeparada.f1.lblSubTotal,
                        frmPagarSeparada.f1.lblIgv, frmPagarSeparada.f1.lblTotal,"C");
                    frmPagarSeparada.f1.mostrarTotales();
                    //frmPagar.f1.cbTipoCliente.Enabled = true;
                }
            }
            else if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "T")
            {
                // frmPagar.f1.cbTipoCliente.Enabled = false;
                string idTipoCliente;
                idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoTrabajador"].Value);
                decimal subtotal = Convert.ToDecimal(frmPagarSeparada.f1.lblSubTotal.Text);
                decimal igv = Convert.ToDecimal(frmPagarSeparada.f1.lblIgv.Text);
                decimal montoAd = 00.00m;
                decimal dctoI = Convert.ToDecimal(frmPagarSeparada.f1.lblDescuento.Text);
                decimal dctoG = Convert.ToDecimal(frmPagarSeparada.f1.lblDctoGeneral.Text);
                NDescuento.DescuentoClientes(idTipoCliente, subtotal, igv, montoAd, dctoI, dctoG, frmPagarSeparada.f1.lblDctoGeneral, frmPagarSeparada.f1.lblSubTotal,
                       frmPagarSeparada.f1.lblIgv, frmPagarSeparada.f1.lblTotal, "C");
                frmPagarSeparada.f1.mostrarTotales();

                frmPagarSeparada.f1.cbTipoCliente.SelectedIndex = -1;
                frmPagarSeparada.f1.cbTipoCliente.Enabled = false;
                frmPagarSeparada.f1.cbPaga.Visible = true;
                frmPagarSeparada.f1.cbPaga.Checked = true;
            }
            frmPagarSeparada.f1.btnEditar.Enabled = true;
            frmPagarSeparada.f1.dataListadoProducto.Select();
            this.Close();
        }
    }
}
