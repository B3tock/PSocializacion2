using DespachosBusinessLayer.Business;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DespachosJaveriana.Catalogo
{
    public partial class FormCatalogo : System.Web.UI.Page
    {
        CatalogoBusiness catalogoBusiness = new CatalogoBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridCatalogos.DataSource = catalogoBusiness.ConsultarCatalogos();
                gridCatalogos.DataBind();                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoServicioEntity catalogoServicioEntity = new CatalogoServicioEntity();

                if (!string.IsNullOrEmpty(lblCodigo.Text))
                    catalogoServicioEntity.codigo = Convert.ToInt32(lblCodigo.Text);
                catalogoServicioEntity.nombre = txbNombre.Text.Trim();
                catalogoServicioEntity.descripcion = txbDescripcion.Text.Trim();
                catalogoServicioEntity.precio = float.Parse(txbPrecio.Text.Trim());
                catalogoServicioEntity.estado = ddlEstado.SelectedValue;
                catalogoServicioEntity.categoria = txbCategoria.Text.Trim();

                ClientesEntity usuario = (ClientesEntity)Session["User"];
                catalogoServicioEntity.codigoProveedor = Convert.ToInt32(usuario.codigo);

                int id = 0;
                if (catalogoServicioEntity.codigo > 0)
                    id = catalogoBusiness.ActualizarCatalogo(catalogoServicioEntity);
                else
                    id = catalogoBusiness.InsertarCatalogos(catalogoServicioEntity);

                lblMensajeCatalogo.Text = string.Empty;
                if (id > 0)
                {
                    lblMensajeCatalogo.Text = "Registro guardado";
                    LimpiarControles();
                }
                else
                    lblMensajeCatalogo.Text = "El registro no se pudo guardar";
            }
            catch (Exception exc)
            {

            }
        }

        protected void gridCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCodigo.Text = gridCatalogos.SelectedRow.Cells[0].Text;
            txbNombre.Text = gridCatalogos.SelectedRow.Cells[1].Text;
            txbDescripcion.Text = gridCatalogos.SelectedRow.Cells[2].Text;
            txbPrecio.Text = gridCatalogos.SelectedRow.Cells[3].Text;
            ddlEstado.SelectedValue = gridCatalogos.SelectedRow.Cells[4].Text;
            txbCategoria.Text = gridCatalogos.SelectedRow.Cells[5].Text;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void gridCatalogos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gridCatalogos.DataSource = catalogoBusiness.ConsultarCatalogos();
            gridCatalogos.DataBind();
            LimpiarControles();            
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiView1.ActiveViewIndex = 1;
        }

        private void LimpiarControles()        
        {
            lblCodigo.Text = string.Empty;
            txbNombre.Text = string.Empty;
            txbDescripcion.Text = string.Empty;
            txbPrecio.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
            txbCategoria.Text = string.Empty;
        }

        protected void gridCatalogos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}