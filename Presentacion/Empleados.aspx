<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_Principal.master" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
        .style1
        {
            text-align: left;
            font-size: large;
        }
        .style2
        {
            text-align: right;
            font-size: large;
            width: 604px;
        }
        .style3
        {
            text-align: center;
            font-size: large;
            width: 434px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width: 100%; height: 81px;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                Mantenimiento Empleados</td>
            <td class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Cedula de Identidad:&nbsp;
            </td>
            <td class="style3">
                <asp:TextBox ID="txtCI" runat="server" Width="280px"></asp:TextBox>
            </td>
            <td class="style1">
                <asp:Button ID="btnBuscarEmp" runat="server" Text="Buscar" Width="101px" 
                    onclick="btnBuscarEmp_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Nombre del Empleado:</td>
            <td class="style3">
                <asp:TextBox ID="txtNomEmp" runat="server" Width="280px"></asp:TextBox>
            </td>
            <td class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Contraseña:</td>
            <td class="style3">
                <asp:TextBox ID="txtContraseña" runat="server" Width="280px" 
                    TextMode="Password"></asp:TextBox>
            </td>
            <td class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnModificarEmp" runat="server" Text="Modificar" 
                    Width="101px" onclick="btnModificarEmp_Click" />
                <asp:Button ID="btnAgregarEmp" runat="server" Text="Agregar" Width="101px" 
                    onclick="btnAgregarEmp_Click" />
                <asp:Button ID="btnEliminarEmp" runat="server" Text="Eliminar" Width="101px" 
                    onclick="btnEliminarEmp_Click" />
            </td>
            <td class="style1">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="101px" 
                    onclick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
            </td>
            <td class="style1">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

