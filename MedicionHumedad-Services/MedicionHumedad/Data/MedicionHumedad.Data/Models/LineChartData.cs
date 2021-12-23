namespace MedicionHumedad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.ComponentModel;
    [Serializable]
    public class LineChartData
    {
        public LineChartData(string xval, double yvalue1)
        {
            this.Xvalue = xval;
            this.YValue1 = yvalue1;
        }
        public string Xvalue
        {
            get;
            set;
        }
        public double YValue1
        {
            get;
            set;
        }
    }
}
