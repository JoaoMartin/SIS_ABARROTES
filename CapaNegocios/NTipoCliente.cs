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
    public class NTipoCliente
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTipoCliente, string nombre, string descripcion)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.IdTipoCliente = idTipoCliente;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTipoCliente)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.IdTipoCliente = idTipoCliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTipoCliente().Mostrar();
        }


        public static DataTable Buscar(string textoBuscar)
        {
            DTipoCliente Obj = new DTipoCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.Buscar(Obj);
        }

        

        public static string GuardarCliente(string total, string totaladelanto,string banderaComprobante,string nroDoc,ComboBox cbTipoCliente, bool isNuevo,
            string nombre,string direccion, string idCliente)
        {
            string rpta = "";
            try
            {
                
                decimal monto = 00.00m;
                string tipoDoc = "";
                int? tipoCliente;
                monto = Convert.ToDecimal(total) + Convert.ToDecimal(totaladelanto);
                if (banderaComprobante == "1" || banderaComprobante=="0")
                {
                    if (monto <= 700)
                    {
                        if (nroDoc != "" || (nroDoc.Length == 8 || nroDoc.Length == 11))
                        {
                            if (nroDoc.Length == 8)
                            {
                                tipoDoc = "DNI";
                            }
                            else if (nroDoc.Length == 11)
                            {
                                tipoDoc = "RUC";
                                
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un número de documento válido");
                                return null;
                            }
                        }
                        else
                        {
                            tipoDoc = "";
                        }

                        if (cbTipoCliente.SelectedIndex == -1)
                        {
                            tipoCliente = null;
                        }
                        else
                        {
                            tipoCliente = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                        }
                        if (isNuevo)
                        {
                            rpta = NCliente.InsertarVenta(nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc.Trim(), direccion, "", "", tipoCliente);

                        }
                        else
                        {
                            rpta = NCliente.Editar(Convert.ToInt32(idCliente), nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc, direccion, "", "", tipoCliente);

                        }

                    }
                    else if (monto > 700)
                    {
                        if (nroDoc.Length == 0 && (nroDoc.Length != 8 || nroDoc.Length != 11))
                        {
                            MessageBox.Show("Ingrese un número de documento válido");
                           

                        }
                        else if (nroDoc.Length == 11)
                        {
                            tipoDoc = "RUC";
                        }
                        else if (nroDoc.Length == 8)
                        {
                            tipoDoc = "DNI";
                        }

                        if (nombre == "" || direccion == "")
                        {
                            MessageBox.Show("Complete el nombre y la dirección");
                           

                        }
                        if (cbTipoCliente.SelectedIndex == -1)
                        {
                            tipoCliente = null;
                        }
                        else
                        {
                            tipoCliente = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                        }
                        if (isNuevo)
                        {
                            rpta = NCliente.InsertarVenta(nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc, direccion, "", "", tipoCliente);

                        }
                        else
                        {
                            rpta = NCliente.Editar(Convert.ToInt32(idCliente), nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc, direccion, "", "", tipoCliente);

                        }
                    }

                    return rpta;
                }
                else if (banderaComprobante == "2")
                {
                    if (nroDoc.Length == 0 || nroDoc.Length != 11)
                    {
                        MessageBox.Show("Ingrese un número de documento válido");
                       

                    }
                    else if (nroDoc.Length == 0 || nroDoc.Length == 0)
                    {
                        MessageBox.Show("Complete el nombre y la dirección");
                       
                    }
                    else
                    {
                        if (cbTipoCliente.SelectedIndex == -1)
                        {
                            tipoCliente = null;
                        }
                        else
                        {
                            tipoCliente = Convert.ToInt32(cbTipoCliente.SelectedValue.ToString());
                        }
                        if (isNuevo)
                        {
                            rpta = NCliente.InsertarVenta(nombre.ToUpper(), DateTime.MinValue, tipoDoc, nombre, direccion, "", "", tipoCliente);

                        }
                        else
                        {
                            rpta = NCliente.Editar(Convert.ToInt32(idCliente), nombre.ToUpper(), DateTime.MinValue, tipoDoc, nroDoc, direccion, "", "", tipoCliente);

                        }

                    }
                    return rpta;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            return rpta;
        }
    }
}
