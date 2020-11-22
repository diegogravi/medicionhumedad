<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="StaffHome.aspx.cs" Inherits="OfficeHoteling._StaffHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body { background-image: url(../images/staff.jpg); }
    </style>
        <div class="jumbotron">
            <h1>Administrar Staff</h1>
            <p class="lead">Aqui podra ver todo el staff y activar o desactivarlos de ser necesario</p>
            <asp:GridView ID="GVStaff" runat="server" Width="852px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="GVStaff_RowCommand" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Guid" HeaderText="Guid" SortExpression="Guid" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />   
                        <asp:TemplateField HeaderText="Es Personal Auxiliar" >   
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPersonalAuxiliar" Text='<%#(Eval("EsPersonalAuxiliar").ToString() == "True" ? "Si" : "No")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Borrado" >   
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblActivo" Text='<%#(Eval("Activo").ToString() == "True" ? "No" : "Si")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Borrar">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgDesactivarStaff" runat="server" CommandName="Inactivate" ToolTip="Borrar" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/inactivate_icon.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere borrar este empleado ?')"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reactivar">   
                            <ItemTemplate>
                                <asp:ImageButton id="imgActivateStaff" runat="server" CommandName="Activate"  ToolTip="Reactivar" CommandArgument='<%# Bind("Id") %>' ImageUrl="~/images/activate_icon.png" Height="20px" Width="20px" OnClientClick="return confirm('Esta seguro que quiere reactivar este empleado ?')"></asp:ImageButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <em>No hay usuarios para mostrar.</em>
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
