<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormEstadisticas.aspx.cs" Inherits="DespachosJaveriana.Estadisticas.FormEstadisticas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="chartEstadistica" runat="server" Width="718px" BorderlineWidth="0" Height="432px">
        <Series>            
            <asp:Series ChartArea="ChartArea1" Name="Series1" XValueMember="Proveedor" YValueMembers="Precio"
                LegendText="Catálogo" IsValueShownAsLabel="false" MarkerBorderColor="#DBDBDB">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" Name="Series2" XValueMember="Catalogo" YValueMembers="Precio"
                LegendText="Proveedor" IsValueShownAsLabel="false" MarkerBorderColor="#DBDBDB">
            </asp:Series>
        </Series>
        <Legends>
            <asp:Legend Title="Cotizaciones" />
        </Legends>
        <Titles>
            <asp:Title Docking="Bottom" Text="Reporte de Cotizaciones" />
        </Titles>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>
