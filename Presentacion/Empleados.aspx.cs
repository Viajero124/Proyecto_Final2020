using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class Empleados : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void LimpioFormulario()
    {
        btnAgregarEmp.Enabled = false;
        btnModificarEmp.Enabled = false;
        btnEliminarEmp.Enabled = false;
        btnBuscarEmp.Enabled = true;
        txtCI.Enabled = true;
        txtCI.Text = "0";
        txtNomEmp.Text = "";
        txtContraseña.Text = "";
        lblError.Text = "";
    }

    private void ActivoBotonesA()
    {
        btnModificarEmp.Enabled = false;
        btnEliminarEmp.Enabled = false;
        btnAgregarEmp.Enabled = true;
        btnBuscarEmp.Enabled = false;

        txtCI.Enabled = false;
    }

    private void ActivoBotonesBM()
    {
        btnModificarEmp.Enabled = true;
        btnEliminarEmp.Enabled = true;
        btnAgregarEmp.Enabled = false;
        btnBuscarEmp.Enabled = false;

        txtCI.Enabled = false;
    }

    protected void btnBuscarEmp_Click(object sender, EventArgs e)
    {
        try
        {
            int _cedula = Convert.ToInt32(txtCI.Text);
            Usuario _objeto = Logica_Usuario.Buscar(_cedula);
      
            if (_objeto == null)
            {
                this.ActivoBotonesA();
                Session["UsuarioABM"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["UsuarioABM"] = _objeto;

                txtNomEmp.Text = _objeto.NomEmpleado;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregarEmp_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario _unEmp = new Usuario(Convert.ToInt32(txtCI.Text), txtNomEmp.Text.Trim(), txtContraseña.Text);
            Logica.Logica_Usuario.Alta(_unEmp);
            lblError.Text = "Alta con exito";

            this.LimpioFormulario();
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

    protected void btnModificarEmp_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario _unEmp = (Usuario)Session["UsuarioABM"];

            //modifico el objeto
            _unEmp.NomEmpleado = txtNomEmp.Text.Trim();

            Logica_Usuario.Modificar(_unEmp);
            lblError.Text = "Modificacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminarEmp_Click(object sender, EventArgs e)
    {

        try
        {
            Usuario _unEmp = (Usuario)Session["UsuarioABM"];

            Logica_Usuario.Eliminar(_unEmp);

            lblError.Text = "Eliminacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
