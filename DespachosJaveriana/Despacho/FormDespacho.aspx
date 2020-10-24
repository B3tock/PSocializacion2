<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDespacho.aspx.cs" Inherits="DespachosJaveriana.Despacho.FormDespacho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="DESPACHOS"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Dirección Origen"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbDireccionOrigen" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Dirección Destino"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbDireccionDestino" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Observaciones"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txbObservaciones" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlClientes" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Estado"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Peso"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Volumen"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
