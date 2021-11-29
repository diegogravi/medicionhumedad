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
    public partial class _CrearReserva : AuthenticatedPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoggedIn();
                _EspacioService = new EspacioService();
                _EdificioService = new EdificioService();
                _PisoService = new PisoService();
                _ReservaService = new ReservaService();
                BindEdificio();
            }
        }

        private void BindEdificio()
        {
            List<EdificioViewModel> edificios = _EdificioService.GetAllEdificios();
            ddlEdificio.Items.Clear();
            foreach (var item in edificios)
            {
                ddlEdificio.Items.Add(new ListItem { Text = item.Nombre, Value = item.Id.ToString() });
            }
            if (ddlEdificio.Items.Count > 0)
            {
                ddlEdificio.Items[0].Selected = true;
            }
            BindPisos();
            BindEspaciosDisponibles();
        }

        private void BindPisos()
        {
            int edificioId = Convert.ToInt32(ddlEdificio.SelectedItem.Value);
            List<PisoViewModel> pisos = _PisoService.GetAllPisosByEdificioId(edificioId);
            ddlPiso.Items.Clear();
            foreach (var item in pisos)
            {
                ddlPiso.Items.Add(new ListItem { Text = item.Numero.ToString(), Value = item.Id.ToString() });
            }
            if (ddlPiso.Items.Count > 0)
            {
                ddlPiso.Items[0].Selected = true;
            }
        }

        protected void ddlEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPisos();
        }

        protected void btnBuscarEspaciosDisponibles_Click(object sender, EventArgs e)
        {
            
            BindEspaciosDisponibles();
        }

        private void BindEspaciosDisponibles()
        {
            int pisoId = Convert.ToInt32(ddlPiso.SelectedItem.Value);
            var fechaDesde = DateTime.Parse(calendarFecha.SelectedDate.ToShortDateString() + " " + txtHoraDesde.Text + " " + ddlDesdeAMPM.Text);

            var fechaHasta = DateTime.Parse(calendarFecha.SelectedDate.ToShortDateString() + " " + txtHoraHasta.Text + " " + ddlHastaAMPM.Text);

            List<EspacioViewModel> espacios = _EspacioService.GetEspaciosDisponiblesByPisoId(pisoId, fechaDesde, fechaHasta);

            lstBxEspaciosDisponibles.Items.Clear();
            foreach (var item in espacios)
            {
                lstBxEspaciosDisponibles.Items.Add(new ListItem { Text = item.Descripcion, Value = item.Id.ToString() });
            }
            if(lstBxEspaciosDisponibles.Items.Count>0)
            {
                lstBxEspaciosDisponibles.Items[0].Selected = true;
            }
        }

        protected void btnCrearReserva_Click(object sender, EventArgs e)
        {
            if(lstBxEspaciosDisponibles.Items.Count == 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "No hay espacios disponibles para ese horario, por favor busque en otro piso";
                return;
            }
            var fechaDesde = DateTime.Parse(calendarFecha.SelectedDate.ToShortDateString() + " " + txtHoraDesde.Text + " " + ddlDesdeAMPM.Text);
            ReservaViewModel reserva = new ReservaViewModel
            {
                CreadaEn = DateTime.Now,
                EspacioId = Convert.ToInt32(lstBxEspaciosDisponibles.SelectedValue),
                EspacioDescripcion = lstBxEspaciosDisponibles.SelectedItem.Text,
                FechaDesde = fechaDesde,
                FechaHasta = DateTime.Parse(calendarFecha.SelectedDate.ToShortDateString() + " " + txtHoraHasta.Text + " " + ddlHastaAMPM.Text),
                UsuarioId = Usuario.Id,
                Active = true
            };
            int reservaId = _ReservaService.CrearReserva(reserva);
            if(reservaId>0)
            {
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "La reserva " + reservaId + " ha sido creada con exito para el dia " + fechaDesde.ToString("MM/dd/yyyy h:mm tt") + " en " + lstBxEspaciosDisponibles.SelectedItem.Text;

                BindEspaciosDisponibles();
            }
            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Ha ocurrido un error al crear la reserva, intentelo nuevamente";
            }
        
        }
    }
}