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
            
        }

        protected void lbRegistro_Click(object sender, EventArgs e)
        {            
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dza", "<script type='text/javascript'>window.location='" + ResolveUrl("FormRegistro.aspx") + "';</script>", false);
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
                Session.Add(Global.AUTHENTICATION_KEY, cliente);
                if (cliente.login == txbUsuario.Text.Trim())
                {                    
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dza", "<script type='text/javascript'>window.location='" + ResolveUrl("Default.aspx") + "';</script>", false);
                }
                else
                {
                    lbMensaje.Text = "Acceso no autorizado!!!";
                    string message = "Usuario no autenticado intente de nuevo";
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "", "<script type='text/javascript'>myfunction('" + message + "');</script>", false);
                }
            }
            catch (Exception exc)
            {
                lbMensaje.Text = exc.Message;
            }
        }

        protected void lbReset_Click(object sender, EventArgs e)
        {            
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dza", "<script type='text/javascript'>window.location='" + ResolveUrl("ResetPassword.aspx") + "';</script>", false);
        }
    }
}