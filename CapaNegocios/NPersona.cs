using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NPersona
    {
        public static string Insertar(string nombre, DateTime fechaNac, string tipoDoc, string nroDoc, string direccion, string email, string telefono, int? idTipoCliente,
            string clase, string usuario, string password, decimal sueldo, DateTime fechaIngreso, string estado, int? idTipoTrabajador)
        {
            DPersona Obj = new DPersona();
            Obj.Nombre = nombre;
            Obj.FechaNac = fechaNac;
            Obj.TipoDoc = tipoDoc;
            Obj.NumDoc = nroDoc;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            Obj.IdTipoCliente = idTipoCliente;
            Obj.Clase = clase;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Sueldo = sueldo;
            Obj.FechaIngreso = fechaIngreso;
            Obj.Estado = estado;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idPersona,string nombre, DateTime fechaNac, string tipoDoc, string nroDoc, string direccion, string email, string telefono, int? idTipoCliente,
           string clase, string usuario, string password, decimal sueldo, DateTime fechaIngreso, string estado, int? idTipoTrabajador)
        {
            DPersona Obj = new DPersona();
            Obj.IdPersona = idPersona;
            Obj.Nombre = nombre;
            Obj.FechaNac = fechaNac;
            Obj.TipoDoc = tipoDoc;
            Obj.NumDoc = nroDoc;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Telefono = telefono;
            Obj.IdTipoCliente = idTipoCliente;
            Obj.Clase = clase;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Sueldo = sueldo;
            Obj.FechaIngreso = fechaIngreso;
            Obj.Estado = estado;
            Obj.IdTipoTrabajador = idTipoTrabajador;
            return Obj.Editar(Obj);
        }
    }
}
