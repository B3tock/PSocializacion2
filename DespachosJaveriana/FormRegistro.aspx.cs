using DespachosBusinessLayer.Business;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DespachosJaveriana
{
    public partial class FormRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                ClientesEntity cliente = new ClientesEntity();
                UsuarioBusiness negocio = new UsuarioBusiness();

                cliente.codigo = 0;
                cliente.correo = txbCorreo.Text.Trim();
                cliente.direccion = txbDireccion.Text.Trim();
                cliente.fechaCreacion = DateTime.Now;
                cliente.login = txbCorreo.Text.Trim();
                cliente.nit = txbNit.Text.Trim();
                cliente.nombre = txbNombre.Text.Trim();
                cliente.password = txbContrasenia.Text.Trim();
                cliente.razonSocial = txbRazonSocial.Text.Trim();
                cliente.sitioWeb = txbSitioWeb.Text.Trim();
                cliente.telefono = txbTelefono.Text.Trim();
                cliente.tipoUsuario = ddlTipoUsuario.SelectedValue;

                negocio.InsertarClientes(cliente);
            }
            catch (Exception exc)
            {
                throw new Exception("Ocurió un error durante el proceso " + exc.Message);
            }

            lblMensaje.Text = "Registro exitoso";

            LimpiarCampos();
            lbIrLogin.Visible = true;
        }

        private void LimpiarCampos()
        {
            txbCorreo.Text = string.Empty;
            txbDireccion.Text = string.Empty;            
            txbCorreo.Text = string.Empty;
            txbNit.Text = string.Empty;
            txbNombre.Text = string.Empty;
            txbContrasenia.Text = string.Empty;
            txbRazonSocial.Text = string.Empty;
            txbSitioWeb.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            ddlTipoUsuario.SelectedIndex = 0;
        }

        protected void lbIrLogin_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dza", "<script type='text/javascript'>window.location='" + ResolveUrl("Login.aspx") + "';</script>", false);
        }
    }
}