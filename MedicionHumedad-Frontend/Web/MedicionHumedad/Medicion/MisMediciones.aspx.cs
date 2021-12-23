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
    public partial class _MisReservas : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                _MedicionService = new MedicionService();
                BindGridMediciones();
            }
        }

        private void BindGridMediciones()
        {
            GVMediciones.DataSource = GetMedicionesByUsuarioId();
            GVMediciones.DataBind();
        }
        private List<MedicionViewModel> GetMedicionesByUsuarioId()
        {
            int UsuarioId = ((UsuarioViewModel)Session["Usuario"]).Id;
            var results = _MedicionService.GetMedicionesByUsuarioId(UsuarioId);
            return results;
        }

        protected void GVMediciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int medicionId = Convert.ToInt32(e.CommandArgument);
                var medicionBorrada = _MedicionService.BorrarMedicionByMedicionId(medicionId);
                if (medicionBorrada)
                {
                    BindGridMediciones();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha borrado la medicion exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "No se pudo borrar la medicion, intente borrarla nuevamente o contactese con el administrador";
                }
            }
        }
    }
}