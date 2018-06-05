using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmRDctoTrabajador : Form
    {
        public frmRDctoTrabajador()
        {
            InitializeComponent();
        }

        private void frmRDctoTrabajador_Load(object sender, EventArgs e)
        {
            try
            {
                ExcelFormatOptions objExcel = new ExcelFormatOptions();

                string fechaInicio = "";
                string fechaFin = "";
                int idTrabajador = 0;
                string estado = frmReporteDctoTrabajador.f1.cbEstado.Text;
                if (frmReporteDctoTrabajador.f1.cbTrabajador.Checked == true)
                {
                    idTrabajador = Convert.ToInt32(frmReporteDctoTrabajador.f1.cbEmpleado.SelectedValue);
                }
                else if (frmReporteDctoTrabajador.f1.cbTrabajador.Checked == false)
                {
                    idTrabajador = 0;
                }


                fechaInicio = frmReporteDctoTrabajador.f1.dtpFechaInicio.Value.ToString("yyyy-MM-dd" + " 00:00:00");
                fechaFin = frmReporteDctoTrabajador.f1.dtpFechaFin.Value.ToString("yyyy-MM-dd" + " 23:59:59");

                //int idProducto = Convert.ToInt32(frmReporteVentasProducto.f1.cbProducto.SelectedValue);

                ReportDocument repdoc = new ReportDocument();
                // repdoc.Load(@"C:\Users\vioma\OneDrive\Documentos\Visual Studio 2017\Projects\SisVentas_ResAlm\CapaPresentacion\Reportes/RVentaProducto.rpt");
                repdoc.Load(@"D:\Reportes\RDescuentoTrabajador.rpt");

                ParameterFieldDefinitions pfds;
                ParameterFieldDefinition pfd;

                ParameterValues pvs = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                pdv.Value = Convert.ToDateTime(fechaInicio);
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@fechaInicio"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);


                pdv.Value = Convert.ToDateTime(fechaFin);
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@fechaFin"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                pdv.Value = idTrabajador;
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@idTrabajador"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);

                pdv.Value = estado;
                pfds = repdoc.DataDefinition.ParameterFields;
                pfd = pfds["@estado"];
                pvs.Add(pdv);
                pfd.ApplyCurrentValues(pvs);



                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                crConnectionInfo.ServerName = @"EQUIPO\SQLEXPRESS";
                crConnectionInfo.DatabaseName = "BD_RESTAURANTE";
                crConnectionInfo.UserID = "admin";
                crConnectionInfo.Password = "1234";

                CrTables = repdoc.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }


                cvVentas.ReportSource = repdoc;
                cvVentas.Refresh();
                objExcel.ExcelUseConstantColumnWidth = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR" + ex);
            }
        }
    }
}
