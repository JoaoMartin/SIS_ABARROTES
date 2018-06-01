using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DAdelanto
    {
        private int _IdAdelanto;
        private int _IdTrabajador;
        private decimal _Monto;
        private DateTime _Fecha;
        private string _Estado;
        private string _Caja;

        public int IdAdelanto
        {
            get
            {
                return _IdAdelanto;
            }

            set
            {
                _IdAdelanto = value;
            }
        }

        public int IdTrabajador
        {
            get
            {
                return _IdTrabajador;
            }

            set
            {
                _IdTrabajador = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return _Monto;
            }

            set
            {
                _Monto = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
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

        public string Caja
        {
            get
            {
                return _Caja;
            }

            set
            {
                _Caja = value;
            }
        }

        public DAdelanto() { }

        public DAdelanto(int idAdelanto, int idTrabajador, decimal monto, DateTime fecha, string estado, string caja)
        {
            this.IdAdelanto = idAdelanto;
            this.IdTrabajador = idTrabajador;
            this.Monto = monto;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Caja = caja;
        }

        public string Insertar(DAdelanto Adelanto)
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
                sqlCmd.CommandText = "sp_insertarAdelanto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAdelanto = new SqlParameter();
                ParIdAdelanto.ParameterName = "@idAdelanto";
                ParIdAdelanto.SqlDbType = SqlDbType.Int;
                ParIdAdelanto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdAdelanto);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Adelanto.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 8;
                ParMonto.Scale = 2;
                ParMonto.Value = Adelanto.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Adelanto.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 20;
                ParEstado.Value = Adelanto.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParCaja = new SqlParameter();
                ParCaja.ParameterName = "@caja";
                ParCaja.SqlDbType = SqlDbType.Char;
                ParCaja.Size = 2;
                ParCaja.Value = Adelanto.Caja;
                sqlCmd.Parameters.Add(ParCaja);


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

        public string Editar(DAdelanto Adelanto)
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
                sqlCmd.CommandText = "sp_editarAdelanto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAdelanto = new SqlParameter();
                ParIdAdelanto.ParameterName = "@idAdelanto";
                ParIdAdelanto.SqlDbType = SqlDbType.Int;
                ParIdAdelanto.Value = Adelanto.IdAdelanto;
                sqlCmd.Parameters.Add(ParIdAdelanto);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Adelanto.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 8;
                ParMonto.Scale = 2;
                ParMonto.Value = Adelanto.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Adelanto.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 20;
                ParEstado.Value = Adelanto.Estado;
                sqlCmd.Parameters.Add(ParEstado);

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

        public string Eliminar(DAdelanto Adelanto)
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
                sqlCmd.CommandText = "sp_eliminarAdelanto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAdelanto = new SqlParameter();
                ParIdAdelanto.ParameterName = "@idAdelanto";
                ParIdAdelanto.SqlDbType = SqlDbType.Int;
                ParIdAdelanto.Value = Adelanto.IdAdelanto;
                sqlCmd.Parameters.Add(ParIdAdelanto);

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

        public DataTable Mostrar(int idTrabajador, string mes)
        {
            DataTable dtResultado = new DataTable("Adelanto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarAdelantoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = idTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParMes = new SqlParameter();
                ParMes.ParameterName = "@mes";
                ParMes.SqlDbType = SqlDbType.VarChar;
                ParMes.Size = 14;
                ParMes.Value = mes;
                sqlCmd.Parameters.Add(ParMes);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;
        }

        public string EditarEstado(string estado, int idAdelanto)
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
                sqlCmd.CommandText = "sp_editarEstadoAdelanto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdAdelanto = new SqlParameter();
                ParIdAdelanto.ParameterName = "@idAdelanto";
                ParIdAdelanto.SqlDbType = SqlDbType.Int;
                ParIdAdelanto.Value = idAdelanto;
                sqlCmd.Parameters.Add(ParIdAdelanto);

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

    }
}
