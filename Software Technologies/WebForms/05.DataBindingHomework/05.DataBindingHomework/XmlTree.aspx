<%@ Page 
    Title="Tree" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="XmlTree.aspx.cs" 
    Inherits="_05.DataBindingHomework.XmlTree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>XML Tree</h2>
    <asp:TreeView ID="BookstoreTree" runat="server" DataSourceID="Bookstore">
 
    </asp:TreeView>
    <asp:XmlDataSource ID="Bookstore" runat="server" DataFile="~/bookstore.xml"></asp:XmlDataSource>
</asp:Content>
