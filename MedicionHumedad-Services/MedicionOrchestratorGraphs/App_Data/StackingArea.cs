#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using System.Web.Script.Serialization;
[Serializable]
    public class StackingAreaChartData
    {
        public StackingAreaChartData(double xval, double yvalue1, double yvalue2, double yvalue3, double yvalue4)
        {
            this.Xvalue = xval;
            this.YValue1 = yvalue1;
            this.YValue2 = yvalue2;
            this.YValue3 = yvalue3;
            this.YValue4 = yvalue4;
        }
        public double Xvalue
        {
            get;
            set;
        }
        public double YValue1
        {
            get;
            set;
        }
        public double YValue2
        {
            get;
            set;
        }
        public double YValue3
        {
            get;
            set;
        }
        public double YValue4
        {
            get;
            set;
        }

    }