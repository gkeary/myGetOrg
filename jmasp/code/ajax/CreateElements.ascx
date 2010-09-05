<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %> //<label id="partial.inherit"/>
<% using (Html.BeginForm()) {%> 
<fieldset>
  <legend>Fields</legend>
  <div class="editor-label">
    <%= Html.LabelFor(model => model.Title) %>
  </div>
  <div class="editor-field">
    <%= Html.TextBoxFor(model => model.Title) %>
    <%= Html.ValidationMessageFor(model => model.Title) %>
  </div>
  <p>
    <input type="submit" value="Create" />
  </p>
</fieldset>
<% } %>