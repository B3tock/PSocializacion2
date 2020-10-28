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
            if (!IsPostBack)
                LoadData();
        }

        void LoadData()
        {
            List<EstadisticaEntity> dataList = estadisticaBusiness.ConsultarEstadisticas();
            chartEstadistica.DataSource = dataList;
            chartEstadistica.DataBind();

            /*string[] x = new string[dataList.Count];
            float[] y = new float[dataList.Count];
            for (int i = 0; i < dataList.Count; i++)
            {
                x[i] = dataList[i].Catalogo;
                y[i] = dataList[i].Precio;
            }
            chartEstadistica.Series[0].Points.DataBindXY(x, y);
            chartEstadistica.Series[0].ChartType = SeriesChartType.Pie;
            //chartEstadistica.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            chartEstadistica.Legends[0].Enabled = true;*/
        }
    }
}