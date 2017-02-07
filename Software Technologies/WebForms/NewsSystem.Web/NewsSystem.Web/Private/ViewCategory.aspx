<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategory.aspx.cs" Inherits="NewsSystem.Web.Private.ViewCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Categories</h1>
    <asp:GridView
        ID="GridViewCategories"
        runat="server"
        ItemType="NewsSystem.Data.Models.Category"
        DataKeyNames="Id"
        SelectMethod="GridViewCategories_GetData"
        AutoGenerateColumns="false"
        AllowPaging="true"
        PageSize="5"
        AllowSorting="true"
        UpdateMethod="GridViewCategories_UpdateItem"
        DeleteMethod="GridViewCategories_DeleteItem">
        <Columns>
            <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="Sort" />
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>
    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator1"
        runat="server"
        ErrorMessage="Category name is mandatory"
        ControlToValidate="CategoryCreate"
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TextBox ID="CategoryCreate" runat="server" ToolTip="Category Name"></asp:TextBox>
    <br />
    <asp:Button ID="ButtonCreate" runat="server" Text="Save" CssClass="btn btn-info" OnClick="ButtonCreate_Click" />
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="ButtonCancel_Click" />

</asp:Content>
