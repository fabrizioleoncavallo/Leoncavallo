<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DettaglioArticolo.aspx.cs"
    Inherits="TestCSharp.Pages.Articoli.DettaglioArticolo" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="server">
    <script type="text/javascript">
        function VerificaMovimentazione(source, arguments) {
            try {
                var ddlMagazzinoPartenza = document.getElementById('<%= ddlMagazzinoPartenza.ClientID %>');
                var ddlMagazzinoDestinazione = document.getElementById('<%= ddlMagazzinoDestinazione.ClientID %>');
                var selectedMagazzinoPartenza = ddlMagazzinoPartenza.value;
                var selectedMagazzinoDestinazione = ddlMagazzinoDestinazione.value;
                arguments.IsValid = selectedMagazzinoPartenza != selectedMagazzinoDestinazione;
            }
            catch (ex) {
                arguments.IsValid = false;
                alert("" + ex.Message);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            Dettaglio articolo</h1>
    </div>
    <fieldset>
        <legend>Dettaglio</legend>
        <asp:Panel runat="server" ID="pnlDettaglioArticolo">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblNome" Text="Nome"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvNome" ControlToValidate="txtNome"
                            ErrorMessage="Il nome è un campo obbligatorio" Text="*" Display="None" ValidationGroup="vgSalva"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnAnnulla" Text="Indietro" OnClick="btnAnnulla_Click" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSalva" Text="Salva" OnClick="btnSalva_Click" ValidationGroup="vgSalva" />
                        <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"
                            ValidationGroup="vgSalva" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
    <fieldset>
        <legend>Movimentazioni</legend>
        <asp:Panel runat="server" ID="pnlMovimentazioni">
            <asp:GridView runat="server" ID="gvMovimentazioni" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="MagazzinoPartenza.Nome" HeaderText="Magazzino di partenza" />
                    <asp:BoundField DataField="MagazzinoDestinazione.Nome" HeaderText="Magazzino di destinazione" />
                    <asp:BoundField DataField="Causale.Nome" HeaderText="Causale" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </fieldset>
    <asp:Button runat="server" ID="btnAggiungiMovimentazione" Text="Aggiungi movimentazione"
        OnClick="btnAggiungiMovimentazione_Click" />
    <fieldset runat="server" id="fsAggiungiMovimentazione">
        <legend>Aggiungi movimentazione</legend>
        <asp:Panel runat="server" ID="CreaMovimentazione">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblMagazzinoPartenza" Text="Magazzino di partenza"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMagazzinoPartenza">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMagazzinoPartenza" ControlToValidate="ddlMagazzinoPartenza"
                            ErrorMessage="Il magazzino di partenza è un campo obbligatorio" Text="*" Display="None"
                            ValidationGroup="vgSalvaMovimentazione"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblMagazzinoDestinazione" Text="Magazzino di destinazione"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMagazzinoDestinazione">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMagazzinoDestinazione" ControlToValidate="ddlMagazzinoDestinazione"
                            ErrorMessage="Il magazzino di destinazione è un campo obbligatorio" Text="*"
                            Display="None" ValidationGroup="vgSalvaMovimentazione"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvMovimentazione" EnableClientScript="true" ClientValidationFunction="VerificaMovimentazione"
                            ValidationGroup="vgSalvaMovimentazione" ControlToValidate="ddlMagazzinoDestinazione"
                            ErrorMessage="Il magazzino di partenza non può coincidere con il magazzino di destinazione"
                            Text="*" runat="server"> </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblCausale" Text="Causale"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCausale">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="btnSalvaMovimentazione" Text="Salva movimentazione"
                OnClick="btnSalvaMovimentazione_Click" ValidationGroup="vgSalvaMovimentazione" />
            <asp:ValidationSummary ID="vsSalvaMovimentazione" runat="server" ShowSummary="false"
                ShowMessageBox="true" ValidationGroup="vgSalvaMovimentazione" />
        </asp:Panel>
    </fieldset>
</asp:Content>