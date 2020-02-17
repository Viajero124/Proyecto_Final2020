<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 741px;
        }
    </style>
</head>
<body bgcolor="#61679e">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario :"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtUsuario" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtUsuario" ErrorMessage="Debe Ingresar Usuario"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña  :"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtContraseña" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtContraseña" ErrorMessage="Debe Ingresar Contraseña"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1" style="margin-left: 80px">
                <asp:Button ID="BtnLogueo" runat="server" onclick="BtnLogueo_Click" 
                    Text="Login" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
