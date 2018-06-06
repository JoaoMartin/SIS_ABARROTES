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
    public partial class frmPagarSeparada : Form
    {
        Button[] btnCuenta;
        int nroCuentas;
        public static frmPagarSeparada f1;
        private bool isNuevo;
        private string formaPago;
        private decimal efectivo, tarjeta;
        private string efectivo1, vuelto1, tarjeta1, formaPago1, modoProd;

        public frmPagarSeparada()
        {
            InitializeComponent();
            frmPagarSeparada.f1 = this;
        }

        public void Facturador(int idVenta, DataGridView dtDetalle)
        {
            if (this.lblBanderaComprobante.Text != "0")
            {
                enviarFormaPago();
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
                if (this.lblBanderaComprobante.Text == "1")
                {
                    tipoCompr = "BOLETA";
                }
                else if (this.lblBanderaComprobante.Text == "2")
                {
                    tipoCompr = "FACTURA";
                }

                NFacturador.registrarComprobanteCabecera("01", DateTime.Now.ToString("yyyy-MM-dd"), "", tipoDoc, nroDoc, nombre, "PEN", this.lblDctoGeneral.Text.Trim(),
                    "0.00", this.lblDctoGeneral.Text.Trim(), this.lblSubTotal.Text.Trim(), "0.00", "0.00", this.lblIgv.Text.Trim(), "0.00", "0.00", this.lblTotal.Text, tipoCompr, idVenta);

                for (int i = 0; i < dtDetalle.Rows.Count; i++)
                {
                    codigo = dtDetalle.Rows[i].Cells["Cod"].Value.ToString();
                    cantidad = dtDetalle.Rows[i].Cells["Cant"].Value.ToString();

                    descr = dtDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                    valorUnitario = dtDetalle.Rows[i].Cells["Precio_Un"].Value.ToString();
                    valUn = Convert.ToDecimal(valorUnitario);
                    dcto = dtDetalle.Rows[i].Cells["Descuento"].Value.ToString();
                    igvUn = Convert.ToDecimal(valorUnitario) * (18 / 100);
                    afecIgv = (Convert.ToDecimal(cantidad) * Convert.ToDecimal(valorUnitario)) * 0.18m;
                    importe = dtDetalle.Rows[i].Cells["Importe"].Value.ToString();

                    decimal mtoDsctoItem = Convert.ToDecimal(dcto) / Convert.ToDecimal(cantidad);
                    decimal mtoPrecioVentaItem = Decimal.Round((Convert.ToDecimal(importe) / 1.18m), 2) - mtoDsctoItem;
                    decimal mtoIgvItem = Convert.ToDecimal(importe) - mtoPrecioVentaItem;
                    decimal mtoValorUnitario = Decimal.Round(mtoPrecioVentaItem / Convert.ToDecimal(cantidad), 2);


                    NFacturador.registrarComprobanteDetalle("NIU", cantidad, codigo, "", descr, mtoValorUnitario.ToString("#0.00#"), mtoDsctoItem.ToString("#0.00#"), mtoIgvItem.ToString("#0.00#"), "10", "0.00", "",
                        mtoPrecioVentaItem.ToString("#0.00#"), importe, tipoCompr, idVenta);
                }
            }
        }


        private void enviarFormaPago()
        {
            if (rbTarjeta.Checked)
            {
                efectivo1 = "TARJETA";
                tarjeta1 = lblTotal.Text;
                vuelto1 = "00.00";
                formaPago1 = "TARJETA";
            }
            else if (rbEfectivo.Checked)
            {
                efectivo1 = this.txtEfectivo.Text.Trim();
                tarjeta1 = "00.00";
                vuelto1 = this.txtVuelto.Text.Trim();
                formaPago1 = "EFECTIVO";
            }
            else if (rbMixto.Checked)
            {
                efectivo1 = this.txtEfectivo.Text.Trim();
                tarjeta1 = this.txtTarjeta.Text.Trim();
                vuelto1 = "00.00";
                formaPago1 = "MIXTO";
            }
            else if (rbCreditoEmitido.Checked == true)
            {
                efectivo1 = "00.00";
                tarjeta1 = "00.00";
                vuelto1 = "00.00";
                formaPago1 = "CREDITO_E";
            }
            else if (rbCredioNEm.Checked == true)
            {
                efectivo1 = "00.00";
                tarjeta1 = "00.00";
                vuelto1 = "00.00";
                formaPago1 = "CREDITO_NE";
            }
            else if (rbCortesia.Checked == true)
            {
                efectivo1 = "00.00";
                tarjeta1 = "00.00";
                vuelto1 = "00.00";
                formaPago1 = "CORTESIA";
            }
            else if (rbConsumoT.Checked == true)
            {
                efectivo1 = "00.00";
                tarjeta1 = "00.00";
                vuelto1 = "00.00";
                formaPago1 = "CONSUMO_TRABAJADOR";

            }

            if (rbDetallado.Checked)
            {
                modoProd = "Detallado";
            }
            else if (rbConsumo.Checked)
            {
                modoProd = "Por Consumo";
            }
        }

        public void mostrarTotales()
        {
            decimal total = Convert.ToDecimal(this.lblTotal.Text);
            decimal tarjeta;
            decimal efectivo = 0;
            if (rbEfectivo.Checked)
            {
                if (this.txtEfectivo.Text != "")
                {
                    efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                    decimal vuelto = efectivo - total;
                    this.txtVuelto.Text = vuelto.ToString();
                }
                else
                {
                    this.txtVuelto.Text = string.Empty;
                }
            }
            else if (rbTarjeta.Checked)
            {
                this.txtEfectivo.Text = string.Empty;
                this.txtTarjeta.Text = string.Empty;
                this.txtVuelto.Text = string.Empty;
            }
            else if (rbMixto.Checked)
            {
                if (this.txtEfectivo.Text != "")
                {
                    efectivo = Convert.ToDecimal(this.txtEfectivo.Text);
                    tarjeta = total - efectivo;
                    this.txtTarjeta.Text = tarjeta.ToString();
                    this.txtVuelto.Text = string.Empty;
                }
                else
                {
                    this.txtTarjeta.Text = string.Empty;
                }

            }

        }

        private bool insertarCaja()
        {
            string rptaCaja = "";
            try
            {
                if (rbEfectivo.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "EFECTIVO");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (rbTarjeta.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "TARJETA");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (rbMixto.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.txtEfectivo.Text), "VENTA", "EFECTIVO");
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.txtTarjeta.Text), "VENTA", "TARJETA");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (rbCreditoEmitido.Checked == true || rbCredioNEm.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "CREDITO");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (rbCortesia.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "CORTESIA");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (rbConsumoT.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "CONSUMO_TRABAJADOR");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (rbConsumoT.Checked == true)
                {
                    rptaCaja = NCaja.Insertar(Convert.ToInt32(this.lblIdUsuario.Text), "1", "Ingreso", Convert.ToDecimal(this.lblTotal.Text), "VENTA", "CONSUMO_TRABAJADOR");
                    if (rptaCaja == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            return true;
        }

        private void Limpiar()
        {
            this.txtIdCliente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;

            this.txtEfectivo.Text = string.Empty;
            this.txtTarjeta.Text = string.Empty;
            this.txtVuelto.Text = string.Empty;
            this.lblSubTotal.Text = "00.00";
            this.lblDescuento.Text = "00.00";
            this.lblDctoGeneral.Text = "00.00";
            this.lblIgv.Text = "00.00";
            this.lblTotal.Text = "00.00";
        }

        private void Deshabilitado()
        {
            this.btnDescuentoTotal.Visible = false;

        }
        private void ValidarAcceso()
        {
            this.Deshabilitado();
            DataTable dtIdTipoTrabajador = NTipoTrabajador.MostrarIdTipoUsuario(Convert.ToInt32(this.lblIdUsuario.Text));
            DataTable dtNivel = NNivel.Mostrar(Convert.ToInt32(dtIdTipoTrabajador.Rows[0][0].ToString()));
            for (int i = 0; i < dtNivel.Rows.Count; i++)
            {
                if (dtNivel.Rows[i][2].ToString() == "Venta-Dcto General")
                {
                    this.btnDescuentoTotal.Visible = true;
                }

            }
        }

        private void frmPagarSeparada_Load(object sender, EventArgs e)
        {
            cargarTipoCliente();
            this.ValidarAcceso();
            this.txtEfectivo.Select();
            cbTipoCliente.Enabled = false;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtEfectivo.Clear();
            txtEfectivo.ReadOnly = false;
            this.rbEfectivo.Checked = true;
            this.btnCobro.Enabled = true;
            btnDescuentoTotal.Enabled = true;

            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC1.Text);
            decimal totalRedondeo = NRedondeo.redondearParcial(precioVenta);
            //total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            total = totalRedondeo + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            this.lblTotal.Text = totalRedondeo.ToString();
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            //decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            decimal subTotal = (totalRedondeo) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC1.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            //decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            decimal igv = totalRedondeo - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));


            this.lblBanderaCuenta.Text = "1";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
            this.txtEfectivo.Select();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtEfectivo.Clear();
            txtEfectivo.ReadOnly = false;
            this.rbEfectivo.Checked = true;
            this.btnCobro.Enabled = true;
            btnDescuentoTotal.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC2.Text);
            decimal totalRedondeo = NRedondeo.redondearParcial(precioVenta);
            //total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            total = totalRedondeo + Convert.ToDecimal(frmSepararCuenta.f1.tdC2.Text);
            this.lblTotal.Text = totalRedondeo.ToString();
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            //decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            decimal subTotal = (totalRedondeo) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC2.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            //decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            decimal igv = totalRedondeo - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "2";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtEfectivo.Clear();
            txtEfectivo.ReadOnly = false;
            this.rbEfectivo.Checked = true;
            this.btnCobro.Enabled = true;
            btnDescuentoTotal.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC3.Text);
            decimal totalRedondeo = NRedondeo.redondearParcial(precioVenta);
            //total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            total = totalRedondeo + Convert.ToDecimal(frmSepararCuenta.f1.tdC3.Text);
            this.lblTotal.Text = totalRedondeo.ToString();
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            //decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            decimal subTotal = (totalRedondeo) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC3.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            //decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            decimal igv = totalRedondeo - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "3";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtEfectivo.Clear();
            txtEfectivo.ReadOnly = false;
            this.rbEfectivo.Checked = true;
            this.btnCobro.Enabled = true;
            btnDescuentoTotal.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC4.Text);
            decimal totalRedondeo = NRedondeo.redondearParcial(precioVenta);
            //total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            total = totalRedondeo + Convert.ToDecimal(frmSepararCuenta.f1.tdC4.Text);
            this.lblTotal.Text = totalRedondeo.ToString();
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            //decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            decimal subTotal = (totalRedondeo) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC4.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            //decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            decimal igv = totalRedondeo - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "4";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtEfectivo.Clear();
            txtEfectivo.ReadOnly = false;
            this.rbEfectivo.Checked = true;
            this.btnCobro.Enabled = true;
            btnDescuentoTotal.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC5.Text);
            decimal totalRedondeo = NRedondeo.redondearParcial(precioVenta);
            //total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            total = totalRedondeo + Convert.ToDecimal(frmSepararCuenta.f1.tdC5.Text);
            this.lblTotal.Text = totalRedondeo.ToString();
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            //decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            decimal subTotal = (totalRedondeo) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC5.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            //decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            decimal igv = totalRedondeo - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "5";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            txtEfectivo.Clear();
            txtEfectivo.ReadOnly = false;
            this.rbEfectivo.Checked = true;
            this.btnCobro.Enabled = true;
            btnDescuentoTotal.Enabled = true;
            this.txtEfectivo.Select();
            decimal precioVenta, total;
            precioVenta = Convert.ToDecimal(frmSepararCuenta.f1.lblTotalC6.Text);
            decimal totalRedondeo = NRedondeo.redondearParcial(precioVenta);
            //total = precioVenta + Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text);
            total = totalRedondeo + Convert.ToDecimal(frmSepararCuenta.f1.tdC6.Text);
            this.lblTotal.Text = totalRedondeo.ToString();
            this.lblDescuento.Text = frmSepararCuenta.f1.lblDescuento_Actual.Text;
            //decimal subTotal = (precioVenta - Convert.ToDecimal(frmSepararCuenta.f1.tdC1.Text)) / 1.18m;
            decimal subTotal = (totalRedondeo) / 1.18m;
            this.lblDescuento.Text = frmSepararCuenta.f1.tdC6.Text;
            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subTotal));
            //decimal igv = precioVenta - Convert.ToDecimal(this.lblSubTotal.Text);
            decimal igv = totalRedondeo - Convert.ToDecimal(this.lblSubTotal.Text);
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igv));
            this.lblBanderaCuenta.Text = "6";
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
        }

        public void PagoPorCuentaVentaSinRegistrar(int? idCliente, DataTable dtDetalle, decimal vuelto, Button btn, DataGridView dgv)
        {
            //recorrer dg1 y eliminar detalles
            string rpta = "";
            string estadoVenta = "";
            if (this.txtIdCliente.Text == string.Empty && this.lblBanderaComprobante.Text == "2")
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }
            else if (this.lblBanderaComprobante.Text == "2" && this.txtDocumento.Text.Trim().Length != 11)
            {
                MessageBox.Show("Ingrese un número de RUC válido");
                return;
            }
            else
            {
                for (int i = 0; i < dtDetalle.Rows.Count; i++)
                {
                    rpta = NDetalleVenta.Eliminar(Convert.ToInt32(dtDetalle.Rows[i]["idDetalleVenta"].ToString()));
                }

            }


            if (rpta == "OK")
            {
                if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
                {
                    string tipoCompr = "";
                    if (this.lblBanderaComprobante.Text == "0")
                    {
                        tipoCompr = "TICKET";
                    }
                    else
                    {
                        tipoCompr = "BOLETA";
                    }
                    if (rbCreditoEmitido.Checked == true)
                    {
                        formaPago = "CREDITO_E";
                        estadoVenta = "CREDITO-PENDIENTE_E";

                    }
                    else if (rbCredioNEm.Checked == true)
                    {
                        formaPago = "CREDITO_NE";
                        estadoVenta = "CREDITO-PENDIENTE_NE";

                    }
                    else if (rbCortesia.Checked == true)
                    {
                        formaPago = "CORTESIA";
                        estadoVenta = "CORTESIA";

                    }
                    else if (rbConsumoT.Checked == true)
                    {

                        formaPago = "CONSUMO_TRABAJADOR";
                        estadoVenta = "PENDIENTE";

                    }
                    if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbConsumoT.Checked == true)
                    {
                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                       formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                       Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                       tarjeta, 00.00m, dtDetalle, vuelto, DateTime.Now, 00.00m, Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);
                    }
                    else if (rbCreditoEmitido.Checked == true)
                    {
                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta,
                     formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, tipoCompr, 1,
                     Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                     tarjeta, 00.00m, dtDetalle, vuelto,  DateTime.Now, 00.00m, Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);
                    }

                    else
                    {
                        rpta = NVenta.InsertarPedidoPagadoCredCor(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                           , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, dtDetalle, 
                                                                           DateTime.Now, Convert.ToDecimal(lblTotal.Text), Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),
                                                                           lblObs.Text, "", "", "", lblClase.Text);
                    }



                    btn.Enabled = false;
                }
                else if (this.lblBanderaComprobante.Text == "2")
                {
                    if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                        return;
                    }
                    else
                    {
                        if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbCreditoEmitido.Checked == true || rbConsumoT.Checked == true)
                        {
                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                           formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                           Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                           tarjeta, 00.00m, dtDetalle, vuelto, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);

                        }
                        else if (rbCreditoEmitido.Checked == true)
                        {
                            rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta,
                         formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(this.lblIdUsuario.Text), "CS", 1, "FACTURA", 1,
                         Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo,
                         tarjeta, 00.00m, dtDetalle, vuelto,DateTime.Now, 00.00m, Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);
                        }

                        else
                        {
                            rpta = NVenta.InsertarPedidoPagadoCredCor(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                               , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, dtDetalle,
                                                                               DateTime.Now, Convert.ToDecimal(lblTotal.Text), Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),
                                                                               lblObs.Text, "", "", "", lblClase.Text);
                        }

                        btn.Enabled = false;

                    }

                }
                if (rpta != "")
                {
                    if (insertarCaja() == true)
                    {
                        //MessageBox.Show("Se registró correctamente");
                        enviarFormaPago();
                        string tipoCompr = "";
                        if (this.lblBanderaComprobante.Text == "0")
                        {
                            tipoCompr = "TICKET";
                        }
                        else if (this.lblBanderaComprobante.Text == "1")
                        {
                            tipoCompr = "BOLETA";
                        }
                        else
                        {
                            tipoCompr = "FACTURA";
                        }
                        if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbCreditoEmitido.Checked == true || rbConsumoT.Checked == true)
                        {
                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(rpta), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                        this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                        frmSepararCuenta.f1.lblMesa.Text, dgv, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                        this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd,
                                        "00.00", "", NAliento.MensajeAliento());



                            this.Facturador(Convert.ToInt32(rpta), dgv);
                        }
                        if (cbPaga.Checked)
                        {
                            NDescuentoTrabajador.Insertar(Convert.ToInt32(txtIdCliente.Text), Convert.ToDecimal(lblTotal.Text),
                                "CONSUMO_", DateTime.Now, "PENDIENTE", rpta);
                        }
                        this.Limpiar();
                        cbPaga.Checked = false;
                        cbPaga.Visible = false;

                    }

                    lblObs.Text = "";
                    btn.Enabled = false;
                    cbTipoCliente.Enabled = false;
                    cbTipoCliente.SelectedIndex = -1;
                    btnCobro.Enabled = false;
                    btnDescuentoTotal.Enabled = false;
                    if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                    {
                        rpta = NVenta.EliminarCS(Convert.ToInt32(this.lblIdVenta.Text));
                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                        frmModuloSalon.f3.limpiarMesas();
                        frmModuloSalon.f3.mostrarSalones();

                        this.Close();
                        frmVenta.f1.Close();
                        frmSepararCuenta.f1.Close();
                        frmModuloSalon.f3.tEstado.Enabled = true;

                    }

                }
                else
                {
                    MessageBox.Show(rpta);
                }
            }
            else
            {
                MessageBox.Show(rpta);
            }

        }

        public void PagoPorCuentaVentaRegistrada(int? idCliente, DataTable dtDetalle, decimal vuelto, Button btn, DataGridView dgv)
        {
            string rpta = "";
            string estadoVenta = "";
            if (this.lblBanderaComprobante.Text == "0" || this.lblBanderaComprobante.Text == "1")
            {
                string tipoCompr = "";
                if (this.lblBanderaComprobante.Text == "0")
                {
                    tipoCompr = "TICKET";
                }
                else
                {
                    tipoCompr = "BOLETA";
                }

                if (rbCreditoEmitido.Checked == true)
                {
                    formaPago = "CREDITO_E";
                    estadoVenta = "CREDITO-PENDIENTE_E";

                }
                else if (rbCredioNEm.Checked == true)
                {
                    formaPago = "CREDITO_NE";
                    estadoVenta = "CREDITO-PENDIENTE_NE";

                }
                else if (rbCortesia.Checked == true)
                {
                    formaPago = "CORTESIA";
                    estadoVenta = "CORTESIA";

                }
                else if (rbConsumoT.Checked == true)
                {

                    formaPago = "CONSUMO_TRABAJADOR";
                    estadoVenta = "PENDIENTE";

                }
                if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbConsumoT.Checked == true)
                {
                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA", formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim())
                                             , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                             Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                             dtDetalle, vuelto, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);

                }
                else if (rbCreditoEmitido.Checked == true)
                {
                    rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim())
                                            , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, tipoCompr, 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                            Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                            dtDetalle, vuelto, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);
                }
                else
                {
                    rpta = NVenta.InsertarPedidoPagadoCredCor(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                            , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, dtDetalle, 
                                                                            DateTime.Now, Convert.ToDecimal(lblTotal.Text), Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),
                                                                          lblObs.Text, "", "", "", lblClase.Text);
                }




                btn.Enabled = false;
                
            }
            else if (this.lblBanderaComprobante.Text == "2")
            {
                if (this.txtIdCliente.Text.Trim() == string.Empty || this.txtDocumento.Text.Trim().Length != 11)
                {
                    MessageBox.Show("Seleccione un cliente o ingrese un número de RUC válido");
                    return;
                }
                else
                {
                    if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbConsumoT.Checked == true)
                    {
                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "PAGADA",
                   formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim()), Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, "FACTURA",
                   1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA", Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                   dtDetalle, vuelto,DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text), "",
                   "", "", "", lblClase.Text);
                    }
                    else if (rbCreditoEmitido.Checked == true)
                    {
                        rpta = NVenta.InsertarPedidoPagado(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text.Trim())
                                                , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, "FACTURA", 1, Convert.ToDecimal(this.lblIgv.Text), "EMITIDA",
                                                Convert.ToDecimal(this.lblTotal.Text), efectivo, tarjeta, 00.00m,
                                                dtDetalle, vuelto, DateTime.Now, 00.00m, Convert.ToInt32(this.lblIdUsuario.Text),lblObs.Text, "", "", "", lblClase.Text);
                    }
                    else
                    {
                        rpta = NVenta.InsertarPedidoPagadoCredCor(idCliente, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, estadoVenta, formaPago, Convert.ToDecimal(this.lblDctoGeneral.Text)
                                                                                , Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "CS", 1, dtDetalle, 
                                                                                DateTime.Now, Convert.ToDecimal(lblTotal.Text), Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text),
                                                                                lblObs.Text, "", "", "", lblClase.Text);
                    }




                    btn.Enabled = false;
                }

            }
            if (rpta == "OK")
            {
                if (insertarCaja() == true)
                {
                    //MessageBox.Show("Se registró correctamente");
                    enviarFormaPago();
                    string tipoCompr = "";
                    if (this.lblBanderaComprobante.Text == "0")
                    {
                        tipoCompr = "TICKET";
                    }
                    else if (this.lblBanderaComprobante.Text == "1")
                    {
                        tipoCompr = "BOLETA";
                    }
                    else
                    {
                        tipoCompr = "FACTURA";
                    }

                    int count = 0;
                    DataTable dtCategoriaProducto = new DataTable();
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {

                        dtCategoriaProducto = NCategoria.MostrarCategoriaProducto(Convert.ToInt32(dgv.Rows[i].Cells[0].ToString()));
                        if (dtCategoriaProducto.Rows[0][1].ToString() == "BOCADITOS POR MENOR" || dtCategoriaProducto.Rows[0][1].ToString() == "PANES POR MENOR")
                        {
                            count = count + 1;
                        }

                    }
                    if (count != dgv.Rows.Count)
                    {
                        if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbCreditoEmitido.Checked == true || rbConsumoT.Checked == true)
                        {
                            NImprimir_Comprobante.imprimirCom(Convert.ToInt32(this.lblIdVenta.Text), tipoCompr, this.txtNombre.Text.Trim(), this.txtDireccion.Text.Trim(),
                                                                     this.txtDocumento.Text.Trim(), frmSepararCuenta.f1.lblTrabajador.Text, frmSepararCuenta.f1.lblSalon.Text,
                                                                     frmSepararCuenta.f1.lblMesa.Text, dgv, this.lblDescuento.Text, this.lblDctoGeneral.Text,
                                                                     this.lblSubTotal.Text, this.lblIgv.Text, this.lblTotal.Text, efectivo1, vuelto1, tarjeta1, formaPago1, modoProd, "00.00",
                                                                     "", NAliento.MensajeAliento());
                        }


                    }

                    if (rbEfectivo.Checked == true || rbTarjeta.Checked == true || rbMixto.Checked == true || rbCreditoEmitido.Checked == true || rbConsumoT.Checked == true)
                    {
                        this.Facturador(Convert.ToInt32(this.lblIdVenta.Text), dgv);
                    }

                    if (cbPaga.Checked)
                    {
                        NDescuentoTrabajador.Insertar(Convert.ToInt32(txtIdCliente.Text), Convert.ToDecimal(lblTotal.Text),
                            "CONSUMO_", DateTime.Now, "PENDIENTE", lblIdVenta.Text);
                    }
                    cbPaga.Checked = false;
                    cbPaga.Visible = false;

                    this.Limpiar();
                }
                lblObs.Text = "";
                btn.Enabled = false;
                cbTipoCliente.Enabled = false;
                cbTipoCliente.SelectedIndex = -1;
                btnCobro.Enabled = false;
                btnDescuentoTotal.Enabled = false;
                if (btn1.Enabled == false && btn2.Enabled == false && btn3.Enabled == false && btn4.Enabled == false && btn5.Enabled == false && btn6.Enabled == false)
                {
                    NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                    frmModuloSalon.f3.limpiarMesas();
                    frmModuloSalon.f3.mostrarSalones();

                    this.Close();
                    frmVenta.f1.Close();
                    frmSepararCuenta.f1.Close();
                    frmModuloSalon.f3.tEstado.Enabled = true;

                }

            }
            else
            {
                MessageBox.Show(rpta);
            }
        }

        private void Cobrar()
        {
            decimal efectivo, total, vuelto;
            if (this.txtEfectivo.Text.Trim() == "")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
            }
            total = Convert.ToDecimal(this.lblTotal.Text);

            if ((efectivo < total) && (rbEfectivo.Checked == true))
            {
                MessageBox.Show("El efectivo es insuficiente");
                this.txtEfectivo.Focus();
            }
            else
            {
                int? idCliente = null;
                if (this.txtIdCliente.Text != string.Empty)
                {
                    idCliente = Convert.ToInt32(this.txtIdCliente.Text);
                }
                else
                {
                    idCliente = null;
                }
                if (txtVuelto.Text == string.Empty)
                {
                    vuelto = 00.00m;
                }
                else
                {
                    vuelto = Convert.ToDecimal(this.txtVuelto.Text);
                }
                string rpta = "";
                if (this.lblIdVenta.Text == "0")
                {
                    if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                    {
                        MessageBox.Show("El campo efectivo es obligatorio");
                    }
                    else
                    {
                        if (verMontosPago() == true)
                        {
                            this.verFormaPago();
                            if (lblBanderaCuenta.Text == "1")
                            {
                                PagoPorCuentaVentaRegistrada(idCliente, frmSepararCuenta.f1.dtDetalle, vuelto, btn1, frmSepararCuenta.f1.dgCuenta1);
                            }
                            else if (lblBanderaCuenta.Text == "2")
                            {
                                PagoPorCuentaVentaRegistrada(idCliente, frmSepararCuenta.f1.dtDetalle2, vuelto, btn2, frmSepararCuenta.f1.dgCuenta2);

                            }
                            else if (lblBanderaCuenta.Text == "3")
                            {
                                PagoPorCuentaVentaRegistrada(idCliente, frmSepararCuenta.f1.dtDetalle3, vuelto, btn3, frmSepararCuenta.f1.dgCuenta3);

                            }
                            else if (lblBanderaCuenta.Text == "4")
                            {
                                PagoPorCuentaVentaRegistrada(idCliente, frmSepararCuenta.f1.dtDetalle4, vuelto, btn4, frmSepararCuenta.f1.dgCuenta4);
                            }
                            else if (lblBanderaCuenta.Text == "5")
                            {
                                PagoPorCuentaVentaRegistrada(idCliente, frmSepararCuenta.f1.dtDetalle5, vuelto, btn5, frmSepararCuenta.f1.dgCuenta5);
                            }
                            else if (lblBanderaCuenta.Text == "6")
                            {


                                PagoPorCuentaVentaRegistrada(idCliente, frmSepararCuenta.f1.dtDetalle6, vuelto, btn6, frmSepararCuenta.f1.dgCuenta6);
                            }
                        }
                    }
                }

                //AQUI OTRO
                else if (this.lblIdVenta.Text != "0")
                {
                    if (this.txtEfectivo.Text == "" && (this.rbEfectivo.Checked == true || this.rbMixto.Checked == true))
                    {
                        MessageBox.Show("El campo efectivo es obligatorio");
                    }
                    else
                    {
                        if (verMontosPago() == true)
                        {
                            this.verFormaPago();

                            if (lblBanderaCuenta.Text == "1")
                            {
                                PagoPorCuentaVentaSinRegistrar(idCliente, frmSepararCuenta.f1.dtDetalle, vuelto, btn1, frmSepararCuenta.f1.dgCuenta1);
                            }
                            else if (lblBanderaCuenta.Text == "2")
                            {
                                PagoPorCuentaVentaSinRegistrar(idCliente, frmSepararCuenta.f1.dtDetalle2, vuelto, btn2, frmSepararCuenta.f1.dgCuenta2);
                            }
                            else if (lblBanderaCuenta.Text == "3")
                            {
                                PagoPorCuentaVentaSinRegistrar(idCliente, frmSepararCuenta.f1.dtDetalle3, vuelto, btn3, frmSepararCuenta.f1.dgCuenta3);
                            }
                            else if (lblBanderaCuenta.Text == "4")
                            {
                                PagoPorCuentaVentaSinRegistrar(idCliente, frmSepararCuenta.f1.dtDetalle4, vuelto, btn4, frmSepararCuenta.f1.dgCuenta4);

                            }
                            else if (lblBanderaCuenta.Text == "5")
                            {

                                PagoPorCuentaVentaSinRegistrar(idCliente, frmSepararCuenta.f1.dtDetalle5, vuelto, btn5, frmSepararCuenta.f1.dgCuenta5);
                            }
                            else if (lblBanderaCuenta.Text == "6")
                            {

                                PagoPorCuentaVentaSinRegistrar(idCliente, frmSepararCuenta.f1.dtDetalle6, vuelto, btn6, frmSepararCuenta.f1.dgCuenta6);

                            }
                            NVenta.EditarVentaCS(Convert.ToInt32(this.lblIdVenta.Text));


                        }

                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = Convert.ToDecimal(lblTotal.Text);
            if (lblBanderaComprobante.Text == "1")
            {
                if (total > 700 && (txtIdCliente.Text.Length == 0 || txtDocumento.Text.Length == 0 || txtNombre.Text.Length == 0 || txtDireccion.Text.Length == 0))
                {
                    MessageBox.Show("El monto supera los 700 soles, complete todos los datos del cliente");
                    return;
                }
                else
                {
                    if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                        return;
                    }
                    else
                    {
                        Cobrar();
                    }

                }
            }
            else if (lblBanderaComprobante.Text == "0")
            {
                if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                    return;
                }
                else
                {
                    Cobrar();
                }

            }
            else if (lblBanderaComprobante.Text == "2")
            {
                if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                    return;
                }
                else
                {
                    Cobrar();
                }

            }
        }

        public void MontosNuevosDescuento()
        {
            decimal totalText = Convert.ToDecimal(this.lblTotal.Text) + Convert.ToDecimal(lblDctoGeneral.Text) + Convert.ToDecimal(lblDescuento.Text) -
                                Convert.ToDecimal(this.lblDescuento.Text);
            decimal totalSubTotalText = (totalText - Convert.ToDecimal(this.lblDctoGeneral.Text)) / 1.18m;

            this.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
            decimal totalIgvText = Convert.ToDecimal(lblTotal.Text) - totalSubTotalText;
            this.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
        }

        private void btnBoleta_Click(object sender, EventArgs e)
        {
            this.lblBanderaComprobante.Text = "1";
            this.btnBoleta.BackColor = Color.FromArgb(236, 236, 236);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
            this.btnTicket.BackColor = Color.FromArgb(205, 201, 201);
            MontosNuevosDescuento();
            this.dataListadoProducto.Select();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            this.lblBanderaComprobante.Text = "2";
            this.btnFactura.BackColor = Color.FromArgb(236, 236, 236);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);
            this.btnTicket.BackColor = Color.FromArgb(205, 201, 201);

            MontosNuevosDescuento();
            this.dataListadoProducto.Select();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaClientePago_Separado form = new frmVistaClientePago_Separado();
            form.ShowDialog();
            this.dataListadoProducto.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "1";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "1";
                this.dataListadoProducto.Select();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "2";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "2";
                this.dataListadoProducto.Select();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "3";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "3";
                this.dataListadoProducto.Select();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "4";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "4";
                this.dataListadoProducto.Select();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "5";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "5";
                this.dataListadoProducto.Select();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "6";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "6";
                this.dataListadoProducto.Select();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "7";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "7";
                this.dataListadoProducto.Select();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "8";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "8";
                this.dataListadoProducto.Select();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "9";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "9";
                this.dataListadoProducto.Select();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += ".";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += ".";
                this.dataListadoProducto.Select();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text += "0";
                mostrarTotales();
                this.dataListadoProducto.Select();
            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                this.txtTarjeta.Text += "0";
                this.dataListadoProducto.Select();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                if (this.txtEfectivo.Text.Length == 1)
                {
                    this.txtEfectivo.Text = string.Empty;
                    this.dataListadoProducto.Select();
                }
                else if (this.txtEfectivo.Text.Length != 0)
                {
                    this.txtEfectivo.Text = this.txtEfectivo.Text.Substring(0, this.txtEfectivo.Text.Length - 1);
                    this.dataListadoProducto.Select();

                }
                mostrarTotales();
                this.dataListadoProducto.Select();

            }
            else if (this.lblBanderaTexto.Text == "1")
            {
                if (this.txtTarjeta.Text.Length == 1)
                {
                    this.txtTarjeta.Text = string.Empty;
                    this.dataListadoProducto.Select();
                }
                else if (this.txtTarjeta.Text.Length != 0)
                {
                    this.txtTarjeta.Text = this.txtTarjeta.Text.Substring(0, this.txtTarjeta.Text.Length - 1);
                    this.dataListadoProducto.Select();
                }

            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtEfectivo.Text.Length; i++)
            {
                if (txtEfectivo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;

        }

        private void txtEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotales();
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtTarjeta.Text.Length; i++)
            {
                if (txtTarjeta.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescuentoTotal_Click(object sender, EventArgs e)
        {
            frmDescuentoTotal form = new frmDescuentoTotal();
            form.lblIdBandera.Text = "1";
            form.ShowDialog();
            this.dataListadoProducto.Select();
        }

        private bool verMontosPago()
        {
            if (rbEfectivo.Checked == true)
            {
                efectivo = Convert.ToDecimal(this.lblTotal.Text);
                tarjeta = 00.00m;
                return true;
            }
            else if (rbTarjeta.Checked == true)
            {
                efectivo = 00.00m;
                tarjeta = Convert.ToDecimal(this.lblTotal.Text);
                return true;
            }
            else if (rbMixto.Checked == true)
            {
                if (this.txtEfectivo.Text.Trim().Equals(string.Empty) || this.txtTarjeta.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Complete el campo efectivo y/o tarjeta");
                    return false;
                }
                else
                {
                    if (Convert.ToDecimal(this.lblTotal.Text) > (Convert.ToDecimal(this.txtEfectivo.Text) + Convert.ToDecimal(this.txtTarjeta.Text)))
                    {
                        MessageBox.Show("Los monto son menores al total, complete los campos");
                        return false;
                    }
                    else
                    {
                        efectivo = Convert.ToDecimal(this.txtEfectivo.Text.Trim());
                        tarjeta = Convert.ToDecimal(this.txtTarjeta.Text.Trim());
                        return true;
                    }

                }
            }
            return true;
        }

        private void verFormaPago()
        {
            if (rbEfectivo.Checked == true)
            {
                formaPago = rbEfectivo.Text;
            }
            else if (rbTarjeta.Checked == true)
            {
                formaPago = rbTarjeta.Text;
            }
            else if (rbMixto.Checked == true)
            {
                formaPago = rbMixto.Text;
            }
            else if (rbCreditoEmitido.Checked == true)
            {
                formaPago = "CREDITO_E";
            }
            else if (rbCredioNEm.Checked == true)
            {
                formaPago = "CREDITO_NE";
            }
            else if (rbCortesia.Checked == true)
            {
                formaPago = "CORTESIA";
            }
            else if(rbConsumoT.Checked== true)
            {
                formaPago = "CONSUMO_TRABAJADOR";
            }

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataTable dtClienteVenta;
                dtClienteVenta = NCliente.mostrarClienteVenta(this.txtDocumento.Text.Trim());
                if (dtClienteVenta.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe el cliente, regístrelo");
                }
                else
                {
                    this.txtIdCliente.Text = dtClienteVenta.Rows[0][0].ToString();
                    this.txtNombre.Text = dtClienteVenta.Rows[0][1].ToString();
                    this.txtDocumento.Text = dtClienteVenta.Rows[0][2].ToString();
                    this.txtDireccion.Text = dtClienteVenta.Rows[0][3].ToString();
                    this.lblClase.Text = dtClienteVenta.Rows[0][7].ToString();
                    if (lblClase.Text == "C")
                    {
                        string idTipoCliente;
                        idTipoCliente = dtClienteVenta.Rows[0][6].ToString();
                        if (idTipoCliente == "" || idTipoCliente == null)
                        {
                            cbTipoCliente.SelectedIndex = -1;
                        }
                        else
                        {
                            cbTipoCliente.SelectedValue = idTipoCliente;
                            cbTipoCliente.Enabled = true;
                        }
                        NDescuento.DescuentoClientes(idTipoCliente, Convert.ToDecimal(lblSubTotal.Text), Convert.ToDecimal(lblIgv.Text), 00.00m,
                                 Convert.ToDecimal(lblDescuento.Text), Convert.ToDecimal(lblDctoGeneral.Text), lblDctoGeneral, lblSubTotal, lblIgv, lblTotal,"C");
                        cbPaga.Visible = false;
                        cbPaga.Checked = false;
                        mostrarTotales();
                    }
                    else if (lblClase.Text == "T")
                    {
                        string idTipoCliente;
                        idTipoCliente = dtClienteVenta.Rows[0][8].ToString();
                        lblIdTipoCliente.Text = idTipoCliente;
                        NDescuento.DescuentoClientes(idTipoCliente, Convert.ToDecimal(lblSubTotal.Text), Convert.ToDecimal(lblIgv.Text), 00.00m,
                             Convert.ToDecimal(lblDescuento.Text), Convert.ToDecimal(lblDctoGeneral.Text), lblDctoGeneral, lblSubTotal, lblIgv, lblTotal, "T");
                        mostrarTotales();
                        cbTipoCliente.Enabled = false;
                        cbTipoCliente.SelectedIndex = -1;
                        cbPaga.Visible = true;
                        cbPaga.Checked = true;
                        
                    }
                    btnEditar.Enabled = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (lblBanderaComprobante.Text == "0")
            {
                MessageBox.Show("Seleccione BOLETA O FACTURA");
            }
            else
            {
                this.btnGuardar.Enabled = true;
                this.txtNombre.ReadOnly = false;
                this.txtDireccion.ReadOnly = false;
                this.cbTipoCliente.Enabled = true;
                this.txtNombre.Text = string.Empty;
                this.txtDireccion.Text = string.Empty;
                this.txtDocumento.Text = string.Empty;
                this.txtIdCliente.Text = string.Empty;
                this.cbTipoCliente.Enabled = true;
                this.txtDocumento.Focus();
                btnEditar.Enabled = false;
                isNuevo = true;
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = NTipoCliente.GuardarCliente(lblTotal.Text, "00.00", lblBanderaComprobante.Text, txtDocumento.Text, cbTipoCliente, isNuevo, txtNombre.Text,
               txtDireccion.Text, txtIdCliente.Text);
            if (isNuevo && rpta != null)
            {
                this.txtIdCliente.Text = rpta;
                this.txtNombre.ReadOnly = true;
                this.txtDireccion.ReadOnly = true;
                this.btnGuardar.Enabled = false;
                this.btnNuevo.Enabled = false;
                cbTipoCliente.Enabled = false;

            }
            else if (rpta == "OK")
            {
                this.txtNombre.ReadOnly = true;
                this.txtDireccion.ReadOnly = true;
                this.btnGuardar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
            }
        }

        private void rbConsumo_CheckedChanged(object sender, EventArgs e)
        {
            btnBoleta.Enabled = true;
            btnFactura.Enabled = true;
            btnTicket.Enabled = true;
            this.dataListadoProducto.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "10";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "20";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "50";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "100";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (this.lblBanderaTexto.Text == "0")
            {
                this.txtEfectivo.Text = "200";

                mostrarTotales();
                this.dataListadoProducto.Select();

            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            this.lblBanderaComprobante.Text = "0";
            this.btnTicket.BackColor = Color.FromArgb(236, 236, 236);
            this.btnFactura.BackColor = Color.FromArgb(205, 201, 201);
            this.btnBoleta.BackColor = Color.FromArgb(205, 201, 201);

            MontosNuevosDescuento();
            this.dataListadoProducto.Select();
        }

        private void rbDetallado_CheckedChanged(object sender, EventArgs e)
        {
            btnBoleta.Enabled = true;
            btnFactura.Enabled = true;
            btnTicket.Enabled = true;
            this.dataListadoProducto.Select();
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                decimal total = Convert.ToDecimal(lblTotal.Text);
                if (lblBanderaComprobante.Text == "1")
                {
                    if (total > 700 && (txtIdCliente.Text.Length == 0 || txtDocumento.Text.Length == 0 || txtNombre.Text.Length == 0 || txtDireccion.Text.Length == 0))
                    {
                        MessageBox.Show("El monto supera los 700 soles, complete todos los datos del cliente");
                        return;
                    }
                    else
                    {
                        if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                        {
                            MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                            return;
                        }
                        else
                        {
                            Cobrar();
                        }

                    }
                }
                else if (lblBanderaComprobante.Text == "0")
                {
                    if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                        return;
                    }
                    else
                    {
                        Cobrar();
                    }

                }
                else if (lblBanderaComprobante.Text == "2")
                {
                    if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                        return;
                    }
                    else
                    {
                        Cobrar();
                    }

                }

            }
        }

        private void dataListadoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                decimal total = Convert.ToDecimal(lblTotal.Text);
                if (lblBanderaComprobante.Text == "1")
                {
                    if (total > 700 && (txtIdCliente.Text.Length == 0 || txtDocumento.Text.Length == 0 || txtNombre.Text.Length == 0 || txtDireccion.Text.Length == 0))
                    {
                        MessageBox.Show("El monto supera los 700 soles, complete todos los datos del cliente");
                        return;
                    }
                    else
                    {
                        if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                        {
                            MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                            return;
                        }
                        else
                        {
                            Cobrar();
                        }

                    }
                }
                else if (lblBanderaComprobante.Text == "0")
                {
                    if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                        return;
                    }
                    else
                    {
                        Cobrar();
                    }

                }
                else if (lblBanderaComprobante.Text == "2")
                {
                    if ((rbCredioNEm.Checked == true || rbCortesia.Checked == true || rbCreditoEmitido.Checked == true) && txtIdCliente.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione o ingrese un nuevo cliente");
                        return;
                    }
                    else
                    {
                        Cobrar();
                    }

                }

            }
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
                btnGuardar.Enabled = true;
                if (lblClase.Text == "C")
                {
                    cbTipoCliente.Enabled = true;
                }

            }
        }

        private void rbCreditoEmitido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCreditoEmitido.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                mostrarTotales();
                btnTicket.Enabled = true;
                btnBoleta.Enabled = true;
                btnFactura.Enabled = true;
                lblBanderaComprobante.Text = "0";
                this.dataListadoProducto.Select();
            }
        }

        private void rbCredioNEm_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCredioNEm.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                txtTarjeta.Clear();
                txtEfectivo.Clear();
                txtVuelto.Clear();
                btnTicket.Enabled = false;
                btnBoleta.Enabled = false;
                btnFactura.Enabled = false;
                this.dataListadoProducto.Select();
                lblBanderaComprobante.Text = "0";
            }
        }

        private void rbCortesia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCortesia.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                txtTarjeta.Clear();
                txtEfectivo.Clear();
                txtVuelto.Clear();
                btnTicket.Enabled = false;
                btnBoleta.Enabled = false;
                btnFactura.Enabled = false;
                lblBanderaComprobante.Text = "0";
                this.dataListadoProducto.Select();
            }
        }

        private void cbPaga_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPaga.Checked == true)
            {
                groupBox3.Enabled = false;
                rbConsumoT.Checked = true;
                txtEfectivo.ReadOnly = true;
                txtEfectivo.Clear();
                txtTarjeta.Clear();
                txtVuelto.Clear();
                string idTipoCliente;
                idTipoCliente = "0";
                NDescuento.DescuentoClientes(idTipoCliente, Convert.ToDecimal(lblSubTotal.Text), Convert.ToDecimal(lblIgv.Text), 00.00m,
                    Convert.ToDecimal(lblDescuento.Text), Convert.ToDecimal(lblDctoGeneral.Text), lblDctoGeneral, lblSubTotal, lblIgv, lblTotal, "T");
                mostrarTotales();
            }
            else
            {
                groupBox3.Enabled = true;
                rbEfectivo.Checked = true;
                txtEfectivo.Clear();
                txtTarjeta.Clear();
                txtEfectivo.ReadOnly = false;
                NDescuento.DescuentoClientes(lblIdTipoCliente.Text, Convert.ToDecimal(lblSubTotal.Text), Convert.ToDecimal(lblIgv.Text), 00.00m,
                  Convert.ToDecimal(lblDescuento.Text), Convert.ToDecimal(lblDctoGeneral.Text), lblDctoGeneral, lblSubTotal, lblIgv, lblTotal, "T");
                mostrarTotales();
            }
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            frmObs frm = new frmObs();
            frm.lblBandera.Text = "3";
            frm.ShowDialog();
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = false;
                this.txtVuelto.ReadOnly = true;
                this.txtEfectivo.Focus();
                this.txtTarjeta.Text = "";
                mostrarTotales();
                btnTicket.Enabled = true;
                btnBoleta.Enabled = true;
                btnFactura.Enabled = true;
                this.dataListadoProducto.Select();
            }
        }

        private void rbMixto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMixto.Checked == true)
            {
                this.txtEfectivo.ReadOnly = false;
                this.txtTarjeta.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                this.txtEfectivo.Focus();
                mostrarTotales();
                btnTicket.Enabled = true;
                btnBoleta.Enabled = true;
                btnFactura.Enabled = true;
                this.dataListadoProducto.Select();
            }
        }

        private void txtEfectivo_Click(object sender, EventArgs e)
        {
            this.lblBanderaTexto.Text = "0";
        }

        private void txtTarjeta_Click(object sender, EventArgs e)
        {
            this.lblBanderaTexto.Text = "1";
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTarjeta.Checked == true)
            {
                this.txtTarjeta.ReadOnly = true;
                this.txtEfectivo.ReadOnly = true;
                this.txtVuelto.ReadOnly = true;
                mostrarTotales();
                btnTicket.Enabled = true;
                btnBoleta.Enabled = true;
                btnFactura.Enabled = true;
                this.dataListadoProducto.Select();
            }
        }
    }
}
