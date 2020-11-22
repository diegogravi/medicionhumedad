using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OfficeHoteling.Services
{
    public abstract class BaseService
    {
        protected RestClient client;
        public BaseService()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUrl"];
            client = new RestClient(baseAddress);
        }
        
    }
}