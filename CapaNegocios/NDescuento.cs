using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NDescuento
    {
        public static string Insertar(int idProducto, string tipo, decimal porcentaje, string estado)
        {
            DDescuento Obj = new DDescuento();
            Obj.IdProducto = idProducto;
            Obj.Tipo = tipo;
            Obj.Porcentaje = porcentaje;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idDescuento, int idProducto, decimal porcentaje, string estado, string tipo)
        {
            DDescuento Obj = new DDescuento();
            Obj.IdDescuento = idDescuento;
            Obj.IdProducto = idProducto;
            Obj.Porcentaje = porcentaje;
            Obj.Estado = estado;
            Obj.Tipo = tipo;
            return Obj.Editar(Obj);
        }

        public static DataTable MostrarDescuentoCategoria()
        {
            return new DDescuento().MostrarDescuentoCategoria();
        }

        public static DataTable MostrarDescuentoTipoCliente()
        {
            return new DDescuento().MostrarDescuentoTipoCliente();
        }
        public static DataTable MostrarDescuentoTipoTrabajador()
        {
            return new DDescuento().MostrarDescuentoTipoTrabajador();
        }

        public static DataTable MostrarDescuentoProducto()
        {
            return new DDescuento().MostrarDescuentoProducto();
        }

        public static string Eliminar(int idDescuento)
        {
            DDescuento Obj = new DDescuento();
            Obj.IdDescuento = idDescuento;
            return Obj.Eliminar(Obj);
        }

        public static void DescuentoClientes(string idTipoCliente,decimal lblSubTotal, decimal lblIgv, decimal lblMontoAdelanto,decimal lblDescuento, decimal lblDctoGeneral,
            Label txtDctoGral, Label txtSubTotal, Label txtIgv, Label txtTotal,string clase)
        {
            DataTable dtDescuentoCliente = new DataTable();
            if (clase == "C")
            {
                dtDescuentoCliente = NDescuento.MostrarDescuentoTipoCliente();
            }else
            {
                dtDescuentoCliente = NDescuento.MostrarDescuentoTipoTrabajador();
            }
              NDescuento.MostrarDescuentoTipoCliente();
            if (dtDescuentoCliente.Rows.Count > 0)
            {
                for (int i = 0; i < dtDescuentoCliente.Rows.Count; i++)
                {
                    decimal subtotal = 00.00m, igv = 00.00m, dctoInd = 00.00m, montoAdelanto = 00.00m, total = 00.00m, dctoTC = 00.00m, totalAD = 00.00m, dctoGral = 00.00m;
                    if (dtDescuentoCliente.Rows[i][5].ToString() == idTipoCliente)
                    {

                        subtotal = Convert.ToDecimal(lblSubTotal);
                        igv = Convert.ToDecimal(lblIgv);
                        montoAdelanto = Convert.ToDecimal(lblMontoAdelanto);
                        dctoInd = Convert.ToDecimal(lblDescuento);
                        dctoGral = Convert.ToDecimal(lblDctoGeneral);
                        total = subtotal + igv + montoAdelanto + dctoInd + dctoGral;
                        dctoTC = Convert.ToDecimal(dtDescuentoCliente.Rows[i][2].ToString()) / 100;
                        decimal totalRed = NRedondeo.redondearParcial(dctoTC * (total-dctoInd));
                        totalAD = total - (totalRed) - dctoInd;
                        
                        txtDctoGral.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalRed));
                        decimal totalSubTotalText = (totalAD) / 1.18m;
                        txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                        decimal totalIgvText = totalAD - totalSubTotalText;
                        txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
                        decimal totalMonto = Convert.ToDecimal(txtIgv.Text) + Convert.ToDecimal(txtSubTotal.Text);
                        txtTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalMonto));
                        return;

                    }
                    else
                    {
                        subtotal = Convert.ToDecimal(lblSubTotal);
                        igv = Convert.ToDecimal(lblIgv);
                        montoAdelanto = Convert.ToDecimal(lblMontoAdelanto);
                        dctoInd = Convert.ToDecimal(lblDescuento);
                        dctoGral = Convert.ToDecimal(lblDctoGeneral);
                        total = subtotal + igv + montoAdelanto + dctoInd + dctoGral;
                        totalAD = total - dctoInd;
                        txtDctoGral.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(dctoTC * totalAD));
                        decimal totalSubTotalText = (totalAD) / 1.18m;
                        txtSubTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalSubTotalText));
                        decimal totalIgvText = totalAD - totalSubTotalText;
                        txtIgv.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalIgvText));
                        decimal totalMonto = Convert.ToDecimal(txtIgv.Text) + Convert.ToDecimal(txtSubTotal.Text);
                        txtTotal.Text = string.Format(" {0:#,##0.00}", Convert.ToDouble(totalMonto));
                        

                    }
                }
            }
        }
    }
}
