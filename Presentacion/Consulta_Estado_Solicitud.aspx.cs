using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;


public partial class Consulta_Estado_Solicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int numero = 0;
        try
        {
            numero = Convert.ToInt32(txtSolicitud.Text);

        }
        catch
        {
            lblError.Text = "Debe ingresar un numero mayor a cero";
            return;


        }
        try
        {
            Solicitud_de_Tramite sol = Logica_Solicitud_de_tramite.Buscar(numero);
            if (sol != null)
            {

                lblError.Text = sol.EstadoSolicitud;


                Session["UnaSolicitud"] = sol;

            }
            else
            {
                
                Session["UnAlumno"] = null;

            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

        
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {

    }
}