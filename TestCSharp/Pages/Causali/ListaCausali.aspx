<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaCausali.aspx.cs" Inherits="TestCSharp.Pages.ListaCausali"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            Lista causali</h1>
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
            <asp:GridView runat="server" ID="gvCausali" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </fieldset>
</asp:Content>
