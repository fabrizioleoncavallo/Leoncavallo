<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaMagazzini.aspx.cs"
    Inherits="TestCSharp.Pages.ListaMagazzini" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            Lista magazzini</h1>
    </div>
    <fieldset>
        <legend>Ricerca</legend>
        <asp:Panel runat="server" ID="pnlFiltri">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblNome" Text="Nome"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnResetta" Text="Resetta" OnClick="btnResetta_Click" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnRicerca" Text="Ricerca" OnClick="btnRicerca_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
    <fieldset>
        <legend>Risultati</legend>
        <asp:Panel runat="server" ID="pnlRisultati">
            <asp:GridView runat="server" ID="gvMagazzini" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDettaglio" Text="Dettaglio" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>'
                                OnClick="btnDettaglio_Click" Style="cursor: hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCancella" Text="Cancella" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>'
                                OnClick="btnCancella_Click" Style="cursor: hand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </fieldset>
    <asp:Button runat="server" ID="btnAggiungi" Text="Aggiungi" OnClick="btnAggiungi_Click" />
</asp:Content>
