<%@ Page Title="Plantaciones" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Plantacion.aspx.cs" Inherits="MedicionHumedad._Plantacion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { 
            background-image: url(../images/plantacion.jpg); 
    background-repeat: no-repeat;
    background-size: cover;

        }
    </style>

     <div class="jumbotron">
            <h1>Plantaciones</h1>
            <p class="lead">Aqui podra ver todas las plantaciones, manejarlas y eliminarlas de ser necesario</p>
         <p class="lead">Si desea crear una nueva plantacion, <asp:HyperLink runat="server" id="hpVisualizar" NavigateUrl="~/Plantacion/CrearPlantacion.aspx" Text="Haga click aqui"></asp:HyperLink> </p>
            <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Crear Reserva &raquo;</a></p>--%>
                <asp:GridView ID="GVPlantaciones"  runat="server" Width="852px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" 
                    OnRowCommand="GVPlantaciones_RowCommand" AutoGenerateColumns="False">
                    <Columns>                        
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:TemplateField HeaderText="Borrar">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgDeletePlantacion" runat="server" CommandName="Borrar" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/delete_icon.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere borrar la plantacion ?')"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <EmptyDataTemplate>
                        <em>No hay Planaciones creadas.</em>
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
