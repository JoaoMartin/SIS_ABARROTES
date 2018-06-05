using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NAdelanto
    {
        public static string Insertar(int idTrabajador, decimal monto, DateTime fecha, string estado, string caja)
        {
            DAdelanto Obj = new DAdelanto();
            Obj.IdTrabajador = idTrabajador;
            Obj.Monto = monto;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.Caja = caja;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idAdelanto, int idTrabajador, decimal monto, DateTime fecha, string estado)
        {
            DAdelanto Obj = new DAdelanto();
            Obj.IdAdelanto = idAdelanto;
            Obj.IdTrabajador = idTrabajador;
            Obj.Monto = monto;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idAdelanto)
        {
            DAdelanto Obj = new DAdelanto();
            Obj.IdAdelanto = idAdelanto;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar(int idTrabajador, string mes)
        {
            return new DAdelanto().Mostrar(idTrabajador, mes);
        }

        public static string EditarEstado(string estado, int idAdelanto)
        {
            DAdelanto Obj = new DAdelanto();
            return Obj.EditarEstado(estado, idAdelanto);
        }
        public static DataTable reporteAdelanto(DateTime fechaInicio, DateTime fechaFin, string estado, int idTrabajador)
        {
            return new DAdelanto().reporteAdelanto(fechaInicio, fechaFin, estado, idTrabajador);
        }
    }
}
