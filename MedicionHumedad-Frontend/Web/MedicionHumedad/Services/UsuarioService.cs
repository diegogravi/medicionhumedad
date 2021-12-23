using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class UsuarioService : BaseService
    {
        private const string getAllUsuario = "Usuario/GetAllUsuario"; 
        private const string inactivateUsuarioByUsuarioId = "Usuario/InactivateUsuarioByUsuarioId"; 
        private const string activateUsuarioByUsuarioId = "Usuario/ActivateUsuarioByUsuarioId";
        private const string crearUsuario = "Usuario/CrearUsuario";
        private const string changeRole = "Usuario/ChangeRole";


        public int CrearUsuario(UsuarioViewModel usuario)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(crearUsuario, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(usuario);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public bool ActivateUsuarioByUsuarioId(int UsuarioId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(activateUsuarioByUsuarioId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(UsuarioId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }

        public bool InactivateUsuarioByUsuarioId(int UsuarioId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(inactivateUsuarioByUsuarioId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(UsuarioId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }


        public List<UsuarioViewModel> GetAllUsuario()
        {
            List<UsuarioViewModel> queryResult = new List<UsuarioViewModel>();
            try
            {
                var request = new RestRequest(getAllUsuario, Method.GET);

                queryResult = client.Execute<List<UsuarioViewModel>>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }

        public bool ChangeRole()
        {
            bool queryResult = false;
            try
            {
                var request = new RestRequest(changeRole, Method.GET);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;
        }

    }
}