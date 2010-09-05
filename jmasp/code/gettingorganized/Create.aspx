<h2>Create</h2>

<%= Html.ValidationSummary("Create was unsuccessful. 
  Please correct the errors and try again") %>  //<label id="validation.summary"/>

<% using (Html.BeginForm()) {%>
<fieldset>
  <legend>Fields</legend>
  <div class="editor-label">
    <%= Html.LabelFor(model => model.Completed) %>
  </div>
  <div class="editor-field">
    <%= Html.TextBoxFor(model => model.Completed) %>
    <%= Html.ValidationMessageFor(model => model.Completed) %>
  </div>
  <div class="editor-label">
    <%= Html.LabelFor(model => model.Title) %>
  </div>
  <div class="editor-field">
    <%= Html.TextBoxFor(model => model.Title) //<label id="input.textbox"/> %> 
    <%= Html.ValidationMessageFor(model => model.Title) %>
  </div>
  <p>
    <input type="submit" value="Create" />
  </p>
</fieldset>
<% } %>
