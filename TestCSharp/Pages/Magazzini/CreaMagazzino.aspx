<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreaMagazzino.aspx.cs"
    Inherits="TestCSharp.Pages.Magazzini.CreaMagazzino" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            Crea magazzino</h1>
    </div>
    <asp:Panel runat="server" ID="pnlCreaMagazzino">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblNome" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvNome" ControlToValidate="txtNome"
                        ErrorMessage="Il nome è un campo obbligatorio" Text="*" Display="None" ValidationGroup="vgAggiungi"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnAnnulla" Text="Annulla" OnClick="btnAnnulla_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnAggiungi" Text="Aggiungi" OnClick="btnAggiungi_Click"
                        ValidationGroup="vgAggiungi" />
                    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"
                        ValidationGroup="vgAggiungi" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>