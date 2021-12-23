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
        protected UsuarioService _UsuarioService
        {
            get { return (UsuarioService)Session["UsuarioService"]; }
            set { Session["UsuarioService"] = value; }
        }
        protected MedicionService _MedicionService
        {
            get { return (MedicionService)Session["MedicionService"]; }
            set { Session["MedicionService"] = value; }
        }
        protected PlantacionService _PlantacionService
        {
            get { return (PlantacionService)Session["PlantacionService"]; }
            set { Session["PlantacionService"] = value; }
        }
        protected FrutoService _FrutoService
        {
            get { return (FrutoService)Session["FrutoService"]; }
            set { Session["FrutoService"] = value; }
        }
        protected SensorService _SensorService
        {
            get { return (SensorService)Session["SensorService"]; }
            set { Session["SensorService"] = value; }
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