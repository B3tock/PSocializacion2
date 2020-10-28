<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormRegistro.aspx.cs" Inherits="DespachosJaveriana.FormRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<%--    <style type="text/css">
        .auto-style1 {
            width: 70%;
        }
    </style>--%>

      <link rel="stylesheet" href="css/style.css"/>

</head>
<body class="main-layout home_page">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2" align="center">
                        <h1><asp:Label ID="Label7" runat="server" Text="Registro Usuarios"></asp:Label></h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="NIT"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbNit" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNit" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbNombre" runat="server" MaxLength="255" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Teléfono"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbTelefono" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbTelefono" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Dirección"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbDireccion" runat="server" MaxLength="255" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbDireccion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Razón Social"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbRazonSocial" runat="server" MaxLength="255" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txbRazonSocial" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbCorreo" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbCorreo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txbContrasenia" runat="server" MaxLength="50" Width="200px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txbContrasenia" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:DropDownList ID="ddlTipoUsuario" runat="server" Width="200px">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>Cliente</asp:ListItem>
                            <asp:ListItem>Proveedor</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlTipoUsuario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:LinkButton ID="lbIrLogin" runat="server" CausesValidation="False" OnClick="lbIrLogin_Click">Volver a login</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
