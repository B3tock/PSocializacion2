<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormRegistroClientes.aspx.cs" Inherits="DespachosJaveriana.FormRegistroClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="NIT"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbNit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Teléfono"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbTelefono" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Razón Social"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbRazonSocial" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbCorreo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Sitio Web"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbSitioWeb" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
