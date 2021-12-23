<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="CrearPlantacion.aspx.cs" Inherits="MedicionHumedad._CrearPlantacion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { 
            background-image: url(../images/plantacion.jpg); 
    background-repeat: no-repeat;
    background-size: cover;

        }
    </style>
        <div class="jumbotron">
            <h1>Crear Plantacion</h1>
            <p class="lead">Ingrese los campos para crear la plantacion.</p>
             <p class="lead">Si desea ver todas las plantaciones, <asp:HyperLink runat="server" id="hpVisualizar" NavigateUrl="~/Plantacion/Plantacion.aspx" Text="Haga click aqui"></asp:HyperLink> </p>
            <p>                
                    Nombre: <asp:TextBox ID="txtNombre" runat="server" Text="" Width="250px"></asp:TextBox>
            </p>
            
                <p>
                    <asp:Button ID="btnCrearPlantacion" CssClass="btn btn-primary" runat="server" Text="Crear Plantacion &raquo;" OnClick="btnCrearPlantacion_Click" OnClientClick="return confirm('Esta seguro que quiere crear la plantacion?')"  />
                </p>
                <p>
                    <asp:Label ID="lblResult" runat="server" Text="" ForeColor="Green"></asp:Label>
                </p>
        </div>

   
</asp:Content>
