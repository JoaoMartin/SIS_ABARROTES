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
    public partial class frmAnularComprobante : Form
    {
        public frmAnularComprobante()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.lblBandera.Text == "0")
            {
                string rpta = "";
                rpta = NComprobante.AnularComprobante(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));
                if (rpta == "OK")
                {
                    DataTable dtDetalle = new DataTable();
                    dtDetalle = NDetalleVenta.mostrarIDDetalleVenra((Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text)));
                    for (int i = 0; i < dtDetalle.Rows.Count; i++)
                    {
                        NDetalleVenta.ActualizarStockProd_Anulada(Convert.ToInt32(dtDetalle.Rows[i][0].ToString()));
                        DataTable dtCompuesto = new DataTable();
                        dtCompuesto = NVenta.mostrarDetalleVenta(Convert.ToInt32(frmMostrarVentas.f1.lblIdVenta.Text));

                        if (dtCompuesto.Rows[i][8].ToString() == "C")
                        {
                            DataTable dtDetalleProducto = new DataTable();
                            dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(dtCompuesto.Rows[i][0].ToString()));

                            for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                            {
                                int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(dtCompuesto.Rows[i][2].ToString()) * -1)));

                                DataTable dtRecetaC = NReceta.Mostrar(Convert.ToInt32(idProducto_Com));
                                if (dtRecetaC.Rows.Count > 0)
                                {
                                    int cantInsumo = Convert.ToInt32(dtCompuesto.Rows[i][2].ToString());
                                    decimal cantTotal;
                                    for (int k = 0; k < dtRecetaC.Rows.Count; k++)
                                    {
                                        cantTotal = cantInsumo * Convert.ToDecimal(dtRecetaC.Rows[k][3].ToString());
                                        rpta = NInsumo.EditarStock(Convert.ToInt32(dtRecetaC.Rows[k][0].ToString()), cantTotal * -1);
                                    }
                                }
                            }
                        }

                        DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(dtDetalle.Rows[i][0].ToString()));

                        if (dtReceta.Rows.Count > 0)
                        {
                            int cantInsumo = Convert.ToInt32(dtDetalle.Rows[i][2].ToString());
                            decimal cantTotal;
                            for (int k = 0; k < dtReceta.Rows.Count; k++)
                            {
                                cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), ((-1) * cantTotal));
                            }

                        }
                    }



                    rpta = NComprobanteAnulado.Insertar(Convert.ToInt32(frmMostrarVentas.f1.lblIdComprobante.Text), DateTime.Now, frmMostrarVentas.f1.lblSerie.Text,
                        frmMostrarVentas.f1.lblNumero.Text, "ANULADA", this.txtDescripcion.Text.Trim());
                    if (rpta == "OK")
                    {
                        string tipoDoc;
                        DataTable dtCorrelativo = NComprobanteAnulado.mostrarCorrelativo(DateTime.Now);
                        DateTime fechaGen = Convert.ToDateTime(frmMostrarVentas.f1.lblFechaGene.Text);
                        string fechaConv = fechaGen.ToString("yyyy-MM-dd");
                        if (frmMostrarVentas.f1.lblComprobante.Text == "FACTURA")
                        {
                            tipoDoc = "01";
                        }
                        else
                        {
                            tipoDoc = "03";
                        }
                        if (cbOrigen.Checked == true)
                        {
                            NCaja.Insertar(Convert.ToInt32(frmMostrarVentas.f1.lblIdUsuario.Text), "1", "EGRESO", Convert.ToDecimal(frmMostrarVentas.f1.lblEfectivo.Text), this.txtDescripcion.Text.Trim(), "EFECTIVO");

                        }
                        NFacturador.bajaComprobante(frmMostrarVentas.f1.lblComprobante.Text, fechaConv, DateTime.Now.ToString("yyyy-MM-dd"), tipoDoc, frmMostrarVentas.f1.lblNumero.Text,
                            this.txtDescripcion.Text, dtCorrelativo.Rows[0][0].ToString());
                        MessageBox.Show("Se anuló correctamente");
                        frmMostrarVentas.f1.MostrarTodo();
                        frmMostrarVentas.f1.btnEliminar.Enabled = false;
                        frmMostrarVentas.f1.btnCancelar.Enabled = false;
                        this.Close();
                    }
                }
            }
            else if (lblBandera.Text == "5")
            {
                string rpta = "";
                if (frmCreditosPendientes.f1.lblBanderaAnulacion.Text == "1")
                {
                    rpta = NComprobante.AnularComprobante(Convert.ToInt32(frmCreditosPendientes.f1.lblIdVenta.Text));
                }
                else if (frmCreditosPendientes.f1.lblBanderaAnulacion.Text == "0")
                {
                    rpta = "OK";
                }

                if (rpta == "OK")
                {
                    DataTable dtDetalle = new DataTable();
                    dtDetalle = NDetalleVenta.mostrarIDDetalleVenra((Convert.ToInt32(frmCreditosPendientes.f1.lblIdVenta.Text)));
                    for (int i = 0; i < dtDetalle.Rows.Count; i++)
                    {
                        NDetalleVenta.ActualizarStockProd_Anulada(Convert.ToInt32(dtDetalle.Rows[i][0].ToString()));
                        DataTable dtCompuesto = new DataTable();
                        dtCompuesto = NVenta.mostrarDetalleVenta(Convert.ToInt32(frmCreditosPendientes.f1.lblIdVenta.Text));

                        if (dtCompuesto.Rows[i][8].ToString() == "C")
                        {
                            DataTable dtDetalleProducto = new DataTable();
                            dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(dtCompuesto.Rows[i][0].ToString()));

                            for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                            {
                                int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(dtCompuesto.Rows[i][2].ToString()) * -1)));

                                DataTable dtRecetaC = NReceta.Mostrar(Convert.ToInt32(idProducto_Com));
                                if (dtRecetaC.Rows.Count > 0)
                                {
                                    int cantInsumo = Convert.ToInt32(dtCompuesto.Rows[i][2].ToString());
                                    decimal cantTotal;
                                    for (int k = 0; k < dtRecetaC.Rows.Count; k++)
                                    {
                                        cantTotal = cantInsumo * Convert.ToDecimal(dtRecetaC.Rows[k][3].ToString());
                                        rpta = NInsumo.EditarStock(Convert.ToInt32(dtRecetaC.Rows[k][0].ToString()), cantTotal * -1);
                                    }
                                }
                            }
                        }

                        DataTable dtReceta = NReceta.Mostrar(Convert.ToInt32(dtDetalle.Rows[i][0].ToString()));

                        if (dtReceta.Rows.Count > 0)
                        {
                            int cantInsumo = Convert.ToInt32(dtDetalle.Rows[i][2].ToString());
                            decimal cantTotal;
                            for (int k = 0; k < dtReceta.Rows.Count; k++)
                            {
                                cantTotal = cantInsumo * Convert.ToDecimal(dtReceta.Rows[k][3].ToString());
                                NInsumo.EditarStock(Convert.ToInt32(dtReceta.Rows[k][0].ToString()), ((-1) * cantTotal));
                            }

                        }
                    }

                    if (frmCreditosPendientes.f1.lblBanderaAnulacion.Text == "1")
                    {
                        rpta = NComprobanteAnulado.Insertar(Convert.ToInt32(frmCreditosPendientes.f1.lblIdComprobante.Text), DateTime.Now, "1",
                            frmCreditosPendientes.f1.lblCorrelativo.Text, "ANULADA", this.txtDescripcion.Text.Trim());
                        if (rpta == "OK")
                        {
                            string tipoDoc;
                            DataTable dtCorrelativo = NComprobanteAnulado.mostrarCorrelativo(DateTime.Now);
                            DateTime fechaGen = Convert.ToDateTime(frmCreditosPendientes.f1.lblFechaCompr.Text);
                            string fechaConv = fechaGen.ToString("yyyy-MM-dd");
                            if (frmCreditosPendientes.f1.lblTipoComprobante.Text == "FACTURA")
                            {
                                tipoDoc = "01";
                            }
                            else
                            {
                                tipoDoc = "03";
                            }
                            if (cbOrigen.Checked == true)
                            {
                                NCaja.Insertar(Convert.ToInt32(1), "1", "EGRESO", Convert.ToDecimal(frmCreditosPendientes.f1.lblEfectivo.Text), this.txtDescripcion.Text.Trim(), "EFECTIVO");

                            }
                            NFacturador.bajaComprobante(frmCreditosPendientes.f1.lblTipoComprobante.Text, fechaConv, DateTime.Now.ToString("yyyy-MM-dd"), tipoDoc,
                                frmCreditosPendientes.f1.lblCorrelativo.Text,this.txtDescripcion.Text, dtCorrelativo.Rows[0][0].ToString());
                            MessageBox.Show("Se anuló correctamente");
                            frmCreditosPendientes.f1.Mostrar();
                            frmCreditosPendientes.f1.btnAnular.Enabled = false;
                            frmCreditosPendientes.f1.btnCobrar.Enabled = false;
                            this.Close();
                        }
                    }


                }
            }
            else
            {
                string rpta = "";
                rpta = NComprobante.AnularComprobante(Convert.ToInt32(lblIdCompro.Text));
                if (rpta == "OK")
                {
                    rpta = NComprobanteAnulado.Insertar(Convert.ToInt32(lblIdCompro.Text), DateTime.Now, this.lblSerie.Text,
                        this.lblNro.Text, "ANULADA", this.txtDescripcion.Text.Trim());
                    if (rpta == "OK")
                    {
                        string tipoDoc;
                        DataTable dtCorrelativo = NComprobanteAnulado.mostrarCorrelativo(DateTime.Now);
                        DateTime fechaGen = Convert.ToDateTime(lblFecha.Text);
                        string fechaConv = fechaGen.ToString("yyyy-MM-dd");
                        if (this.lblComprobante.Text == "Factura")
                        {
                            tipoDoc = "01";
                        }
                        else
                        {
                            tipoDoc = "03";
                        }
                        NFacturador.bajaComprobante(this.lblComprobante.Text, fechaConv, DateTime.Now.ToString("yyyy-MM-dd"), tipoDoc, lblNro.Text,
                            this.txtDescripcion.Text, dtCorrelativo.Rows[0][0].ToString());
                        NDelivery.Eliminar(Convert.ToInt32(frmCobroDelivery.f1.lblIdVenta.Text));
                        NImprimirComanda.imprimirCom(frmCobroDelivery.f1.lblRepartidos.Text, "DELIVERY", "DELIVERY", frmCobroDelivery.f1.dataCocina, "COMANDA ADICIONAL");
                        MessageBox.Show("Se anuló correctamente");
                        this.Hide();
                        frmCobroDelivery.f1.Hide();
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblComprobante_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void lblNro_Click(object sender, EventArgs e)
        {

        }

        private void lblSerie_Click(object sender, EventArgs e)
        {

        }

        private void lblIdCompro_Click(object sender, EventArgs e)
        {

        }

        private void lblBandera_Click(object sender, EventArgs e)
        {

        }

        private void cbOrigen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
