<%@ Page Title="Login" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OfficeHoteling._Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { background-image: url(../images/login.jpg); }
    </style>
        <div class="jumbotron">
            <h1>Iniciar Sesión</h1>
            <p class="lead">Inicie sesion para empezar a utilizar la applicacion que le facilitara la medicion de humedad en tierra y sus predicciones. Utilize su Email para ingresar</p>
            <p>
                Email:
            </p>
            <p>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser" ErrorMessage="* requerido" ForeColor="#FF3300" ValidationGroup="login"></asp:RequiredFieldValidator>
            </p>
            <p>
                Contraseña:
            </p>
            <p>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="* requerido" ForeColor="#FF3300" ValidationGroup="login"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblResult" runat="server" ForeColor="#FF3300"></asp:Label>
            </p>
            <p><asp:Button CssClass="btn btn-primary btn-lg" ID="btnLogin" runat="server" Text="Iniciar Sesión &raquo;" OnClick="btnLogin_Click" ValidationGroup="login" /></p>
        </div>

   
</asp:Content>
