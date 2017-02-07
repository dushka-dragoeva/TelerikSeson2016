<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NewsSystem.Web._Default" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>News</h1>
    <h2>Most Popular Articles</h2>
    <asp:Repeater
        ID="MostPopulerArticles"
        runat="server"
        ItemType="NewsSystem.Data.Models.Article"
        SelectMethod="MostPopulerArticles_GetDatail">
        <ItemTemplate>
            <h3><a href="ViewArticle?id=<%#:Item.Id %>"><%#: Item.Title %></a>
                <small><%#: Item.Category.Name %></small>
            </h3>
            <p><%#: Item.Content %></p>
            <p>Likes: <%#: Item.Likes.Count() %></p>
            <i>by <%#: Item.Author.UserName %> created on: <%#: Item.DateCreated %></i>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ListView
        ID="Categories"
        runat="server"
        ItemType="NewsSystem.Data.Models.Category"
        SelectMethod="Categories_GetData">
        <LayoutTemplate>
            <h2>All Categories</h2>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView
                    ID="ListView1"
                    runat="server"
                    ItemType="NewsSystem.Data.Models.Article"
                    DataSource="<%# Item.Articles.OrderByDescending(x=>x.DateCreated).Take(3)%>">
                    <LayoutTemplate>
                        <ul runat="server" id="ItemPlaceholder">
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="ViewArticle?id=<%#:Item.Id %>"><strong><%#: Item.Title %></strong>
                                <i>by <%#:Item.Author.UserName %></i>
                        </li>
                        </a>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
