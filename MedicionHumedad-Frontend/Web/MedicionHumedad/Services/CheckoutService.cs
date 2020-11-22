using OfficeHoteling.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public class CheckoutService : BaseService
    {
        private const string checkoutByCheckinId = "Checkout/CheckoutByCheckinId";

        public int CheckoutByCheckinId(int checkinId)
        {
            int queryResult;
            try
            {
                var request = new RestRequest(checkoutByCheckinId, Method.POST);

                //request.AddParameter("reservaId", reservaId);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(checkinId);

                //client.Execute(request);

                queryResult = client.Execute<int>(request).Data;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return queryResult;
        }

    }
}