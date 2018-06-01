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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login()
        {
            if(this.txtUsuario.Text.Trim() == "" || this.txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Complete ambos campos");
            }
            else
            {
                DataTable datos = NTrabajador.Login(this.txtUsuario.Text.Trim(), this.txtPass.Text.Trim());
                if (datos.Rows.Count == 0)
                {
                    MessageBox.Show("El usuario no existe", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataTable dtEstado = NCaja_A.MostrarEstadoCaja(1);
                    DataTable dtEstadoMonto = NCaja_A.MostrarEstadoCajaMonto(1);

                    string estado;
                    DateTime fecha_estado;

                    if (dtEstado.Rows.Count > 0)
                    {
                        estado = dtEstado.Rows[0]["Estado"].ToString();
                    }
                    else
                    {
                        estado = "0";
                    }

                    if (estado == "0" || estado == "Cerrada")
                    {
                        frmPrincipal frm = new frmPrincipal();
                        frm.lblFechaCaja.Text = "";
                        frm.lblEstadoCaja.Text = "0";
                        frm.lblEstadoTurno.Text = "Cerrada";
                        frm.lblMontoApertura.Text = "0";
                        frm.lblFechaApertura.Text = "0";
                        // fecha_estado = Convert.ToDateTime(dt1.Rows[0]["Fecha"].ToString());
                        frm.lblIdUsuario.Text = datos.Rows[0][0].ToString();
                        frm.lblUsuario.Text = datos.Rows[0][1].ToString();
                        frm.lblAcceso.Text = datos.Rows[0][2].ToString();
                       // frm.lblApellidos.Text = datos.Rows[0][3].ToString();
                        frm.lblPass.Text = this.txtPass.Text;
                        frm.lblUsuarioSis.Text = this.txtUsuario.Text.Trim();
                        frm.Show();
                    }
                    else
                    {
                        DataTable dtMonto = NCaja_A.MostrarMontoCaja(1);
                        frmPrincipal frm = new frmPrincipal();
                        frm.lblEstadoCaja.Text = dtEstado.Rows[0]["Estado"].ToString();
                        fecha_estado = Convert.ToDateTime(dtEstado.Rows[0]["Fecha"].ToString());
                        frm.lblFechaCaja.Text = fecha_estado.ToShortDateString();
                        frm.lblIdUsuario.Text = datos.Rows[0][0].ToString();
                        frm.lblUsuario.Text = datos.Rows[0][1].ToString();
                        frm.lblAcceso.Text = datos.Rows[0][2].ToString();
                      // frm.lblApellidos.Text = datos.Rows[0][3].ToString();
                        frm.lblMontoApertura.Text = dtMonto.Rows[0]["monto"].ToString();
                        frm.lblFechaApertura.Text = dtMonto.Rows[0]["fecha"].ToString();
                        frm.lblPass.Text = this.txtPass.Text;
                        frm.lblUsuarioSis.Text = this.txtUsuario.Text.Trim();
                        DataTable dtCorte = NCaja_A.MostrarCorteCaja(1);
                        if (dtEstadoMonto.Rows[0]["Estado"].ToString() == "Abierta")
                        {
                            frm.lblFechaCorteCaja.Text = dtEstadoMonto.Rows[0]["Fecha"].ToString();
                            frm.lblMontoCorteCaja.Text = dtEstadoMonto.Rows[0]["monto"].ToString();
                        }else if (dtEstadoMonto.Rows[0]["Estado"].ToString() == "Corte Caja")
                        {
                            frm.lblFechaCorteCaja.Text = dtCorte.Rows[0]["fecha"].ToString();
                            frm.lblMontoCorteCaja.Text = dtCorte.Rows[0]["monto"].ToString();
                        }else if (dtEstadoMonto.Rows[0]["Estado"].ToString() == "Cierre Caja" ||  dtEstadoMonto.Rows[0]["Estado"].ToString() == "Cerrada")
                        {
                            
                        }
                        /*
                            if (dtCorte.Rows.Count <=0)
                        {
                            frm.lblFechaCorteCaja.Text = dtMonto.Rows[0]["fecha"].ToString();
                            frm.lblMontoCorteCaja.Text = dtMonto.Rows[0]["monto"].ToString();
                        }
                        else
                        {
                            frm.lblFechaCorteCaja.Text = dtCorte.Rows[0]["fecha"].ToString();
                            frm.lblMontoCorteCaja.Text = dtCorte.Rows[0]["monto"].ToString();
                        }*/
                 
                        frm.Show();
                    }

                    
                    this.Hide();
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Login();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Login();

            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Login();
            }
        }
    }
}
