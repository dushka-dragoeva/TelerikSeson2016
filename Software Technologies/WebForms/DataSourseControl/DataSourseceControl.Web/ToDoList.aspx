<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="DataSourseceControl.Web.ToDoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>My To do List</h1>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="EntityDataSource1"></asp:ListView>

 

 
    <asp:EntityDataSource ID="EntityDataSource1" runat="server">
    </asp:EntityDataSource>

 

 
</asp:Content>

