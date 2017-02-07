<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_05.DataBindingHomework._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="panel-heading">Data Binding Homework</h1>
    </div>
    <div class="row">
        <div class="col-xs-6 ">
            <div id="Panel1" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CarSearcher.aspx">Task 1. Car Searcher</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal3" runat="server">
          <p>
           Create a Web form for searching for cars by producer + model + type of engine + set of extras (see www.`mobile.bg`). Use two DropDownLists for the producer (e.g. VW, BMW, …) and for the model (A6, Corsa,…). Create a class Producer hodling Name + collection of models. Bind the list of producers to the first DropDownList. The second should be bound to the models of this producer. You should have a check box for each “extra” (use class Extra and bind the list of extras at the server side). Implement the type of engineas a horizontal radio button selection (options bound to a fixed array). On submit display all collected information in &lt;asp:Literal&gt;.
          </p> 
                </asp:Literal>
            </div>
        </div>
        <div class="col-xs-6">
            <asp:Panel ID="Panel2" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Employees.aspx">Task 2. Northwind Employees</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal4" runat="server">
             
                 Create a page Employees.aspx to display the names of all employees from Northwind database in a GridViewas hyperlinks. All links should redirect to another page (e.g. EmpDetails.aspx?id=3) where details about the employee are displayed in a DetailsView. Add a back button to return back to the previous page.
             
                 <ul>
                     <li>
                            Implement the same task in a single ASPX page by using a FormView instead of DetailsView.
                     </li>
                      <li>
                                Display the information about all employees a table in an ASPX page using a Repeater.
                     </li>
                      <li>
                             Re-implement using ListView.
                     </li>

                 </ul> 
          
                </asp:Literal>
            </asp:Panel>
        </div>

    </div>
    <div class="row">
        <div class="col-xs-6 ">
            <asp:Panel ID="Panel4" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/XmlTree.aspx">Task 3. XML Tree</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal7" runat="server">
          <p>
           Create a Web Form that reads arbitrary XML document and displays it as tree. Use the TreeView Web control on the left side to display the inner XML of the selected node on the right side..
          </p> 
                </asp:Literal>
            </asp:Panel>
        </div>
        <div class="col-xs-6">
            <asp:Panel ID="Panel8" runat="server" class="panel panel-default">
                <h4 class="panel-heading">
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/EmployeesJS.aspx">Task 4. Northwind Details</asp:HyperLink>
                </h4>

                <asp:Literal ID="Literal8" runat="server">
          <p>
            Create a Web Form that shows in a table the names, country and city of all employees from the Northwind database. Implement paging (10 employees on each page) and sorting by each column. Using AJAX, JavaScript and jQuery on mouse over display a popup DIV with additional info about the employee: photo, phone, email, address, notes. On mouse out hide the additional info.
          </p> 
                </asp:Literal>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
