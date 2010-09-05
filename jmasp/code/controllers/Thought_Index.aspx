<% //inside View/Thought/Index.aspx %>
<td>
<%= item.ImageAttachment != null ? 
  Html.ActionLink("Download Image", "Download", new { item.Id }) 
          : MvcHtmlString.Empty %>
</td>