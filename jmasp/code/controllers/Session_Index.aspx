<%@ Page Title="" Language="C#" 
  MasterPageFile="~/Views/Shared/Site.Master" Inherits=
  "System.Web.Mvc.ViewPage<GetOrganized.Models.SessionSummary>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" 
  runat="server">

    <h2>New Things You Have to Do</h2>
    <ul>
        <% foreach (var todo in Model.AddedTodos)
          {%>
          <li><%= Html.Encode(todo.Title) %></li>
        
        <%} %>
    </ul>
</asp:Content>