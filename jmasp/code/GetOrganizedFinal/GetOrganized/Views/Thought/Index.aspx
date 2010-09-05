<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GetOrganized.Models.Thought>>" %>
<%@ Import Namespace="System.Drawing"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Collect Your Thoughts</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Thought
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { item.Id}) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>
            <td style="color: white;background-color: <%= ColorTranslator.ToHtml(item.Topic.Color) %>">
                <%= Html.Encode(item.Name) %>
               </td>
               <td>
                <%= item.ImageAttachment != null ? 
                    Html.ActionLink("Download Image", "Download", new { item.Id }) 
                                    : MvcHtmlString.Empty %>
               </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

