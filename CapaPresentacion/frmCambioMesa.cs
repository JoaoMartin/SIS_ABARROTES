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
    public partial class frmCambioMesa : Form
    {
        Button[] btnSalon;
        Button[] btnMesa;
        DataTable dtSalon, dtMesa;
        int nroSalon, nroMesa;
        private int loc = 0;


        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public frmCambioMesa()
        {
            InitializeComponent();

            this.plMesa.AutoScrollPosition = new Point(90, 0);
            this.plMesa.VerticalScroll.Maximum = 900;
        }

        private void mostrarSalones()
        {
            dtSalon = NSalon.Mostrar();
            nroSalon = dtSalon.Rows.Count;
            int y = 40;
            int x = 10;
            btnSalon = new Button[nroSalon];

            for (int i = 0; i < nroSalon; i++)
            {
                DataRow row = dtSalon.Rows[i];
                if (i == 0)
                {
                    this.lblPrimerID.Text = String.Concat(row[0].ToString());
                    this.lblIdSalon.Text = String.Concat(row[0].ToString());
                    this.lblMesa.Text = string.Concat("MESAS  ", row[1].ToString());
                    this.lblNombreSalon.Text = row[1].ToString();
                    this.mostrarMesas(this.lblPrimerID.Text);
                }
                btnSalon[i] = new Button();
                btnSalon[i].Location = new Point(x, y);
                btnSalon[i].Name = string.Concat("btnSalon", i.ToString());
                btnSalon[i].Size = new Size(164, 80);
                btnSalon[i].TabIndex = i;
                btnSalon[i].Text = row[1].ToString();
                btnSalon[i].BackColor = Color.White;

                btnSalon[i].Visible = true;
                btnSalon[i].Tag = i;
                btnSalon[i].Click += new EventHandler((sender, e) =>
                {
                    this.lblIdSalon.Text = String.Concat(row[0].ToString());

                    this.limpiarMesas();
                    this.mostrarMesas(this.lblIdSalon.Text);
                    this.lblMesa.Text = string.Concat("MESAS ", row[1].ToString());
                    this.lblIdMesa.Text = string.Empty;
                    this.lblNombreSalon.Text = row[1].ToString();
                });
                //this.Controls.Add(this.btnSalon[i]);
                y += 90;

                gbSalon.Controls.Add(btnSalon[i]);

            }

        }

        private void mostrarMesas(string idSalon)
        {
            this.lblNroMesas.Text = "0";
            dtMesa = NMesa.MostrarLibre(Convert.ToInt32(idSalon));
            nroMesa = dtMesa.Rows.Count;

            int y1 = 50;
            int x1 = 6;


            btnMesa = new Button[nroMesa];

            for (int i = 0; i < nroMesa; i++)
            {
                if (i == 7)
                {
                    y1 = 180;
                    x1 = 3;
                }
                else if (i == 14)
                {
                    y1 = 290;
                    x1 = 3;
                }
                else if (i == 21)
                {
                    y1 = 400;
                    x1 = 3;
                }
                else if (i == 28)
                {
                    y1 = 510;
                    x1 = 3;
                }
                else if (i == 35)
                {
                    y1 = 620;
                    x1 = 3;
                }
                else if (i == 42)
                {
                    y1 = 730;
                    x1 = 3;
                }
                else if (i == 49)
                {
                    y1 = 840;
                    x1 = 3;
                }
                else if (i == 56)
                {
                    y1 = 950;
                    x1 = 3;
                }
                DataRow row = dtMesa.Rows[i];
                btnMesa[i] = new Button();
                btnMesa[i].Location = new Point(x1, y1);
                btnMesa[i].Name = string.Concat("btnMesa", i.ToString());
                //String mesa = row[0].ToString();
                //btnMesa[i].Name = string.Concat("btnMesa",mesa);
                btnMesa[i].Size = new Size(154, 110);
                btnMesa[i].Font = new Font("Roboto", 14f, FontStyle.Bold);
                btnMesa[i].TabIndex = i;
                btnMesa[i].Text = row[1].ToString();
                btnMesa[i].Visible = true;
                btnMesa[i].BackColor = Color.DarkOliveGreen;

                btnMesa[i].ForeColor = Color.White;
                btnMesa[i].Tag = i;
                lblNroMesas.Text = nroMesa.ToString();

                x1 += 170;

                plMesa.Controls.Add(btnMesa[i]);

                btnMesa[i].Click += new EventHandler((sender, e) =>
                {
                    //this.btnMesa[2].BackColor = Color.Red;
                    DialogResult opcion;
                    string rpta = "";
                    opcion = MessageBox.Show("Está seguro de cambiar de mesa?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (opcion == DialogResult.OK)
                    {

                        rpta =NMesa.EditarEstadoMesa(Convert.ToInt32(frmVenta.f1.lblIdMesa.Text), "Libre");
                        rpta = NMesa.EditarEstadoMesa(Convert.ToInt32(row[0].ToString()), "Ocupada");
                        rpta = NVenta.EditarMesaVenta(Convert.ToInt32(this.lblIdVenta.Text), Convert.ToInt32(row[0].ToString()));
                        if (rpta == "OK")
                        {
                            frmVenta.f1.lblIdMesa.Text = row[0].ToString();
                           // frmVenta.f1.lblMesa.Text = row[1].ToString();

                            frmVenta.f1.lblIdSalon.Text = this.lblIdSalon.Text;
                            //frmVenta.f1.lblSalon.Text = this.lblNombreSalon.Text;

                            frmModuloSalon.f3.limpiarMesas();
                            frmModuloSalon.f3.mostrarSalones();
                            // this.MensajeOK("Se realizo el cambio de mesa");
                            this.Close();
                            frmVenta.f1.Close();
                            frmModuloSalon.f3.Show();
                        }

                    }


                });

            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (loc - 250 > 0)
            {
                loc -= 276;
                plMesa.VerticalScroll.Value = loc;
            }
            else
            {
                loc = 0;
                plMesa.AutoScrollPosition = new Point(0, loc);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (loc + 150 < plMesa.VerticalScroll.Maximum)
            {
                loc += 150;
                plMesa.VerticalScroll.Value = loc;
            }
            else
            {

                loc = plMesa.VerticalScroll.Maximum;
                plMesa.AutoScrollPosition = new Point(0, loc);

            }
        }

        private void limpiarMesas()
        {

            if (lblNroMesas.Text != "")
            {
                int nro = Convert.ToInt32(lblNroMesas.Text);
                for (int j = 0; j < nro; j++)
                {
                    plMesa.Controls.Remove(btnMesa[j]);
                }
            }
        }


        private void frmCambioMesa_Load(object sender, EventArgs e)
        {
            this.mostrarSalones();
        }
    }
}
