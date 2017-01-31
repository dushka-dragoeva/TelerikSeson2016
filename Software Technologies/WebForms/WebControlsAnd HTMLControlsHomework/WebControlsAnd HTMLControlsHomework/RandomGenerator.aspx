<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="WebControlsAnd_HTMLControlsHomework.RandomGenerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="WebControl" runat="server">
        <h2>Random with Web server controls</h2>
        <span style="color: red">
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server"
                ControlToValidate="FirstNum"
                ErrorMessage="Please enter a whole number.">
            </asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator
                runat="server"
                Operator="DataTypeCheck"
                Type="Integer"
                ControlToValidate="FirstNum"
                ErrorMessage="Value must be a whole number" />
            <br />
        </span>
        <asp:TextBox ID="FirstNum" runat="server" placeholder="Whole Number" Width="225px"></asp:TextBox>
        <br />
        <span style="color: red">
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2"
                runat="server"
                ControlToValidate="SecondNum"
                ErrorMessage="Please enter a whole number.">
            </asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator
                runat="server"
                Operator="DataTypeCheck"
                Type="Integer"
                ControlToValidate="SecondNum"
                ErrorMessage="Value must be a whole number" />
            <br />
            <asp:CompareValidator
                ControlToValidate="SecondNum"
                ControlToCompare="FirstNum"
                Display="Dynamic"
                Text="Second number must be greater than first one"
                Operator="GreaterThan"
                Type="Integer"
                runat="Server" />
            <br />
        </span>
        <asp:TextBox ID="SecondNum" runat="server" placeholder="Bigger Whole Number" Width="225px"></asp:TextBox>
        <br />
        <br />
        <asp:Button
            ID="WebRandomButton"
            runat="server" Text="Random"
            onserverclick="OnWebRandomButton_Click"
            Width="85px"
            OnClick="OnWebRandomButton_Click" />
        <br />
        <br />
        <span style="color: purple">
            <strong>
                <asp:Literal ID="WebResult" runat="server"></asp:Literal>
            </strong>
        </span>

    </asp:Panel>

    <hr style="border: none; height: 3px; background-color: purple;" />

    <div id="HTMLControl" runat="server">
        <h2>Random with HTML server controls</h2>
        <div>
            <span id="Error1" runat="server" style="color: red"></span>
            <br />
            <input id="Num1" runat="server" type="number" placeholder="Whole Number" /><br />
        </div>
        <div>
            <span id="Error2" runat="server" style="color: red"></span>
            <br />
            <input id="Num2" runat="server" type="number" placeholder="Bigger Whole Number" />
        </div>
        <br />
        <p runat="server">
            <button id="HtmlRandomButton" runat="server" style="width: 85px" onserverclick="OnHtmlRandomButton_Click">Random</button>
        </p>

        <p>
            <strong><span id="HtmlResult" runat="server" style="color: purple"></span></strong>
        </p>

    </div>

</asp:Content>
