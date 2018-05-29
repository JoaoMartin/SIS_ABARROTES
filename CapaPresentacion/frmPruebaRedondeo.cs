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
    public partial class frmPruebaRedondeo : Form
    {
        public frmPruebaRedondeo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal numredondeo = NRedondeo.redondearParcial(Convert.ToDecimal(textBox1.Text));
            label1.Text = numredondeo.ToString();
        }
    }
}
