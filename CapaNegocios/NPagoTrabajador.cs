using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NPagoTrabajador
    {
        public static string Insertar(int idTrabajador, decimal montoPagado, decimal montoDcto, decimal montoAdelanto, decimal montoExtras, decimal montoOtrosDctos,
            DateTime fecha, string obs, string estado, decimal diasTrabajados, int factor, string caja)
        {
            DPagoTrabajador Obj = new DPagoTrabajador();
            Obj.IdTrabajador = idTrabajador;
            Obj.MontoPagado = montoPagado;
            Obj.MontoDcto = montoDcto;
            Obj.MontoAdelanto = montoAdelanto;
            Obj.MontoHorasExtras = montoExtras;
            Obj.MontoOtrosDctos = montoOtrosDctos;
            Obj.Fecha = fecha;
            Obj.Obs = obs;
            Obj.Estado = estado;
            Obj.DiasTrabajados = diasTrabajados;
            Obj.Factor = factor;
            Obj.Caja = caja;
            return Obj.Insertar(Obj);
        }
        public static string Eliminar(int idPagoTrabajador)
        {
            DPagoTrabajador Obj = new DPagoTrabajador();
            Obj.IdPagoTrabajador = idPagoTrabajador;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar(int idTrabajador, string mes)
        {
            return new DPagoTrabajador().Mostrar(idTrabajador, mes);
        }

        public static DataTable Validar(int idTrabajador, string mes)
        {
            return new DPagoTrabajador().ValidarPago(idTrabajador, mes);
        }
    }
}
