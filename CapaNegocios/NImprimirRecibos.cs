using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class NImprimirRecibos
    {
        public static void imprimirPagoTrabajador(string trabajador, string sueldo, string diasTrabajados, string montoBruto, string horasExtras, string dctos, string adelantos,
            string otrosDctos, string totalPagado)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();


            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            ticket.TextoCentro("PAGO TRABAJADOR");

            ticket.TextoIzquierda("");

            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Trabajador:" + trabajador);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Sueldo: " + sueldo);
            ticket.lineasAsteriscos();

            ticket.TextoCentro("DETALLES");
            ticket.lineasAsteriscos();

            ticket.TextoExtremos("Días Trabajados ", diasTrabajados);
            ticket.TextoExtremos("Monto Bruto: +", montoBruto);
            ticket.TextoExtremos("Horas Extras: +", horasExtras);
            ticket.TextoExtremos("Descuentos: -", dctos);
            ticket.TextoExtremos("Adelantos: -", adelantos);
            ticket.TextoExtremos("Otros Dctos: -", otrosDctos);
            ticket.lineasAsteriscos();
            ticket.TextoExtremos("TOTAL PAGADO: +", totalPagado);
       
            ticket.CortaTicket();
            // ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("Microsoft XPS Document Writer");
            // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }

        public static void imprimirAdelanto(string trabajador, string adelanto)
        {

            NTicket ticket = new NTicket();
            ticket.AbreCajon();


            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("D'LALO");
            ticket.TextoCentro("Inversiones Lalos S.R.L");
            //  ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
            ticket.TextoCentro("AV. MARISCAL CACERES 1243 - Ayacucho");
            ticket.TextoCentro("RUC: 20304455463");
            ticket.TextoCentro("ADELANTO TRABAJADOR");

            ticket.TextoIzquierda("");

            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Trabajador:" + trabajador);
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            ticket.TextoCentro("DETALLES");
            ticket.lineasAsteriscos();

            ticket.TextoExtremos("ADELANTO REMUNERACION", "S/ "+ adelanto+".00");
            ticket.CortaTicket();
            // ticket.ImprimirTicket("COCINA_LALOS");//Nombre de la impresora ticketera
            ticket.ImprimirTicket("Microsoft XPS Document Writer");
            // ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }
    }
}
