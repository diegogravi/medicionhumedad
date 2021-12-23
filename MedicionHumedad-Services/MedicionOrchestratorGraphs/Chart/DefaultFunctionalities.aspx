<%@ Page Title="Medicion de humedad"  Async="true"   Language="C#" MetaDescription="Mediciones" MasterPageFile="~/Samplebrowser.Master" AutoEventWireup="true" CodeBehind="DefaultFunctionalities.aspx.cs" Inherits="WebSampleBrowser.Chart.DefaultFunctionalities" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ScriptSection">
         
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ControlsSection" runat="server">
    <div id="Tooltip" style="display: none;">
		<div id="icon">	
          <div id="eficon"></div>
	    </div>
        <div id="value">
             <div>
                <label id="efpercentage">&nbsp;#point.y#</label>
                <label id="ef">Humedad</label>
             </div>
        </div>

    </div>
  <div id="container">
      <script type="text/javascript" src="../Scripts/ChartData.js"></script>
      <div style="text-align: -webkit-center;">
      <table style="margin-top:20px;">
          <tr class="spaceUnder">
              <td>
                  Range Min: <asp:TextBox ID="txtRangeMin" runat="server" Text="38" Width="80px"></asp:TextBox>
              </td>
              <td>
                  Range Max: <asp:TextBox ID="txtRangeMax" runat="server" Text="48" Width="80px"></asp:TextBox>
              </td>
              <td>
                  Intervalo: <asp:TextBox ID="txtInterval" runat="server" Text="0.2" Width="80px"></asp:TextBox>
              </td>
              <td>
              </td>
          </tr>          
          <tr class="spaceUnder">
              <td>
                  Dia Comienzo: <asp:TextBox ID="txtDiaComienzo" runat="server" Text="2021-12-24" Width="80px"></asp:TextBox>
              </td>
              <td>
                  Hora del dia: <asp:TextBox ID="txtHoraComienzo" runat="server" Text="12:11" Width="80px"></asp:TextBox>
              </td>
              <td>
                  Dias siguientes: <asp:TextBox ID="txtDiasSiguientes" runat="server" Text="9" Width="80px"></asp:TextBox>
              </td>
              <td>
              </td>
          </tr>          
          <tr class="spaceUnder">
              <td colspan="4" style="text-align:center">
                  <asp:Button ID="btnLoadData" runat="server" Text="Cargar Predicciones" OnClick="btnLoadData_Click" BackColor="CadetBlue" ForeColor="White"/>
              </td>
          </tr>
      </table>
    </div>
    
    
      
      <ej:WaitingPopup runat="server" ID="waitingpopup" ShowOnInit="false"></ej:WaitingPopup>
      <ej:Chart ClientIDMode="Static" ID="Chart1" runat="server" Width="970" Height="600" IsResponsive="true" OnClientLoad="onChartLoad" >
           <PrimaryXAxis Title-Text="Fecha" Valuetype="Category"/>
           <PrimaryYAxis LabelFormat="{value}%" RangePadding="Round" Title-Text="Humedad"/>
           <CommonSeriesOptions Type="Line" DoughnutSize="0.2" Tooltip-Visible="true" Tooltip-Template="Tooltip" Marker-Size-Height="10" 
               Marker-Size-Width="10" Marker-Border-Width="2"  Marker-Visible="true" EnableAnimation="True"/>
           <Series>
             <ej:Series Name="Valor" XName="Xvalue" YName="YValue1"></ej:Series>
             <%--<ej:Series Name="Germany" XName="Xvalue" YName="YValue2"></ej:Series>
             <ej:Series Name="England" XName="Xvalue" YName="YValue3"></ej:Series>
             <ej:Series Name="France" XName="Xvalue" YName="YValue4"></ej:Series>--%>
           </Series>
           <Legend Visible="true"></Legend>
          <Title Text="Medicion de humedad en tierra"></Title>
      </ej:Chart>
  </div>
    <style>
        label {
		margin-bottom : -25px !important ;
		text-align :center !important;
		}
        .tooltipDivChart1 {
            background-color:#E94649;        
            color: white;
			width:130px;
        }
        #Tooltip >div:first-child {
            float: left;
        }
        #Tooltip #value {
            float: right;
            height: 50px;
            width: 68px;
        }
        #Tooltip #value >div {
            margin: 5px 5px 5px 5px;
            
        }
        #Tooltip #efpercentage {
            font-size: 20px;
            font-family: segoe ui;
			padding-left: 2px;
        }
         #Tooltip #ef {
             font-size: 12px;
             font-family: segoe ui;
        }
        #eficon {
            background-image: url("../Content/images/chart/eficon.png");
            height: 60px;
           
            width: 60px;
            background-repeat: no-repeat;
        }
       tr.spaceUnder>td {
          padding-bottom: 1em;
          padding-right:0.5em;
        }
     </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleSection" runat="server">
    
</asp:Content>

