<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MedicionHumedad._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { background-image: url(images/fondo.jpg); }
    </style>
        <div class="jumbotron">
            <h1>Mediciones de humedad</h1>
            <p class="lead">Administre y cree todas las mediciones de humedad.</p>
            <p>
                    <a class="btn btn-primary" runat="server" href="~/Medicion/CrearMedicion.aspx">Crear Medicion &raquo;</a>
            </p>
        </div>

        <div class="row">
            <div class="col-md-4">
                <h2>Mis Mediciones</h2>
                <p>
                    Verifique las mediciones ingresadas y vea las caracteristicas de todas y cada una.
                </p>
                <p>
                    <a class="btn btn-primary" runat="server" href="~/Medicion/MisMediciones">Mis Mediciones &raquo;</a>
                </p>
            </div>
            <div class="col-md-4">
                <h2>Sensores</h2>
                <p>
                    Administre los sensores del sistema segun fruto y plantacion.
                </p>
                <p>
                    <a class="btn btn-primary" runat="server" href="~/Sensor/Sensor.aspx">Sensores &raquo;</a>
                </p>
            </div>
            <div class="col-md-4">
                <h2>Plantaciones</h2>
                <p>
                    Administre las plantaciones y los frutos asociados.
                </p>
                <p>
                    <a class="btn btn-primary" runat="server" href="~/Plantacion/Plantacion.aspx">Plantaciones &raquo;</a>
                </p>
            </div>
        </div>
   
</asp:Content>
