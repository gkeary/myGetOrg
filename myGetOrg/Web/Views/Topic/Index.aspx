<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GetOrganized.Web.Models.Topic>>" %>
<%@ Import Namespace="System.Drawing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Topics</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%= Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <!--<td style="color: white;background-color: <%= ColorTranslator.ToHtml(item.Color) %>">-->
            <td style="color: white;background-color: <%= item.ColorInWebHex() %>">
               <%= Html.Encode(item.Id) %>
            </td>
            <td style="color:White; background-color:<%= item.ColorInWebHex() %>" >
                <%= Html.Encode(item.Name) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

