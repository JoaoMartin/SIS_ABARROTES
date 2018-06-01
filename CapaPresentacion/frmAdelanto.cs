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
    public partial class frmAdelanto : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public frmAdelanto()
        {
            InitializeComponent();
        }

        //Limpiar
        private void Limpiar()
        {
            this.txtMonto.Text = string.Empty;
            
            this.txtIdDescuentoTrab.Text = string.Empty;
            this.cbTrabajador.SelectedIndex = -1;
            this.cbEliminar.Checked = false;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtMonto.ReadOnly = !valor;
            this.cbCaja.Enabled = valor;
            this.cbTrabajador.Enabled = valor;
            this.errorIcono.Clear();
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void Guardar()
        {
            try
            {
                string rpta = "";
                 if (this.txtMonto.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el monto del descuento");
                    errorIcono.SetError(txtMonto, "Ingrese el monto");
                }
                else if (cbTrabajador.SelectedIndex == -1)
                {
                    MensajeError("Seleccione un trabajador");
                    errorIcono.SetError(cbTrabajador, "Seleccione un trabajador");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        string caja = "";
                        if (cbCaja.Checked)
                        {
                            caja = "SI";
                        }else
                        {
                            caja = "NO";
                        }

                        rpta = NAdelanto.Insertar(Convert.ToInt32(cbTrabajador.SelectedValue.ToString()), Convert.ToDecimal(txtMonto.Text),DateTime.Now,"PENDIENTE",caja);
                        if (caja == "SI")
                        {
                            NCaja.Insertar(Convert.ToInt32(frmPrincipal.f1.lblIdUsuario.Text), "1", "EGRESO", Convert.ToDecimal(txtMonto.Text),"ADELANTO SUELDO", "EFECTIVO");
                        }
                    }
                   

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            NImprimirRecibos.imprimirAdelanto(cbTrabajador.SelectedItem.ToString(), txtMonto.Text);
                            Mostrar();
                        }
                      
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    // this.Mostrar();
                    this.tbInfo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cargarTrabajador()
        {
            cbTrabajador.DataSource = NTrabajador.MostrarDesc();
            cbTrabajador.ValueMember = "Codigo";
            cbTrabajador.DisplayMember = "Trabajador";
            cbTrabajador.SelectedIndex = -1;

            cbTraba.DataSource = NTrabajador.MostrarDesc();
            cbTraba.ValueMember = "Codigo";
            cbTraba.DisplayMember = "Trabajador";
            cbTraba.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }

        private void frmAdelanto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            //this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            cargarTrabajador();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdDescuentoTrab.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.txtMonto.Select();
                this.tbInfo.SelectedIndex = 1;
            }
            else
            {
                this.MensajeError("Seleccione un registro");
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnNuevo.Enabled = false;
                DataGridViewCheckBoxCell cbEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                cbEliminar.Value = !Convert.ToBoolean(cbEliminar.Value);
            }
        }

        private void cbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.btnEliminar.Enabled = false;
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();

            this.Limpiar();
            this.Habilitar(false);
            this.dataListado.ClearSelection();
            this.tbInfo.SelectedIndex = 0;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtMonto.Text.Length; i++)
            {
                if (txtMonto.Text[i] == '.')
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbTrabajador.Focus();
            this.dataListado.ClearSelection();
            this.tbInfo.SelectedIndex = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Está seguro de eliminar los registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NAdelanto.Eliminar(Convert.ToInt32(codigo));
                        }

                    }

                    if (rpta.Equals("OK"))
                    {
                        Mostrar();
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.Limpiar();
                    this.btnEliminar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    cbEliminar.Checked = false;
                    btnNuevo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[5].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[2].Width = 180;
            this.dataListado.Columns[3].Width = 255;
            this.dataListado.Columns[4].Width = 180;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.DefaultCellStyle.Font = new Font("Roboto", 9);
            this.dataListado.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            if (IsNuevo)
            {
                this.dataListado.DataSource = NAdelanto.Mostrar(Convert.ToInt32(cbTrabajador.SelectedValue), DateTime.Now.Month.ToString());
                cbTraba.SelectedValue = cbTrabajador.SelectedValue;
            }else
            {
                this.dataListado.DataSource = NAdelanto.Mostrar(Convert.ToInt32(cbTraba.SelectedValue), DateTime.Now.Month.ToString());
            }
 


            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (this.dataListado.Rows.Count == 0)
            {
                this.dataListado.Visible = false;
            }
            else
            {
                this.dataListado.Visible = true;
                this.ocultarColumnas();
            }
        }

        private void cbTraba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTraba.SelectedIndex != 0)
            {
                Mostrar();
            }
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            string idDescuento = "";
            string caja;
            if (this.IsNuevo)
            {
                this.Habilitar(false);
                this.btnGuardar.Enabled = false;
            }
           
            this.btnCancelar.Enabled = true;
            this.txtIdDescuentoTrab.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            caja = Convert.ToString(this.dataListado.CurrentRow.Cells["caja"].Value);
            this.txtMonto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Monto"].Value);
            if(caja == "SI")
            {
                cbCaja.Checked = true;
            }else
            {
                cbCaja.Checked = false;
            }

            idDescuento = cbTraba.SelectedValue.ToString();
            cbTrabajador.SelectedValue = idDescuento;
            cbTrabajador.Enabled = false;
        }
    }
}
