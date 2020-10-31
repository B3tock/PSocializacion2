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
            ClientesEntity cliente = (ClientesEntity)Session["User"];
            List<EstadisticaEntity> dataList = estadisticaBusiness.ConsultarEstadisticas(cliente.codigo);
            chartEstadistica.DataSource = dataList;
            chartEstadistica.DataBind();            
        }
    }
}