using OfficeHoteling.Services;
using OfficeHoteling.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace OfficeHoteling.Autorizacion
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
        protected StaffService _StaffService
        {
            get { return (StaffService)Session["StaffService"]; }
            set { Session["StaffService"] = value; }
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
        protected StaffViewModel staff
        {
            get
            {
                object SessionObject = HttpContext.Current.Session["Staff"];
                return (SessionObject == null) ? new StaffViewModel() : (StaffViewModel)SessionObject;
            }
            set
            {
                HttpContext.Current.Session["Staff"] = value;
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
            if (staff != null && !staff.EsPersonalAuxiliar)
            {
                HttpContext.Current.Response.Redirect("~/Autorizacion/unauthorized.aspx");
            }
        }

    }
}