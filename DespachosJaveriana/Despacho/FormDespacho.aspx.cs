using DespachosBusinessLayer.Business;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DespachosJaveriana.Despacho
{
    public partial class FormDespacho : System.Web.UI.Page
    {
        DespachoBusiness despachoBusiness = new DespachoBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClientesEntity cliente = (ClientesEntity)Session["User"];
                gridDespachos.DataSource = despachoBusiness.ConsultarDespachosPorCliente(cliente.codigo);
                gridDespachos.DataBind();
            }
        }
    }
}