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
        }

        protected void lbIrLogin_Click(object sender, EventArgs e)
        {

        }
    }
}