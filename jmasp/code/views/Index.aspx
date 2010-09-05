<asp:Content ID="indexContent" 
  ContentPlaceHolderID="MainContent" runat="server">
    <h2>Quick Links</h2>
    <ul>
    <li><%= Html.ActionLink("My Todos", //<label id="use.action.link"/>
        "Index", "Todo") %></li>
  <li><%= Html.ActionLink("Input Your Thoughts",
      "Create", "Thought") %> </li>
  <li><%= Html.ActionLink("Process Thoughts into Todos", 
      "Process", "Thought") %> </li>
    </ul> 
</asp:Content>