<%@ Page
    Title="Todos"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Categories.aspx.cs"
    Inherits="Data_Source_Controls_Homework.Categories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView
                ID="ListView1"
                runat="server"
                DataSourceID="EntityDataSource1"
                DataKeyNames="Id"
                ItemType="Data_Source_Controls_Homework.Category"
                OnDataBound="ListView1_DataBound">
                <LayoutTemplate>
                    Categories
                    <div runat="server" id="itemPlaceholder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <%#:Item.Name %>
                </ItemTemplate>

            </asp:ListView>

            <asp:EntityDataSource
                ID="EntityDataSource1"
                runat="server"
                ConnectionString="name=ToDoListEntities"
                DefaultContainerName="ToDoListEntities"
                EnableFlattening="False"
                EntitySetName="Categories"
                EnableDelete="True"
                EnableInsert="True"
                EnableUpdate="True">
            </asp:EntityDataSource>
        </div>
    </form>
</body>
</html>
