using MedicionHumedad.Autorizacion;
using MedicionHumedad.Services;
using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicionHumedad
{
    public partial class _CrearSensor : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                IsPersonalAuxiliar();
                _SensorService = new SensorService();
                _PlantacionService = new PlantacionService();
                BindPlantaciones();
            }
        }

        private void BindPlantaciones()
        {
            List<PlantacionViewModel> plantaciones = _PlantacionService.GetAllPlantaciones();
            ddlPlantacion.Items.Clear();
            foreach (var item in plantaciones)
            {
                ddlPlantacion.Items.Add(new ListItem { Text = item.Nombre, Value = item.Id.ToString() });
            }
            if (ddlPlantacion.Items.Count > 0)
            {
                ddlPlantacion.Items[0].Selected = true;
            }

        }
        protected void btnCrearSensor_Click(object sender, EventArgs e)
        {
            SensorViewModel sensor = new SensorViewModel
            {
                Activo = true,
                FechaCreacion = DateTimeOffset.Now,
                PlantacionId = Convert.ToInt32(ddlPlantacion.SelectedValue)
            };
            int sensorId = _SensorService.CrearSensor(sensor);
            if (sensorId > 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "El sensor ha sido creada con exito con el Id " + sensorId;

            }
            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Ha ocurrido un error al crear el sensor, intentelo nuevamente";
            }
        }

    }

}