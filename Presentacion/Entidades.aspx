<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_Principal.master" AutoEventWireup="true" CodeFile="Entidades.aspx.cs" Inherits="Entidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 377px;
        }
        .style3
        {
            width: 268px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table style="width:100%;">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblNombreE" runat="server" Text="Nombre Entidad Publica:"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtNombreE" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click1" 
                    Text="Buscar" Width="89px" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" Width="91px" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblTelefonos" runat="server" Text="Telefonos :"></asp:Label>
            </td>
            <td class="style1">
                <asp:ListBox ID="lbTelefonos" runat="server"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="btnEliminarTel" runat="server" Text=" Eliminar Telefono" 
                    Width="139px" onclick="btnEliminarTel_Click" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                <asp:TextBox ID="txtAgregarTel" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAgregarTel" runat="server" Text="Agregar Telefono" 
                    onclick="btnAgregarTel_Click" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" Width="86px" />
                <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                    Text="Modificar" Width="81px" />
                <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                    Text="Eliminar" Width="84px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                <asp:LinkButton ID="lkbVolver" runat="server" PostBackUrl="~/Bienvenida.aspx">Volver</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   
</asp:Content>
