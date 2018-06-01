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
    public partial class frmPagoTrabajador : Form
    {
        public static frmPagoTrabajador f1;
        public frmPagoTrabajador()
        {
            InitializeComponent();
            frmPagoTrabajador.f1 = this;
        }

        private void frmPagoTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            txtNroDoc.Select();
        }

        private void Montos()
        {
            decimal diasTrabajados = Convert.ToDecimal(txtDiasTrabajados.Text);
            int factor = Convert.ToInt32(cbFactor.SelectedItem.ToString());
            decimal sueldo = Convert.ToDecimal(txtSueldo.Text);

            decimal sueldoBruto = (sueldo * diasTrabajados) / factor;
            decimal sueldoBrutoR = NRedondeo.redondearParcial(sueldoBruto);
            txtMontoBruto.Text = sueldoBrutoR.ToString("#0.00#");

            decimal totalDctos = Convert.ToDecimal(txtDctos.Text);
            decimal totalAdelantos = Convert.ToDecimal(txtAdelantos.Text);
            decimal pagoTotal = 00.00m;
            decimal otrosDctos = 00.00m, horasExtras = 00.00m;
            if (txtOtrosDctos.Text.Trim().Length == 0)
            {
                otrosDctos = 00.00m;
            } else
            {
                otrosDctos = Convert.ToDecimal(txtOtrosDctos.Text);
            }

            if (txtPagosExtras.Text.Trim().Length == 0)
            {
                horasExtras = 00.00m;
            } else
            {
                horasExtras = Convert.ToDecimal(txtPagosExtras.Text);
            }

            pagoTotal = sueldoBrutoR + horasExtras - otrosDctos - totalAdelantos - totalDctos;
            txtMontoPagado.Text = pagoTotal.ToString("#0.00#");

        }

        private void MontosPagados()
        {
            decimal totalDctos = Convert.ToDecimal(txtDctos.Text);
            decimal totalAdelantos = Convert.ToDecimal(txtAdelantos.Text);
            decimal pagoTotal = 00.00m;
            decimal otrosDctos = 00.00m, horasExtras = 00.00m;
            decimal montoBruto = 00.00m;
            if (txtMontoBruto.Text.Trim().Length != 0)
            {
                montoBruto = Convert.ToDecimal(txtMontoBruto.Text);
            } else
            {
                montoBruto = 00.00m;
            }
            if (txtOtrosDctos.Text.Trim().Length == 0)
            {
                otrosDctos = 00.00m;
            }
            else
            {
                otrosDctos = Convert.ToDecimal(txtOtrosDctos.Text);
            }

            if (txtPagosExtras.Text.Trim().Length == 0)
            {
                horasExtras = 00.00m;
            }
            else
            {
                horasExtras = Convert.ToDecimal(txtPagosExtras.Text);
            }

            pagoTotal = montoBruto + horasExtras - otrosDctos - totalAdelantos - totalDctos;
            txtMontoPagado.Text = pagoTotal.ToString("#0.00#");
        }
        public bool Validar()
        {
            DataTable dtValidar= NPagoTrabajador.Validar(Convert.ToInt32(lblIdTrabajador.Text), DateTime.Now.Month.ToString());
            if (dtValidar.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataTable dtTrabajador;
                dtTrabajador = NTrabajador.mostrarTrabajadorDni(txtNroDoc.Text);
                if (dtTrabajador.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe un trabajador con el nro de doc ingresado");
                }
                else
                {
                    decimal sueldo = 00.00m;
                    if (Convert.ToString(dtTrabajador.Rows[0][2].ToString()) == "" || Convert.ToString(dtTrabajador.Rows[0][2].ToString()) == null)
                    {
                        sueldo = 00.00m;
                    }
                    else
                    {
                        sueldo = Convert.ToDecimal(Convert.ToString(dtTrabajador.Rows[0][2].ToString()));
                    }
                    if (sueldo <= 0)
                    {
                        MessageBox.Show("Ingrese un sueldo mayor a 0");
                        cbFactor.SelectedIndex = -1;
                        return;

                    }
                    else
                    {
                        lblIdTrabajador.Text = Convert.ToString(dtTrabajador.Rows[0][0].ToString());
                        if (Validar() == true)
                        {
                            txtTrabajador.Text = Convert.ToString(dtTrabajador.Rows[0][1].ToString());
                            txtSueldo.Text = Convert.ToString(dtTrabajador.Rows[0][2].ToString());
                            lblDNI.Text = Convert.ToString(dtTrabajador.Rows[0][3].ToString());
                            cbFactor.SelectedIndex = 1;
                            mostrarDctos();
                            mostrarAdelantos();
                            txtDiasTrabajados.Select();
                            btnGuardar.Enabled = true;
                        }else
                        {
                            MessageBox.Show("Ya se registró un pago a este traajador en este mes");
                            txtNroDoc.Focus();
                            btnGuardar.Enabled = false;

                        }
                      
                    }

                }
            }

        }

        private void ocultarColumnasDcto()
        {
            this.dataListadoDcto.Columns[0].Visible = false;
            //this.dataListadoDcto.Columns[1].Visible = false;
            this.dataListadoDcto.Columns[5].Visible = false;
            this.dataListadoDcto.Columns[4].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListadoDcto.Columns[1].Width = 135;
            this.dataListadoDcto.Columns[2].Width = 400;
            this.dataListadoDcto.Columns[3].Width = 150;
            //this.dataListadoDcto.Columns[4].Width = 120;

            this.dataListadoDcto.ClearSelection();
            this.dataListadoDcto.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoDcto.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoDcto.DefaultCellStyle.Font = new Font("Roboto", 8);
            this.dataListadoDcto.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListadoDcto.GridColor = SystemColors.ActiveBorder;
            this.dataListadoDcto.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            decimal totalDcto = 00.00m;
            for (int i = 0; i < dataListadoDcto.Rows.Count; i++)
            {
                totalDcto = totalDcto + Convert.ToDecimal(dataListadoDcto.Rows[i].Cells[3].Value);
            }
            this.txtDctos.Text = totalDcto.ToString();


        }

        private void ocultarColumnasAdelanto()
        {
            this.dataListadoAdelanto.Columns[0].Visible = false;
            //this.dataListadoAdelanto.Columns[1].Visible = false;
            //this.dataListado.Columns[4].Visible = false;
            this.dataListadoAdelanto.Columns[4].Visible = false;
            this.dataListadoAdelanto.Columns[3].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListadoAdelanto.Columns[2].Width = 240;
            this.dataListadoAdelanto.Columns[1].Width = 240;
            //this.dataListadoAdelanto.Columns[3].Width = 150;

            this.dataListadoAdelanto.ClearSelection();
            this.dataListadoAdelanto.ColumnHeadersDefaultCellStyle.Font = new Font(dataListadoAdelanto.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListadoAdelanto.DefaultCellStyle.Font = new Font("Roboto", 8);
            this.dataListadoAdelanto.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListadoAdelanto.GridColor = SystemColors.ActiveBorder;
            this.dataListadoAdelanto.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            decimal totalAdelanto = 00.00m;
            for (int i = 0; i < dataListadoAdelanto.Rows.Count; i++)
            {
                totalAdelanto = totalAdelanto + Convert.ToDecimal(dataListadoAdelanto.Rows[i].Cells[2].Value);
            }
            this.txtAdelantos.Text = totalAdelanto.ToString();

        }
        public void mostrarDctos()
        {
            this.dataListadoDcto.DataSource = NDescuentoTrabajador.Mostrar(Convert.ToInt32(lblIdTrabajador.Text), DateTime.Now.Month.ToString());
            if (dataListadoDcto.Rows.Count > 0)
            {
                ocultarColumnasDcto();
                dataListadoDcto.Visible = true;
            } else
            {
                txtDctos.Text = "00.00";
            }
        }

        public void mostrarAdelantos()
        {
            this.dataListadoAdelanto.DataSource = NAdelanto.Mostrar(Convert.ToInt32(lblIdTrabajador.Text), DateTime.Now.Month.ToString());
            if (dataListadoAdelanto.Rows.Count > 0)
            {
                ocultarColumnasAdelanto();
                dataListadoAdelanto.Visible = true;
            } else
            {
                txtAdelantos.Text = "00.00";
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaTrabajador frm = new frmVistaTrabajador();
            frm.ShowDialog();
        }

        private void txtOtrosDctos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPagosExtras_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiasTrabajados_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtDiasTrabajados.Text.Length; i++)
            {
                if (txtDiasTrabajados.Text[i] == '.')
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

        private void txtOtrosDctos_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtOtrosDctos.Text.Length; i++)
            {
                if (txtOtrosDctos.Text[i] == '.')
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

        private void txtPagosExtras_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPagosExtras.Text.Length; i++)
            {
                if (txtPagosExtras.Text[i] == '.')
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

        private void txtDiasTrabajados_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDiasTrabajados.Text.Trim().Length != 0)
            {
                Montos();
            } else
            {
                txtMontoBruto.Text = "";
            }

        }

        private void txtOtrosDctos_KeyUp(object sender, KeyEventArgs e)
        {
            MontosPagados();
        }

        private void txtPagosExtras_KeyUp(object sender, KeyEventArgs e)
        {
            MontosPagados();
        }

        private void Limpiar()
        {
            txtNroDoc.Text = string.Empty;
            dataListadoAdelanto.Visible = false;
            dataListadoDcto.Visible = false;
            txtDiasTrabajados.Clear();
            txtMontoBruto.Clear();
            txtDctos.Clear();
            txtAdelantos.Clear();
            txtOtrosDctos.Clear();
            txtPagosExtras.Clear();
            txtMontoPagado.Clear();
            txtTrabajador.Clear();
            txtSueldo.Clear();
            txtNroDoc.Select();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtMontoPagado.Text.Trim().Length != 0)
            {
                decimal dctos = Convert.ToDecimal(txtDctos.Text);
                decimal adelanto = Convert.ToDecimal(txtAdelantos.Text);
                decimal diasTrabajados = Convert.ToDecimal(txtDiasTrabajados.Text);
                decimal montoPagado = Convert.ToDecimal(txtMontoPagado.Text);
                int factorDias = Convert.ToInt32(cbFactor.SelectedItem.ToString());
                decimal montoOtrosDctos = 00.00m, pagosExtras = 00.00m;
                string caja = "";
                if(cbCaja.Checked == true)
                {
                    caja = "SI";
                }else
                {
                    caja = "NO";
                }
                if(txtOtrosDctos.Text.Trim().Length == 0)
                {
                    montoOtrosDctos = 00.00m;
                }
                else
                {
                    montoOtrosDctos = Convert.ToDecimal(txtOtrosDctos.Text);
                }

                if(txtPagosExtras.Text.Trim().Length == 0)
                {
                    pagosExtras = 00.00m;
                }else
                {
                    pagosExtras = Convert.ToDecimal(txtPagosExtras.Text);
                }

                string rpta = "";
                rpta = NPagoTrabajador.Insertar(Convert.ToInt32(lblIdTrabajador.Text), montoPagado, dctos, adelanto, pagosExtras, montoOtrosDctos, DateTime.Now, txtObs.Text.Trim(),
                    "PAGADO", diasTrabajados, factorDias, caja);
                if(rpta == "OK")
                {
                    if (caja == "SI")
                    {
                        NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "EGRESO", montoPagado, "PAGO A TRABAJADOR " + txtTrabajador.Text, "EFECTIVO");
                    }
                   

                    if (dataListadoAdelanto.Rows.Count > 0)
                    {
                        for (int a = 0; a < dataListadoAdelanto.Rows.Count; a++)
                        {
                            NAdelanto.EditarEstado("PAGADO", Convert.ToInt32(dataListadoAdelanto.Rows[a].Cells[0].Value));
                        }
                    }
                    if (dataListadoDcto.Rows.Count > 0)
                    {
                        for (int a = 0; a < dataListadoDcto.Rows.Count; a++)
                        {
                            NDescuentoTrabajador.EditarEstado("PAGADO", Convert.ToInt32(dataListadoDcto.Rows[a].Cells[0].Value));
                        }
                    }
                    NImprimirRecibos.imprimirPagoTrabajador(txtTrabajador.Text, txtSueldo.Text, txtDiasTrabajados.Text, txtMontoBruto.Text, pagosExtras.ToString(), txtDctos.Text,
                        txtAdelantos.Text, montoOtrosDctos.ToString(), txtMontoPagado.Text);
                    Limpiar();
                }
              
            }
        }
    }
}
