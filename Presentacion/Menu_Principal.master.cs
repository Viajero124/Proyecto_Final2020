using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu_Principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string bienvenida="Bienvenido ";
        txtUsuarioActivo.Text = bienvenida + (string)Session["UsuarioActivo"].ToString();
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
     System.Web.Security.FormsAuthentication.SignOut();  
     Session.Clear();
     Session.Abandon();
     Response.Redirect("Default.aspx");
    }
}
