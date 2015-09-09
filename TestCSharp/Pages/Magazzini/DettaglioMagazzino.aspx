<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DettaglioMagazzino.aspx.cs"
    Inherits="TestCSharp.Pages.DettaglioMagazzino" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            Dettaglio magazzino</h1>
    </div>
    <asp:Panel runat="server" ID="pnlDettaglioMagazzino">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblNome" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvNome" ControlToValidate="txtNome"
                        ErrorMessage="Il nome è un campo obbligatorio" Display="None" ValidationGroup="vgSalva"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnAnnulla" Text="Annulla" OnClick="btnAnnulla_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSalva" Text="Salva" OnClick="btnSalva_Click" ValidationGroup="vgSalva" />
                    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"
                        ValidationGroup="vgSalva" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
