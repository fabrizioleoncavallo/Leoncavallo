<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaArticoli.aspx.cs" Inherits="TestCSharp.Pages.ListaArticoli"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Lista articoli</h1>
    </div>
    <asp:Panel runat="server">
        <table>
            <tr>
                <td><asp:Label runat="server" Text="Nome"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtNome"></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView runat="server" ID="gvArticoli" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
