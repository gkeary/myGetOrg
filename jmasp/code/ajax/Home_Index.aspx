<asp:Content ID="indexHead" ContentPlaceHolderID="head" 
  runat="server">
<title>Home Page</title>
<script type="text/javascript" language="javascript">
  $(document).ready(function() {
    $("#searchThoughtsTextBox").
      autocomplete("Thought/Search", { minChars: 1 }); //<label id="use.jquery.autocomplete"/>
    $("#searchButton").click(function() {
      window.location = "Thought/FindDetails?nameOfThought=" + //<label id="window.location.javascript.redirect"/>
        escape($("#searchThoughtsTextBox")[0].value); //<label id="use.escape.and.jQuery.get.element.by.id"/>
      });
  });
</script>   
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" 
    runat="server">
  <!-- omitted quick link code -->
  
  <h2>Search Thoughts</h2>
  <input id="searchThoughtsTextBox" name="title" type="text" /> //<label id="normal.text.box.and.submit.button.could.support.graceful.degredation"/>
  <input id="searchButton" type="submit" value="Find" /> 
</asp:Content>
