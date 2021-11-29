using MedicionHumedad.Services;
using MedicionHumedad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MedicionHumedad.Autorizacion
{
    public abstract class AuthenticatedPage : Page
    {
        //Services
        protected EspacioService _EspacioService
        {
            get { return (EspacioService)Session["EspacioService"]; }
            set { Session["EspacioService"] = value; }
        }
        protected EdificioService _EdificioService
        {
            get { return (EdificioService)Session["EdificioService"]; }
            set { Session["EdificioService"] = value; }
        }
        protected PisoService _PisoService
        {
            get { return (PisoService)Session["PisoService"]; }
            set { Session["PisoService"] = value; }
        }

        protected ReservaService _ReservaService
        {
            get { return (ReservaService)Session["ReservaService"]; }
            set { Session["ReservaService"] = value; }
        }
        protected CheckinService _CheckinService
        {
            get { return (CheckinService)Session["CheckinService"]; }
            set { Session["CheckinService"] = value; }
        }
        protected CheckoutService _CheckoutService
        {
            get { return (CheckoutService)Session["CheckoutService"]; }
            set { Session["CheckoutService"] = value; }
        }
        protected UsuarioService _UsuarioService
        {
            get { return (UsuarioService)Session["UsuarioService"]; }
            set { Session["UsuarioService"] = value; }
        }

        protected bool isLoggedIn
        {
            get
             {
                object SessionObject = HttpContext.Current.Session["IsLoggedIn"];
                return (SessionObject == null) ? false : (bool)SessionObject;
            }
            set
            {
                HttpContext.Current.Session["IsLoggedIn"] = value;
            }
        }
        protected UsuarioViewModel Usuario
        {
            get
            {
                object SessionObject = HttpContext.Current.Session["Usuario"];
                return (SessionObject == null) ? new UsuarioViewModel() : (UsuarioViewModel)SessionObject;
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }
        public void IsLoggedIn()
        {
            if(!isLoggedIn)
            {
                HttpContext.Current.Response.Redirect("~/Autorizacion/Login.aspx");
            }
        }
        public void IsPersonalAuxiliar()
        {
            if (Usuario != null && !Usuario.EsAdminOIrrigador)
            {
                HttpContext.Current.Response.Redirect("~/Autorizacion/unauthorized.aspx");
            }
        }

    }
}