using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NDescuentoTrabajador
    {
        public static string Insertar(int idTrabajador,decimal monto, string motivo, DateTime fecha, string estado, string obs)
        {
            DDescuentoTrabajador Obj = new DDescuentoTrabajador();
            Obj.IdTrabajador = idTrabajador;
            Obj.Monto = monto;
            Obj.Motivo = motivo;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            Obj.Obs = obs;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idDescuentoTrabajador,int idTrabajador, decimal monto, string motivo, DateTime fecha, string estado)
        {
            DDescuentoTrabajador Obj = new DDescuentoTrabajador();
            Obj.IdDescuentoTrabajador = idDescuentoTrabajador;
            Obj.IdTrabajador = idTrabajador;
            Obj.Monto = monto;
            Obj.Motivo = motivo;
            Obj.Fecha = fecha;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idDescuentoTrabajador)
        {
            DDescuentoTrabajador Obj = new DDescuentoTrabajador();
            Obj.IdDescuentoTrabajador = idDescuentoTrabajador;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar(int idTrabajador, string mes)
        {
            return new DDescuentoTrabajador().Mostrar(idTrabajador,mes);
        }

        public static string EditarEstado(string estado, int idAdelanto)
        {
            DDescuentoTrabajador Obj = new DDescuentoTrabajador();
            return Obj.EditarEstado(estado, idAdelanto);
        }
    }
}
