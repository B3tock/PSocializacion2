<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCatalogo.aspx.cs" Inherits="DespachosJaveriana.Catalogo.FormCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click" ToolTip="Nuevo Catálogo">Nuevo Catálogo</asp:LinkButton>
                        <asp:GridView ID="gridCatalogos" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="gridCatalogos_SelectedIndexChanged" Width="100%" DataKeyNames="codigo">
                            <Columns>
                                <asp:BoundField DataField="codigo" HeaderText="codigo" SortExpression="codigo" />
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
                                <asp:BoundField DataField="categoria" HeaderText="categoria" SortExpression="categoria" />
                                <asp:BoundField DataField="codigoProveedor" HeaderText="codigoProveedor" SortExpression="codigoProveedor" Visible="False" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DespachosDataLayer.Entity.CatalogoServicioEntity" InsertMethod="InsertarCatalogos" SelectMethod="ConsultarCatalogos" TypeName="DespachosBusinessLayer.Business.CatalogoBusiness" UpdateMethod="ActualizarCatalogo"></asp:ObjectDataSource>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table class="nav-justified">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="CATALOGO DE SERVICIOS"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Código"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbNombre" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbDescripcion" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbPrecio" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txbPrecio"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
                                        <asp:ListItem>Activo</asp:ListItem>
                                        <asp:ListItem>Inactivo</asp:ListItem>
                                        <asp:ListItem>Procesado</asp:ListItem>
                                        <asp:ListItem>Entregado</asp:ListItem>
                                        <asp:ListItem>Pendiente</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Categoría"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txbCategoria" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Volver" CausesValidation="False" OnClick="btnCancelar_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblMensajeCatalogo" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
