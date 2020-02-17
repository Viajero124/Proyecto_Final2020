using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //por defecto cada vez q vuelvo o paso por la defaul, determino q se realizo un Deslogueo
        Session["Usuario"] = null;
        Session["UsuarioActivo"] = null;
    }
    protected void BtnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico usuario
            Usuario unUsu = Logica_Usuario.Logueo(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
            if (unUsu != null)
            {
                //si llego aca es pq es valido
                Session["UsuarioActivo"] = unUsu.NomEmpleado;

                Session["Usuario"] = unUsu;
                Response.Redirect("Bienvenida.aspx");
               
            }
            else
                lblError.Text = "Datos Incorrectos";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}