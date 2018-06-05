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
    public partial class frmObs : Form
    {
        public static frmObs f1;
        public frmObs()
        {
            InitializeComponent();
            frmObs.f1 = this;
        }

        private void frmObs_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(lblBandera.Text == "1")
            {
                frmPagar.f1.lblObs.Text = this.txtObs.Text;
                this.Close();
            }else if(lblBandera.Text == "2")
            {
                frmPagarDividida.f1.lblObs.Text = this.txtObs.Text;
                this.Close();
            }else if(lblBandera.Text == "3")
            {
                frmPagarSeparada.f1.lblObs.Text = this.txtObs.Text;
                this.Close();
            }
        }
    }
}
