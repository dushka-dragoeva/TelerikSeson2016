<%@ Page Title="Escaping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="WebControlsAnd_HTMLControlsHomework.Escaping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Escaping</h2>
    <asp:TextBox ID="TextToEscape" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button
        ID="EscapeButton"
        runat="server"
        Text="Escape Text"
        OnClick="OnEscapeButton_Click"
        Width="100px" />
    <br />
    <br />
    <asp:TextBox ID="TextBoxEscapedText" runat="server"></asp:TextBox>
    <br />
    <br />
    <strong>Label:
    </strong>
     <br />
    <br />
    <asp:Label ID="LableEscapedText" runat="server" />
</asp:Content>
