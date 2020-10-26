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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoServicioEntity catalogoServicioEntity = new CatalogoServicioEntity();
                catalogoServicioEntity.nombre = txbNombre.Text.Trim();
                catalogoServicioEntity.descripcion = txbDescripcion.Text.Trim();
                catalogoServicioEntity.precio = float.Parse(txbPrecio.Text.Trim());
                catalogoServicioEntity.estado = ddlEstado.SelectedValue;
                catalogoServicioEntity.categoria = txbCategoria.Text.Trim();
                ClientesEntity usuario = (ClientesEntity)Session["User"];
                catalogoServicioEntity.codigoProveedor = Convert.ToInt32(usuario.codigo);
                int id = catalogoBusiness.InsertarCatalogos(catalogoServicioEntity);
            }
            catch (Exception exc)
            {
                
            }
        }
    }
}