using DespachosBusinessLayer.Business;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace DespachosJaveriana.Estadisticas
{
    public partial class FormEstadisticas : System.Web.UI.Page
    {
        EstadisticaBusiness estadisticaBusiness = new EstadisticaBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EstadisticaEntity> dataList = estadisticaBusiness.ConsultarEstadisticas();

            chartEstadistica.Palette = ChartColorPalette.Pastel;
            chartEstadistica.Titles.Add("Cotizaciones");

            foreach (EstadisticaEntity data in dataList)
            {
                Series serie = chartEstadistica.Series.Add(data.Proveedor);
                serie.Label = data.Precio.ToString();
                serie.Points.Add(data.Precio);
            }
        }
    }
}