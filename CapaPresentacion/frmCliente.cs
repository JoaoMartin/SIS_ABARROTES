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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Cliente");
        }

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtFechaNac.Text = string.Empty;
            this.txtNumDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;

            this.pbFecha.Enabled = false;
            this.cbTipoDoc.SelectedIndex = -1;
        }

        //Habilitar Controles
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.cbTipoDoc.Enabled = valor;
            this.pbFecha.Enabled = valor;
            this.txtNumDoc.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.errorIcono.Clear();
          //  this.cbTipoDoc.SelectedIndex = -1;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void ocultarColumnas()
        {
            this.dataListado.Columns[6].Visible = false;
            //this.dataListado.Columns[2].Visible = false;
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[9].Visible = false;

            // DataGridView1.Columns(1).Width = 150
            this.dataListado.Columns[0].Width = 70;
            this.dataListado.Columns[1].Width = 330;
            this.dataListado.Columns[2].Width = 100;
            this.dataListado.Columns[3].Width = 100;
            this.dataListado.Columns[5].Width = 438;
            this.dataListado.Columns[7].Width = 150;
            //this.dataListado.Columns[7].Width = 120;

            this.dataListado.ClearSelection();
            this.dataListado.ColumnHeadersDefaultCellStyle.Font = new Font(dataListado.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            this.dataListado.GridColor = SystemColors.ActiveBorder;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            
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

        private void Buscar()
        {
            this.dataListado.DataSource = NCliente.Buscar(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarDni()
        {
            this.dataListado.DataSource = NCliente.BuscarDni(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarTipoCliente()
        {
            this.dataListado.DataSource = NCliente.BuscarTipoCliente(this.txtBuscar.Text.Trim());
            this.ocultarColumnas();
            this.lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Guardar()
        {
            try
            {
                string rpta = "";
                string tipoDoc = "";
                int? idTipoCliente;
                DateTime fecNac;
                if (this.txtNombre.Text.Trim() == string.Empty)
                {
                    MensajeError("Ingrese el nombre del cliente");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre");
                }
                else
                {
                    if(this.txtFechaNac.Text == "")
                    {
                        fecNac = DateTime.MinValue;
                    }
                    else
                    {
                        fecNac = Convert.ToDateTime(this.txtFechaNac.Text);
                    }
                    if(this.cbTipoDoc.SelectedIndex == -1)
                    {
                        tipoDoc = "";
                    }
                    else
                    {
                        tipoDoc = this.cbTipoDoc.SelectedItem.ToString();
                    }

                    if(cbTipoCliente.SelectedIndex == -1)
                    {
                       idTipoCliente = null;
                    }else
                    {
                        idTipoCliente = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                    }

                    if(cbTipoDoc.SelectedIndex == 0 && txtNumDoc.Text.Trim().Length !=8)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                        return;
                    }
                    else if (cbTipoDoc.SelectedIndex == 1 && txtNumDoc.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                        return;
                    }
                    else if (cbTipoDoc.SelectedIndex == 2 && txtNumDoc.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                        return;
                    }


                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(), fecNac, tipoDoc,
                                                 this.txtNumDoc.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtEmail.Text.Trim(), this.txtTelefono.Text.Trim(),idTipoCliente);
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text), this.txtNombre.Text.Trim().ToUpper(), fecNac, 
                            tipoDoc,this.txtNumDoc.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtEmail.Text.Trim(), this.txtTelefono.Text.Trim(),idTipoCliente);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó correcatamente");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó correctamente");
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
                    this.Mostrar();
                    this.tabControl2.SelectedIndex = 0;
                    txtBuscar.Clear();
                    txtBuscar.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void pbFecha_Click(object sender, EventArgs e)
        {
            if(mcFecha.Visible == true)
            {
                mcFecha.Visible = false;
            }
            else
            {
                mcFecha.Visible = true;
            }
        }

        private void mcFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaNac.Text = mcFecha.SelectionStart.ToShortDateString();
            mcFecha.Visible = false;
        }

        private void cargarTipoCliente()
        {
            cbTipoCliente.DataSource = NTipoCliente.Mostrar();
            cbTipoCliente.ValueMember = "Codigo";
            cbTipoCliente.DisplayMember = "TipoCliente";
            cbTipoCliente.SelectedIndex = -1;
            //lblPrueba.Text = cbCategoria.SelectedValue.ToString();

        }


        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.cargarTipoCliente();
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.txtBuscar.Focus();
            txtBuscar.Select();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 1;
            this.cbTipoDoc.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(this.rbTipoDoc.Checked == true)
            {
                this.BuscarDni();
            }
            else if(this.rbNombre.Checked == true || this.rbTodos.Checked == true)
            {
                this.Buscar();
            }
            else if (this.rbTipoDoc.Checked == true)
            {
                this.BuscarTipoCliente();
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            string idTipoCliente;
            if (this.IsNuevo)
            {
                this.Habilitar(false);               
                this.btnGuardar.Enabled = false;
            }
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
            DateTime fechaNac;
            String fechaNacimiento;
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            fechaNacimiento = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha_Nac"].Value);
            fechaNac = Convert.ToDateTime(fechaNacimiento);
            if(fechaNacimiento == "01/01/0001 12:00:00 a. m.")
            {
                this.txtFechaNac.Text = "";
            }
            else
            {
                this.txtFechaNac.Text = fechaNac.ToShortDateString();
            }
            idTipoCliente = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoCliente"].Value);
            if(idTipoCliente =="" || idTipoCliente == null)
            {
                cbTipoCliente.SelectedIndex = -1;
            }else
            {
                cbTipoCliente.SelectedValue = idTipoCliente;
            }

            if(Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Doc"].Value) == "DNI")
            {
                this.cbTipoDoc.SelectedIndex = 0;
            }
            else if(Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Doc"].Value) == "RUC")
            {
                this.cbTipoDoc.SelectedIndex = 1;
            }
            else if (Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Doc"].Value) == "PASAPORTE")
            {
                this.cbTipoDoc.SelectedIndex = 2;
            }
       
            this.txtNumDoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Doc"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);

            //pbFecha.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdCliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.txtNombre.Focus();
                this.tabControl2.SelectedIndex = 1;
            }
            else
            {
                this.MensajeError("Seleccione un registro");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.dataListado.ClearSelection();
            this.tabControl2.SelectedIndex = 0;
            this.cbTipoDoc.SelectedIndex = -1;
            txtBuscar.Clear();
            txtBuscar.Select();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbTodos.Checked == true)
            {
                this.Mostrar();
                this.txtBuscar.Text = string.Empty;
                this.txtBuscar.Select();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRCliente frm = new frmRCliente();
            frm.ShowDialog();
        }

        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void rbTipoDoc_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Select();
            Mostrar();
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Select();
            Mostrar();
        }

        private void rbTipoCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtBuscar.Select();
            Mostrar();
        }
    }
}
