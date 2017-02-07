<%@ Page Title="Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSystem.Web.ViewArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView
        ID="FormView1"
        runat="server"
        ItemType="NewsSystem.Data.Models.Article"
        SelectMethod="DetailsViewGetItem">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <h1><%#:Item.Title %><small> Category: <%#:Item.Category.Name %></small></h1>
            <p><%#:Item.Content %></p>
            <p>Author: <%#:Item.Author.UserName %> </p>
            <p class="pull-right"><%#: Item.DateCreated %></p>
        </ItemTemplate>
        <EmptyDataTemplate>
            The required Article does not exist.
        </EmptyDataTemplate>
    </asp:FormView>
</asp:Content>
