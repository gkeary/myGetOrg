//START:main
<table>
<tr>
    <th></th>
    <th>
        Completed
    </th>
    <th>
        Title
    </th>
</tr>
<% foreach (var item in Model) { %>
<tr>
  <td>
    <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
    <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
    <%= Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
  </td>
  <td>
    <%= Html.Encode(item.Completed) %>
  </td>
  <td>
    <%= Html.Encode(item.Title) %>
  </td>
</tr>
<% } %>
</table>
//END:main
//START:deletelink
<%= Html.ActionLink("Delete", "Delete", new { item.Title } , 
  new { onclick="return 
    confirm('Are you sure you want to delete this?');" }) %>
//END:deletelink
//START:indexafterdelete
<table>
<tr>
  <th></th>
  <th>Completed</th>
  <th>Title</th>
</tr>
<% foreach (var item in Model) { %>
<tr>
  <td>
    <%= Html.ActionLink("Delete", "Delete", new { item.Title }, 
      new { onclick ="return confirm('Are you sure?');" }) %> |
    <%= Html.ActionLink("Edit", "Edit", 
      new { /* id=item.PrimaryKey */ })%> | //<label id="mvc.template.for.primary.key"/>
    <%= Html.ActionLink("Details", "Details", 
      new { /* id=item.PrimaryKey */ })%>
  </td>
  <td>
    <%= Html.Encode(item.Completed) %>
  </td>
  <td>
    <%= Html.Encode(item.Title) %>
  </td>
</tr>
<% } %>
</table>
//END:indexafterdelete
//START:edit
 <%= Html.ActionLink("Edit", "Edit", new { item.Title }) %> |
 //END:edit
