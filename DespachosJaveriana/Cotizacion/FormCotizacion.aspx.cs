using DespachosBusinessLayer.Business;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DespachosJaveriana.Cotizacion
{
    public partial class FormCotizacion : System.Web.UI.Page
    {
        CotizacionBusiness cotizacionBusiness = new CotizacionBusiness();
        CatalogoBusiness catalogoBusiness = new CatalogoBusiness();
        DespachoBusiness despachoBusiness = new DespachoBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridCotizaciones.DataSource = cotizacionBusiness.ConsultarCotizaciones();
                gridCotizaciones.DataBind();
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            //estadosNovedad.Insert(0, new EstadoNovedadSolicitud { IdEstadoNovedadSolicitud = 0, Descripcion = "Seleccione" });

            ddlCatalogo.DataSource = catalogoBusiness.ConsultarCatalogos();
            ddlCatalogo.DataBind();

            ddlDespacho.DataSource = despachoBusiness.ConsultarDespachos();
            ddlDespacho.DataBind();

            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CotizacionEntity entidad = new CotizacionEntity();
                if (lblCodigo.Text != string.Empty)
                    entidad.codigo = Convert.ToInt32(lblCodigo.Text);
                entidad.fecha = DateTime.Now;                
                if (float.TryParse(txbPrecio.Text.Trim(), out float precio))
                    entidad.precio = precio;
                entidad.codigoCatalogo = Convert.ToInt32(ddlCatalogo.SelectedValue);
                entidad.descripcion = txbDescripcion.Text.Trim();
                entidad.estado = ddlEstado.SelectedValue;
                entidad.codigoDespacho = Convert.ToInt32(ddlDespacho.SelectedValue);

                lblMensajeCotizacion.Text = string.Empty;
                
                int id = 0;
                if (entidad.codigo > 0)
                    id = cotizacionBusiness.ActualizarCotizacion(entidad);
                else
                    id = cotizacionBusiness.InsertarCotizacion(entidad);

                if (id > 0)
                {
                    lblMensajeCotizacion.Text = "Registro guardado";
                    LimpiarControles();
                }
                else
                    lblMensajeCotizacion.Text = "El registro no se pudo guardar";
            }
            catch (Exception exc)
            {

            }
        }

        private void LimpiarControles()
        {
            lblCodigo.Text = string.Empty;
            lblMensajeCotizacion.Text = string.Empty;
            txbPrecio.Text = string.Empty;
            ddlCatalogo.SelectedIndex = 0;
            txbDescripcion.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            ddlDespacho.SelectedIndex = 0;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}