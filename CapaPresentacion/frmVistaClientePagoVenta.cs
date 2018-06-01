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
    public partial class frmVistaClientePagoVenta : Form
    {
        public frmVistaClientePagoVenta()
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

        private void frmVistaClientePagoVenta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtBuscar.Select();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
           

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

        private void dataListado_Click(object sender, EventArgs e)
        {
            if (lblBandera.Text == "0")
            {
                frmPagar.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmPagar.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
                frmPagar.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
                frmPagar.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
                frmPagar.f1.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value);
                if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "C")
                {
                    string idTipoCliente;
                    idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                    if (idTipoCliente == "" || idTipoCliente == null)
                    {
                       
                        idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                        decimal subtotal = Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text);
                        decimal igv = Convert.ToDecimal(frmPagar.f1.lblIgv.Text);
                        decimal montoAd = Convert.ToDecimal(frmPagar.f1.lblMontoAdelanto.Text);
                        decimal dctoI = Convert.ToDecimal(frmPagar.f1.lblDescuento.Text);
                        decimal dctoG = Convert.ToDecimal(frmPagar.f1.lblDctoGeneral.Text);
                        NDescuento.DescuentoClientes(idTipoCliente, subtotal, igv, montoAd, dctoI, dctoG, frmPagar.f1.lblDctoGeneral, frmPagar.f1.lblSubTotal,
                            frmPagar.f1.lblIgv, frmPagar.f1.lblTotal, "C");
                        frmPagar.f1.mostrarTotales();
                        frmPagar.f1.cbTipoCliente.SelectedIndex = -1;
                        frmPagar.f1.cbTipoCliente.Enabled = false;
                        frmPagar.f1.cbPaga.Visible = false;
                        frmPagar.f1.cbPaga.Checked = false;
                    }
                    else
                    {
                        idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                        frmPagar.f1.cbTipoCliente.SelectedValue = idTipoCliente;
                        decimal subtotal = Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text);
                        decimal igv = Convert.ToDecimal(frmPagar.f1.lblIgv.Text);
                        decimal montoAd = Convert.ToDecimal(frmPagar.f1.lblMontoAdelanto.Text);
                        decimal dctoI = Convert.ToDecimal(frmPagar.f1.lblDescuento.Text);
                        decimal dctoG = Convert.ToDecimal(frmPagar.f1.lblDctoGeneral.Text);
                        NDescuento.DescuentoClientes(idTipoCliente, subtotal, igv, montoAd, dctoI, dctoG, frmPagar.f1.lblDctoGeneral, frmPagar.f1.lblSubTotal,
                            frmPagar.f1.lblIgv, frmPagar.f1.lblTotal,"C");
                        frmPagar.f1.cbPaga.Checked = false;
                        frmPagar.f1.cbPaga.Visible = false;
                        frmPagar.f1.mostrarTotales();
                        //frmPagar.f1.cbTipoCliente.Enabled = true;
                    }
                }
                else if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "T")
                {
                    // frmPagar.f1.cbTipoCliente.Enabled = false;
                    string idTipoCliente;
                    idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoTrabajador"].Value);
                    decimal subtotal = Convert.ToDecimal(frmPagar.f1.lblSubTotal.Text);
                    decimal igv = Convert.ToDecimal(frmPagar.f1.lblIgv.Text);
                    decimal montoAd = Convert.ToDecimal(frmPagar.f1.lblMontoAdelanto.Text);
                    decimal dctoI = Convert.ToDecimal(frmPagar.f1.lblDescuento.Text);
                    decimal dctoG = Convert.ToDecimal(frmPagar.f1.lblDctoGeneral.Text);
                    NDescuento.DescuentoClientes(idTipoCliente, subtotal, igv, montoAd, dctoI, dctoG, frmPagar.f1.lblDctoGeneral, frmPagar.f1.lblSubTotal,
                        frmPagar.f1.lblIgv, frmPagar.f1.lblTotal, "T");
                    frmPagar.f1.mostrarTotales();
                    frmPagar.f1.cbTipoCliente.SelectedIndex = -1;
                    frmPagar.f1.cbTipoCliente.Enabled = false;
                    frmPagar.f1.cbPaga.Visible = true;
                    frmPagar.f1.cbPaga.Checked = true;
                }
                frmPagar.f1.btnEditar.Enabled = true;
                frmPagar.f1.dataListadoProducto.Select();
                this.Close();
            }
            else if (lblBandera.Text == "1")
            {
                frmDelivery.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmDelivery.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
                frmDelivery.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
                frmDelivery.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
                frmDelivery.f1.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);

                frmDelivery.f1.btnEditar.Enabled = true;
                this.Close();
            }
            else if (lblBandera.Text == "2")
            {
                frmCambioComprobante.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmCambioComprobante.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
                frmCambioComprobante.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
                frmCambioComprobante.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
                frmCambioComprobante.f1.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value);
                if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "C")
                {
                    string idTipoCliente;
                    idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                    if (idTipoCliente == "" || idTipoCliente == null)
                    {
                        frmCambioComprobante.f1.cbTipoCliente.SelectedIndex = -1;
                    }
                    else
                    {
                        frmCambioComprobante.f1.cbTipoCliente.SelectedValue = idTipoCliente;
                      //  frmCambioComprobante.f1.cbTipoCliente.Enabled = true;
                    }
                }
                else
                {
                   // frmCambioComprobante.f1.cbTipoCliente.Enabled = false;
                    frmCambioComprobante.f1.cbTipoCliente.SelectedIndex = -1;
                }
                frmCambioComprobante.f1.btnEditar.Enabled = true;
                this.Close();
            }
            else if (lblBandera.Text == "3")
            {
                fmComprobanteManual.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                fmComprobanteManual.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
                fmComprobanteManual.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
                fmComprobanteManual.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
                fmComprobanteManual.f1.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value);
                if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "C")
                {
                    string idTipoCliente;
                    idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                    if (idTipoCliente == "" || idTipoCliente == null)
                    {
                        fmComprobanteManual.f1.cbTipoCliente.SelectedIndex = -1;
                    }
                    else
                    {
                        fmComprobanteManual.f1.cbTipoCliente.SelectedValue = idTipoCliente;
                        //fmComprobanteManual.f1.cbTipoCliente.Enabled = true;
                    }
                }
                else
                {
                    //fmComprobanteManual.f1.cbTipoCliente.Enabled = false;
                    fmComprobanteManual.f1.cbTipoCliente.SelectedIndex = -1;
                }
                fmComprobanteManual.f1.btnEditar.Enabled = true;
                this.Close();
                
            }
            else if (lblBandera.Text == "4")
            {
                frmConfirmarCredito.f1.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
                frmConfirmarCredito.f1.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
                frmConfirmarCredito.f1.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
                frmConfirmarCredito.f1.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DIreccion"].Value);
                frmConfirmarCredito.f1.lblClase.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value);
                if (Convert.ToString(this.dataListado.CurrentRow.Cells["Clase"].Value) == "C")
                {
                    string idTipoCliente;
                    idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
                    if (idTipoCliente == "" || idTipoCliente == null)
                    {
                        frmConfirmarCredito.f1.cbTipoCliente.SelectedIndex = -1;
                    }
                    else
                    {
                        frmConfirmarCredito.f1.cbTipoCliente.SelectedValue = idTipoCliente;
                        //frmPagar.f1.cbTipoCliente.Enabled = true;
                    }
                }
                else
                {
                    // frmPagar.f1.cbTipoCliente.Enabled = false;
                    frmConfirmarCredito.f1.cbTipoCliente.SelectedIndex = -1;
                }
                frmConfirmarCredito.f1.btnEditar.Enabled = true;
               
                this.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
