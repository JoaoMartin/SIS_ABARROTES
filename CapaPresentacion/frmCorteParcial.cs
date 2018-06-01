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
    public partial class frmCorteParcial : Form
    {
        public frmCorteParcial()
        {
            InitializeComponent();
        }

        public void ingresosEfectivo()
        {
            DataTable dt;
            dt = NTurno.MostrarIngresosEfectivoTurno(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0]["Monto"].ToString() == "")
            {
                this.txtVentaEfectivo.Text = "00.00";
            }
            else
            {
                this.txtVentaEfectivo.Text = dt.Rows[0]["Monto"].ToString();
                this.txtVentaEfectivo.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(this.txtVentaEfectivo.Text));
            }

            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
        }

        public void ingresosTarjeta()
        {
            DataTable dt;
            dt = NTurno.MostrarIngresosTarjetaTurno(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0]["Monto"].ToString() == "")
            {
                this.txtTarjeta.Text = "00.00";
            }
            else
            {
                this.txtTarjeta.Text = dt.Rows[0]["Monto"].ToString();
                this.txtTarjeta.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(this.txtTarjeta.Text));
            }
        }


        public void total()
        {
            decimal ventasEfectivo = 00.00m;
            decimal ventasTarjeta = 00.00m;
            decimal otrosIngresos = 00.00m;
            decimal egresos = 00.00m;
            decimal totalVentas = 00.00m;
            decimal totalParcial = 00.00m;
            decimal totalCaja = 00.00m;
            decimal montoApertura = 00.00m;
            decimal montoDeposito = 00.00m;
            decimal montoDejado = 00.00m;

            montoDejado = Convert.ToDecimal(txtMontoDejado.Text);
            ventasEfectivo = Convert.ToDecimal(txtVentaEfectivo.Text.Trim());
            ventasTarjeta = Convert.ToDecimal(txtTarjeta.Text.Trim());
            otrosIngresos = Convert.ToDecimal(txtOtrosIngresos.Text.Trim());
            egresos = Convert.ToDecimal(txtEgresos.Text);
            montoApertura = Convert.ToDecimal(lblMontoInicial.Text);
            totalParcial = ventasEfectivo + otrosIngresos - egresos;
            totalCaja = totalParcial + montoApertura;
            totalVentas = ventasEfectivo + ventasTarjeta;
            montoDeposito = totalCaja - montoDejado;

            lblTotalParcial.Text = totalParcial.ToString();
            lblTotalCaja.Text = totalCaja.ToString();
            txtMontoConteo.Text = totalCaja.ToString();
            lblTotalVentas.Text = totalVentas.ToString();
            txtMontoDeposito.Text = montoDeposito.ToString();

        }

        //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
        // dt.Rows[0]["Estado"].ToString();

        public void egresos()
        {
            DataTable dt;
            dt = NTurno.MostrarEgresosTurno(1, Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if (dt.Rows[0]["Monto"].ToString() == "")
            {
                this.txtEgresos.Text = "00.00";
            }
            else
            {
                this.txtEgresos.Text = dt.Rows[0]["Monto"].ToString();
                this.txtEgresos.Text = string.Format("{0:#,##0.00}", Convert.ToDouble(this.txtEgresos.Text));
            }

            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
        }

        public void ventas()
        {
            DataTable dt;
            dt = NTurno.MostrarVentasTurno(Convert.ToDateTime(this.lblfechaApert.Text), DateTime.Now);
            if(dt.Rows[0][0].ToString() != "")
            {
                this.txtEnEfectivo.Text = dt.Rows[0][0].ToString();
                this.txtVentaEfectivo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                this.txtEnEfectivo.Text= "00.00";
                this.txtVentaEfectivo.Text = "00.00";
            }

            if (dt.Rows[1][0].ToString() != "")
            {
                this.txtTarjeta.Text = dt.Rows[1][0].ToString();
            }
            else
            {
                this.txtTarjeta.Text = "00.00";
            }

            if (dt.Rows[2][0].ToString() != "")
            {
                this.txtOtrosIngresos.Text = dt.Rows[2][0].ToString();
            }
            else
            {
                this.txtOtrosIngresos.Text = "00.00";
            }

            if (dt.Rows[3][0].ToString() != "")
            {
                this.lblNroVentas.Text = dt.Rows[3][0].ToString();
            }
            else
            {
                this.lblNroVentas.Text = "0";
            }
            if (dt.Rows[4][0].ToString() != "")
            {
                this.txtEgresos.Text = dt.Rows[4][0].ToString();
            }
            else
            {
                this.txtEgresos.Text = "00.00";
            }
            if (dt.Rows[5][0].ToString() != "")
            {
                this.txtCredito.Text = dt.Rows[5][0].ToString();
            }
            else
            {
                this.txtCredito.Text = "00.00";
            }
            if (dt.Rows[6][0].ToString() != "")
            {
                this.txtConsumoTrab.Text = dt.Rows[6][0].ToString();
            }
            else
            {
                this.txtConsumoTrab.Text = "00.00";
            }
            if (dt.Rows[7][0].ToString() != "")
            {
                this.txtCortesia.Text = dt.Rows[7][0].ToString();
            }
            else
            {
                this.txtCortesia.Text = "00.00";
            }
            //cuenta_usuario.idCliente(txtUsuario.Text, txtContraseña.Text);
            // dt.Rows[0]["Estado"].ToString();
            this.total();
        }

        private void frmCierreTurno_Load(object sender, EventArgs e)
        {
           this.Top = 0;
            this.Left = 0;
            this.ventas();
            this.label1.Select();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            //rpta = NCaja_A.Insertar(Convert.ToInt32(this.lblidUsuario.Text), "Caja 1", DateTime.Now, Convert.ToDecimal(this.lblTotalEfectivo.Text), "Cerrada", 1);
            //  rpta = NTurno.Insertar(Convert.ToInt32(this.lblidUsuario.Text),DateTime.Now,)
            //rpta = NTurno.Insertar(Convert.ToInt32(this.lblidUsuario.Text), DateTime.Now, Convert.ToDecimal(this.txtVentaEfectivo.Text), "Cerrado", Convert.ToDecimal(this.txtTarjeta.Text),
            //  Convert.ToDecimal(this.txtEgresos.Text));
            DateTime? fechaApertura = null;
            decimal montoDejado = 00.00m, montoDeposito = 00.00m, montoConteo = 00.00m, ventaCredito = 00.00m, ventaCortesia = 00.00m, ventaConsumoTr = 00.00m;
            if (txtMontoDejado.Text.Trim().Length == 0)
            {
                montoDejado = 00.00m;
            }else
            {
                montoDejado = Convert.ToDecimal(txtMontoDejado.Text.Trim());
            }
            if (txtMontoDeposito.Text.Trim().Length == 0)
            {
                montoDeposito = 00.00m;
            }
            else
            {
                montoDeposito = Convert.ToDecimal(txtMontoDeposito.Text.Trim());
            }
            if (txtMontoConteo.Text.Trim().Length == 0)
            {
                montoConteo = 00.00m;
            }
            else
            {
                montoConteo = Convert.ToDecimal(txtMontoConteo.Text.Trim());
            }

            if (txtCredito.Text.Trim().Length == 0)
            {
                ventaCredito = 00.00m;
            }
            else
            {
                ventaCredito = Convert.ToDecimal(txtCredito.Text.Trim());
            }

            if (txtCortesia.Text.Trim().Length == 0)
            {
                ventaCortesia = 00.00m;
            }
            else
            {
                ventaCortesia = Convert.ToDecimal(txtCortesia.Text.Trim());
            }

            if (txtConsumoTrab.Text.Trim().Length == 0)
            {
                ventaConsumoTr = 00.00m;
            }
            else
            {
                ventaConsumoTr = Convert.ToDecimal(txtConsumoTrab.Text.Trim());
            }

            rpta = NCaja_A.Insertar(Convert.ToInt32(this.lblidUsuario.Text), "Caja 1", DateTime.Now, Convert.ToDecimal(lblTotalCaja.Text), "Corte Caja", 1,
                Convert.ToDecimal(txtTarjeta.Text),Convert.ToDecimal(txtEgresos.Text), Convert.ToDecimal(txtOtrosIngresos.Text), Convert.ToDecimal(txtVentaEfectivo.Text), 
                Convert.ToDecimal(lblMontoInicial.Text),fechaApertura,montoDejado,montoDeposito,montoConteo, ventaCredito,ventaCortesia,ventaConsumoTr);
            if (rpta != "OK")
            {
                MessageBox.Show("Se registró correctamente");
                //Application.Exit();
                NImprimirCierreTurno.imprimirCom(lblTrabajador.Text, lblfechaApert.Text, DateTime.Now, lblMontoInicial.Text, txtVentaEfectivo.Text, txtOtrosIngresos.Text, txtEgresos.Text,
                    lblTotalCaja.Text, lblNroVentas.Text, txtTarjeta.Text, lblTotalVentas.Text,txtCredito.Text,txtConsumoTrab.Text,txtCortesia.Text);
                this.Hide();
                frmPrincipal.f1.ValidarAcceso();
                frmPrincipal.f1.ValidarControlesR();
                
            }
            else
            {
                MessageBox.Show(rpta);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMovimientoCaja frm = new frmMovimientoCaja();
            frm.lblFechaApertura.Text = this.lblfechaApert.Text;
            frm.ShowDialog();
        }

        private void frmCierreTurno_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmCierreTurno_FormClosed(object sender, FormClosedEventArgs e)
        {
     
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtMontoDejado_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtMontoDejado.Text.Length; i++)
            {
                if (txtMontoDejado.Text[i] == '.')
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

        private void txtMontoDeposito_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtMontoDeposito.Text.Length; i++)
            {
                if (txtMontoDeposito.Text[i] == '.')
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

        private void txtMontoConteo_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtMontoConteo.Text.Length; i++)
            {
                if (txtMontoConteo.Text[i] == '.')
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
    }
}
