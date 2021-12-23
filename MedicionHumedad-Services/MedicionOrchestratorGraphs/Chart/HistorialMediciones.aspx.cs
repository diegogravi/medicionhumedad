#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Syncfusion.JavaScript.DataVisualization;
using Syncfusion.JavaScript.DataVisualization.Models;

namespace WebSampleBrowser.Chart
{
    public partial class HistorialMediciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageAsyncTask t = new PageAsyncTask(LoadDataAsync);

                // Register the asynchronous task.
                Page.RegisterAsyncTask(t);

                // Execute the register asynchronous task.
                Page.ExecuteRegisteredAsyncTasks();
            }
        }

        protected async void btnLoadData_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        public async Task LoadDataAsync()
        {
            List<LineChartData> data = await this.GetMedicionesDataAsync(Convert.ToInt32(txtLecturas.Text), Convert.ToInt32(ddlPlantacion.SelectedValue));

            //Binding Datasource to Chart
            this.Chart1.DataSource = data;
            this.Chart1.DataBind();

            //Setting range for PrimaryXAxis
            this.Chart1.PrimaryXAxis.Range.Min = 2005;
            this.Chart1.PrimaryXAxis.Range.Max = 2011;
            this.Chart1.PrimaryXAxis.Range.Interval = 1;

            //Setting range for PrimaryYAxis
            this.Chart1.PrimaryYAxis.Range.Min = Convert.ToInt32(txtRangeMin.Text);
            this.Chart1.PrimaryYAxis.Range.Max = Convert.ToInt32(txtRangeMax.Text);
            this.Chart1.PrimaryYAxis.Range.Interval = Convert.ToDouble(txtInterval.Text);
        }
        public async Task<List<LineChartData>> GetMedicionesDataAsync(int lecturas, int plantacionId)
        {
            var httpClient = new HttpClient();
            var apiUrl = "https://localhost:44399/api/";
            var urlBase = apiUrl + "Orchestrator/GetMedicionesData";
            var url = string.Format("{0}?lecturas={1}&plantacionId={2}", urlBase, lecturas, plantacionId);
            List<LineChartData> dataPredicted = new List<LineChartData>();

            var client = new HttpClient();
            try
            {                
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var response = await httpClient.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();
                dataPredicted = JsonConvert.DeserializeObject<List<LineChartData>>(content);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                
            }
            return dataPredicted;

        }
    }
   
}

      
   
      
      