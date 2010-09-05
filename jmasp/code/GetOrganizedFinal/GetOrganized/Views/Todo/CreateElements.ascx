<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% using (Html.BeginForm("Create", "Todo", FormMethod.Post, new { id="CreateTodo"})) {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            <label for="Title">Title:</label>
            <%= Html.TextBox("Title") %>
            <%= Html.ValidationMessage("Title", "*") %>
        </p>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>
