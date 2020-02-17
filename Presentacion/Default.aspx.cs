using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //cargo dos listas en la session para trabajar
            Session["_listaC"] = Logica_EntidadesP.ListarEntidades();
            Session["_listaS"] = new List<Tipo_de_Tramite>();
            //cargo las dos grillas
            GVCompleto.DataSource = (List<Entidades_Publicas>)Session["_listaC"];
            GVCompleto.DataBind();
            GVSeleccion.DataSource = (List<Tipo_de_Tramite>)Session["_listaS"];
            GVSeleccion.DataBind();


        }

    }
    protected void btnVer_Click(object sender, EventArgs e)
    {
        try
        {
            //primero verifico que haya una linea seleccionada
            if (GVCompleto.SelectedRow != null)
            {
                string nombre = GVCompleto.SelectedRow.Cells[2].Text;
                Entidades_Publicas enti = Logica_EntidadesP.Buscar(nombre);
                lblerror.Text = "Ud. Selecciono la Entidad" + enti.ToString() + "\n";


            }

        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
        }

    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        List<Entidades_Publicas> _listaC = (List<Entidades_Publicas>)Session["_listaC"];
        try
        {
            //primero verifico que haya una linea seleccionada
            if (GVCompleto.SelectedRow != null)
            {
                //saco el identificador de publicacion y lo borro d3e la lista completa
                //el metodo Remove at de los List borra pasandole la ubicacion del objeto
                //dentro de la coleccion dinamica
                _listaC.RemoveAt(GVCompleto.SelectedRow.RowIndex);
                GVCompleto.DataSource = _listaC;
                GVCompleto.DataBind();



            }

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;


        }

    }
    protected void btnCopiar_Click(object sender, EventArgs e)
    {
        Tipo_de_Tramite tram = null;
        List<Tipo_de_Tramite> _listaS = (List<Tipo_de_Tramite>)Session["_ListaS"];
        //primero verifico que haya una linea seleccionada
        if (GVCompleto.SelectedRow != null)
        {
            try
            {
                string nombre = GVCompleto.SelectedRow.Cells[2].Text;
                tram = Logica_TipoTramite.Buscar(nombre);
                _listaS.Add(tram);
                GVSeleccion.DataSource = _listaS;
                GVSeleccion.DataBind();


            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message;

            }

        }

    }
    
}