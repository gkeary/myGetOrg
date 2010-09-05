<asp:Content ID="Content2" 
    ContentPlaceHolderID="MainContent" runat="server">
  
  <h2>Create Todo</h2>
  <%= Html.ValidationSummary() %>
  
  <% Html.RenderPartial("CreateElements"); %> //<label id="call.partial.which.searchs.two.directories"/>
  
  <div>
      <%=Html.ActionLink("Back to List", "Index") %>
  </div>
</asp:Content>