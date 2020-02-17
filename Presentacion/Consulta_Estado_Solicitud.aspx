<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consulta_Estado_Solicitud.aspx.cs" Inherits="Consulta_Estado_Solicitud" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 271px;
        }
        .style2
        {
            width: 340px;
        }
        .style3
        {
            color: #FFFFFF;
            font-family: Bahnschrift;
        }
        .style4
        {
            color: #FFFFFF;
        }
        .auto-style1 {
            width: 340px;
            text-align: center;
        }
        .auto-style2 {
            width: 340px;
            text-align: left;
        }
        .auto-style3 {
            width: 271px;
            height: 23px;
        }
        .auto-style4 {
            width: 340px;
            height: 23px;
            text-align: center;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            font-size: larger;
        }
    </style>
</head>
<body bgcolor="Black">
    <form id="form1" runat="server">
    <div class="style4">
    
        <p style="margin-left: 280px">
            &nbsp;</p>
    
    </div>
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
            </td>
            <td class="auto-style4">
                <strong>
                <asp:Label ID="Label1" runat="server" CssClass="auto-style6" ForeColor="White" 
                    Text="CONSULTA ESTADO SOLICITUD"></asp:Label>
                </strong>
            </td>
            <td class="auto-style5">
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblSolicitud" runat="server" Text="Ingrese Numero de Solicitud:" 
                    CssClass="style3"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtSolicitud" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                    onclick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="lblError" runat="server" CssClass="style3"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                    style="color: #CC0000">Volver</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
