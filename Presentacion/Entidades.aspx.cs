using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class Entidades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


private void DesactivoBotones()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        btnLimpiar.Enabled = false;
        btnAgregarTel.Enabled = false;
        btnEliminarTel.Enabled = false;
    }

    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        string nombreE;
        try
        {
            nombreE = txtNombreE.Text;

        }
        catch
        {
            lblError.Text = "El nombre no es correcto";
            return;


        }
        try
        {
            List<string> ListaT = new List<string>();
            Entidades_Publicas entiP = Logica_EntidadesP.Buscar(nombreE);
            if (entiP != null)
            {
                ListaT = entiP.MisTelefonos;

                txtNombreE.Text = entiP.Nombre;
                txtDireccion.Text = entiP.Direccion;
                lbTelefonos.DataSource = entiP.MisTelefonos;
                lbTelefonos.DataBind();
                Session["UnaEntidad"] = entiP;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
                btnAgregarTel.Enabled = true;
                btnEliminarTel.Enabled = true;
                btnLimpiar.Enabled = true;



            }
            else
            {
                btnAgregar.Enabled = true;
                btnAgregarTel.Enabled = true;
                btnLimpiar.Enabled = true;
                btnEliminarTel.Enabled = true;
                Session["UnaEntidad"] = null;

            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
         this.LimpioFormulario();
        

    }
    private void LimpioFormulario()
    {
        txtNombreE.Text = "";
        txtDireccion.Text = "";
        lbTelefonos.Items.Clear();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        string nombreE;
        try
        {
            nombreE = txtNombreE.Text;

        }
        catch
        {
            oMensaje = "El nombre no es correcto";

        }
        List<string> Telefonos = new List<string>();
        string Nombre = txtNombreE.Text;
        string Direccion = txtDireccion.Text;
        foreach (ListItem item in lbTelefonos.Items)
        Telefonos.Add(item.Text);

        if (oMensaje != "")
        {
            lblError.Text = oMensaje;

        }
        else//todo bien en cuanto a tipo de datos
        {
            try
            {
                Entidades_Publicas enti = new Entidades_Publicas(Nombre,Telefonos,Direccion);

                Logica_EntidadesP.Agregar(enti);
                lblError.Text = "Alta con exito";
                this.LimpioFormulario();
                this.DesactivoBotones();

            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }

        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        List<string> Telefonos = new List<string>();
        string Nombre = txtNombreE.Text;
        string Direccion = txtDireccion.Text;
        foreach (ListItem item in lbTelefonos.Items)
            Telefonos.Add(item.Text);


        Entidades_Publicas Enti = (Entidades_Publicas)Session["UnaEntidad"];
        Enti.Nombre = Nombre;
        Enti.Direccion = Direccion;
        Enti.MisTelefonos = Telefonos;
        


        

        try
        {
            Logica_EntidadesP.Modificar(Enti);
            lblError.Text = "Modificacion Exitosa";
            this.LimpioFormulario();
            this.DesactivoBotones();


        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;

        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Entidades_Publicas enti = (Entidades_Publicas)Session["UnaEntidad"];
            Logica_EntidadesP.Eliminar(enti);
            lblError.Text = "Eliminacion Exitosa";
            this.LimpioFormulario();
            this.DesactivoBotones();


        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }

    }
    protected void btnEliminarTel_Click(object sender, EventArgs e)
    {
        if (lbTelefonos.SelectedIndex >= 0)
        {
            lbTelefonos.Items.RemoveAt(lbTelefonos.SelectedIndex);
        }
    }
    protected void btnAgregarTel_Click(object sender, EventArgs e)
    {
        //Obtendo numero de tel a dar de alta en la lista
        string unTelefono = txtAgregarTel.Text;

        

        //Agrego a lista
        lbTelefonos.Items.Add(unTelefono);
        txtAgregarTel.Text = "";
    }
}