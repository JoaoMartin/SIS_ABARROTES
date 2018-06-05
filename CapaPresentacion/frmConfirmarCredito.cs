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
    public partial class frmConfirmarCredito : Form
    {
        public static frmConfirmarCredito f1;
        private bool isNuevo;
        public frmConfirmarCredito()
        {
            InitializeComponent();
            frmConfirmarCredito.f1 = this;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedIndex == 0)
            {
                label2.Visible = true;
                cbCaja.Visible = true;
            }
            else
            {
                label2.Visible = false;
                cbCaja.Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de pago");
                return;
            }
            else if (txtIdCliente.Text == "")
            {
                MessageBox.Show("Ingrese un cliente");
                return;
            }
            else
            {
                string rpta = NCredito.Insertar(Convert.ToInt32(lblIdVenta.Text), cbFormaPago.SelectedItem.ToString(), txtDetalle.Text.Trim(), "PAGADO");
                if (rpta == "OK")
                {
                    decimal igv = 00.00m, total = 00.00m, subtotal = 00.00m, efectivo = 00.00m;
                    int idCliente = Convert.ToInt32(txtIdCliente.Text);
                    string tipoComprobante = "";

                    total = Convert.ToDecimal(lblMonto.Text);
                    subtotal = (total) / 1.18m;

                    this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotal));
                    igv = total - subtotal;
                    this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));

                    if (lblBanderaComprobante.Text == "1")
                    {
                        tipoComprobante = "BOLETA";
                    }
                    else
                    {
                        tipoComprobante = "FACTURA";
                    }
                    if (cbFormaPago.SelectedIndex == 0)
                    {
                        efectivo = Convert.ToDecimal(lblMonto.Text);
                    }
                    else
                    {
                        efectivo = 00.00m;
                    }




                    if (lblEstado.Text == "CREDITO-PENDIENTE_NE")
                    {
                        rpta = NComprobante.Insertar(tipoComprobante, 1, Convert.ToDecimal(lblIgv.Text), DateTime.Now, Convert.ToInt32(lblIdVenta.Text), "EMITIDA", idCliente,
                            Convert.ToDecimal(lblMonto.Text), efectivo, 00.00m, 00.00m, cbFormaPago.SelectedItem.ToString(), 00.00m);
                        dataDetalle.DataSource = NVenta.reporteDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                        DataTable dtdatos = NVenta.reporteDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                       
                        //DataTable dtdatos= NVenta.reporteDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                        decimal dctoInd = 00.00m;
                        for (int i = 0; i < dataDetalle.Rows.Count; i++)
                        {
                            dctoInd = dctoInd + Convert.ToDecimal(dataDetalle.Rows[i].Cells[4].Value);
                        }
                        NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoComprobante, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                          this.txtDocumento.Text.Trim(), "", "","",
                                                                          dataDetalle, dctoInd.ToString(), lblDctoGral.Text, this.lblSubTotal.Text,
                                                                          this.lblIgv.Text, lblMonto.Text,efectivo.ToString(),"00.00", "00.00", cbFormaPago.SelectedItem.ToString(),
                                                                          "Detallado_Cr", "00.00", "",
                                                                          NAliento.MensajeAliento());
                        Facturador(Convert.ToInt32(lblIdVenta.Text), dtdatos);
                    }
                  

                    if (cbFormaPago.SelectedIndex == 0 && cbCaja.Checked == true)
                    {
                        NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(lblMonto.Text), "VENTA", "EFECTIVO");
                    }else if(cbFormaPago.SelectedIndex == 1)
                    {
                        NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(lblMonto.Text), "VENTA", "TARJETA");
                    }
                    else
                    {
                        NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(lblMonto.Text), "VENTA", "TRANSFERENCIA");
                    }
                    MessageBox.Show("Se registró correctamente");
                    NVenta.EditarEstadoVentaCredito_Cortesia("PAGADO-CREDITO", Convert.ToInt32(lblIdVenta.Text));
                    frmCreditosPendientes.f1.Mostrar();
                    frmCreditosPendientes.f1.btnAnular.Enabled = false;
                    frmCreditosPendientes.f1.btnCobrar.Enabled = false;
                    this.Close();
                }
            }
        }



        public void Facturador(int idVenta, DataTable dtDetalle)
        {
            int? tipoDoc;
            string cantidad, codigo, descr, valorUnitario, dcto, importe, nroDoc, nombre;
            decimal igvUn, afecIgv, valUn;

            if (this.txtDocumento.Text.Length == 8)
            {
                tipoDoc = 1;
                nroDoc = this.txtDocumento.Text.Trim();

            }
            else if (this.txtDocumento.Text.Length == 11)
            {
                tipoDoc = 6;
                nroDoc = this.txtDocumento.Text.Trim();
            }
            else
            {
                tipoDoc = 1;
                nroDoc = "0";
            }

            if (this.txtNombre.Text == string.Empty)
            {
                nombre = "SIN DNI";
            }
            else
            {
                nombre = this.txtNombre.Text.Trim();
            }


            string tipoCompr = "";

            if (this.rbBoleta.Checked == true)
            {
                tipoCompr = "BOLETA";

            }
            else if (this.rbFactura.Checked == true)
            {
                tipoCompr = "FACTURA";

            }



            decimal subTotal = Convert.ToDecimal(lblMonto.Text) - Convert.ToDecimal(lblIgv.Text);

            NFacturador.registrarComprobanteCabecera("01", DateTime.Now.ToString("yyyy-MM-dd"), "", tipoDoc, nroDoc, nombre, "PEN", lblDctoGral.Text,
                    "0.00", lblDctoGral.Text, subTotal.ToString(), "0.00", "0.00", lblIgv.Text, "0.00", "0.00",
                    lblMonto.Text, tipoCompr, idVenta);

            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                cantidad = dtDetalle.Rows[i]["Cant"].ToString();
                codigo = dtDetalle.Rows[i]["Cod_Producto"].ToString();
                descr = dtDetalle.Rows[i]["Descr"].ToString();
                valorUnitario = dtDetalle.Rows[i]["Precio"].ToString();
                valUn = Convert.ToDecimal(valorUnitario);
                dcto = dtDetalle.Rows[i]["Dcto"].ToString();
                igvUn = Convert.ToDecimal(valorUnitario) * (18 / 100);
                afecIgv = (Convert.ToDecimal(cantidad) * Convert.ToDecimal(valorUnitario)) * 0.18m;
                importe = dtDetalle.Rows[i]["Importe"].ToString();

                decimal mtoDsctoItem = Convert.ToDecimal(dcto) / Convert.ToDecimal(cantidad);
                decimal mtoPrecioVentaItem = Decimal.Round((Convert.ToDecimal(importe) / 1.18m), 2);
                decimal mtoIgvItem = Convert.ToDecimal(importe) - mtoPrecioVentaItem;
                decimal mtoValorUnitario = mtoPrecioVentaItem / Convert.ToDecimal(cantidad);


                NFacturador.registrarComprobanteDetalle("NIU", cantidad, codigo, "", descr, mtoValorUnitario.ToString("#0.00#"), mtoDsctoItem.ToString("#0.00#"), mtoIgvItem.ToString("#0.00#"), "10", "0.00", "",
                    mtoPrecioVentaItem.ToString("#0.00#"), importe, tipoCompr, idVenta);
            }

        }

        private void cargarTipoCliente()
        {
            cbTipoCliente.DataSource = NTipoCliente.Mostrar();
            cbTipoCliente.ValueMember = "Codigo";
            cbTipoCliente.DisplayMember = "TipoCliente";
            cbTipoCliente.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        public void cargarCliente()
        {
            DataTable dtCliente = NCliente.consultaClienteCredito(lblClase.Text, Convert.ToInt32(lblIdVenta.Text));
            if (dtCliente.Rows.Count > 0)
            {
                txtIdCliente.Text = dtCliente.Rows[0][0].ToString();
                txtNombre.Text = dtCliente.Rows[0][1].ToString();
                txtDocumento.Text = dtCliente.Rows[0][3].ToString();
                txtDireccion.Text = dtCliente.Rows[0][2].ToString();
                if (lblClase.Text == "C")
                {
                    string idTipoCliente;
                    idTipoCliente = dtCliente.Rows[0][4].ToString();
                    if (idTipoCliente == null || idTipoCliente == "")
                    {
                        cbTipoCliente.SelectedIndex = -1;
                    }
                    else
                    {
                        cbTipoCliente.SelectedValue = idTipoCliente;
                    }
                }
                btnEditar.Enabled = true;
                cbTipoCliente.Enabled = false;
            }
        }

        private void frmConfirmarCredito_Load(object sender, EventArgs e)
        {
            this.cbFormaPago.Select();
            cargarTipoCliente();
            if (lblEstado.Text == "CREDITO-PENDIENTE_NE")
            {
                cargarCliente();
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                cargarCliente();
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.btnGuardarCliente.Enabled = true;
            this.txtNombre.ReadOnly = false;
            this.txtDireccion.ReadOnly = false;
            this.cbTipoCliente.Enabled = true;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.cbTipoCliente.Enabled = true;
            this.cbTipoCliente.SelectedIndex = -1;
            this.txtDocumento.Focus();
            btnEditar.Enabled = false;
            isNuevo = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text != "")
            {
                txtDocumento.ReadOnly = false;
                txtNombre.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                // cbTipoCliente.Enabled = true;
                isNuevo = false;
                btnGuardarCliente.Enabled = true;
                if (lblClase.Text == "C")
                {
                    cbTipoCliente.Enabled = true;
                }

            }
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string rpta = NTipoCliente.GuardarCliente(lblMonto.Text, "00.00", lblBanderaComprobante.Text, txtDocumento.Text, cbTipoCliente,
                isNuevo, txtNombre.Text, txtDireccion.Text, txtIdCliente.Text);
            if (isNuevo && rpta != null)
            {
                this.txtIdCliente.Text = rpta;
                this.txtNombre.ReadOnly = true;
                this.txtDireccion.ReadOnly = true;
                this.btnGuardarCliente.Enabled = false;
                this.btnNuevo.Enabled = false;
            }
            else if (rpta == "OK")
            {
                this.txtNombre.ReadOnly = true;
                this.txtDireccion.ReadOnly = true;
                this.btnGuardarCliente.Enabled = false;
                this.btnNuevo.Enabled = false;
            }
        }

        private void rbFactura_CheckedChanged(object sender, EventArgs e)
        {
            lblBanderaComprobante.Text = "2";
        }

        private void rbBoleta_CheckedChanged(object sender, EventArgs e)
        {
            lblBanderaComprobante.Text = "1";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePagoVenta form = new frmVistaClientePagoVenta();
            form.lblBandera.Text = "4";
            form.ShowDialog();

        }
    }
}
