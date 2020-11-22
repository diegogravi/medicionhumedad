using OfficeHoteling.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHoteling
{
    public partial class StaffMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StaffViewModel staff = null;
                if (Session["Staff"] != null)
                {
                    staff = ((StaffViewModel)Session["Staff"]);
                }
                if (staff != null)
                {
                    hlStaffHome.Visible = staff.EsPersonalAuxiliar;
                    
                    LblName.Text = staff.Nombre + " " + staff.Apellido;
                    lnkLogout.Visible = true;
                }
                else
                {
                    hlStaffHome.Visible = false;
                    LblName.Text = "No hay usuario logeado";
                    lnkLogout.Visible = false;
                }
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["IsLoggedIn"] = false;
            Session["Staff"] = null;
            Response.Redirect("~/Autorizacion/Login.aspx");
        }
    }
}