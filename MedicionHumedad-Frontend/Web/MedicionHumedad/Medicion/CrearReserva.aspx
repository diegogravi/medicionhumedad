<%@ Page Title="Crear Reserva" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="CrearReserva.aspx.cs" Inherits="MedicionHumedad._CrearReserva" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { background-image: url(../images/reserva.jpg); }
    </style>

     <div class="jumbotron">
            <h1>Crear Reserva</h1>
            <p class="lead">Busque el espacio de trabajo y confirme su reserva en tres simples pasos!</p>
            <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Crear Reserva &raquo;</a></p>--%>
        </div>

        <div class="row">
            <div class="col-md-4">
                <h2>1) Busque el espacio de trabajo</h2>
                <table>
                <tr>
                <td>
                

            <p>
                Edificio:  <asp:DropDownList ID="ddlEdificio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdificio_SelectedIndexChanged"></asp:DropDownList>
            </p>
            <p>
                Piso:  <asp:DropDownList ID="ddlPiso" runat="server" AutoPostBack="True"  ></asp:DropDownList>
            </p>
                    
                    <p>
                Fecha de Reserva:
            </p>
            <p>
                <asp:Calendar ID="calendarFecha" runat="server" SelectedDate="<%# DateTime.Today %>" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="350px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
            </p>
                </td>
                <td>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                 <td>

                 </td>
                     </tr>
                     <tr>
                         <td>
                         <p>
                             Hora Desde:  <asp:TextBox ID="txtHoraDesde" runat="server" Width="100px">08:00</asp:TextBox>
                             <asp:DropDownList ID="ddlDesdeAMPM" runat="server">
                                 <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                 <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                             </asp:DropDownList>
                         </p>
                             <p>
                                 Hora Hasta:  <asp:TextBox ID="txtHoraHasta" runat="server" Width="100px">05:00</asp:TextBox>
                                 <asp:DropDownList ID="ddlHastaAMPM" runat="server">
                                 <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                 <asp:ListItem Text="PM" Value="PM" Selected="True"></asp:ListItem>
                             </asp:DropDownList>
                             </p>
                             </td>
                         <td>
                             &nbsp;&nbsp;&nbsp;&nbsp;
                         </td>
                         <td> 
                             
                         </td>
                     </tr>
                
            </table>
            
            
            <p><asp:Button ID="btnBuscarEspaciosDisponibles" runat="server" CssClass="btn btn-primary btn-lg" Text="Buscar espacios disponibles »" OnClick="btnBuscarEspaciosDisponibles_Click" /></p>
                
            </div>
            <div class="col-md-4">
                <h2>2) Encuentre el espacio ideal</h2>
                <p>
                    Seleccione el espacio de trabajo que sea de su agrado.
                </p>
                <p>
                    <asp:ListBox ID="lstBxEspaciosDisponibles" runat="server" Width="300px" Height="150px">
                        </asp:ListBox>
                </p>
            </div>
            <div class="col-md-4">
                <h2>3) Confirme su Reserva!</h2>
                <p>
                    Asegurese que lo seleccionado es de su agrade y clickee en Confirmar Reserva!
                </p>
                <p>
                    <asp:Button ID="btnCrearReserva" CssClass="btn btn-primary" runat="server" Text="Confirmar Reserva &raquo;" OnClick="btnCrearReserva_Click" OnClientClick="return confirm('Esta seguro que quiere crear la reserva ?')"  />
                </p>
                <p>
                    <asp:Label ID="lblResult" runat="server" Text="" ForeColor="Green"></asp:Label>
                </p>
            </div>
        </div>

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
