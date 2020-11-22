using OfficeHoteling.Autorizacion;
using OfficeHoteling.Services;
using OfficeHoteling.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHoteling
{
    public partial class _StaffHome : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                IsPersonalAuxiliar();
                _ReservaService = new ReservaService();
                _CheckinService = new CheckinService();
                _StaffService = new StaffService();
                BindGridStaff();
            }
        }

        private void BindGridStaff()
        {
            GVStaff.DataSource = GetAllStaff();
            GVStaff.DataBind();
        }
        private List<StaffViewModel> GetAllStaff()
        {
            var results = _StaffService.GetAllStaff();
            return results;
        }

        protected void GVStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Activate")
            {
                int staffId = Convert.ToInt32(e.CommandArgument);
                var staffUpdated = _StaffService.ActivateStaffByStaffId(staffId);
                if (staffUpdated)
                {
                    BindGridStaff();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha reactivado el staff exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Hay un problema con el activado, intentelo nuevamente";
                }
            }
            else if (e.CommandName == "Inactivate")
            {
                int staffId = Convert.ToInt32(e.CommandArgument);
                var staffUpdated = _StaffService.InactivateStaffByStaffId(staffId);
                if (staffUpdated)
                {
                    BindGridStaff();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha borrado el staff exitosamente!";
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