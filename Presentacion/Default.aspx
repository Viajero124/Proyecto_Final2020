<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
            font-family: Bahnschrift;
        }
        .style2
        {
            color: #FFFFFF;
            font-size: larger;
        }
        .style3
        {
            width: 849px;
        }
    </style>
</head>
<body bgcolor="#006699">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span class="style2"><strong>Bienvenido al Sitio Oficial de Tramites Publicos Online</strong></span><br />
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:LinkButton ID="lknLogueo" runat="server" 
                        PostBackUrl="~/Logueo.aspx" style="color: #FFFFFF">Loguearse</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 600px" border="1">
            <tr>
                <td style="width: 211px" class="style1">
                    Listado de Entidades Publicas</td>
                <td style="width: 482px">
                    <asp:GridView ID="GVCompleto" runat="server" Width="427px" 
                        AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnVer" runat="server" OnClick="btnVer_Click" Text="Usar Seleccion" />
                    &nbsp;<asp:Button ID="btnBorrar" runat="server" OnClick="btnBorrar_Click" Text="Borrar Seleccion" />&nbsp;<br />
                    <br />
                    <asp:Button ID="btnCopiar" runat="server" OnClick="btnCopiar_Click" Text="Agregar a Seleccionadas" /><br />
                </td>
            </tr>
            <tr>
                <td style="width: 211px; height: 59px" class="style1">
                    Tipos de tramites habilitados para realizar solicitudes
                  </td>
                <td style="width: 482px; height: 59px">
                    <asp:GridView ID="GVSeleccion" runat="server" BackColor="White" 
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 211px">
                </td>
                <td style="width: 482px">
                    <asp:Label ID="lblerror" runat="server" Width="400px" 
                        style="color: #FFFFFF; font-family: Bahnschrift"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 211px">
                    &nbsp;</td>
                <td style="width: 482px">
                    <asp:LinkButton ID="Consulta" runat="server" 
                        PostBackUrl="~/Consulta_Estado_Solicitud.aspx" style="color: #FFFFFF">Consulta Estado Solicitud</asp:LinkButton>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>