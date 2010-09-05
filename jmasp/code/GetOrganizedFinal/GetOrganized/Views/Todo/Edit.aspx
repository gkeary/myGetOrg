<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GetOrganized.Models.Todo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Edit</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary() %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Completed">Completed:</label>
                <%= Html.TextBox("Completed") %>
                <%= Html.ValidationMessage("Completed", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%= Html.Hidden("oldTitle", Model.Title)%>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

