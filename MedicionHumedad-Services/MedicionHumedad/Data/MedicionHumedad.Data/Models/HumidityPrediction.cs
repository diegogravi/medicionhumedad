namespace MedicionHumedad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.ComponentModel;

    // HumidityPrediction myDeserializedClass = JsonConvert.DeserializeObject<HumidityPrediction>
    [Serializable]
    public class HumidityPrediction
    {
        public double humidity { get; set; }
    }
}
