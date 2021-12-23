<%@ Page Title="Mis mediciones" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="MisMediciones.aspx.cs" Inherits="MedicionHumedad._MisReservas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { 
            background-image: url(../images/medicion.jpg); 
    background-repeat: no-repeat;
    background-size: cover;

        }
    </style>

     <div class="jumbotron">
            <h1>Mediciones</h1>
            <p class="lead">Aqui podra ver todas sus mediciones, manejarlas y eliminarlas de ser necesario</p>
         <p class="lead">Si desea visualizar las mediciones, <asp:HyperLink runat="server" id="hpVisualizar" NavigateUrl="http://localhost:50723/chart/HistorialMediciones.aspx" Text="Haga click aqui"></asp:HyperLink> </p>
            <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Crear Reserva &raquo;</a></p>--%>
                <asp:GridView ID="GVMediciones"  runat="server" Width="852px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="GVMediciones_RowCommand" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Fecha" DataFormatString="{0:MM-dd-yyyy hh:mm tt}" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="SensorId" HeaderText="Sensor" SortExpression="Sensor" />
                        <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" SortExpression="Porcentaje" />
                        <asp:BoundField DataField="FrutoNombre" HeaderText="Fruto" SortExpression="FrutoNombre" />
                        <asp:BoundField DataField="PlantacionNombre" HeaderText="Plantacion" SortExpression="PlantacionNombre" />
                        <asp:BoundField DataField="UsuarioNombre" HeaderText="Usuario" SortExpression="UsuarioNombre"  />
                        <asp:BoundField DataField="UsuarioId" HeaderText="Usuario Id" SortExpression="UsuarioId" Visible="False" />
                        <asp:TemplateField HeaderText="Borrar">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgDeleteReserva" runat="server" CommandName="Borrar" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/delete_icon.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere borrar la medicion ?')"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <EmptyDataTemplate>
                        <em>No hay Mediciones creadas para el usuario.</em>
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
    
        <%--<div class="row">
            <div class="col-md-4">
                <h2>1) Busque el espacio de trabajo</h2>
                <table>
                <tr>
                <td>

            <p>
                Edificio:  <asp:DropDownList ID="DropDownList3" runat="server"><asp:ListItem Text="Tampa PwC"></asp:ListItem></asp:DropDownList>
            </p>
            <p>
                Piso:  <asp:DropDownList ID="DropDownList4" runat="server"><asp:ListItem Text="8vo Piso"></asp:ListItem></asp:DropDownList>
            </p>
                    
                    <p>
                Fecha de Reserva:
            </p>
            <p>
                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            </p>
                </td>
                <td>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                 <td>

                 </td>
                     </tr>
                     <tr>
                         <td>
                         <p>
                             Hora:  <asp:TextBox ID="TextBox3" runat="server" Width="100px">08:00 am</asp:TextBox>
                         </p>
                             </td>
                         <td>
                             &nbsp;&nbsp;&nbsp;&nbsp;
                         </td>
                         <td> 
                             <p>
                                 Hora:  <asp:TextBox ID="TextBox4" runat="server" Width="100px">05:00 pm</asp:TextBox>
                             </p>
                         </td>
                     </tr>
                
            </table>
            
            
            <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Buscar espacio disponible &raquo;</a></p>
            </div>
            <div class="col-md-4">
                <h2>2) Encuentre el espacio ideal</h2>
                <p>
                    Seleccione el espacio de trabajo que sea de su agrado.
                </p>
                <p>
                    <asp:ListBox ID="ListBox2" runat="server">
                            <asp:ListItem Text="853 Workstation Center"></asp:ListItem>
                            <asp:ListItem Text="854 Workstation Collaboration"></asp:ListItem>
                            <asp:ListItem Text="855 Conference Room"></asp:ListItem>
                            <asp:ListItem Text="856 Workstation Collaboration"></asp:ListItem>
                            <asp:ListItem Text="857 Open Space"></asp:ListItem>
                        </asp:ListBox>
                </p>
            </div>
            <div class="col-md-4">
                <h2>3) Confirme su Reserva!</h2>
                <p>
                    Asegurese que lo seleccionado es de su agrade y clickee en Confirmar Reserva!
                </p>
                <p>
                    <a class="btn btn-primary" href="https://go.microsoft.com/fwlink/?LinkId=301950">Confirmar Reserva &raquo;</a>
                </p>
            </div>
        </div>--%>

<%--        <div class="jumbotron">
            <h1>Crear Reserva</h1>
            <table>
                <tr>
                <td>

            <p class="lead">Busque el espacio de trabajo y confirme su reserva.</p>
            <p>
                Edificio:  <asp:DropDownList ID="DropDownList1" runat="server"><asp:ListItem Text="Seleccione edificio"></asp:ListItem></asp:DropDownList>
            </p>
            <p>
                Piso:  <asp:DropDownList ID="DropDownList2" runat="server"><asp:ListItem Text="Seleccione edificio"></asp:ListItem></asp:DropDownList>
            </p>
            <table>
                <tr>
                <td>
                    
                    <p>
                Fecha Desde:
            </p>
            <p>
                <asp:Calendar ID="calFrom" runat="server"></asp:Calendar>
            </p>
                </td>
                <td>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                 <td>
                    <p>
                Fecha Hasta:
            </p>
            <p>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </p>

                 </td>
                     </tr>
                     <tr>
                         <td>
                         <p>
                             Hora:  <asp:TextBox ID="TextBox2" runat="server" Width="100px">08:00 am</asp:TextBox>
                         </p>
                             </td>
                         <td>
                             &nbsp;&nbsp;&nbsp;&nbsp;
                         </td>
                         <td> 
                             <p>
                                 Hora:  <asp:TextBox ID="TextBox1" runat="server" Width="100px">05:00 pm</asp:TextBox>
                             </p>
                         </td>
                     </tr>
                
            </table>
            
            
            <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Buscar espacio disponible &raquo;</a></p>

                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:ListBox ID="ListBox1" runat="server">
                            <asp:ListItem Text="853 Workstation Center"></asp:ListItem>
                            <asp:ListItem Text="854 Workstation Collaboration"></asp:ListItem>
                            <asp:ListItem Text="855 Conference Room"></asp:ListItem>
                            <asp:ListItem Text="856 Workstation Collaboration"></asp:ListItem>
                            <asp:ListItem Text="857 Open Space"></asp:ListItem>
                        </asp:ListBox>
                    </td>
                     </tr>
                
            </table>
        </div>
   --%>
</asp:Content>
