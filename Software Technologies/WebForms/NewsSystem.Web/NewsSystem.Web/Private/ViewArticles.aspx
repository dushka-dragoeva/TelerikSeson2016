<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticles.aspx.cs" Inherits="NewsSystem.Web.Private.ViewArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView
        ID="ArtivlesLV"
        runat="server"
        DataKeyNames="Id"
        ItemType="NewsSystem.Data.Models.Article"
        SelectMethod="ArtivlesLV_GetData"
        UpdateMethod="ArtivlesLV_UpdateItem"
        DeleteMethod="ArtivlesLV_DeleteItem"
        InsertMethod="ArtivlesLV_InsertItem"
        InsertItemPosition="None">

        <LayoutTemplate>
            <asp:HyperLink NavigateUrl="?orderBy=Title" Text="Sort by Title" runat="server" CssClass="btn btn-md-2 btn-default" />
            <asp:HyperLink NavigateUrl="?orderBy=DateCreated" Text="Sort by Date" runat="server" CssClass="btn btn-md-2 btn-default" />
            <asp:HyperLink NavigateUrl="?orderBy=Category.Name" Text="Sort by Category" runat="server" CssClass="btn btn-md-2 btn-default" />
            <asp:HyperLink NavigateUrl="?orderBy=Likes.Count()" Text="Sort by Likes" runat="server" CssClass="btn btn-md-2 btn-default" />
            <div runat="server" id="itemPlaceholder"></div>
            <br />
            <br />
            <asp:DataPager runat="server" PageSize="3" PagedControlID="ArtivlesLV">
        <Fields>
            <asp:NextPreviousPagerField ShowPreviousPageButton="true" ShowNextPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="true" />
        </Fields>
    </asp:DataPager>
            <span ID="btnInsert">
    <asp:Button  runat="server" Text="Insert New Article" OnClick="btnInsert_Click"  CssClass="btn btn-info pull-right" />
        </span>
        </LayoutTemplate>
        <ItemTemplate>

            <h2><%#:Item.Title %>
                <asp:Button runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-info" />
                <asp:Button runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" />
            </h2>
            <p>Category: <%#:Item.Category.Name %></p>
            <p><%#: Item.Content.Length>300? Item.Content.Substring(0,300)+"...": Item.Content %></p>
            <p>Likes count: <%#:Item.Likes.Count %></p>
            <i>by <%#: Item.Author.UserName %> created on: <%#: Item.DateCreated %></i>

        </ItemTemplate>
        <EditItemTemplate>
            <br />
            <h3>Title:
                <asp:TextBox ID="tbTitle" runat="server" Text="<%#:BindItem.Title %>" Width="100%"></asp:TextBox>
            </h3>
            <p>
                Category:
                <asp:DropDownList
                    ID="ddCategories"
                    ItemType="NewsSystem.Data.Models.Category"
                    runat="server"
                    DataValueField="Id"
                    DataTextField="Name"
                    SelectedValue="<%# BindItem.CategoryId %>"
                    SelectMethod="CategoriesDD_GetData">
                </asp:DropDownList>
            </p>
            <p>
                Content:
                <asp:TextBox ID="tbContent" runat="server" Text="<%#:BindItem.Content %>" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
            </p>
            <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Update" CssClass="btn btn-success" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger" />
            <br />
            <br />

        </EditItemTemplate>
        <InsertItemTemplate>

            <div ID="panelInsertArticle" runat="server">
                <h3>Title:
                <asp:TextBox ID="tbTitle" runat="server" Text="<%#:BindItem.Title %>" Width="100%"></asp:TextBox>
                </h3>
                <p>
                    Category:
                <asp:DropDownList
                    ID="DropDownList1"
                    ItemType="NewsSystem.Data.Models.Category"
                    runat="server"
                    DataValueField="Id"
                    DataTextField="Name"
                    SelectedValue="<%# BindItem.CategoryId %>"
                    SelectMethod="CategoriesDD_GetData">
                </asp:DropDownList>
                </p>
                <p>
                    Content:
                <asp:TextBox ID="tbContent" runat="server" Text="<%#:BindItem.Content %>" TextMode="MultiLine" Rows="10" Width="100%"></asp:TextBox>
                </p>
                <asp:Button ID="btnCreate" runat="server" Text="Create" CommandName="Insert" CssClass="btn btn-success" />
                <asp:Button ID="btnCancelCreate" runat="server" Text="Cancel" OnClick="btnCancelCreate_Click" CssClass="btn btn-danger" />
            </div>
            <br />
            <br />
        </InsertItemTemplate>
            </asp:ListView>
   </asp:Content>
