<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="_05.DataBindingHomework.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="DetailsTitle" runat="server" visible="false"> Details:</h2>
    <asp:DetailsView ID="EmployeeDetils" runat="server" Height="50px" Width="125px"></asp:DetailsView>
    <br />
   <a  runat ="server" class="btn btn-default" href="/Employees" >Back</a>
</asp:Content>
