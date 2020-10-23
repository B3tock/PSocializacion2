<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DespachosJaveriana.Login" %>

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
                        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbContrasenia" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server">Registro</asp:LinkButton>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Entrar" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
