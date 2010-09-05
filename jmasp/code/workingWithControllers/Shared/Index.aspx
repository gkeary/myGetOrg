<h2>Index</h2>
<table>    
  <% var modelList = (IEnumerable) Model; %> //<label id="cast.model.as.list"/>
  <% foreach (var item in modelList) { %> 
  <tr> 
   <td> 
    <% ViewData["item"] = item; %> //<label id="set.list.item.to.view.data"/>
    <%= Html.Display("item") %> //<label id="use.non.generic.helper.to.display"/>
   </td> 
  </tr> 
  <% } %>
</table>
