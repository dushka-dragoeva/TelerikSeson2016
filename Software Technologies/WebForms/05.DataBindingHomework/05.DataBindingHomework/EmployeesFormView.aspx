<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="_05.DataBindingHomework.EmployeesFormView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Form View</h2>
    <asp:FormView
        ID="EmployeeForm"
        runat="server"
        AllowPaging="true"
        DataKeyNames="EmployeeID" OnPageIndexChanging="EmployeeForm_PageIndexChanging" >

        <ItemTemplate>
            <div id="Photo" runat="server">
                Photo
            </div>

            <h3><%#:Eval("Fullname") %></h3>

            <table id="Details" runat="server">
                <tr>
                    <td>Title:</td>
                    <td><%#:Eval("Title") %></td>
                </tr>
                <tr>
                    <td>Title Of Courtesy:</td>
                    <td><%#:Eval("TitleOfCourtesy") %></td>
                </tr>
                <tr>
                    <td>Birth Date:</td>
                    <td><%#:Eval("BirthDate") %></td>
                </tr>
                <tr>
                    <td>Hire Date:</td>
                    <td><%#:Eval("HireDate") %></td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td><%#:Eval("Address") %></td>
                </tr>
                <tr>
                    <td>City:</td>
                    <td><%#:Eval("City") %></td>
                </tr>
                <tr>
                    <td>Region:</td>
                    <td><%#:Eval("Region") %></td>
                </tr>
                <tr>
                    <td>PostalCode:</td>
                    <td><%#:Eval("PostalCode") %></td>
                </tr>
                <tr>
                    <td>Country:</td>
                    <td><%#: Eval("Country") %></td>
                </tr>
                <tr>
                    <td>HomePhone:</td>
                    <td><%#:Eval("HomePhone") %></td>
                </tr>
                <tr>
                    <td>Extension:</td>
                    <td><%#:Eval("Extension") %></td>
                </tr>
                <tr>
                    <td>Notes:</td>
                    <td><%#:Eval("Notes") %></td>
                </tr>
                <tr>
                    <td>Reports To:</td>
                    <td><%#:Eval("ReportsTo") %></td>
                </tr>

            </table>
        </ItemTemplate>
    </asp:FormView>




    <br />
    <a runat="server" class="btn btn-default" href="/Employees">Back To Employees</a>
</asp:Content>
