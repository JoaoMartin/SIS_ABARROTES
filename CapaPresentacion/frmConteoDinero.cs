using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmConteoDinero : Form
    {
        public frmConteoDinero()
        {
            InitializeComponent();
        }

        private void mostrarTotalBilletes()
        {
            decimal totalMoneda = 00.00m, totalArqueo = 00.00m, totalBilletes = 00.00m;
            decimal diezSoles, veinteSoles, cincuentaSoles, cienSoles, doscientosSoles;
            if (txtDiezSoles.Text.Trim() == string.Empty)
            {
                diezSoles = 00.00m;
                lblImpDiezSoles.Text = "00.00";
            }
            else
            {
                diezSoles = 10 * Convert.ToDecimal(this.txtDiezSoles.Text.Trim());
                lblImpDiezSoles.Text = (10 * Convert.ToDecimal(this.txtDiezSoles.Text.Trim())).ToString();
            }

            if (txtVeinteSoles.Text.Trim() == string.Empty)
            {
                veinteSoles = 00.00m;
                lblImpVeinteSoles.Text = "00.00";
            }
            else
            {
                veinteSoles = 20 * Convert.ToDecimal(this.txtVeinteSoles.Text.Trim());
                lblImpVeinteSoles.Text = (20 * Convert.ToDecimal(this.txtVeinteSoles.Text.Trim())).ToString();
            }

            if (txtCincuentaSoles.Text.Trim() == string.Empty)
            {
                cincuentaSoles = 00.00m;
                lblImpCincuentaSoles.Text = "00.00";
            }
            else
            {
                cincuentaSoles = 50 * Convert.ToDecimal(this.txtCincuentaSoles.Text.Trim());
                lblImpCincuentaSoles.Text = (50 * Convert.ToDecimal(this.txtCincuentaSoles.Text.Trim())).ToString();
            }

            if (txtCienSoles.Text.Trim() == string.Empty)
            {
                cienSoles = 00.00m;
                lblImpCienSoles.Text = "00.00";
            }
            else
            {
                cienSoles = 100 * Convert.ToDecimal(this.txtCienSoles.Text.Trim());
                lblImpCienSoles.Text = (100 * Convert.ToDecimal(this.txtCienSoles.Text.Trim())).ToString();
            }

            if (txtDoscientoSoles.Text.Trim() == string.Empty)
            {
                doscientosSoles = 00.00m;
                lblImpDoscientosSoles.Text = "00.00";
            }
            else
            {
                doscientosSoles = 200 * Convert.ToDecimal(this.txtDoscientoSoles.Text.Trim());
                lblImpDoscientosSoles.Text = (200 * Convert.ToDecimal(this.txtDoscientoSoles.Text.Trim())).ToString();
            }


            totalBilletes = diezSoles + veinteSoles + cincuentaSoles + cienSoles + doscientosSoles;
            totalMoneda = Convert.ToDecimal(this.lblTotalMonedas.Text);
            totalArqueo = totalBilletes + totalMoneda;
            this.lblTotalArqueo.Text = totalArqueo.ToString();

            this.lblTotalBilletes.Text = totalBilletes.ToString();

        }
        private void mostrarTotalMonedas()
        {
            decimal totalMoneda = 00.00m, totalArqueo = 00.00m, totalBilletes = 00.00m;
            decimal diezCen, veinteCen, cincuentaCen, unSol, dosSoles, cincoSoles;
            if (txtDiezCentimos.Text.Trim() == string.Empty)
            {
                diezCen = 00.00m;
                lblImpDiezC.Text = "00.00";
            }
            else
            {
                diezCen = 0.10m * Convert.ToDecimal(this.txtDiezCentimos.Text.Trim());
                lblImpDiezC.Text = (0.10m * Convert.ToDecimal(this.txtDiezCentimos.Text.Trim())).ToString();

            }

            if (txtVeinteCentimos.Text.Trim() == string.Empty)
            {
                veinteCen = 00.00m;
                lblImpVeinteC.Text = "00.00";
            }
            else
            {
                veinteCen = 0.20m * Convert.ToDecimal(this.txtVeinteCentimos.Text.Trim());
                lblImpVeinteC.Text = (0.20m * Convert.ToDecimal(this.txtVeinteCentimos.Text.Trim())).ToString();
            }

            if (txtCincuentaCentimos.Text.Trim() == string.Empty)
            {
                cincuentaCen = 00.00m;
                lblImpCincuentaC.Text = "00.00";
            }
            else
            {
                cincuentaCen = 0.50m * Convert.ToDecimal(this.txtCincuentaCentimos.Text.Trim());
                lblImpCincuentaC.Text = (0.50m * Convert.ToDecimal(this.txtCincuentaCentimos.Text.Trim())).ToString();
            }

            if (txtUnSol.Text.Trim() == string.Empty)
            {
                unSol = 00.00m;
                lblImpUnSol.Text = "00.00";
            }
            else
            {
                unSol = 1 * Convert.ToDecimal(this.txtUnSol.Text.Trim());
                lblImpUnSol.Text = (1 * Convert.ToDecimal(this.txtUnSol.Text.Trim())).ToString();
            }

            if (txtDosSoles.Text.Trim() == string.Empty)
            {
                dosSoles = 00.00m;
                lblImpDosSoles.Text = "00.00";
            }
            else
            {
                dosSoles = 2 * Convert.ToDecimal(this.txtDosSoles.Text.Trim());
                lblImpDosSoles.Text = (2 * Convert.ToDecimal(this.txtDosSoles.Text.Trim())).ToString();
            }

            if (txtCincoSoles.Text.Trim() == string.Empty)
            {
                cincoSoles = 00.00m;
            }
            else
            {
                cincoSoles = 5 * Convert.ToDecimal(this.txtCincoSoles.Text.Trim());
                lblImpCincoSoles.Text = (5 * Convert.ToDecimal(this.txtCincoSoles.Text.Trim())).ToString();
            }

            totalMoneda = diezCen + veinteCen + cincuentaCen + unSol + dosSoles + cincoSoles;
            totalBilletes = Convert.ToDecimal(this.lblTotalBilletes.Text);
            totalArqueo = totalBilletes + totalMoneda;
            this.lblTotalArqueo.Text = totalArqueo.ToString();

            this.lblTotalMonedas.Text = totalMoneda.ToString();

        }

        private void frmConteoDinero_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiezSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtDiezSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVeinteSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVeinteSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtCincuentaSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtCincuentaSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCienSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtCienSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDoscientoSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalBilletes();
        }

        private void txtDoscientoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDiezCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDiezCentimos_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtVeinteCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVeinteCentimos_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtCincuentaCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCincuentaCentimos_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtUnSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtUnSol_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtDosSoles_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDosSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDosSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void txtCincoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Escape))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCincoSoles_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarTotalMonedas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal montoTotal = Convert.ToDecimal(lblTotalArqueo.Text);
            if (montoTotal > 0)
            {
                frmCierreCaja.f1.txtMontoConteo.Text = montoTotal.ToString();
                this.Close();
            }
            
        }
    }
}
