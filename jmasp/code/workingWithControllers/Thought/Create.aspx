<p>
  <label for="Topic">Topic:</label>
  <%= Html.DropDownList("Topic.Id", 
    (List<SelectListItem>) ViewData["Topics"])%>
</p>
