<%@ Page Title="Checkin" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Checkin.aspx.cs" Inherits="MedicionHumedad._Checkin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { background-image: url(../images/checkin.jpeg); }
    </style>

     <div class="jumbotron">
            <h1>Mi Checkin</h1>
            <p class="lead">Aqui podra ver su checkin activo y checkoutearlo de ser necesario</p>
            <asp:GridView ID="GVCheckins" runat="server" Width="852px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="GVCheckins_RowCommand" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FechaCheckin" DataFormatString="{0:MM-dd-yyyy hh:mm tt}" HeaderText="Fecha Desde" SortExpression="FechaCheckin" />
                        <asp:BoundField DataField="EdificioNombre" HeaderText="Edificio" SortExpression="EspacioDescripcion" />
                        <asp:BoundField DataField="EspacioDescripcion" HeaderText="Espacio" SortExpression="EspacioDescripcion"  />
                        
                        <asp:TemplateField HeaderText="Checkout">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgCheckout" runat="server" CommandName="Checkout" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/Checkout_icon.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere checkoutear el checkin ?')"></asp:ImageButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <em>No hay ningun Checkin activo.</em>
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
