<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebCalculator.aspx.cs" Inherits="WebControlsAnd_HTMLControlsHomework.WebCalculator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Web Calculator</h2>

    <asp:Table ID="Calculator" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox
                    ID="Field"
                    runat="server"
                    CssClass="form-control"
                    Width="500"
                    Enables="false">
                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button1" runat="server" Text="1" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="Button2" runat="server" Text="2" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100"/>
                <asp:Button ID="Button3" runat="server" Text="3" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="ButtonPlus" runat="server" Text="+" OnClick="Operation" CssClass="btn btn-default" Width="100" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button4" runat="server" Text="4" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100"/>
                <asp:Button ID="Button5" runat="server" Text="5" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100"/>
                <asp:Button ID="Button6" runat="server" Text="6" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100"/>
                <asp:Button ID="ButtonMinus" runat="server" Text="-" OnClick="Operation" CssClass="btn btn-default" Width="100"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button7" runat="server" Text="7" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="Button8" runat="server" Text="8" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="Button9" runat="server" Text="9" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="ButtonMultiply" runat="server" Text="*" OnClick="Operation" CssClass="btn btn-default" Width="100" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="Button0" runat="server" Text="0" OnClick="Number_Clicked" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="ButtonDevision" runat="server" Text="/" OnClick="Operation" CssClass="btn btn-default" Width="100" />
                <asp:Button ID="ButtonSqareRooot" runat="server" Text="SQRT" OnClick="Operation" CssClass="btn btn-default" Width="100" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="ButtonEquals" runat="server" Text="=" OnClick="Operation" CssClass="btn btn-default" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
