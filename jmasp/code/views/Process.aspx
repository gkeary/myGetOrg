//START:main
Actionable: <%= Html.RadioButton("IsActionable", 
  "Action", true, new {id = "actionRadio"}) //<label id="isActionable"/> %>
Maybe Someday: <%= Html.RadioButton("IsActionable", 
  "MaybeSomeday", false, new {id = "someDayRadio"}) %>

<div id="actionDiv"> //<label id="actionDiv"/>
<fieldset>
<legend>Actionable</legend>
<% //... convert Todo form removed to shorten %>
</fieldset>
</div>
<div id="someDayDiv"> //<label id="doItSomedayDiv"/>
<% using (Html.BeginForm("MakeASomeday", "Thought")) {%> //<label id="somedayForm"/>
<fieldset>
<legend>Maybe Someday</legend>
<p>
  <%= Html.Hidden("Id", Model.Id) %>
  <%= Html.Hidden("Name", Model.Name) %>
  <%= Html.Hidden("Topic.Id", Model.Topic.Id) %>
  <input type="submit" value="Do it Someday" />
</p>
</fieldset> 
<% } %>
</div>
//END:main
//START:jquery
<asp:Content ID="Content2" ContentPlaceHolderID="Head" 
  runat="server"> //<label id="headContent" />
  <script type="text/javascript">
     $(document).ready(function(){
      
      $("#actionRadio").click(function(){ //<label id="targetActionRadioClick" />
        $("#actionDiv").slideDown();
        $("#someDayDiv").slideUp();
      });
      
      $("#someDayRadio").click(function(){ //<label id="targetSomedayRadioClick" />
        $("#actionDiv").slideUp();
        $("#someDayDiv").slideDown(); 
      });
     });
  </script>
</asp:Content>
//END:jquery
//START:css
<asp:Content ID="Content2" ContentPlaceHolderID="Head" 
  runat="server"> 
  <style type="text/css">
    #actionDiv
    {
      display: none;
    }
    #someDayDiv
    {
      display: none;
    }
  </style>
  // ... omitted javascript ...
</asp:Content>
//END:jquery
