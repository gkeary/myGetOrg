<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GetOrganized.Web.Models.Todo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Completed
            </th>
            <th>
                Title
            </th>
        </tr>

    <% foreach (var item in Model)
       {%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", new {/* id=item.PrimaryKey */})%> |
                <%=Html.ActionLink("Details", "Details", new {/* id=item.PrimaryKey */})%> |
                <%=Html.ActionLink("Delete", "Delete", new {item.Title},
                                             new {onclick = "return confirm('Are you sure you want to delete this?');"})%>
                <%=Html.ActionLink("Delete", "Delete", new { item.Title}, new{ onclick="return confirm('Are you xxx?');"}) %>
            </td>
            <td>
                <%= Html.Encode(item.Completed) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

