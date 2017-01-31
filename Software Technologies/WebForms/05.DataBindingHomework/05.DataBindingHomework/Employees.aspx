<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_05.DataBindingHomework.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Northwind Employees</h2>
    <div class="row">
        <a runat="server" class="btn" href="~/EmployeesGridView">
            <h4>Grid View</h4>
        </a>
    </div>
    <div class="row">
        <a runat="server" class="btn" href="~/employeesFormView">
            <h4>Form View</h4>
        </a>
    </div>
    <div class="row">
        <a runat="server" class="btn" href="~/employeesFormView">
            <h4>Repeater</h4>
        </a>
    </div>
    <div class="row">
        <a runat="server" class="btn" href="~/employeesFormView">
            <h4>ListView</h4>
        </a>
    </div>
</asp:Content>
