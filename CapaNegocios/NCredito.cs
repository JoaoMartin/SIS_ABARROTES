using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NCredito
    {
        public static string Insertar(int idVenta,string formaPago, string descripcion, string estado)
        {
            DCredito Obj = new DCredito();
            Obj.IdVenta = idVenta;
            Obj.FormaPago = formaPago;
            Obj.Descr = descripcion;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }
    }
}
