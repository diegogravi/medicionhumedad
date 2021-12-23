<%@ Page Title="Plantaciones" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Sensor.aspx.cs" Inherits="MedicionHumedad._Sensor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { 
            background-image: url(../images/sensor.jpg); 
    background-repeat: no-repeat;
    background-size: cover;

        }
    </style>
     <div class="jumbotron">
            <h1>Sensores</h1>
            <p class="lead">Aqui podra ver todos los sensores, manejarlos y eliminarlos de ser necesario</p>
         <p class="lead">Si desea crear un nuevo sensor, <asp:HyperLink runat="server" id="hpVisualizar" NavigateUrl="~/Sensor/CrearSensor.aspx" Text="Haga click aqui"></asp:HyperLink> </p>
            <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Crear Reserva &raquo;</a></p>--%>
                <asp:GridView ID="GVSensores"  runat="server" Width="852px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" 
                    OnRowCommand="GVSensores_RowCommand" AutoGenerateColumns="False">
                    <Columns>                   
                        <asp:BoundField DataField="FechaCreacion" DataFormatString="{0:MM-dd-yyyy hh:mm tt}" HeaderText="Fecha de Creacion" SortExpression="Fecha" />
                        <asp:BoundField DataField="Id" HeaderText="Sensor Id" SortExpression="Id" />
                        <asp:BoundField DataField="PlantacionNombre" HeaderText="Plantacion" SortExpression="PlantacionNombre" />
                        <asp:TemplateField HeaderText="Activo" >   
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblActivo" Text='<%#(Eval("Activo").ToString() == "True" ? "Si" : "No")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Desactivar">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgDeleteSensor" runat="server" CommandName="Borrar" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/delete_icon.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere desactivar el sensor ?')"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Reactivar">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgRestore" runat="server" CommandName="Activate"  ToolTip="Reactivar" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/restore.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere reactivar este sensor ?')"></asp:ImageButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <em>No hay Sensores creados.</em>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
         <p>
             <asp:Label runat="server" ID="lblResult" ForeColor="Red"></asp:Label>
         </p>
        </div>
    
</asp:Content>
