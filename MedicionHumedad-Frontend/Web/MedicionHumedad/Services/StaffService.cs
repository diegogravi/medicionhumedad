using OfficeHoteling.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public class StaffService : BaseService
    {
        private const string getAllStaff = "Staff/GetAllStaff"; 
        private const string inactivateStaffByStaffId = "Staff/InactivateStaffByStaffId"; 
        private const string activateStaffByStaffId = "Staff/ActivateStaffByStaffId";
        private const string crearStaff = "Staff/CrearStaff";


        public int CrearStaff(StaffViewModel staff)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(crearStaff, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(staff);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }
        public bool ActivateStaffByStaffId(int staffId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(activateStaffByStaffId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(staffId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }

        public bool InactivateStaffByStaffId(int staffId)
        {
            bool queryResult;
            try
            {
                var request = new RestRequest(inactivateStaffByStaffId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(staffId);

                //client.Execute(request);

                queryResult = client.Execute<bool>(request).Data;
            }
            catch (Exception ex)
            {
                return false;
            }

            return queryResult;

        }


        public List<StaffViewModel> GetAllStaff()
        {
            List<StaffViewModel> queryResult = new List<StaffViewModel>();
            try
            {
                var request = new RestRequest(getAllStaff, Method.GET);

                queryResult = client.Execute<List<StaffViewModel>>(request).Data;
            }
            catch (Exception ex)
            {
                return null;
            }

            return queryResult;
        }

        
    }
}