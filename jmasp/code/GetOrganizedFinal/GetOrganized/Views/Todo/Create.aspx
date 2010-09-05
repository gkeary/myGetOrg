<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GetOrganized.Models.Todo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Create</title>
</asp:Content>

<asp:Content ID="Content2" 
    ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Todo</h2>
    <%= Html.ValidationSummary() %>

    <% Html.RenderPartial("CreateElements"); %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

