<%@ Page Title="EmployeesJS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesJS.aspx.cs" Inherits="_05.DataBindingHomework.EmployeesJS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>JS Click</h2>
    <div id="employees-container">
        <asp:ListView
            ID="ListViewEmpJS"
            runat="server"
            ItemType="DataBindingHomework.Employees.Employee">
            <LayoutTemplate>
                <table id="TableViewJS">
                    <thead>
                        <th hidden="hidden">ID</th>
                        <th>Full Name</th>
                        <th>Country</th>
                        <th>City</th>
                    </thead>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>

            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td hidden="hidden"><%#:Item.EmployeeID %></td>
                    <td><%#:Item.Fullname%></td>
                    <td><%#:Item.Country%></td>
                    <td><%#:Item.City%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <asp:DataPager
        ID="DataPager1"
        runat="server"
        PagedControlID="ListViewEmpJS"
        PageSize="4"
        QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField
                ShowFirstPageButton="true"
                ShowNextPageButton="false"
                ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField
                ShowLastPageButton="true"
                ShowNextPageButton="false"
                ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
        </Fields>
    </asp:DataPager>

    <script src="<%=ResolveUrl("~/Scripts/jquery-1.10.2.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/Employee/popup.js") %>"></script>
</asp:Content>

