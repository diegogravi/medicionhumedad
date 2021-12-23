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
    public partial class _CrearPlantacion : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                IsPersonalAuxiliar();
                _PlantacionService = new PlantacionService();
            }
        }
        protected void btnCrearPlantacion_Click(object sender, EventArgs e)
        {
            PlantacionViewModel plantacion = new PlantacionViewModel
            {
                Nombre = txtNombre.Text
            };
            int plantacionId = _PlantacionService.CrearPlantacion(plantacion);
            if (plantacionId > 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "La plantacion " + plantacion.Nombre + " ha sido creada con exito con el Id " + plantacionId;

                txtNombre.Text = string.Empty;
            }
            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Ha ocurrido un error al crear la plantacion, intentelo nuevamente";
            }
        }

    }

}