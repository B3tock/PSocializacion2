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
                ClientesEntity proveedor = (ClientesEntity)Session["User"];
                gridCotizaciones.DataSource = cotizacionBusiness.ConsultarCotizacionesProveedor(proveedor.codigo);
                gridCotizaciones.DataBind();

                ddlCatalogo.DataSource = catalogoBusiness.ConsultarCatalogosProveedor(proveedor.codigo);
                ddlCatalogo.DataBind();

                ddlDespacho.DataSource = despachoBusiness.ConsultarDespachos();
                ddlDespacho.DataBind();
            }
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            ClientesEntity proveedor = (ClientesEntity)Session["User"];
            ddlCatalogo.DataSource = catalogoBusiness.ConsultarCatalogosProveedor(proveedor.codigo);
            ddlCatalogo.DataBind();

            ddlDespacho.DataSource = despachoBusiness.ConsultarDespachos();
            ddlDespacho.DataBind();

            MultiView1.ActiveViewIndex = 1;
            ActivarControles();
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
            txbPrecio.Text = string.Empty;
            ddlCatalogo.SelectedIndex = 0;
            txbDescripcion.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            if (ddlDespacho.SelectedIndex > 0)
                ddlDespacho.SelectedIndex = 0;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            ClientesEntity proveedor = (ClientesEntity)Session["User"];
            gridCotizaciones.DataSource = cotizacionBusiness.ConsultarCotizacionesProveedor(proveedor.codigo);
            gridCotizaciones.DataBind();
            
            MultiView1.ActiveViewIndex = 0;
            LimpiarControles();
        }

        protected void gridCotizaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCodigo.Text = gridCotizaciones.SelectedRow.Cells[0].Text;
            int codigo = 0;
            if (!string.IsNullOrEmpty(lblCodigo.Text))
                codigo = Convert.ToInt32(lblCodigo.Text);

            CotizacionEntity entidad = new CotizacionEntity();
            entidad = cotizacionBusiness.ConsultarCotizacionPorID(codigo);
                        
            txbPrecio.Text = entidad.precio.ToString();
            ddlCatalogo.SelectedValue = entidad.codigoCatalogo.ToString();
            txbDescripcion.Text = entidad.descripcion;
            ddlEstado.SelectedValue = entidad.estado;
            ddlDespacho.SelectedValue = entidad.codigoDespacho.ToString();

            MultiView1.ActiveViewIndex = 1;
            InactivarControles();
        }

        void InactivarControles()
        {
            txbPrecio.Enabled = false;
            ddlCatalogo.Enabled = false;
            txbDescripcion.Enabled = false;
            ddlDespacho.Enabled = false;
        }
        void ActivarControles()
        {
            txbPrecio.Enabled = true;
            ddlCatalogo.Enabled = true;
            txbDescripcion.Enabled = true;
            ddlDespacho.Enabled = true;
        }
    }
}