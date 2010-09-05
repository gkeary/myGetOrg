<h2>Process Thoughts</h2>
<fieldset>  //<label id="add.second.fieldset"/>
  <legend>Thought</legend>
  <p>
    <b><%= Html.Encode(Model.Name) %></b>
  </p>
  <p>   
    Topic:
    <%= Html.Encode(Model.Topic.Name) %>
   </p>
</fieldset>
<% using (Html.BeginForm("Convert", "Todo")) {%> //<label id="new.html.form"/>
<fieldset>
<legend>Actionable</legend>
<p>
  <%= Html.Hidden("Name", Model.Name) %> //<label id="hidden.fields"/>
  <%= Html.Hidden("Topic.Id", Model.Topic.Id) %>
  Well Defined Outcome:<%= Html.TextBox("Outcome") %>
</p>
<p>   
  <input type="submit" value="Create Action" />
 </p>
 </fieldset>
<% } %>

