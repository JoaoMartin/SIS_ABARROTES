using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPagoTrabajador
    {
        private int _IdPagoTrabajador;
        private int _IdTrabajador;
        private decimal _MontoPagado;
        private decimal _MontoDcto;
        private decimal _MontoAdelanto;
        private decimal _MontoHorasExtras;
        private decimal _MontoOtrosDctos;
        private DateTime _Fecha;
        private string _Obs;
        private string _Estado;
        private decimal _DiasTrabajados;
        private int _Factor;
        private string _Caja;

        public int IdPagoTrabajador
        {
            get
            {
                return _IdPagoTrabajador;
            }

            set
            {
                _IdPagoTrabajador = value;
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

        public decimal MontoPagado
        {
            get
            {
                return _MontoPagado;
            }

            set
            {
                _MontoPagado = value;
            }
        }

        public decimal MontoDcto
        {
            get
            {
                return _MontoDcto;
            }

            set
            {
                _MontoDcto = value;
            }
        }

        public decimal MontoAdelanto
        {
            get
            {
                return _MontoAdelanto;
            }

            set
            {
                _MontoAdelanto = value;
            }
        }

        public decimal MontoHorasExtras
        {
            get
            {
                return _MontoHorasExtras;
            }

            set
            {
                _MontoHorasExtras = value;
            }
        }

        public decimal MontoOtrosDctos
        {
            get
            {
                return _MontoOtrosDctos;
            }

            set
            {
                _MontoOtrosDctos = value;
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

        public decimal DiasTrabajados
        {
            get
            {
                return _DiasTrabajados;
            }

            set
            {
                _DiasTrabajados = value;
            }
        }

        public int Factor
        {
            get
            {
                return _Factor;
            }

            set
            {
                _Factor = value;
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

        public DPagoTrabajador() { }

        public DPagoTrabajador(int idPagoTrabajador,int idTrabajador,decimal montoPagado, decimal montoDcto, decimal montoAdelanto, decimal montoExtras, decimal montoOtrosDctos,
            DateTime fecha, string obs, string estado, decimal diasTrabajados, int factor, string caja)
        {
            this.IdPagoTrabajador = idPagoTrabajador;
            this.IdTrabajador = idTrabajador;
            this.MontoPagado = montoPagado;
            this.MontoDcto = montoDcto;
            this.MontoAdelanto = montoAdelanto;
            this.MontoHorasExtras = montoExtras;
            this.MontoOtrosDctos = montoOtrosDctos;
            this.Fecha = fecha;
            this.Obs = obs;
            this.Estado = estado;
            this.DiasTrabajados = diasTrabajados;
            this.Factor = factor;
            this.Caja = caja;
        }

        public string Insertar(DPagoTrabajador Pago)
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
                sqlCmd.CommandText = "sp_insertarPagoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPagoTrabajador = new SqlParameter();
                ParIdPagoTrabajador.ParameterName = "@idPagoTrabajador";
                ParIdPagoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdPagoTrabajador.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdPagoTrabajador);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Pago.IdTrabajador;
                sqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParMontoPagado = new SqlParameter();
                ParMontoPagado.ParameterName = "@montoPagado";
                ParMontoPagado.SqlDbType = SqlDbType.Decimal;
                ParMontoPagado.Precision = 8;
                ParMontoPagado.Scale = 2;
                ParMontoPagado.Value = Pago.MontoPagado;
                sqlCmd.Parameters.Add(ParMontoPagado);

                SqlParameter ParMontoDcto = new SqlParameter();
                ParMontoDcto.ParameterName = "@montoDcto";
                ParMontoDcto.SqlDbType = SqlDbType.Decimal;
                ParMontoDcto.Precision = 8;
                ParMontoDcto.Scale = 2;
                ParMontoDcto.Value = Pago.MontoDcto;
                sqlCmd.Parameters.Add(ParMontoDcto);

                SqlParameter ParMontoAdelanto = new SqlParameter();
                ParMontoAdelanto.ParameterName = "@montoAdelanto";
                ParMontoAdelanto.SqlDbType = SqlDbType.Decimal;
                ParMontoAdelanto.Precision = 8;
                ParMontoAdelanto.Scale = 2;
                ParMontoAdelanto.Value = Pago.MontoAdelanto;
                sqlCmd.Parameters.Add(ParMontoAdelanto);

                SqlParameter ParMontoHorasExtras = new SqlParameter();
                ParMontoHorasExtras.ParameterName = "@montoHorasExtras";
                ParMontoHorasExtras.SqlDbType = SqlDbType.Decimal;
                ParMontoHorasExtras.Precision = 8;
                ParMontoHorasExtras.Scale = 2;
                ParMontoHorasExtras.Value = Pago.MontoHorasExtras;
                sqlCmd.Parameters.Add(ParMontoHorasExtras);

                SqlParameter ParMontoOtrosDctos = new SqlParameter();
                ParMontoOtrosDctos.ParameterName = "@montoOtrosDctos";
                ParMontoOtrosDctos.SqlDbType = SqlDbType.Decimal;
                ParMontoOtrosDctos.Precision = 8;
                ParMontoOtrosDctos.Scale = 2;
                ParMontoOtrosDctos.Value = Pago.MontoOtrosDctos;
                sqlCmd.Parameters.Add(ParMontoOtrosDctos);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Pago.Fecha;
                sqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParObs = new SqlParameter();
                ParObs.ParameterName = "@obs";
                ParObs.SqlDbType = SqlDbType.VarChar;
                ParObs.Size = 100;
                ParObs.Value = Pago.Obs;
                sqlCmd.Parameters.Add(ParObs);

                SqlParameter ParEstado= new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Pago.Estado;
                sqlCmd.Parameters.Add(ParEstado);

                SqlParameter ParDiasTrabajados = new SqlParameter();
                ParDiasTrabajados.ParameterName = "@diasTrabajados";
                ParDiasTrabajados.SqlDbType = SqlDbType.Decimal;
                ParDiasTrabajados.Precision = 8;
                ParDiasTrabajados.Scale = 2;
                ParDiasTrabajados.Value = Pago.DiasTrabajados;
                sqlCmd.Parameters.Add(ParDiasTrabajados);

                SqlParameter ParFactor = new SqlParameter();
                ParFactor.ParameterName = "@factor";
                ParFactor.SqlDbType = SqlDbType.Int;
                ParFactor.Value = Pago.Factor;
                sqlCmd.Parameters.Add(ParFactor);

                SqlParameter ParCaja = new SqlParameter();
                ParCaja.ParameterName = "@caja";
                ParCaja.SqlDbType = SqlDbType.Char;
                ParCaja.Size = 2;
                ParCaja.Value = Pago.Caja;
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

        public string Eliminar(DPagoTrabajador Pago)
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
                sqlCmd.CommandText = "sp_eliminarPagoTrabajador";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPagoTrabajador = new SqlParameter();
                ParIdPagoTrabajador.ParameterName = "@idPagoTrabajador";
                ParIdPagoTrabajador.SqlDbType = SqlDbType.Int;
                ParIdPagoTrabajador.Value = Pago.IdPagoTrabajador;
                sqlCmd.Parameters.Add(ParIdPagoTrabajador);

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
            DataTable dtResultado = new DataTable("PagoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_mostrarPagoTrabajador";
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

        public DataTable ValidarPago(int idTrabajador, string mes)
        {
            DataTable dtResultado = new DataTable("PagoTrabajador");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_validarPagoTrabajador";
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
    }
}
