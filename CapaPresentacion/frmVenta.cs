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
    public partial class frmVenta : Form
    {
        public string idMesa, nroMesa, idSalon, nombreSalon, idMesero, nombreMesero;
        public DataTable dtDetalle, dtDetalleVenta, dtDetalleMenu;
        public DataTable dtDetallePedido;
        private bool isNuevo = true;
        public DataRow row;
        private int cantFilas = 0;
        public decimal totalPagado = 0, subTotal = 0;
        public static frmVenta f1;

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void actualizarProducto()
        {
            if (this.txtCantidad.Text.Equals("0") || (this.txtCantidad.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Ingrese una cantidad mayor a cero");
            }
            else
            {
                decimal descuentoIndividual = 0;
                this.lblBanderaStock.Text = "3";
                int cantidad = Convert.ToInt32(this.txtCantidad.Text.Trim());
                descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                decimal subTotal = cantidad * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) + (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = this.txtCantidad.Text.Trim();
                this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                /*
                totalPagado = totalPagado + subTotal - importeActual;
                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                int cantidad20 = 0;

                for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                {
                    dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                    cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                    subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                }
                this.txtDescuento.Text = dctoTotProm.ToString();
                descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                //this.txtCantidad.Text = "1";
                this.lblPosicion.Text = string.Empty;
                this.lblBandera.Text = "0";
                this.dataListadoDetalle.ClearSelection();
                this.lblBandera.Focus();
                this.txtCantidad.Text = "";
                //this.txtCantidad.Text = "1";
            }

        }

        private void dataListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpProductos_Click(object sender, EventArgs e)
        {
         
        }

        private void btnDownProductos_Click(object sender, EventArgs e)
        {
           
        }

      

        private void dataListadoDetalle_Click(object sender, EventArgs e)
        {
            if (dataListadoDetalle.Rows.Count > 0)
            {
                this.lblPrecioUnitario.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Precio_Un"].Value);
                this.lblImporte.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Importe"].Value);
                this.lblNota.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Nota"].Value);
                this.lblDescuento.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Descuento"].Value);
                this.lblTipo.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Tipo"].Value);
                this.lblCantidadCom.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cant"].Value);
                this.lblIdProductoCom.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Cod"].Value);
                if (this.lblIdVenta.Text != "0" && this.dataListadoDetalle.Columns.Count == 12)
                {
                    this.lblidDetalle.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["idDetalleVenta"].Value);
                }

                this.lblTotalActual.Text = this.txtTotalPagado.Text;
                this.lblPosicion.Text = dataListadoDetalle.CurrentRow.Index.ToString();
                this.lblBandera.Text = "1";
                if (this.lblIdVenta.Text != "0")
                {
                    //this.txtCantidad.Enabled = false;
                    this.btnActualizarCantidad.Enabled = false;
                    this.button2.Enabled = false;
                    this.txtCantidad.Focus();
                    this.lblDescrProducto.Text = Convert.ToString(this.dataListadoDetalle.CurrentRow.Cells["Descripcion"].Value);
                    this.lblIndice.Text = dataListadoDetalle.CurrentRow.Index.ToString();
                }

                if (lblidDetalle.Text != "")
                {
                    dgvDetalleVentaMenu.DataSource = NDetalleVenta.mostrarDetalleVentaMenu(Convert.ToInt32(lblidDetalle.Text));
                }

                if (lblTipo.Text == "M")
                {
                    btnActualizarCantidad.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }



        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if ((int)e.KeyChar == (int)Keys.Enter && this.txtCantidad.Text != string.Empty && this.lblBandera.Text.Equals("1") && this.lblIdVenta.Text == "0")
            {
                actualizarProducto();
            }
            if ((int)e.KeyChar == (int)Keys.Escape)
            {
                this.txtCantidad.Text = "";
                this.dataListadoDetalle.ClearSelection();
                this.lblBandera.Focus();
            }
        }

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtCantidad.Text != string.Empty && this.lblBandera.Text.Equals("1"))
            {
                if (this.lblIdVenta.Text != "0")
                {

                }
                else
                {
                    actualizarProducto();
                    this.dataListadoDetalle.Select();
                }

            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista e ingrese una cantidad válida");
                this.dataListadoDetalle.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lblIdVenta.Text != "0")
                {
                    this.btnReservar.Enabled = false;
                    if (this.dataListadoDetalle.Rows.Count <= 0)
                    {
                        MensajeError("No existen filas en la tabla");
                        HabilitarUno();
                    }
                    else if (this.dataListadoDetalle.SelectedRows.Count > 0 && this.lblBandera.Text == "1")
                    {

                        DialogResult opcion;
                        string rpta = "";
                        opcion = MessageBox.Show("Está seguro de anular el pedido?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        int filasData = dtDetalleVenta.Rows.Count;
                        int filasDataA = dataListadoDetalle.Rows.Count;
                        int filaSel = Convert.ToInt32(this.lblPosicion.Text);
                        if (opcion == DialogResult.OK && lblidDetalle.Text != "")
                        //if (opcion == DialogResult.OK && filaSel <= filasData)
                        {
                            if (this.lblIdVenta.Text != "0" && this.lblBanderaDatatable.Text == "1")
                            {
                                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                decimal subTotal = Convert.ToDecimal(this.txtSubTotal.Text);
                                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;

                                DataRow row = this.dtDetalle.Rows[indiceFila];
                                dataCocina.Rows.Add(lblDescrProducto.Text, lblCantidadCom.Text,
                                  dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells[6].Value.ToString(),
                                  dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells["Tipo"].Value.ToString());
                                this.totalPagado = subTotal - Convert.ToDecimal(row["Importe"].ToString());

                                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();


                                this.dtDetalle.Rows.Remove(row);
                                this.dataListadoDetalle.DataSource = dtDetalle;


                                this.lblBandera.Text = "0";
                                this.dataListadoDetalle.ClearSelection();

                                if (this.lblidDetalle.Text != string.Empty || this.lblidDetalle.Text != "0")
                                {
                                    rpta = NDetalleVenta.Eliminar(Convert.ToInt32(this.lblidDetalle.Text));
                                    if (this.lblTipo.Text == "C")
                                    {
                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.lblIdProductoCom.Text));

                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(this.lblCantidadCom.Text) * -1)));
                                        }
                                    }


                                    /*DataTable dtDetalleVentaMenu = NVenta.mostrarDetalleVentaMenu(Convert.ToInt32(this.lblIdProductoCom.Text));
                                    for (int kl = 0; kl < dtDetalleVentaMenu.Rows.Count; kl++)
                                    {
                                        DataTable dtRecetaMenu = NReceta.Mostrar(Convert.ToInt32(dgvBanderaMenu.Rows[kl].Cells[0].Value.ToString()));
                                        decimal cantTotalMenu;
                                        if (dtRecetaMenu.Rows.Count > 0)
                                        {
                                            int cantInsumoMenu = Convert.ToInt32(dgvBanderaMenu.Rows[kl].Cells[2].Value.ToString());
                                            for (int rec = 0; rec < dtRecetaMenu.Rows.Count; rec++)
                                            {

                                                cantTotalMenu = cantInsumoMenu * Convert.ToDecimal(dtRecetaMenu.Rows[rec][3].ToString());
                                                rpta = NInsumo.EditarStock(Convert.ToInt32(dtRecetaMenu.Rows[rec][0].ToString()), ((-1) * cantTotalMenu));
                                            }

                                        }

                                    }*/
                                }
                                else
                                {
                                    rpta = "OK";
                                }

                                if (rpta.Equals("OK"))
                                {
                                    // this.MensajeOK("Se anuló correctamente el registro");
                                    //dataCocina.Rows.Add(lblDescrProducto.Text, lblCantidadCom.Text, "","");

                                    NImprimirComanda.imprimirCom(this.lblMesero.Text, "","", dataCocina, "COMANDA ANULACION");
                                    if (this.dataListadoDetalle.Rows.Count == 0)
                                    {
                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                    }

                                    this.dataListadoDetalle.Select();

                                }
                                else
                                {
                                    this.MensajeError(rpta);
                                    this.dataListadoDetalle.Select();
                                }
                                if (dataListadoDetalle.Rows.Count <= 0)
                                {
                                    HabilitarUno();
                                    this.dataListadoDetalle.Select();
                                }
                            }
                            //CAQUI
                            else
                            {
                                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                decimal subTotal = Convert.ToDecimal(this.txtSubTotal.Text);
                                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;

                                DataRow row = this.dtDetalleVenta.Rows[indiceFila];

                                dataCocina.Rows.Add(lblDescrProducto.Text, lblCantidadCom.Text,
                                       dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells["Nota"].Value.ToString(),
                                       dataListadoDetalle.Rows[Convert.ToInt32(lblPosicion.Text)].Cells["Tipo"].Value.ToString());

                                this.totalPagado = subTotal - Convert.ToDecimal(row["Importe"].ToString());

                                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();


                                this.dtDetalleVenta.Rows.Remove(row);
                                this.dataListadoDetalle.DataSource = dtDetalleVenta;


                                this.lblBandera.Text = "0";
                                this.dataListadoDetalle.ClearSelection();

                                if (this.lblidDetalle.Text != string.Empty)
                                {

                                    rpta = NDetalleVenta.Eliminar(Convert.ToInt32(this.lblidDetalle.Text));
                                    if (this.lblTipo.Text == "C")
                                    {
                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.lblIdProductoCom.Text));

                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(this.lblCantidadCom.Text) * -1)));
                                        }
                                    }

                                }
                                else
                                {
                                    rpta = "OK";
                                }

                                if (rpta.Equals("OK"))
                                {
                                    // this.MensajeOK("Se anuló correctamente el registro");

                                    NImprimirComanda.imprimirCom(this.lblMesero.Text,"","", dataCocina, "COMANDA ANULACION");
                                    if (this.dataListadoDetalle.Rows.Count == 0)
                                    {

                                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                                        frmModuloSalon.f3.limpiarMesas();
                                        frmModuloSalon.f3.mostrarSalones();
                                        this.Hide();
                                        this.dataListadoDetalle.Select();
                                    }
                                    this.Hide();
                                    this.dataListadoDetalle.Select();

                                }
                                else
                                {
                                    this.MensajeError(rpta);
                                    this.dataListadoDetalle.Select();
                                }
                                if (dataListadoDetalle.Rows.Count <= 0)
                                {
                                    HabilitarUno();
                                    this.dataListadoDetalle.Select();
                                }
                            }

                        }
                        else if (opcion == DialogResult.OK && lblidDetalle.Text == "")
                        {
                            if (this.dataListadoDetalle.Rows.Count <= 0)
                            {
                                MensajeError("No existen filas en la tabla");
                            }
                            else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                            {
                                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                this.lblBanderaStock.Text = "2";
                                int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                                DataRow row = this.dtDetalleVenta.Rows[indiceFila];

                                /* this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());
                                 this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                 this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                 this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();
         */


                                string tipo1 = dataListadoDetalle.Rows[indiceFila].Cells["Tipo"].Value.ToString();
                                string bandMen = dataListadoDetalle.Rows[indiceFila].Cells["Barra"].Value.ToString();
                                this.dtDetalleVenta.Rows.Remove(row);
                                this.dataListadoDetalle.ClearSelection();
                                this.lblBandera.Text = "0";
                                decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                int cantidad20 = 0;
                                string tipo;
                                for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                {
                                    dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                    cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                    subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                }
                                this.txtDescuento.Text = dctoTotProm.ToString();
                                descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                                this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                                if (dataListadoDetalle.Rows.Count <= 0)
                                {
                                    HabilitarUno();
                                }
                                if (dataListadoDetalle.Rows.Count <= 1)
                                {
                                    this.btnSeparar.Enabled = false;
                                }
                                else
                                {
                                    this.btnSeparar.Enabled = true;
                                }
                            }
                            else
                            {
                                MensajeError("Seleccione una fila");
                                this.dataListadoDetalle.Select();
                            }
                        }

                    }
                    else
                    {
                        MensajeError("Seleccione una fila");
                        this.dataListadoDetalle.Select();
                    }
                }
                else
                {
                    if (this.dataListadoDetalle.Rows.Count <= 0)
                    {
                        MensajeError("No existen filas en la tabla");
                        this.dataListadoDetalle.Select();
                        this.btnReservar.Enabled = false;
                    }
                    else if (this.dataListadoDetalle.SelectedRows.Count > 0)
                    {
                        decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        this.lblBanderaStock.Text = "2";
                        int indiceFila = this.dataListadoDetalle.CurrentRow.Index;
                        DataRow row = this.dtDetalle.Rows[indiceFila];

                        /* this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Importe"].ToString());
                         this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                         this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                         this.txtDescuento.Text = (descuentoTotal - Convert.ToDecimal(row["Descuento"].ToString())).ToString();
 */


                        string tipo1 = dataListadoDetalle.Rows[indiceFila].Cells["Tipo"].Value.ToString();
                        string bandMen = dataListadoDetalle.Rows[indiceFila].Cells["Barra"].Value.ToString();
                        this.dtDetalle.Rows.Remove(row);
                        this.dataListadoDetalle.ClearSelection();
                        this.lblBandera.Text = "0";
                        decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                        int cantidad20 = 0;
                        string tipo;
                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                        {
                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                            cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                            subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                        }
                        this.txtDescuento.Text = dctoTotProm.ToString();
                        descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                        this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                        if (dataListadoDetalle.Rows.Count <= 0)
                        {
                            HabilitarUno();
                        }
                        if (dataListadoDetalle.Rows.Count <= 1)
                        {
                            this.btnSeparar.Enabled = false;
                        }
                        else
                        {
                            this.btnSeparar.Enabled = true;
                        }
                        this.dataListadoDetalle.Select();
                        if (dataListadoDetalle.Rows.Count > 0)
                        {
                            this.btnReservar.Enabled = true;
                        }
                        else
                        {
                            this.btnReservar.Enabled = false;
                        }
                    }
                    else
                    {
                        MensajeError("Seleccione una fila");
                        this.dataListadoDetalle.Select();
                    }
                }




            }
            catch (Exception ex)
            {
                MensajeError("No hay filas para remover");
                this.dataListadoDetalle.Select();
            }
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            frmTeclado form = new frmTeclado();
            form.ShowDialog();
        }

        private void btnTermino_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {
                frmNota form = new frmNota();
                form.posicion = this.lblPosicion.Text;
                form.TxtNota.Text = this.lblNota.Text;
                form.ShowDialog();
                this.dataListadoDetalle.Select();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
                this.dataListadoDetalle.Select();
            }

        }

        private void btnQuitarNota_Click(object sender, EventArgs e)
        {
            if (this.lblBandera.Text.Equals("1"))
            {

                this.dataListadoDetalle[6, Convert.ToInt32(this.lblPosicion.Text)].Value = "";
                this.txtCantidad.Text = "1";
                this.lblBandera.Text = "0";
                this.dataListadoDetalle.ClearSelection();
            }
        }

        private void CambiarMesa()
        {
        }
        private void btnCambiarMesa_Click(object sender, EventArgs e)
        {
            CambiarMesa();
            this.dataListadoDetalle.Select();

        }

        private void Pedir()
        {
            if (this.dataListadoDetalle.Rows.Count == 0)
            {
                MensajeError("No hay productos en la lista");
            }
            else
            {
                try
                {
                    string rpta = "";

                    if (this.isNuevo)
                    {
                        if (this.lblIdVenta.Text != "0")
                        {
                            try
                            {
                                int cont = Convert.ToInt32(this.lblNroFilas.Text);
                                if (cont >= dataListadoDetalle.Rows.Count)
                                {
                                    rpta = "No hay pedidos que agregar";
                                    this.dataListadoDetalle.Select();
                                }
                                else
                                {
                                    for (int i = cont; i < dataListadoDetalle.Rows.Count; i++)
                                    {
                                        int idProducto = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                                        int cantidad = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                                        decimal prVenta = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                                        decimal desc = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                                        string barra = dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                                        string tipo = f1.dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                        rpta = NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(this.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                                            this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), tipo, barra, "Pedido");
                                        if (rpta == "OK")
                                        {
                                            // for (int p = cont; p < this.dataListadoDetalle.Rows.Count; p++)
                                            //{
                                            if (dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                            {

                                                DataTable dtDetalleProducto = new DataTable();
                                                dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                                int cantPedido = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                                for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                                {
                                                    int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                    int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());
                                                    rpta = NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                                }

                                            }



                                            //  }
                                        }


                                        if (dataListadoDetalle.Rows[i].Cells["Imprimir"].Value.ToString() == "Cocina")
                                        {
                                            string producto = dataListadoDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                                            int cantidad1 = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                            string nota = dataListadoDetalle.Rows[i].Cells["Nota"].Value.ToString();
                                            string tipo1 = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                            dataCocina.Rows.Add(producto, cantidad1, nota, tipo1);
                                        }
                                        else if (dataListadoDetalle.Rows[i].Cells["Imprimir"].Value.ToString() == "Bar")
                                        {
                                            string producto = dataListadoDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                                            int cantidad1 = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                            string nota = dataListadoDetalle.Rows[i].Cells["Nota"].Value.ToString();
                                            string tipo1 = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                            dataBar.Rows.Add(producto, cantidad1, nota, tipo1);
                                        }



                                    }


                                    if (dataCocina.Rows.Count > 0)
                                    {
                                        NImprimirComanda.imprimirCom(this.lblMesero.Text, "","", dataCocina, "COMANDA ADICIONAL");
                                    }
                                    if (dataBar.Rows.Count > 0)
                                    {
                                        NImprimirComanda.imprimirCom(this.lblMesero.Text,"","", dataBar, "COMANDA ADICIONAL");
                                    }
                                }
                                this.dataListadoDetalle.Select();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.StackTrace);
                                this.dataListadoDetalle.Select();
                            }

                        }
                        else
                        {
                            // rpta = NVenta.InsertarPedido(null, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "Pedido", "", 
                            //   Convert.ToDecimal(this.txtDescuento.Text), Convert.ToInt32(this.lblIdUsuario.Text), "", 1, dtDetalle);
                            rpta = NVenta.InsertarPedido(null, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "Pedido", "",
                                Convert.ToDecimal(this.txtDescuento.Text), Convert.ToInt32(idMesero), "", 1, dtDetalle,
                                DateTime.Now, 00.00m, Convert.ToInt32(this.idMesero), "", "", "", "","");
                            if (rpta == "OK")
                            {

                                for (int i = 0; i < this.dataListadoDetalle.Rows.Count; i++)
                                {
                                    if (dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                    {

                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                        int cantPedido = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());
                                            rpta = NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);

                                            DataTable dtRecetaC = NReceta.Mostrar(Convert.ToInt32(idProducto_Com));
                                            if (dtRecetaC.Rows.Count > 0)
                                            {
                                                int cantInsumo = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                                decimal cantTotal;
                                                for (int k = 0; k < dtRecetaC.Rows.Count; k++)
                                                {
                                                    cantTotal = cantInsumo * Convert.ToDecimal(dtRecetaC.Rows[k][3].ToString());
                                                    rpta = NInsumo.EditarStock(Convert.ToInt32(dtRecetaC.Rows[k][0].ToString()), cantTotal);
                                                }
                                            }
                                        }

                                    }

                                    if (dataListadoDetalle.Rows[i].Cells["Imprimir"].Value.ToString() == "Cocina")
                                    {
                                        string producto = dataListadoDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                                        int cantidad1 = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        string nota = dataListadoDetalle.Rows[i].Cells["Nota"].Value.ToString();
                                        string tipo = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                        dataCocina.Rows.Add(producto, cantidad1, nota, tipo);
                                    }
                                    else if (dataListadoDetalle.Rows[i].Cells["Imprimir"].Value.ToString() == "Bar")
                                    {
                                        string producto = dataListadoDetalle.Rows[i].Cells["Descripcion"].Value.ToString();
                                        int cantidad1 = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        string nota = dataListadoDetalle.Rows[i].Cells["Nota"].Value.ToString();
                                        string tipo = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                                        dataBar.Rows.Add(producto, cantidad1, nota, tipo);
                                    }

                                }
                                if (dataCocina.Rows.Count > 0)
                                {
                                    NImprimirComanda.imprimirCom(this.lblMesero.Text, "","", dataCocina, "");
                                }
                                if (dataBar.Rows.Count > 0)
                                {
                                    NImprimirComanda.imprimirCom(this.lblMesero.Text, "","", dataBar, "");
                                }

                                this.dataListadoDetalle.Select();
                            }
                            this.dataListadoDetalle.Select();

                        }
                        //rpta = NVenta.InsertarPedido(null, 1,12, DateTime.Now, "Pedido", "", Convert.ToDecimal(this.txtDescuento.Text), dtDetalle);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.isNuevo)
                        {
                            //this.MensajeOK("Se insertó correctamente");
                            frmModuloSalon.f3.limpiarMesas();
                            frmModuloSalon.f3.mostrarSalones();
                            frmModuloSalon.f3.tEstado.Enabled = true;
                            this.Hide();
                            this.dataListadoDetalle.Select();
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                        this.dataListadoDetalle.Select();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + ex.StackTrace);
                    this.dataListadoDetalle.Select();
                }
            }
        }
        private void btnPedido_Click(object sender, EventArgs e)
        {
            Pedir();

        }

        private void DctoIndividual()
        {
            if (this.lblBandera.Text == "1")
            {
                frmDescuentoProducto form = new frmDescuentoProducto();
                form.ShowDialog();
                this.dataListadoDetalle.Select();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
                this.dataListadoDetalle.Select();
            }
        }
        private void btnDctoProducto_Click(object sender, EventArgs e)
        {
            DctoIndividual();

        }

        private void btnDescuentoTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
        
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            if (this.lblIdVenta.Text != "0")
            {
                try
                {

                    for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                    {
                        int idDetalle = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[7].Value.ToString());
                        rpta = NDetalleVenta.EditarNotaPedido(idDetalle, this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[4].Value.ToString()));
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.isNuevo)
                        {
                            this.MensajeOK("Se guardó correctamente");
                            frmModuloSalon.f3.limpiarMesas();
                            frmModuloSalon.f3.mostrarSalones();
                            this.Hide();

                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "1";
            this.dataListadoDetalle.Select();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "2";
            this.dataListadoDetalle.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "3";
            this.dataListadoDetalle.Select();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "4";
            this.dataListadoDetalle.Select();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "5";
            this.dataListadoDetalle.Select();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "6";
            this.dataListadoDetalle.Select();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "7";
            this.dataListadoDetalle.Select();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "8";
            this.dataListadoDetalle.Select();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "9";
            this.dataListadoDetalle.Select();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += "0";
            this.dataListadoDetalle.Select();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.txtCantidad.Text += ".";
            this.dataListadoDetalle.Select();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (this.txtCantidad.Text.Length == 1)
            {
                this.txtCantidad.Text = string.Empty;
                this.dataListadoDetalle.Select();
            }
            else if (this.txtCantidad.Text.Length != 0)
            {
                this.txtCantidad.Text = this.txtCantidad.Text.Substring(0, this.txtCantidad.Text.Length - 1);
                this.dataListadoDetalle.Select();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lblBandera.Text.Equals("1"))
            {
                this.lblBanderaStock.Text = "0";
                decimal descuentoIndividual = 0;
                int cantidad = Convert.ToInt32(this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value);
                descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                decimal subTotal = (cantidad + 1) * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) + (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = (cantidad + 1).ToString();
                this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                /*
                totalPagado = totalPagado + subTotal - importeActual;
                this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                int cantidad20 = 0;

                for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                {
                    dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                    cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                    subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                }
                this.txtDescuento.Text = dctoTotProm.ToString();
                descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");

                this.lblPosicion.Text = string.Empty;
                this.lblBandera.Text = "0";
                this.dataListadoDetalle.ClearSelection();
                this.lblBandera.Focus();
                this.dataListadoDetalle.Select();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
                this.dataListadoDetalle.Select();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblBandera.Text.Equals("1"))
            {
                if (this.lblIdVenta.Text == "0")
                {
                    this.lblBanderaStock.Text = "1";
                    decimal descuentoIndividual = 0;
                    int cantidad = Convert.ToInt32(this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value);
                    if (cantidad > 1)
                    {
                        descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                        decimal subTotal = (cantidad - 1) * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                        decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                        decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) - (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                        this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = (cantidad - 1).ToString();
                        this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                        this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                        /*
                        totalPagado = totalPagado + subTotal - importeActual;
                        this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                        this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                        //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                        decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                        int cantidad20 = 0;

                        for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                        {
                            dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                            cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                            subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                        }
                        this.txtDescuento.Text = dctoTotProm.ToString();
                        descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                        this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                        this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                        //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                        this.lblPosicion.Text = string.Empty;
                        this.lblBandera.Text = "0";
                        this.dataListadoDetalle.ClearSelection();

                        this.lblBandera.Focus();
                        this.dataListadoDetalle.Select();
                    }
                    else
                    {
                        MessageBox.Show("Presione el botón QUITAR");
                        this.txtCantidad.Text = string.Empty;
                        this.dataListadoDetalle.Select();
                    }

                }
                else
                {
                    if (this.txtCantidad.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Ingrese la cantidad a disminuir");
                        this.dataListadoDetalle.Select();
                    }
                    else if (this.txtCantidad.Text.Trim().Equals(this.lblCantidadCom.Text))
                    {
                        MessageBox.Show("Ingrese una cantidad menor al pedido o presione el botón QUITAR");
                        this.dataListadoDetalle.Select();
                    }
                    else
                    {
                        decimal cantDism = Convert.ToDecimal(this.txtCantidad.Text);
                        decimal cantPedi = Convert.ToDecimal(this.lblCantidadCom.Text);
                        if (cantDism > cantPedi)
                        {
                            MessageBox.Show("Ingrese una cantidad menor al pedido");
                            this.dataListadoDetalle.Select();
                        }
                        else if (dataListadoDetalle.Rows.Count == 1 && cantPedi == cantDism)
                        {
                            MessageBox.Show("Presione el botón Quitar");
                            this.txtCantidad.Text = string.Empty;
                            this.dataListadoDetalle.Select();
                        }
                        else
                        {
                            DialogResult opcion;
                            string rpta = "";
                            opcion = MessageBox.Show("Está seguro de disminuir el pedido en " + txtCantidad.Text + "?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                            if (opcion == DialogResult.OK)
                            {
                                int indice = Convert.ToInt32(this.lblIndice.Text);
                                string producto = dataListadoDetalle.Rows[indice].Cells["Descripcion"].Value.ToString();
                                int cantidad1 = Convert.ToInt32(this.txtCantidad.Text);
                                string nota = dataListadoDetalle.Rows[indice].Cells["Nota"].Value.ToString();
                                dataCocina.Rows.Add(producto, cantidad1, nota);

                                this.lblBanderaStock.Text = "1";
                                decimal descuentoIndividual = 0;
                                int cantidad = Convert.ToInt32(this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value);
                                int cantDism1 = Convert.ToInt32(this.txtCantidad.Text.Trim());
                                if (cantidad > 1)
                                {
                                    descuentoIndividual = Convert.ToDecimal(this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value);
                                    decimal subTotal = (cantidad - cantDism1) * Convert.ToDecimal(this.lblPrecioUnitario.Text);
                                    decimal descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                    decimal importeActual = Convert.ToDecimal(this.lblImporte.Text);
                                    decimal nuevoDesc = Convert.ToDecimal(lblDescuento.Text) - (Convert.ToDecimal(lblDescuento.Text) / Convert.ToDecimal(lblCantidadCom.Text));
                                    this.dataListadoDetalle[2, Convert.ToInt32(this.lblPosicion.Text)].Value = (cantidad - cantDism1).ToString();
                                    this.dataListadoDetalle[4, Convert.ToInt32(this.lblPosicion.Text)].Value = nuevoDesc;
                                    this.dataListadoDetalle[5, Convert.ToInt32(this.lblPosicion.Text)].Value = subTotal - nuevoDesc;
                                    /*
                                    totalPagado = totalPagado + subTotal - importeActual;
                                    this.txtSubTotal.Text = totalPagado.ToString("#0.00#");
                                    this.txtTotalPagado.Text = (totalPagado - descuentoTotal).ToString("#0.00#");
                                    //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");*/
                                    decimal dctoTotProm = 0, subTotal20 = 0, total20 = 0;
                                    int cantidad20 = 0;

                                    for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
                                    {
                                        dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                                        cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                                        subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
                                    }
                                    this.txtDescuento.Text = dctoTotProm.ToString();
                                    descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
                                    this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
                                    this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
                                    //this.txtTotalPagado.Text = totalPagado.ToString("#0.00#");
                                    this.lblPosicion.Text = string.Empty;
                                    this.lblBandera.Text = "0";
                                    this.dataListadoDetalle.ClearSelection();
                                    if (this.lblidDetalle.Text != string.Empty)
                                    {
                                        //rpta = NDetalleVenta.Eliminar(Convert.ToInt32(this.lblidDetalle.Text));
                                        if (this.lblTipo.Text == "C")
                                        {
                                            DataTable dtDetalleProducto = new DataTable();
                                            dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.lblIdProductoCom.Text));

                                            for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                            {
                                                int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                                int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                                rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(this.txtCantidad.Text.Trim()) * -1)));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        rpta = "OK";
                                    }
                                    NDetalleVenta.EditarCantidadDetalleVenta(Convert.ToInt32(this.lblidDetalle.Text), Convert.ToInt32(this.txtCantidad.Text.Trim()), Convert.ToInt32(this.lblIdProductoCom.Text));
                                    this.lblBandera.Focus();
                                    this.Hide();
                                    this.dataListadoDetalle.Select();
                                }
                                else
                                {
                                    MessageBox.Show("Presione el botón QUITAR");
                                    this.dataListadoDetalle.Select();
                                }
                                NImprimirComanda.imprimirCom(this.lblMesero.Text, "","", dataCocina, "COMANDA ANULACIÓN");
                                this.dataListadoDetalle.Select();
                            }
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista");
                this.dataListadoDetalle.Select();
            }
        }

        private void SepararCuentas()
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Está seguro de separar las cuentas?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            string rpta = "";
            if (opcion == DialogResult.OK)
            {
                frmSepararCuenta form = new frmSepararCuenta();
                if (this.lblBanderaDatatable.Text == "0" && this.lblIdVenta.Text == "0")
                {
                    rpta = NVenta.InsertarPedidoSeparado(null, Convert.ToInt32(this.lblIdMesa.Text), DateTime.Now, "Pedido CS", "", Convert.ToDecimal(this.txtDescuento.Text),
                        Convert.ToInt32(idMesero), "CS", 1, dtDetalle,  DateTime.Now, 00.00m, Convert.ToInt32(idMesero), "", "", "", "","");

                    this.lblIdVenta.Text = rpta;
                    this.lblBanderaDatatable.Text = "1";
                    this.mostrarDetalleVentaCS();

                    //this.dataListadoDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
                    //mostrarDetalleVentaCS();
                    if (rpta != "")
                    {
                        for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                        {
                            if (dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                            {

                                DataTable dtDetalleProducto = new DataTable();
                                dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                int cantPedido = Convert.ToInt32(dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                {
                                    int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                    int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                    NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                }

                            }
                        }
                    }
                    form.mostrarDetalleVentaPorPedir(rpta);
                    this.lblNroFilas.Text = this.dataListadoDetalle.Rows.Count.ToString();
                }
                else if (this.lblBanderaDatatable.Text == "1" && this.lblIdVenta.Text != "0")
                {
                    if (lblBanderaNota.Text == "1" || lblBanderaDescuento.Text == "1")
                    {

                        for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                        {
                            if (this.dataListadoDetalle.Rows[i].Cells[7].Value.ToString() != "")
                            {
                                int idDetalle = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[7].Value.ToString());
                                rpta = NDetalleVenta.EditarNotaPedido(idDetalle, this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[4].Value.ToString()));


                            }

                        }

                    }

                    int cont = Convert.ToInt32(this.lblNroFilas.Text);
                    if (cont < dataListadoDetalle.Rows.Count)
                    {
                        for (int i = cont; i < dataListadoDetalle.Rows.Count; i++)
                        {
                            int idProducto = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                            int cantidad = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                            decimal prVenta = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                            decimal desc = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                            string barra = dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                            string tipo = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                            rpta = NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(this.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                                this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), tipo, barra, "Pedido");
                            if (rpta == "OK")
                            {
                                for (int p = cont; p < this.dataListadoDetalle.Rows.Count; p++)
                                {
                                    if (dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                    {

                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                        int cantPedido = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                        }

                                    }
                                }
                            }
                            form.mostrarDetalleVentaPorPedir(this.lblIdVenta.Text);
                        }
                        this.lblNroFilas.Text = Convert.ToString(this.dataListadoDetalle.Rows.Count);
                        this.mostrarDetalleVentaCS();
                    }
                    else
                    {
                        form.mostrarDetalleVentaPorPedir(this.lblIdVenta.Text);
                    }

                }
                else if (this.lblBanderaDatatable.Text == "0" && this.lblIdVenta.Text != "0")
                {
                    if (lblBanderaNota.Text == "1" || lblBanderaDescuento.Text == "1")
                    {
                        for (int i = 0; i < dataListadoDetalle.Rows.Count; i++)
                        {
                            if (this.dataListadoDetalle.Rows[i].Cells[7].Value.ToString() != "")
                            {
                                int idDetalle = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[7].Value.ToString());
                                rpta = NDetalleVenta.EditarNotaPedido(idDetalle, this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[4].Value.ToString()));
                            }

                        }
                    }
                    int cont = Convert.ToInt32(this.lblNroFilas.Text);
                    if (cont < dataListadoDetalle.Rows.Count)
                    {
                        for (int i = cont; i < dataListadoDetalle.Rows.Count; i++)
                        {
                            int idProducto = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[0].Value.ToString());
                            int cantidad = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells[2].Value.ToString());
                            decimal prVenta = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[3].Value.ToString());
                            decimal desc = Convert.ToDecimal(this.dataListadoDetalle.Rows[i].Cells[4].Value.ToString());
                            string barra = dataListadoDetalle.Rows[i].Cells["Barra"].Value.ToString();
                            string tipo = dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString();
                            rpta = NDetalleVenta.InsertarAdicPedido(Convert.ToInt32(this.lblIdVenta.Text), idProducto, cantidad, prVenta, desc,
                                this.dataListadoDetalle.Rows[i].Cells[6].Value.ToString(), tipo, barra,"Pedido");
                            if (rpta == "OK")
                            {
                                for (int p = cont; p < this.dataListadoDetalle.Rows.Count; p++)
                                {
                                    if (dataListadoDetalle.Rows[i].Cells["Tipo"].Value.ToString() == "C")
                                    {

                                        DataTable dtDetalleProducto = new DataTable();
                                        dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cod"].Value.ToString()));
                                        int cantPedido = Convert.ToInt32(this.dataListadoDetalle.Rows[i].Cells["Cant"].Value.ToString());
                                        for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                        {
                                            int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                            int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                            rpta = NProducto.EditarStock(idProducto_Com, cantRequerida * cantPedido);
                                        }

                                    }
                                }
                            }
                            form.mostrarDetalleVentaPorPedir(this.lblIdVenta.Text);
                        }
                        this.lblNroFilas.Text = Convert.ToString(this.dataListadoDetalle.Rows.Count);
                        this.mostrarDetalleVentaCS();
                    }
                    else
                    {
                        form.mostrarDetalleVentaPorPedir(this.lblIdVenta.Text);
                    }
                }


                form.lblIdMesa.Text = this.lblIdMesa.Text;
                form.lblIdTrabajador.Text = idMesero;
                form.lblIdVenta.Text = this.lblIdVenta.Text;
                form.lblDescuento_Ind.Text = this.txtDescuento.Text;
                form.lblSalon.Text = "";
                form.lblMesa.Text = "";
                form.lblTrabajador.Text = this.lblMesero.Text;
                form.lblIdUsuario.Text = idMesero;
                form.ShowDialog();
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {

            SepararCuentas();
        }

        private void Cobrar()
        {

            frmPagar form = new frmPagar();
            // form.lblSubTotal.Text = this.txtSubTotal.Text.Trim();
            decimal total = Convert.ToDecimal(this.txtTotalPagado.Text.Trim());
            decimal totalRed = NRedondeo.redondearParcial(total);
            //form.lblTotal.Text = this.txtTotalPagado.Text.Trim();
            form.lblTotal.Text = totalRed.ToString();
            form.lblIdVenta.Text = this.lblIdVenta.Text;
            form.lblIdMesa.Text = this.lblIdMesa.Text;
            form.lblDescuento.Text = this.txtDescuento.Text;
            form.lblIdTrabajador.Text = idMesero;
            form.lblIdUsuario.Text = idMesero;
            decimal subtotal1 = 00.00m;
            //subtotal1 = ((Convert.ToDecimal(this.txtSubTotal.Text) - Convert.ToDecimal(this.txtDescuento.Text)) / 1.18m);
             subtotal1 = ((totalRed) / 1.18m);
            form.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotal1));
           // decimal igvC = (Convert.ToDecimal(this.txtTotalPagado.Text) - subtotal1);
            decimal igvC = (totalRed - subtotal1);
            form.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igvC));
            form.lblBanderaCobro.Text = "0";
            form.ShowDialog();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Cobrar();
        }

        public frmVenta()
        {
            InitializeComponent();
            frmVenta.f1 = this;

        }

        private void DividirCuenta()
        {
            frmDividirCuenta form = new frmDividirCuenta();
            form.lblTrabajador.Text = this.lblMesero.Text;
            form.lblSalon.Text = "";
            form.lblMesa.Text = "";
            form.lblIdVenta.Text = this.lblIdVenta.Text;
            form.lblIdMesa.Text = this.lblIdMesa.Text;
            form.lblIdTrabajador.Text = idMesero;
            form.lblIdUsuario.Text = idMesero;
            form.Show();
            this.dataListadoDetalle.Select();
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            DividirCuenta();

        }

        private void crearTabla()
        {

            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Cod", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cant", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Un", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Importe", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Nota", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("idDetalleVenta", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Tipo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Imprimir", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Barra", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Estado", System.Type.GetType("System.String"));

            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }




        private void btnImprimirPreCuenta_Click(object sender, EventArgs e)
        {

         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void formatoTabla()
        {

            this.dataListadoDetalle.Columns[0].Visible = false;
            // this.dataListadoDetalle.Columns[4].Visible = false;
            this.dataListadoDetalle.Columns[6].Visible = false;
            this.dataListadoDetalle.Columns[7].Visible = false;
            this.dataListadoDetalle.Columns[8].Visible = false;
            this.dataListadoDetalle.Columns[9].Visible = false;

            //this.dataListadoDetalle.Columns[7].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            //this.dataListadoDetalle.Columns[0].Width = 50;
            this.dataListadoDetalle.Columns[1].Width = 300;
            this.dataListadoDetalle.Columns[2].Width = 40;
            this.dataListadoDetalle.Columns[3].Width = 70;
            this.dataListadoDetalle.Columns[4].Width = 65;
            this.dataListadoDetalle.Columns[5].Width = 115;

            this.dataListadoDetalle.RowTemplate.Height = 37;
            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListadoDetalle.Font = new Font("Roboto", 10);
            this.dataListadoDetalle.GridColor = SystemColors.ActiveBorder;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void formatoTablaConsulta()
        {

            this.dataListadoDetalle.Columns[0].Visible = false;
            //this.dataListadoDetalle.Columns[7].Visible = false;
            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDetalle.Columns[1].Width = 300;
            this.dataListadoDetalle.Columns[2].Width = 45;
            this.dataListadoDetalle.Columns[3].Width = 75;
            this.dataListadoDetalle.Columns[4].Width = 70;
            this.dataListadoDetalle.Columns[5].Width = 140;

            this.dataListadoDetalle.RowTemplate.Height = 37;
            this.dataListadoDetalle.ClearSelection();
            this.dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDetalle.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataListadoDetalle.Font = new Font("Robot", 10);
            this.dataListadoDetalle.GridColor = SystemColors.WindowFrame;

        }

      

        private void dataListadoDetalle_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void btnImprimirComanda_Click(object sender, EventArgs e)
        {
           
        }

        private void ComprobanteManual()
        {
            fmComprobanteManual form = new fmComprobanteManual();
            // form.lblSubTotal.Text = this.txtSubTotal.Text.Trim();
            form.lblTotal.Text = this.txtTotalPagado.Text.Trim();
            form.lblIdVenta.Text = this.lblIdVenta.Text;
            form.lblIdMesa.Text = this.lblIdMesa.Text;
            form.lblDescuento.Text = this.txtDescuento.Text;
            form.lblIdTrabajador.Text = this.lblIdTrabajador.Text;
            form.lblIdUsuario.Text = this.lblIdUsuario.Text;
            decimal subtotal1 = 00.00m;
            subtotal1 = ((Convert.ToDecimal(this.txtSubTotal.Text) - Convert.ToDecimal(this.txtDescuento.Text)) / 1.18m);
            form.lblSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(subtotal1));
            decimal igvC = (Convert.ToDecimal(this.txtTotalPagado.Text) - subtotal1);
            form.lblIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(igvC));
            form.txtEfectivo.Text = this.txtTotalPagado.Text;
            form.ShowDialog();
            this.dataListadoDetalle.Select();
        }
        private void button14_Click_1(object sender, EventArgs e)
        {

            ComprobanteManual();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataListadoDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                Pedir();
            }
            else if (e.KeyValue == (char)Keys.F2)
            {
                if (btnCobrar.Enabled == true)
                {
                    Cobrar();
                }
                else
                {
                    MessageBox.Show("No hay productos que cobrar");
                }

            }

            else if (e.KeyValue == (char)Keys.F3)
            {
                if (btnSeparar.Enabled == true)
                {
                    SepararCuentas();
                }


            }
            else if (e.KeyValue == (char)Keys.F4)
            {
                if (btnManual.Enabled == true)
                {
                    ComprobanteManual();
                }


            }
            else if (e.KeyValue == (char)Keys.F5)
            {
                if (btnReservar.Enabled == true)
                {
                    Reservar();
                }


            }
            else if (e.KeyValue == (char)Keys.F6)
            {
                if (btnDividir.Enabled == true)
                {
                   DividirCuenta();
                }


            }

        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                Pedir();
            }
            else if (e.KeyValue == (char)Keys.F2)
            {
                if (btnCobrar.Enabled == true)
                {
                    Cobrar();
                }
                else
                {
                    MessageBox.Show("No hay productos que cobrar");
                }

            }

            else if (e.KeyValue == (char)Keys.F3)
            {
                if (btnSeparar.Enabled == true)
                {
                    SepararCuentas();
                }


            }
            else if (e.KeyValue == (char)Keys.F4)
            {
                if (btnManual.Enabled == true)
                {
                    ComprobanteManual();
                }


            }
            else if (e.KeyValue == (char)Keys.F5)
            {
                if (btnReservar.Enabled == true)
                {
                    Reservar();
                }


            }
            else if (e.KeyValue == (char)Keys.F6)
            {
                if (btnDividir.Enabled == true)
                {
                    DividirCuenta();
                }


            }
        }

        private void txtSubTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                Pedir();
            }
            else if (e.KeyValue == (char)Keys.F2)
            {
                if (btnCobrar.Enabled == true)
                {
                    Cobrar();
                }
                else
                {
                    MessageBox.Show("No hay productos que cobrar");
                }

            }

            else if (e.KeyValue == (char)Keys.F3)
            {
                if (btnSeparar.Enabled == true)
                {
                    SepararCuentas();
                }


            }
            else if (e.KeyValue == (char)Keys.F4)
            {
                if (btnManual.Enabled == true)
                {
                    ComprobanteManual();
                }


            }
            else if (e.KeyValue == (char)Keys.F5)
            {
                if (btnReservar.Enabled == true)
                {
                    Reservar();
                }


            }
            else if (e.KeyValue == (char)Keys.F6)
            {
                if (btnDividir.Enabled == true)
                {
                    DividirCuenta();
                }


            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                Pedir();
            }
            else if (e.KeyValue == (char)Keys.F2)
            {
                if (btnCobrar.Enabled == true)
                {
                    Cobrar();
                }
                else
                {
                    MessageBox.Show("No hay productos que cobrar");
                }

            }

            else if (e.KeyValue == (char)Keys.F3)
            {
                if (btnSeparar.Enabled == true)
                {
                    SepararCuentas();
                }


            }
            else if (e.KeyValue == (char)Keys.F4)
            {
                if (btnManual.Enabled == true)
                {
                    ComprobanteManual();
                }


            }
            else if (e.KeyValue == (char)Keys.F5)
            {
                if (btnReservar.Enabled == true)
                {
                    Reservar();
                }


            }
            else if (e.KeyValue == (char)Keys.F6)
            {
                if (btnDividir.Enabled == true)
                {
                    DividirCuenta();
                }


            }
        }

        private void txtTotalPagado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
            {
                Pedir();
            }
            else if (e.KeyValue == (char)Keys.F2)
            {
                if (btnCobrar.Enabled == true)
                {
                    Cobrar();
                }
                else
                {
                    MessageBox.Show("No hay productos que cobrar");
                }

            }

            else if (e.KeyValue == (char)Keys.F3)
            {
                if (btnSeparar.Enabled == true)
                {
                    SepararCuentas();
                }


            }
            else if (e.KeyValue == (char)Keys.F4)
            {
                if (btnManual.Enabled == true)
                {
                    ComprobanteManual();
                }


            }
            else if (e.KeyValue == (char)Keys.F5)
            {
                if (btnReservar.Enabled == true)
                {
                    Reservar();
                }


            }
            else if (e.KeyValue == (char)Keys.F6)
            {
                if (btnDividir.Enabled == true)
                {
                    DividirCuenta();
                }


            }
        }

        private void Reservar()
        {
            frmReservar frm = new frmReservar();
            frm.ShowDialog();
            this.dataListadoDetalle.Select();
        }
        private void button14_Click_2(object sender, EventArgs e)
        {
            Reservar();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (this.lblIdVenta.Text != "0")
            {
                this.btnReservar.Enabled = false;
                if (this.dataListadoDetalle.Rows.Count <= 0)
                {
                    MensajeError("No existen filas en la tabla");
                    HabilitarUno();
                }
                else
                {

                    DialogResult opcion;
                    string rpta = "";
                    opcion = MessageBox.Show("Está seguro de anular la mesa?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion == DialogResult.OK)
                    //if (opcion == DialogResult.OK && filaSel <= filasData)
                    {
                        for (int i = 0; i < dtDetalleVenta.Rows.Count; i++)
                        {

                            rpta = NDetalleVenta.Eliminar(Convert.ToInt32(dtDetalleVenta.Rows[i][7].ToString()));
                            if (dtDetalleVenta.Rows[i][8].ToString() == "C")
                            {
                                DataTable dtDetalleProducto = new DataTable();
                                dtDetalleProducto = NProducto.mostrarDetalleProducto_Venta(Convert.ToInt32(dtDetalleVenta.Rows[i][0].ToString()));

                                for (int j = 0; j < dtDetalleProducto.Rows.Count; j++)
                                {
                                    int idProducto_Com = Convert.ToInt32(dtDetalleProducto.Rows[j][0].ToString());
                                    int cantRequerida = Convert.ToInt32(dtDetalleProducto.Rows[j][1].ToString());

                                    rpta = NProducto.EditarStock(idProducto_Com, ((cantRequerida * Convert.ToInt32(dtDetalleVenta.Rows[i][2].ToString()) * -1)));

                                }
                            }

                            dataCocina.Rows.Add(dtDetalleVenta.Rows[i][1].ToString(), dtDetalleVenta.Rows[i][2].ToString(), "", "");


                        }
                        NVenta.EliminarCS(Convert.ToInt32(lblIdVenta.Text));
                        NImprimirComanda.imprimirCom(this.lblMesero.Text, "","", dataCocina, "COMANDA ANULACION");


                        NMesa.EditarEstadoMesa(Convert.ToInt32(this.lblIdMesa.Text), "Libre");
                        frmModuloSalon.f3.limpiarMesas();
                        frmModuloSalon.f3.mostrarSalones();
                        this.Close();


                    }
                }
            }
        }

        private void frmVenta_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void mostrarProductos(string idCategoria)
        {
            

        }

        public void sumaTotal()
        {
            decimal dctoTotProm = 0, subTotal20 = 0;
            int cantidad20 = 0;
            decimal descuentoTotal;

            for (int p = 0; p < dataListadoDetalle.Rows.Count; p++)
            {
                dctoTotProm = dctoTotProm + Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Descuento"].Value.ToString());
                cantidad20 = Convert.ToInt32(dataListadoDetalle.Rows[p].Cells["Cant"].Value.ToString());
                subTotal20 = subTotal20 + (cantidad20 * Convert.ToDecimal(dataListadoDetalle.Rows[p].Cells["Precio_Un"].Value.ToString()));
            }
            this.txtDescuento.Text = dctoTotProm.ToString();
            descuentoTotal = Convert.ToDecimal(this.txtDescuento.Text);
            this.txtSubTotal.Text = subTotal20.ToString("#0.00#");
            this.txtTotalPagado.Text = (subTotal20 - descuentoTotal).ToString("#0.00#");
        }

        private void limpiarProductos()
        {

        }

        private void mostrarDetalleVenta()
        {
            this.dataListadoDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
            this.dtDetalleVenta = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
            this.formatoTablaConsulta();
        }

        private void mostrarDetalleVentaCS()
        {
            this.dataListadoDetalle.DataSource = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
            this.dtDetalle = NVenta.mostrarDetalleVenta(Convert.ToInt32(this.lblIdVenta.Text));
            this.formatoTablaConsulta();
        }

        private void mostrarDetallePedido()
        {

            dtDetallePedido = NVenta.mostrarDetallePedido(Convert.ToInt32(this.lblIdVenta.Text));
            this.lblIdMesa.Text = dtDetallePedido.Rows[0]["idMesa"].ToString();
           // this.lblMesa.Text = dtDetallePedido.Rows[0]["nomMesa"].ToString();
            this.lblIdSalon.Text = dtDetallePedido.Rows[0]["idSalon"].ToString();
           // this.lblSalon.Text = dtDetallePedido.Rows[0]["nomSalon"].ToString();
            //this.lblMesero.Text = dtDetallePedido.Rows[0]["Mesero"].ToString();
            this.lblIdTrabajador.Text = dtDetallePedido.Rows[0]["idTrabajador"].ToString();
            this.txtDescuento.Text = dtDetallePedido.Rows[0]["descuentoVenta"].ToString();

            decimal sumaTotal = 0, sumaDescuento = 0, subTotal1;
            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
            {
                sumaTotal += (decimal)row.Cells[5].Value;
                sumaDescuento += (decimal)row.Cells[4].Value;
            }
            subTotal1 = sumaTotal + sumaDescuento;
            subTotal = subTotal1;
            this.txtSubTotal.Text = subTotal1.ToString();
            totalPagado = totalPagado + subTotal1 - sumaDescuento;
            this.txtDescuento.Text = sumaDescuento.ToString();
            this.txtTotalPagado.Text = totalPagado.ToString();
            this.lblNroFilas.Text = this.dataListadoDetalle.Rows.Count.ToString();
        }

        private void HabilitarUno()
        {
            this.btnPedido.Enabled = false;
            this.btnCobrar.Enabled = false;
            this.btnDividir.Enabled = false;
            this.btnSeparar.Enabled = false;
            this.btnDctoProducto.Enabled = false;
            this.btnManual.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.btnReservar.Enabled = false;
        }


        private void Deshabilitado()
        {
            this.btnPedido.Visible = false;
            this.btnCobrar.Visible = false;
            this.btnDctoProducto.Visible = false;
            this.btnSeparar.Visible = false;
            this.btnDividir.Visible = false;
            this.btnManual.Visible = false;
        }
        private void ValidarAcceso()
        {
            this.Deshabilitado();
            DataTable dtIdTipoTrabajador = NTipoTrabajador.MostrarIdTipoUsuario(Convert.ToInt32(this.lblIdUsuario.Text));
            DataTable dtNivel = NNivel.Mostrar(Convert.ToInt32(dtIdTipoTrabajador.Rows[0][0].ToString()));
            for (int i = 0; i < dtNivel.Rows.Count; i++)
            {
                if (dtNivel.Rows[i][2].ToString() == "PVenta_Pedido")
                {
                    this.btnPedido.Visible = true;
                }

                if (dtNivel.Rows[i][2].ToString() == "Venta-Dcto Individual")
                {
                    this.btnDctoProducto.Visible = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "PVenta_Dividir Cuenta")
                {
                    this.btnDividir.Visible = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "PVenta_Separar Cuenta")
                {
                    this.btnSeparar.Visible = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "PVenta_Cobrar")
                {
                    this.btnCobrar.Visible = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "PVenta_ComprobanteManual")
                {
                    this.btnManual.Visible = true;
                }
                if (dtNivel.Rows[i][2].ToString() == "PVenta_Reservar")
                {
                    this.btnManual.Visible = true;
                }

            }
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.lblMesero.Text = nombreMesero;
            this.crearTabla();
            this.ValidarAcceso();
            this.formatoTabla();
            if (this.lblIdVenta.Text != "0")
            {
                mostrarDetalleVenta();
                mostrarDetallePedido();
                this.btnActualizarCantidad.Enabled = false;
                this.dataListadoDetalle.Select();
                this.btnLimpiar.Enabled = true;
                this.btnReservar.Enabled = false;
                cantFilas = dataListadoDetalle.Rows.Count;
                
            }
            else
            {
                HabilitarUno();
                this.btnLimpiar.Enabled = false;
                this.dataListadoDetalle.Select();
            }


        }
    }
}
