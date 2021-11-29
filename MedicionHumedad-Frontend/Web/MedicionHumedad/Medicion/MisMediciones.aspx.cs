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
                _ReservaService = new ReservaService();
                _CheckinService = new CheckinService();
                BindGridReservas();
            }
        }

        private void BindGridReservas()
        {
            GVReservas.DataSource = GetReservasByUsuarioId();
            GVReservas.DataBind();
        }
        private List<ReservaViewModel> GetReservasByUsuarioId()
        {
            int UsuarioId = ((UsuarioViewModel)Session["Usuario"]).Id;
            var results = _ReservaService.GetReservasByUsuarioId(UsuarioId);
            return results;
        }

        protected void GVReservas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Checkin")
            {
                int reservaId = Convert.ToInt32(e.CommandArgument);

                //Chequear si ya hay un checkin activo
                var activeCheckin = _CheckinService.GetCurrentCheckinByUsuarioId(Usuario.Id);

                if (activeCheckin != null)
                {
                    lblResult.Text = "Ya hay un checkin activo, primero debe hacer checkout para checkinear una reserva existente";
                    lblResult.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    var checkinId = _CheckinService.CheckinByReservaId(reservaId);


                    if (checkinId > 0)
                    {
                        //Inactivate reserva

                        var reservaUpdated = _ReservaService.InactivateReservaByReservaId(reservaId);
                        if (reservaUpdated)
                        {
                            BindGridReservas();
                        }

                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Se ha checkineado exitosamente!";
                    }
                    else
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Ha ocurrido un error al intentar checkinear, intentelo nuevamente";
                    }
                }
            }
            else if (e.CommandName == "Inactivate")
            {
                int reservaId = Convert.ToInt32(e.CommandArgument);
                var reservaUpdated = _ReservaService.InactivateReservaByReservaId(reservaId);
                if (reservaUpdated)
                {
                    BindGridReservas();
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Se ha cancelado la reserva exitosamente!";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Hay un checkin activo asociado a esta reserva y no se puede cancelar, intente checkoutearla primero";
                }
            }
        }
    }
}