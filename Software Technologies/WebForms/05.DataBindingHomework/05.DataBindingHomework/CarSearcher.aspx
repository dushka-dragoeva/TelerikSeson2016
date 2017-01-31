<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarSearcher.aspx.cs" Inherits="_05.DataBindingHomework.CarSearcher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Car Searcher </h2>
    <div class="row">
        <div class="col-sm-6">
            <strong>
                <asp:Label runat="server" Text="Марка"></asp:Label>
            </strong>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <strong>
        <asp:Label runat="server" Text="Модел"></asp:Label>
    </strong>
            <br />
            <asp:DropDownList
                ID="CarProducer"
                runat="server"
                AutoPostBack="True"
                DataTextField="Name"
                OnSelectedIndexChanged="CarProducer_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList
                ID="CarModel"
                runat="server"
                AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <strong>
                <asp:Label runat="server" Text="Тип Двигател"></asp:Label>
                <br />
            </strong>
            <asp:RequiredFieldValidator
                ID="EngineValidation"
                ControlToValidate="CarEngine"
                runat="server"
                ErrorMessage="Трябва да изберете тип двигател."
                ForeColor="red"></asp:RequiredFieldValidator>
            <asp:RadioButtonList
                ID="CarEngine"
                runat="server"
                AutoPostBack="True" RepeatDirection="Horizontal" CellPadding="10">
            </asp:RadioButtonList>

            <strong>
                <asp:Label runat="server" Text="Екстри:"></asp:Label>
            </strong>
            <asp:CheckBoxList
                ID="CarExtras"
                runat="server"
                DataTextField="Name">
            </asp:CheckBoxList>
            <asp:Button ID="Search" runat="server" Text="Търси" OnClick="Search_Click" />
        </div>
        <div class="col-sm-6">
            <asp:Literal
                ID="SearchChoice"
                runat="server"
                Visible="false"
                Text="<h3>Търсене за: </h3>"></asp:Literal>
        </div>
    </div>
</asp:Content>
