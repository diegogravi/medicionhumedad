using OfficeHoteling.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public class LoginService : BaseService
    {
        private const string loginMethd = "Login/Login";

        public ServiceResult<StaffViewModel> Login(string guid, string password)
        {
            ServiceResult<StaffViewModel> queryResult = new ServiceResult<StaffViewModel>();
            try
            {
                var request = new RestRequest(loginMethd, Method.GET);

                request.AddParameter("guid", guid);
                request.AddParameter("password", password);
                queryResult = client.Execute<ServiceResult<StaffViewModel>>(request).Data;
            }
            catch(Exception ex)
            {
                return null;
            }

            return queryResult;
        }
    }
}