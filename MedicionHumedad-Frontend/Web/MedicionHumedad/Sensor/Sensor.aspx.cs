using MedicionHumedad.Autorizacion;
using MedicionHumedad.Services;
using MedicionHumedad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicionHumedad
{
    public partial class _Sensor : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                IsPersonalAuxiliar();
                _SensorService = new SensorService();
                BindGridSensores();
            }
        }

        private void BindGridSensores()
        {
            GVSensores.DataSource = GetPlantacionesByUsuarioId();
            GVSensores.DataBind();
        }
        private List<SensorViewModel> GetPlantacionesByUsuarioId()
        {
            int UsuarioId = ((UsuarioViewModel)Session["Usuario"]).Id;
            var results = _SensorService.GetAllSensores();
            return results;
        }

        protected void GVSensores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int sensorId = Convert.ToInt32(e.CommandArgument);
                var sensorBorrado = _SensorService.BorrarSensorBySensorId(sensorId);
                if (sensorBorrado)
                {
                    BindGridSensores();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha desactivado el sensor exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "No se pudo desactivar el sensor, ya que tiene mediciones asociadas";
                }
            }
            if (e.CommandName == "Activate")
            {
                int sensorIdActivate = Convert.ToInt32(e.CommandArgument);
                var UsuarioUpdated = _SensorService.ActivarSensorBySensorId(sensorIdActivate);
                if (UsuarioUpdated)
                {
                    BindGridSensores();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha reactivado el Sensor exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Hay un problema con el activado, intentelo nuevamente";
                }
            }
        }
    }
}