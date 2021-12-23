<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="CrearSensor.aspx.cs" Inherits="MedicionHumedad._CrearSensor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { 
            background-image: url(../images/sensor.jpg); 
    background-repeat: no-repeat;
    background-size: cover;

        }
    </style>
        <div class="jumbotron">
            <h1>Crear Sensor</h1>
            <p class="lead">Seleccione los campos para crear el sensor.</p>
             <p class="lead">Si desea ver todos los sensores, <asp:HyperLink runat="server" id="hpVisualizar" NavigateUrl="~/Sensor/Sensor.aspx" Text="Haga click aqui"></asp:HyperLink> </p>
            <p>
                Plantacion:  <asp:DropDownList ID="ddlPlantacion" runat="server" ></asp:DropDownList>
            </p>
            
                <p>
                    <asp:Button ID="btnCrearSensor" CssClass="btn btn-primary" runat="server" Text="Crear Sensor &raquo;" OnClick="btnCrearSensor_Click" OnClientClick="return confirm('Esta seguro que quiere crear el sensor?')"  />
                </p>
                <p>
                    <asp:Label ID="lblResult" runat="server" Text="" ForeColor="Green"></asp:Label>
                </p>
        </div>

   
</asp:Content>
