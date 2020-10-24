<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DespachosJaveriana.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="Scripts/Master/PopUpWindow.js"></script>
    <script type="text/javascript" src="Scripts/PagesScripts/Functions.js"></script>
    <script type="text/javascript" src="Scripts/Master/SigDocNS.js"></script>
    <script type="text/javascript" src="Scripts/Master/jquery-latest.min.js"></script>    
    <script type="text/javascript" src="Vscripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Vscripts/jquery-ui-1.9.2.min.js"></script>
    <link href="Style/jquery-ui.css" rel="stylesheet" />
    <title>Acceso al sistema</title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login de Usuarios</h2>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbUsuario" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbUsuario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbContrasenia" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbContrasenia" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbRegistro" runat="server" OnClick="lbRegistro_Click" CausesValidation="False">Registro</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="lbReset" runat="server" OnClick="lbReset_Click" CausesValidation="False">Restablecer contraseña</asp:LinkButton>
                    </td>
                    <td align="">
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" Width="150px" OnClick="btnEntrar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lbMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
