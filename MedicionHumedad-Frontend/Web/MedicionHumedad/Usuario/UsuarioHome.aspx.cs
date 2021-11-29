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
    public partial class _UsuarioHome : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                IsPersonalAuxiliar();
                _ReservaService = new ReservaService();
                _CheckinService = new CheckinService();
                _UsuarioService = new UsuarioService();
                BindGridUsuario();
            }
        }

        private void BindGridUsuario()
        {
            GVUsuario.DataSource = GetAllUsuario();
            GVUsuario.DataBind();
        }
        private List<UsuarioViewModel> GetAllUsuario()
        {
            var results = _UsuarioService.GetAllUsuario();
            return results;
        }

        protected void GVUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Activate")
            {
                int UsuarioId = Convert.ToInt32(e.CommandArgument);
                var UsuarioUpdated = _UsuarioService.ActivateUsuarioByUsuarioId(UsuarioId);
                if (UsuarioUpdated)
                {
                    BindGridUsuario();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha reactivado el Usuario exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Hay un problema con el activado, intentelo nuevamente";
                }
            }
            else if (e.CommandName == "Inactivate")
            {
                int UsuarioId = Convert.ToInt32(e.CommandArgument);
                var UsuarioUpdated = _UsuarioService.InactivateUsuarioByUsuarioId(UsuarioId);
                if (UsuarioUpdated)
                {
                    BindGridUsuario();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha borrado el Usuario exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Hay un problema con el desactivado, intentelo nuevamente";
                }
            }
        }
    }
}