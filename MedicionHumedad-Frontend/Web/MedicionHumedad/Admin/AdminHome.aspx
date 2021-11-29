<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="MedicionHumedad._AdminHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { background-image: url(../images/admin.jpg); }
    </style>
        <div class="jumbotron">
            <h1>Office Hoteling</h1>
            <p class="lead">Administre y cree todas sus reservas de sus espacios de trabajo en la oficina.</p>
            <p>
                    <a class="btn btn-primary" runat="server" href="~/Reservas/CrearReserva">Crear Reserva &raquo;</a>
            </p>
        </div>

        <div class="row">
            <div class="col-md-4">
                <h2>Mis Reservas</h2>
                <p>
                    Planee en tiempo y forma su semana laboral y donde va a sentarse a hacer sus tareas y actividades diarias en la oficina.
                </p>
                <p>
                    <a class="btn btn-primary" runat="server" href="~/Default">Mis Reservas &raquo;</a>
                </p>
            </div>
            <div class="col-md-4">
                <h2>Checkin</h2>
                <p>
                    Haga el Checkin de sus reservas para asegurar que ha ocupado el espacio de trabajo y bloquearlo por el tiempo establecido.
                </p>
                <p>
                    <a class="btn btn-primary" runat="server" href="~/Checkin/Checkin">Checkin &raquo;</a>
                </p>
            </div>
            <div class="col-md-4">
                <h2>Checkout</h2>
                <p>
                    Libere su espacio de trabajo haciendo Checkout a su espacio de trabajo y devuelvalo al pool de oficinas.
                </p>
                <p>
                    <a class="btn btn-primary" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </div>
        </div>
   
</asp:Content>
