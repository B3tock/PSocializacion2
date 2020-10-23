<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormRegistroClientes.aspx.cs" Inherits="DespachosJaveriana.FormRegistroClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 70%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label7" runat="server" Text="Registro Usuarios"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="NIT"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbNit" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbNombre" runat="server" MaxLength="255" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Teléfono"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbTelefono" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Razón Social"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbRazonSocial" runat="server" MaxLength="255" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbCorreo" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbContrasenia" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Sitio Web"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbSitioWeb" runat="server" MaxLength="255" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Tipo de Usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoUsuario" runat="server">
                            <asp:ListItem Selected="True">Seleccione Tipo</asp:ListItem>
                            <asp:ListItem>Cliente</asp:ListItem>
                            <asp:ListItem>Proveedor</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
