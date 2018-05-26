using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoCliente
    {
        private int _IdTipoCliente;
        private string _Nombre;
        private string _Descripcion;
        private string _Estado;
        private string _TextoBuscar;

        public int IdTipoCliente
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

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
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

        public DTipoCliente() { }

        public DTipoCliente(int idTipoCliente, string nombre, string descripcion, string estado, string textoBuscar)
        {
            this.IdTipoCliente = idTipoCliente;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DTipoCliente TipoCliente)
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
                sqlCmd.CommandText = "sp_insertarTipoCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoCliente = new SqlParameter();
                ParIdTipoCliente.ParameterName = "@idTipoCliente";
                ParIdTipoCliente.SqlDbType = SqlDbType.Int;
                ParIdTipoCliente.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdTipoCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = TipoCliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 150;
                ParDescripcion.Value = TipoCliente.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
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

        public string Editar(DTipoCliente TipoCliente)
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
                sqlCmd.CommandText = "sp_editarTipoCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoCategoria = new SqlParameter();
                ParIdTipoCategoria.ParameterName = "@idTipoCliente";
                ParIdTipoCategoria.SqlDbType = SqlDbType.Int;
                ParIdTipoCategoria.Value = TipoCliente.IdTipoCliente;
                sqlCmd.Parameters.Add(ParIdTipoCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = TipoCliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 150;
                ParDescripcion.Value = TipoCliente.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el Registro";
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

        public string Eliminar(DTipoCliente TipoCliente)
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
                sqlCmd.CommandText = "sp_eliminarTipoCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoCategoria = new SqlParameter();
                ParIdTipoCategoria.ParameterName = "@idTipoCliente";
                ParIdTipoCategoria.SqlDbType = SqlDbType.Int;
                ParIdTipoCategoria.Value = TipoCliente.IdTipoCliente;
                sqlCmd.Parameters.Add(ParIdTipoCategoria);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el Registro";
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

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("TipoCliente");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarTipoCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public DataTable Buscar(DTipoCliente TipoCliente)
        {
            DataTable dtResultado = new DataTable("Categoria");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_buscarTipoCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TipoCliente.TextoBuscar;

                sqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }
    }
}
