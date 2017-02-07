<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="_05.DataBindingHomework.EmployeesListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView
        ID="EmpListView"
        runat="server"
        ItemType="DataBindingHomework.Employees.Employee">
        <LayoutTemplate>
            <h2>Employees Details with List View</h2>
            <table class="TableView">
                <thead>
                    <th>Full Name</th>
                    <th>Title</th>
                    <th>Title of Courtesy</th>
                    <th>Birth Date</th>
                    <th>Hire Date</th>
                    <th>Address</th>
                    <th>City</th>
                    <th>Region</th>
                    <th>PostalCode</th>
                    <th>Country</th>
                    <th>HomePhone</th>
                    <th>Extension</th>
                </thead>
               <tr id="itemPlaceholder" runat="server"></tr>
            </table>

        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%#:Item.Fullname%></td>
                <td><%#:Item.Title%></td>
                <td><%#:Item.TitleOfCourtesy%></td>
                <td><%#:Item.BirthDate%></td>
                <td><%#:Item.HireDate%></td>
                <td><%#:Item.Address%></td>
                <td><%#:Item.City%></td>
                <td><%#:Item.Region%></td>
                <td><%#:Item.PostalCode%></td>
                <td><%#:Item.Country%></td>
                <td><%#:Item.HomePhone%></td>
                <td><%#:Item.Extension%></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color:#c0b9e4">
                <td><%#:Item.Fullname%></td>
                <td><%#:Item.Title%></td>
                <td><%#:Item.TitleOfCourtesy%></td>
                <td><%#:Item.BirthDate%></td>
                <td><%#:Item.HireDate%></td>
                <td><%#:Item.Address%></td>
                <td><%#:Item.City%></td>
                <td><%#:Item.Region%></td>
                <td><%#:Item.PostalCode%></td>
                <td><%#:Item.Country%></td>
                <td><%#:Item.HomePhone%></td>
                <td><%#:Item.Extension%></td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <h2>No Records!</h2>
        </EmptyDataTemplate>

    </asp:ListView>
     <br />
    <a runat="server" class="btn btn-default" href="/Employees">Back To Employees</a>

</asp:Content>
