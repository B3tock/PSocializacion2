<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormEstadisticas.aspx.cs" Inherits="DespachosJaveriana.Estadisticas.FormEstadisticas" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="Chart1" runat="server">
    <series>
        <asp:Series Name="Series1">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </chartareas>
</asp:Chart>
</asp:Content>
