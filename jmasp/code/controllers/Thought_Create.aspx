<form action="Create" method="post" enctype="multipart/form-data">
<fieldset>
  <legend>Fields</legend>
  <p>
    <label for="Id">Id:</label>
    <%= Html.TextBox("Id") %>
    <%= Html.ValidationMessage("Id", "*") %>
  </p>
  <p>
    <label for="Name">Name:</label>
    <%= Html.TextBox("Name") %>
    <%= Html.ValidationMessage("Name", "*") %>
  </p>
  <p>
    <label for="Topic">Topic:</label>
    <%= Html.DropDownList("Topic.Id", 
      (List<SelectListItem>) ViewData["Topics"])%>
  </p>
  <p>
    Attachment: <input type="file" name="ImageAttachment" />
  </p>
  <p>
    <input type="submit" value="Create" />
  </p>
</fieldset>
</form>