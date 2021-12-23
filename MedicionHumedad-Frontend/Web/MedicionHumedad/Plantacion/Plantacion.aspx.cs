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
    public partial class _Plantacion : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                IsPersonalAuxiliar();
                _PlantacionService = new PlantacionService();
                BindGridPlantaciones();
            }
        }

        private void BindGridPlantaciones()
        {
            GVPlantaciones.DataSource = GetPlantacionesByUsuarioId();
            GVPlantaciones.DataBind();
        }
        private List<PlantacionViewModel> GetPlantacionesByUsuarioId()
        {
            int UsuarioId = ((UsuarioViewModel)Session["Usuario"]).Id;
            var results = _PlantacionService.GetAllPlantaciones();
            return results;
        }

        protected void GVPlantaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int plantacionId = Convert.ToInt32(e.CommandArgument);
                var medicionBorrada = _PlantacionService.BorrarPlantacionByPlantacionId(plantacionId);
                if (medicionBorrada)
                {
                    BindGridPlantaciones();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha borrado la plantacion exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "No se pudo borrar la plantacion, ya que tiene sensores asociados";
                }
            }
        }
    }
}