using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class Registro_de_Solicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargo dos listas en la session para trabaja
            Session["_listaC"] = Logica_TipoTramite.ListarTipoTramite();
            
            //cargo las dos grillas
          
            GVCompleto.DataSource = (List<Tipo_de_Tramite>)Session["_listaC"];
            GVCompleto.DataBind();
            


        }
    }
    protected void GVCompleto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[4].Visible = false;


        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[4].Visible = false;


        }
    }
        protected void btnVer_Click(object sender, EventArgs e)
    {
        try
        {
            //primero verifico que haya una linea seleccionada
            if (GVCompleto.SelectedRow != null)
            {
                string nombre = GVCompleto.SelectedRow.Cells[1].Text;
                Tipo_de_Tramite Ttra = Logica_TipoTramite.Buscar(nombre);
                lblerror.Text = "Ud. Selecciono la Entidad" + Ttra.ToString() + "\n";


            }

        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
        }

    
   

    }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string oMensaje = "";
            string nombreCliente="";
            try
            {
                nombreCliente = txtSolicitante.Text;

            }
            catch
            {
                oMensaje = "El nombre no es correcto";

            }
            
            DateTime FechayHora = Convert.ToDateTime(txtFechayHora.Text);
            string EstadoSolicitud="Alta";
            
           

            if (oMensaje != "")
            {
                lblError2.Text = oMensaje;

            }
            else//todo bien en cuanto a tipo de datos
            {
                try
                {
                    if (GVCompleto.SelectedRow != null)
                    {
                        string nombre = GVCompleto.SelectedRow.Cells[1].Text;
                        Tipo_de_Tramite Ttra = Logica_TipoTramite.Buscar(nombre);
                        lblerror.Text = "Ud. Selecciono la Entidad" + Ttra.ToString() + "\n";

                        Solicitud_de_Tramite soli = new Solicitud_de_Tramite(0, (Usuario)Session["Usuario"], Ttra, FechayHora, nombreCliente, EstadoSolicitud);

                        Logica_Solicitud_de_tramite.Agregar(soli);
                        lblError2.Text = "Alta con exito";
                    }

                   
                   

                }
                catch (Exception ex)
                {

                    lblError2.Text = ex.Message;
                }

            }
        }

}
