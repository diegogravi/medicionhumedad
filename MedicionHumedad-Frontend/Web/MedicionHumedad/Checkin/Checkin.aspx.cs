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
    public partial class _Checkin : AuthenticatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                _ReservaService = new ReservaService();
                _CheckinService = new CheckinService();
                _CheckoutService = new CheckoutService();
                BindGridCheckins();
            }
        }

        private void BindGridCheckins()
        {
            GVCheckins.DataSource = GetCheckinByStaffId();
            GVCheckins.DataBind();
        }
        private List<CheckinViewModel> GetCheckinByStaffId()
        {
            int staffId = ((StaffViewModel)Session["Staff"]).Id;
            var result = _CheckinService.GetCurrentCheckinByStaffId(staffId);
            if(result == null)
            {
                return null;
            }
            return new List<CheckinViewModel> { result };
        }

        protected void GVCheckins_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Checkout")
            {
                int checkinId = Convert.ToInt32(e.CommandArgument);

                var checkoutId = _CheckoutService.CheckoutByCheckinId(checkinId);
                var checkinUpdated = _CheckinService.InactivateCheckinByCheckinId(checkinId);

                if (checkoutId > 0)
                {
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha checkouteado exitosamente!";

                    BindGridCheckins();
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Ha ocurrido un error al intentar checkoutear, intentelo nuevamente";
                }
            }
        }
    }
}