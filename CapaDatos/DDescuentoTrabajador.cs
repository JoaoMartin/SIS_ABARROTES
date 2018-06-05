using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDescuentoTrabajador
    {
        private int _IdDescuentoTrabajador;
        private int _IdTrabajador;
        private decimal _Monto;
        private string _Motivo;
        private DateTime _Fecha;
        private string _Estado;
        private string _Obs;

        public int IdDescuentoTrabajador
        {
            get
            {
                return _IdDescuentoTrabajador;
            }

            set
            {
                _IdDescuentoTrabajador = value;
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

        public string Motivo
        {
            get
            {
                return _Motivo;
            }

            set
            {
                _Motivo = value;
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

        public string Obs
        {
            get
            {
                return _Obs;
            }

            set
            {
                _Obs = value;
            }
        }

        public DDescuentoTrabajador() { }

        public DDescuentoTrabajador(int idDescuentoTrabajador,int idTrabajador,decimal monto, string motivo, DateTime fecha, string estado, string obs)
        {
            this.IdDescuentoTrabajador = idDescuentoTrabajador;
            this.IdTrabajador = idTrabajador;
            this.Monto = monto;
            this.Motivo = motivo;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Obs = obs;
        }

        public string Insertar(DDescuentoTrabajador Descuento)
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
                sqlCmd.CommandText = "sp_insertarDescuentoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDescuentoTrabajador = new SqlParameter();
                ParIdDescuentoTrabajador.ParameterName = "@idDescuentoTrabajador";
                ParIdDescuentoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdDescuentoTrabajador.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdDescuentoTrabajador);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Descuento.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 8;
                ParMonto.Scale = 2;
                ParMonto.Value = Descuento.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 256;
                ParMotivo.Value = Descuento.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Descuento.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 20;
                ParEstado.Value = Descuento.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 10;
                ParObs.Value = Descuento.Obs;
                sqlCmd.Parameters.Add(ParObs);

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

        public string Editar(DDescuentoTrabajador Descuento)
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
                sqlCmd.CommandText = "sp_editarDescuentoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDescuentoTrabajador = new SqlParameter();
                ParIdDescuentoTrabajador.ParameterName = "@idDescuentoTrabajador";
                ParIdDescuentoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdDescuentoTrabajador.Value = Descuento.IdDescuentoTrabajador;
                sqlCmd.Parameters.Add(ParIdDescuentoTrabajador);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Descuento.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Decimal;
                ParMonto.Precision = 8;
                ParMonto.Scale = 2;
                ParMonto.Value = Descuento.Monto;
                sqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParMotivo = new SqlParameter();
                ParMotivo.ParameterName = "@motivo";
                ParMotivo.SqlDbType = SqlDbType.VarChar;
                ParMotivo.Size = 256;
                ParMotivo.Value = Descuento.Motivo;
                sqlCmd.Parameters.Add(ParMotivo);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Descuento.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 20;
                ParEstado.Value = Descuento.Estado;
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

        public string Eliminar(DDescuentoTrabajador Descuento)
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
                sqlCmd.CommandText = "sp_eliminarDescuentoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDescuentoTrabajador = new SqlParameter();
                ParIdDescuentoTrabajador.ParameterName = "@idDescuentoTrabajador";
                ParIdDescuentoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdDescuentoTrabajador.Value = Descuento.IdDescuentoTrabajador;
                sqlCmd.Parameters.Add(ParIdDescuentoTrabajador);

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
            DataTable dtResultado = new DataTable("DescuentoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarDescuentoTrabajador";
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
                sqlCmd.CommandText = "sp_editarEstadoDescuento";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdDescuentoTrabajador = new SqlParameter();
                ParIdDescuentoTrabajador.ParameterName = "@idDescuentoTrabajador";
                ParIdDescuentoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdDescuentoTrabajador.Value = idAdelanto;
                sqlCmd.Parameters.Add(ParIdDescuentoTrabajador);

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

        public DataTable reporteDctos(DateTime fechaInicio, DateTime fechaFin, string estado, int idTrabajador)
        {
            DataTable dtResultado = new DataTable("Venta");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_reporteDctos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechaInicio";
                ParFechaInicio.SqlDbType = SqlDbType.DateTime;
                ParFechaInicio.Value = fechaInicio;
                sqlCmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fechaFin";
                ParFechaFin.SqlDbType = SqlDbType.DateTime;
                ParFechaFin.Value = fechaFin;
                sqlCmd.Parameters.Add(ParFechaFin);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = idTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);


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
