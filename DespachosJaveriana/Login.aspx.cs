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
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Este es el page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("FormRegistro.aspx");
        }

        protected void lbRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormRegistro.aspx");
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                lbMensaje.Text = string.Empty;
                ClientesEntity cliente = new ClientesEntity();
                UsuarioBusiness negocio = new UsuarioBusiness();

                cliente.login = txbUsuario.Text.Trim();
                cliente.password = txbContrasenia.Text.Trim();

                cliente = negocio.Loginusuario(cliente);
                if (cliente.login == txbUsuario.Text.Trim())
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lbMensaje.Text = "Acceso no autorizado!!!";
                }
            }
            catch (Exception exc)
            {
                //throw new Exception("Ocurió un error durante el proceso " + exc.Message);
            }
        }

        protected void lbReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}