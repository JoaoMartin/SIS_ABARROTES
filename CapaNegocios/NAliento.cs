using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NAliento
    {

        public static string MensajeAliento()
        {

            string frase = "";
            int numero;
            string[] frases = new string[] { "¡VAMOS CON TODO , ARRIBA PERU!", "¡VAMOS GUERREROS!", "¡TE AMO PERU!", "!A PONER TODO EN LA CANCHA, VAMOS PERU!",
            "¡SOMOS PERU Y ESTAMOS DE VUELTA!", "¡UN SOLO ALIENTO, ARRIBA PERU!"};

            Random rnd = new Random();
            numero = rnd.Next(0, frases.Length );
            return frase = frases[numero].ToString();
        }
    }
}
