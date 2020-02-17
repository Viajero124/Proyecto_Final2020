<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_Principal.master" AutoEventWireup="true" CodeFile="Registro_de_Solicitud.aspx.cs" Inherits="Registro_de_Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
            color: #000000;
            font-family: Bahnschrift;
            width: 537px;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
    <div style="text-align: center">
        <span class="style2"><strong>Bienvenido al Sitio Oficial de Tramites Publicos Online</strong></span><br />
        <br />
        <br />
        <table style="width: 600px" border="1">
            <tr>
                <td style="width: 211px" class="style3">
                    Listado de Entidades Publicas</td>
                <td style="width: 482px">
                    <asp:GridView ID="GVCompleto" runat="server" Width="427px" 
                        AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GVCompleto_RowDataBound">
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
                    &nbsp;&nbsp;<br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 211px; height: 59px" class="style3">
                    Tipos de tramites habilitados para realizar solicitudes
                  </td>
                <td style="width: 482px; height: 59px">
                    <asp:Label ID="lblerror" runat="server" Width="400px" 
                        style="color: #FFFFFF; font-family: Bahnschrift"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 211px">
                    <asp:Label ID="lblFecha" runat="server" Text="Ingrese Fecha y hora"></asp:Label>
                </td>
                <td style="width: 482px">
                    <asp:TextBox ID="txtFechayHora" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 211px">
                    <asp:Label ID="lblSolicitante" runat="server" Text="Nombre del Solicitante"></asp:Label>
                </td>
                <td style="width: 482px">
                    <asp:TextBox ID="txtSolicitante" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 211px">
                    &nbsp;</td>
                <td style="width: 482px">
                    <asp:Button ID="btnConfirmar" runat="server" onclick="btnConfirmar_Click" 
                        Text="Confirmar" />
                </td>
            </tr>
            <tr>
                <td style="width: 211px">
                    &nbsp;</td>
                <td style="width: 482px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 211px">
                    &nbsp;</td>
                <td style="width: 482px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 211px">
                    &nbsp;</td>
                <td style="width: 482px">
                    <asp:Label ID="lblError2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 211px">
                    &nbsp;</td>
                <td style="width: 482px">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    

</asp:Content>

