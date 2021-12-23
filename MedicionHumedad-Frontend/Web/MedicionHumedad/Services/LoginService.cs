using MedicionHumedad.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicionHumedad.Services
{
    public class LoginService : BaseService
    {
        private const string loginMethd = "Login/Login";

        public ServiceResult<UsuarioViewModel> Login(string guid, string password)
        {
            ServiceResult<UsuarioViewModel> queryResult = new ServiceResult<UsuarioViewModel>();
            try
            {
                var request = new RestRequest(loginMethd, Method.GET);

                request.AddParameter("guid", guid);
                request.AddParameter("password", password);
                queryResult = client.Execute<ServiceResult<UsuarioViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}