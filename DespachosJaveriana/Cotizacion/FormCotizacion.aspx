<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCotizacion.aspx.cs" Inherits="DespachosJaveriana.Cotizacion.FormCotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click">Nueva Cotización</asp:LinkButton>
                        <asp:GridView ID="gridCotizaciones" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" Width="100%" OnSelectedIndexChanged="gridCotizaciones_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="codigo" HeaderText="codigo" SortExpression="codigo" />
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                <asp:BoundField DataField="codigoCatalogo" HeaderText="codigoCatalogo" SortExpression="codigoCatalogo" Visible="False" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" Visible="False" />
                                <asp:BoundField DataField="codigoDespacho" HeaderText="codigoDespacho" SortExpression="codigoDespacho" Visible="False" />
                                <asp:BoundField DataField="nombreCatalogo" HeaderText="nombreCatalogo" />
                                <asp:BoundField DataField="direccionOrigen" HeaderText="direccionOrigen" />
                                <asp:BoundField DataField="direccionDestino" HeaderText="direccionDestino" />
                                <asp:BoundField DataField="proveedor" HeaderText="proveedor" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="Label7" runat="server" Text="No existen datos"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="nav-justified">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbPrecio" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbPrecio" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Catálogo"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCatalogo" runat="server" DataTextField="NOMBRE" DataValueField="CODIGO" Width="200px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCatalogo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbDescripcion" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbDescripcion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="200px">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>PENDIENTE</asp:ListItem>
                                        <asp:ListItem>APROBADA</asp:ListItem>
                                        <asp:ListItem>RECHAZADA</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlEstado" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Despacho"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDespacho" runat="server" DataTextField="RUTA" DataValueField="CODIGO" Width="200px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDespacho" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblMensajeCotizacion" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
