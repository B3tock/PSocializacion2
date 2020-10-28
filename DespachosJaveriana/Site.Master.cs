using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DespachosJaveriana
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientesEntity cliente = (ClientesEntity)Session["User"];
            MenuItemCollection menuItems = MenuFactory.Items;
            MenuItem adminItem = new MenuItem();

            if (cliente.tipoUsuario == "Proveedor")
            {
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Despacho")
                    {
                        adminItem = menuItem;
                    }
                }

                menuItems.Remove(adminItem);
            }
            else
            {
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Cotización")
                    {
                        adminItem = menuItem;                        
                    }
                }

                menuItems.Remove(adminItem);

                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Catálogo")
                    {
                        adminItem = menuItem;                        
                    }
                }

                menuItems.Remove(adminItem);
            }
        }

        protected void MenuFactory_MenuItemClick(object sender, MenuEventArgs e)
        {
            MenuItemCollection menuItems = MenuFactory.Items;
            MenuItem adminItem = new MenuItem();

            foreach (MenuItem menuItem in menuItems)
            {
                if (menuItem.Text == "Salir")
                {
                    try
                    {                        
                        Session.Abandon();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "dza", "<script type='text/javascript'>window.location='" + ResolveUrl("Login.aspx") + "';</script>", false);                        
                    }
                    catch (Exception exc)
                    {
                        
                    }
                }
            }
        }
    }
}