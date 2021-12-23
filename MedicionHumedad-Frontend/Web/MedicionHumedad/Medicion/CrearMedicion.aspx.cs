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
    public partial class _CrearMedicion : AuthenticatedPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                _PlantacionService = new PlantacionService();
                _FrutoService = new FrutoService();
                _MedicionService = new MedicionService();
                _SensorService = new SensorService();
                BindPlantaciones();
                BindFrutos();
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
            
            BindSensores();
        }

        private void BindFrutos()
        {
            List<FrutoViewModel> frutos = _FrutoService.GetAllFrutos();
            ddlFruto.Items.Clear();
            foreach (var item in frutos)
            {
                ddlFruto.Items.Add(new ListItem { Text = item.Nombre.ToString(), Value = item.Id.ToString() });
            }
            if (ddlFruto.Items.Count > 0)
            {
                ddlFruto.Items[0].Selected = true;
            }
        }

        protected void ddlPlantacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSensores();
        }


        private void BindSensores()
        {
            int plantacionId = Convert.ToInt32(ddlPlantacion.SelectedItem.Value);

            if(plantacionId == 0)
            {
                return;
            }

            List<SensorViewModel> sensores = _SensorService.GetSensorByPlantacionId(plantacionId);

            lstSensores.Items.Clear();
            foreach (var item in sensores)
            {
                lstSensores.Items.Add(new ListItem { Text = item.Id.ToString(), Value = item.Id.ToString() });
            }
            if(lstSensores.Items.Count>0)
            {
                lstSensores.Items[0].Selected = true;
            }
        }

        protected void btnCrearMedicion_Click(object sender, EventArgs e)
        {
            if(lstSensores.Items.Count == 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "No hay sensores disponibles, por favor busque en otra plantacion";
                return;
            }
            var fechaDesde = DateTimeOffset.Parse(calendarFecha.SelectedDate.ToShortDateString() + " " + txtHoraDesde.Text + " " + ddlDesdeAMPM.Text);
            MedicionViewModel medicion = new MedicionViewModel
            {
                Descripcion = "Ingresada manualmente",
                Fecha = fechaDesde,
                FrutoId = Convert.ToInt32(ddlFruto.SelectedValue),
                PlantacionId = Convert.ToInt32(ddlPlantacion.SelectedValue),
                SensorId = Convert.ToInt32(lstSensores.SelectedValue),
                Porcentaje = Convert.ToDecimal(txtPorcentaje.Text),
                UsuarioId = this.Usuario.Id
            };
            int medicionId = _MedicionService.CrearMedicion(medicion);
            if(medicionId>0)
            {
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "La medicion " + medicionId + " de " + medicion.Porcentaje.ToString() + "% ha sido creada con exito para el dia " + fechaDesde.ToString("MM/dd/yyyy h:mm tt") + " en el Sensor " + medicion.SensorId;

                BindPlantaciones();
            }
            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Ha ocurrido un error al crear la medicion, intentelo nuevamente";
            }
        
        }
    }
}