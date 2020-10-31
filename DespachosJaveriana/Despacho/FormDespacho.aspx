<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDespacho.aspx.cs" Inherits="DespachosJaveriana.Despacho.FormDespacho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="gridDespachos" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo">
                            <Columns>
                                <asp:BoundField DataField="codigo" HeaderText="Código" />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="direccionOrigen" HeaderText="Origen" />
                                <asp:BoundField DataField="direccionDestino" HeaderText="Destino" />
                                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                                <asp:BoundField DataField="codigoCliente" Visible="False" />
                                <asp:BoundField DataField="estado" HeaderText="Estado Desp." />
                                <asp:BoundField DataField="peso" HeaderText="Peso" />
                                <asp:BoundField DataField="volumen" HeaderText="Volumen" />
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="Ruta" HeaderText="Ruta" Visible="False" />
                                <asp:BoundField DataField="cotizacion" HeaderText="Cotización" />
                                <asp:BoundField DataField="servicio" HeaderText="Servicio" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" />
                                <asp:BoundField DataField="estadoCotizacion" HeaderText="Estado Cot." />
                            </Columns>
                            <EmptyDataTemplate>
                                No existen registros
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="nav-justified">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="DESPACHOS"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 20px">
            <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
        </td>
        <td style="height: 20px"></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Dirección Origen"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbDireccionOrigen" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbDireccionOrigen" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Dirección Destino"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbDireccionDestino" runat="server" Width="200px" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbDireccionDestino" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Observaciones"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbObservaciones" runat="server" Width="200px" MaxLength="255" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbObservaciones" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlClientes" runat="server" Width="200px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClientes" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Estado"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlEstado" runat="server" Width="200px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlEstado" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Peso"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbPeso" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbPeso" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Volumen"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbVolumen" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txbVolumen" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>

</asp:Content>
