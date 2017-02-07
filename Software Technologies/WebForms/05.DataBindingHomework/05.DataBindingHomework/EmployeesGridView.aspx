<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesGridView.aspx.cs" Inherits="_05.DataBindingHomework.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Grid View</h2>
    <%--<asp:SqlDataSource
        ID="NorthwindDb"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT EmployeeID , FirstName + ' ' + LastName as FullName FROM [Employees]"></asp:SqlDataSource>--%>
    <asp:GridView
        ID="EmpNamesGrid"
        runat="server"
        AutoGenerateColumns="False"
        CellPadding="5"
        AllowPaging="true"
        AllowSorting="true">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
            <asp:HyperLinkField
                HeaderText="Full Name"
                DataTextField="Fullname"
                DataNavigateUrlFields="EmployeeID"
                DataNavigateUrlFormatString="~/EmployeeDetails?id={0}" />
        </Columns>
    </asp:GridView>
    <br />
    <a runat="server" class="btn btn-default " href="/Employees">Back</a>
</asp:Content>
