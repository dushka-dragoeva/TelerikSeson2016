<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsAndCourses.aspx.cs" Inherits="WebControlsAnd_HTMLControlsHomework.StudentsAndCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Students and Courses</h2>
    <asp:TextBox ID="FirstName" runat="server" type="text" placeholder="First Name"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="LastName" runat="server" type="text" placeholder="Last Name"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="FacultyNumber" runat="server" type="text" placeholder="Faculty Number"></asp:TextBox>
    <br />
    <br />
    <asp:DropDownList ID="University" runat="server">
        <asp:ListItem Text="Sofia University" Value="0"></asp:ListItem>
        <asp:ListItem Text="Bourgas Free University" Value="1"></asp:ListItem>
        <asp:ListItem Text="Technical University" Value="2"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="Specialty" runat="server">
        <asp:ListItem Text="Maths" Value="0"></asp:ListItem>
        <asp:ListItem Text="Computers" Value="1"></asp:ListItem>
        <asp:ListItem Text="History" Value="2"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />

    <br />
    <asp:Label ID="CoursesList" runat="server">
        <strong>Courses: </strong>
    </asp:Label>
    <br />
    <br />
    <asp:CheckBoxList ID="CheckBoxList" runat="server" SelectionMode="Multiple" Height="120px" Width="390px">
        <asp:ListItem Text="C#" Value="0"></asp:ListItem>
        <asp:ListItem Text="JavaScript" Value="1"></asp:ListItem>
        <asp:ListItem Text="Maths" Value="2"></asp:ListItem>
        <asp:ListItem Text="Middle Age History" Value="3"></asp:ListItem>
        <asp:ListItem Text="Philosophy" Value="4"></asp:ListItem>
        <asp:ListItem Text="AcientHistory" Value="5"></asp:ListItem>
    </asp:CheckBoxList>
    <br />
    <br />
    <asp:Button Text="Submit" runat="server" OnClick="OnSubmit" />
    <br />
    <br />
    <div class="panel-defalt">
        <strong>
            <asp:Label ID="RegisteredName" runat="server"></asp:Label></strong>
        <br />
        <asp:Label ID="RegisteredUniversity" runat="server"></asp:Label>
        <br />
        <asp:Label ID="RegisteredSpecialty" runat="server"></asp:Label>
        <br />
        <asp:Label ID="RegisteredCourses" runat="server"></asp:Label>
    </div>
</asp:Content>
