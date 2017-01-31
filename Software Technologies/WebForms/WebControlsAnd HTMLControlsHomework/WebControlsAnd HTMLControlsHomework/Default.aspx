<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebControlsAnd_HTMLControlsHomework._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <h1 class="panel-heading">Web Controls and HTML Controls Homework</h1>
    </div>
    <div class="row">
        <div class="col-xs-4 ">
            <div ID="Panel1"  class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/RandomGenerator.aspx">Task 1. Random Generators</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal3" runat="server">
          <p>
            Using the HTML server controls create a Web application for generating random numbers. It should have two input fields defining a range (e.g. [10..20]) and a button to generate a random number in the specified range. Re-implement the same using Web server control
          </p> 
                </asp:Literal>
            </div>
        </div>
        <div class="col-xs-4 ">
            <asp:Panel ID="Panel2" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Escaping.aspx">Task 2. Escaping</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal4" runat="server">
          <p>
              Define a Web form with text box and button. On button click show the entered in the first textbox text in other textbox control and label control. Enter some potentially dangerous text. Fix issues related to HTML escaping – the application should accept HTML tags and display them correctly.
          </p> 
                </asp:Literal>
            </asp:Panel>
        </div>
        <div class="col-xs-4 ">
            <asp:Panel ID="Panel3" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/StudentsAndCourses.aspx">Task 3. Students and Courses</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal6" runat="server">
          <p>
           Make a simple Web form for registration of students and courses. The form should accept first name, last name, faculty number, university (drop-down list), specialty (drop-down list) and a list of courses (multi-select list) and display them on submit. Use the appropriate Web server controls. After submission you should display summary of the entered information as formatted HTML. Use dynamically generated tags.
          </p> 
                </asp:Literal>
            </asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-4 ">
            <asp:Panel ID="Panel4" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/TicTacToe.aspx">Task 4. Tic-tac-toe</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal7" runat="server">
          <p>
           Implement the "Tic-tac-toe" game using Web server controls. The user should play against the computer which follows some fixed strategy.
          </p> 
                </asp:Literal>
            </asp:Panel>
        </div>
        <div class="col-xs-4 ">
            <asp:Panel ID="Panel8" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/WebCalculator.aspx">Task 5. Web Calculator</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal8" runat="server">
          <p>
             Make a simple Web Calculator. The calculator should support the operations like addition, subtraction, multiplication, division and square root. Validation is essential!
          </p> 
                </asp:Literal>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
