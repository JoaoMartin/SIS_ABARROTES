using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPersona
    {
        private int _IdPersona;
        private string _Nombre;
        private DateTime _FechaNac;
        private string _TipoDoc;
        private string _NumDoc;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private int? _IdTipoCliente;
        private string _Clase;
        private string _Usuario;
        private string _Password;
        private int? _IdTipoTrabajador;
        private string _TextoBuscar;
        private decimal _Sueldo;
        private DateTime _FechaIngreso;
        private string _Estado;

        public int IdPersona
        {
            get
            {
                return _IdPersona;
            }

            set
            {
                _IdPersona = value;
            }
        }

        public string TipoDoc
        {
            get
            {
                return _TipoDoc;
            }

            set
            {
                _TipoDoc = value;
            }
        }

        public string NumDoc
        {
            get
            {
                return _NumDoc;
            }

            set
            {
                _NumDoc = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public int? IdTipoCliente
        {
            get
            {
                return _IdTipoCliente;
            }

            set
            {
                _IdTipoCliente = value;
            }
        }

        public string Clase
        {
            get
            {
                return _Clase;
            }

            set
            {
                _Clase = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public int? IdTipoTrabajador
        {
            get
            {
                return _IdTipoTrabajador;
            }

            set
            {
                _IdTipoTrabajador = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        public decimal Sueldo
        {
            get
            {
                return _Sueldo;
            }

            set
            {
                _Sueldo = value;
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return _FechaIngreso;
            }

            set
            {
                _FechaIngreso = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public DateTime FechaNac
        {
            get
            {
                return _FechaNac;
            }

            set
            {
                _FechaNac = value;
            }
        }

        public DPersona() { }
        
        public DPersona(int idPersona,string nombre, DateTime fechaNac,string tipoDoc, string nroDoc,string direccion, string email,string telefono,int idTipoCliente,
            string clase,string usuario,string password,decimal sueldo,DateTime fechaIngreso,string estado,int idTipoTrabajador)
        {
            this.IdPersona = idPersona;
            this.Nombre = nombre;
            this.FechaNac = fechaNac;
            this.TipoDoc = tipoDoc;
            this.NumDoc = nroDoc;
            this.Direccion = direccion;
            this.Email = email;
            this.Telefono = telefono;
            this.IdTipoCliente = idTipoCliente;
            this.Clase = clase;
            this.Usuario = usuario;
            this.Password = password;
            this.Sueldo = sueldo;
            this.FechaIngreso = fechaIngreso;
            this.Estado = estado;
            this.IdTipoTrabajador = idTipoTrabajador;
        }

        public string Insertar(DPersona Persona)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_insertarPersona";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idPersona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdPersona);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Persona.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Persona.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 24;
                ParTipoDoc.Value = Persona.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@numDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 15;
                ParNumDoc.Value = Persona.NumDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 150;
                ParDir.Value = Persona.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Persona.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 30;
                ParEmail.Value = Persona.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParIdTipoCliente = new SqlParameter();
                ParIdTipoCliente.ParameterName = "@idTipoCliente";
                ParIdTipoCliente.SqlDbType = SqlDbType.Int;
                ParIdTipoCliente.Value = Persona.IdTipoCliente;
                sqlCmd.Parameters.Add(ParIdTipoCliente);

                SqlParameter ParClase = new SqlParameter();
                ParClase.ParameterName = "@clase";
                ParClase.SqlDbType = SqlDbType.Char;
                ParClase.Size = 1;
                ParClase.Value = Persona.Clase;
                sqlCmd.Parameters.Add(ParClase);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Persona.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Persona.Password;
                sqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParSueldo = new SqlParameter();
                ParSueldo.ParameterName = "@sueldo";
                ParSueldo.SqlDbType = SqlDbType.Decimal;
                ParSueldo.Precision = 8;
                ParSueldo.Scale = 2;
                ParSueldo.Value = Persona.Sueldo;
                sqlCmd.Parameters.Add(ParSueldo);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaIngreso";
                ParFechaIngreso.SqlDbType = SqlDbType.Date;
                ParFechaIngreso.Value = Persona.FechaIngreso;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Persona.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTipoTrabajador = new SqlParameter();
                ParIdTipoTrabajador.ParameterName = "@idTipoTrabajador";
                ParIdTipoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTipoTrabajador.Value = Persona.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipoTrabajador);

              
                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }


        public string Editar(DPersona Persona)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                sqlCon.Open();
                //Comandos
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_editarPersona";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@idPersona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = Persona.IdPersona;
                sqlCmd.Parameters.Add(ParIdPersona);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Persona.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@fechNac";
                ParFechaNac.SqlDbType = SqlDbType.Date;
                ParFechaNac.Value = Persona.FechaNac;
                sqlCmd.Parameters.Add(ParFechaNac);

                SqlParameter ParTipoDoc = new SqlParameter();
                ParTipoDoc.ParameterName = "@tipoDoc";
                ParTipoDoc.SqlDbType = SqlDbType.VarChar;
                ParTipoDoc.Size = 24;
                ParTipoDoc.Value = Persona.TipoDoc;
                sqlCmd.Parameters.Add(ParTipoDoc);

                SqlParameter ParNumDoc = new SqlParameter();
                ParNumDoc.ParameterName = "@numDoc";
                ParNumDoc.SqlDbType = SqlDbType.VarChar;
                ParNumDoc.Size = 15;
                ParNumDoc.Value = Persona.NumDoc;
                sqlCmd.Parameters.Add(ParNumDoc);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 150;
                ParDir.Value = Persona.Direccion;
                sqlCmd.Parameters.Add(ParDir);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 50;
                ParTelefono.Value = Persona.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 30;
                ParEmail.Value = Persona.Email;
                sqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParIdTipoCliente = new SqlParameter();
                ParIdTipoCliente.ParameterName = "@idTipoCliente";
                ParIdTipoCliente.SqlDbType = SqlDbType.Int;
                ParIdTipoCliente.Value = Persona.IdTipoCliente;
                sqlCmd.Parameters.Add(ParIdTipoCliente);

                SqlParameter ParClase = new SqlParameter();
                ParClase.ParameterName = "@clase";
                ParClase.SqlDbType = SqlDbType.Char;
                ParClase.Size = 1;
                ParClase.Value = Persona.Clase;
                sqlCmd.Parameters.Add(ParClase);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Persona.Usuario;
                sqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Persona.Password;
                sqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParSueldo = new SqlParameter();
                ParSueldo.ParameterName = "@sueldo";
                ParSueldo.SqlDbType = SqlDbType.Decimal;
                ParSueldo.Precision = 8;
                ParSueldo.Scale = 2;
                ParSueldo.Value = Persona.Sueldo;
                sqlCmd.Parameters.Add(ParSueldo);

                SqlParameter ParFechaIngreso = new SqlParameter();
                ParFechaIngreso.ParameterName = "@fechaIngreso";
                ParFechaIngreso.SqlDbType = SqlDbType.Date;
                ParFechaIngreso.Value = Persona.FechaIngreso;
                sqlCmd.Parameters.Add(ParFechaIngreso);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Persona.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTipoTrabajador = new SqlParameter();
                ParIdTipoTrabajador.ParameterName = "@idTipoTrabajador";
                ParIdTipoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTipoTrabajador.Value = Persona.IdTipoTrabajador;
                sqlCmd.Parameters.Add(ParIdTipoTrabajador);


                rpta = sqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }
    }
}
