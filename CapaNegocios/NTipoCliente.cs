using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

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
    }
}
