using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCredito
    {
        private int _IdCredito;
        private int _IdVenta;
        private string _FormaPago;
        private string _Descr;
        private string _Estado;

        public int IdCredito
        {
            get
            {
                return _IdCredito;
            }

            set
            {
                _IdCredito = value;
            }
        }

        public int IdVenta
        {
            get
            {
                return _IdVenta;
            }

            set
            {
                _IdVenta = value;
            }
        }

        public string FormaPago
        {
            get
            {
                return _FormaPago;
            }

            set
            {
                _FormaPago = value;
            }
        }

        public string Descr
        {
            get
            {
                return _Descr;
            }

            set
            {
                _Descr = value;
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

        public DCredito() { }

        public DCredito(int idCredito, int idVenta, string formaPago, string descr, string estado)
        {
            this.IdCredito = idCredito;
            this.IdVenta = IdVenta;
            this.FormaPago = formaPago;
            this.Descr = descr;
            this.Estado = estado;
        }

        public string Insertar(DCredito Credito)
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
                sqlCmd.CommandText = "sp_insertarCredito";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCredito = new SqlParameter();
                ParIdCredito.ParameterName = "@idCredito";
                ParIdCredito.SqlDbType = SqlDbType.Int;
                ParIdCredito.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCredito);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Credito.IdVenta;
                sqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@formaPago";
                ParFormaPago.SqlDbType = SqlDbType.VarChar;
                ParFormaPago.Size = 50;
                ParFormaPago.Value = Credito.FormaPago;
                sqlCmd.Parameters.Add(ParFormaPago);

                SqlParameter ParDesc = new SqlParameter();
                ParDesc.ParameterName = "@descr";
                ParDesc.SqlDbType = SqlDbType.VarChar;
                ParDesc.Size = 100;
                ParDesc.Value = Credito.Descr;
                sqlCmd.Parameters.Add(ParDesc);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Char;
                ParEstado.Size = 1;
                ParEstado.Value = Credito.Estado;
                sqlCmd.Parameters.Add(ParEstado);


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
    }
}
