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
    public partial class _Login : Page
    {

        private LoginService _LoginService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //_LoginService = new LoginService();
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _LoginService = new LoginService();

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string guid = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            ServiceResult<UsuarioViewModel> result = _LoginService.Login(guid, password);
            if(!result.Success)
            {
                lblResult.Text = result.Msg;
            }
            else
            {
                Session["IsLoggedIn"] = true;
                Session["Usuario"] = result.Data;
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}