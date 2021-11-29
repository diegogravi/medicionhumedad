using MedicionHumedad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicionHumedad
{
    public partial class UsuarioMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioViewModel Usuario = null;
                if (Session["Usuario"] != null)
                {
                    Usuario = ((UsuarioViewModel)Session["Usuario"]);
                }
                if (Usuario != null)
                {
                    hlUsuarioHome.Visible = Usuario.EsAdminOIrrigador;
                    
                    LblName.Text = Usuario.Nombre + " " + Usuario.Apellido;
                    lnkLogout.Visible = true;
                }
                else
                {
                    hlUsuarioHome.Visible = false;
                    LblName.Text = "No hay usuario logeado";
                    lnkLogout.Visible = false;
                }
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["IsLoggedIn"] = false;
            Session["Usuario"] = null;
            Response.Redirect("~/Autorizacion/Login.aspx");
        }
    }
}