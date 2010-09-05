<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GetOrganized.Models.Thought>" %>
<%@ Import Namespace="GetOrganized.ViewHelpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Process Thoughts</h2>

    <fieldset>
        <legend>Thought</legend>
        <p>
            <b><%= Html.Encode(Model.Name) %></b>
        </p>
        <p>   
            Topic:
            <%= Html.Encode(Model.Topic.Name) %>
         </p>
    </fieldset>
Actionable: <%= Html.RadioButton("IsActionable", "Action", true, new {id = "actionRadio"}) %>
Maybe Someday: <%= Html.RadioButton("IsActionable", "MaybeSomeday", false, new {id = "someDayRadio"}) %>
    
    <div id="actionDiv">
    <fieldset>
        <legend>Actionable</legend>
        <% using (Html.BeginForm("Convert", "Todo")) {%>
            <p>
                <%= Html.Hidden("Id", Model.Id) %>
                <%= Html.Hidden("Name", Model.Name) %>
                <%= Html.Hidden("Topic.Id", Model.Topic.Id) %>
                Well Defined Outcome:<%= Html.TextBox("Outcome") %>
            </p>
            <p>   
                <input type="submit" value="Create Action" />
             </p>
        <% } %>
    </fieldset>
    </div>
    <div id="someDayDiv">
    <fieldset>
    <legend>Maybe Someday</legend>
    <% using (Html.BeginForm("MakeASomeday", "Thought")) {%>
        <p>
	    <%= Html.Hidden("Id", Model.Id) %>
	    <%= Html.Hidden("Name", Model.Name) %>
	    <%= Html.Hidden("Topic.Id", Model.Topic.Id) %>
	    <input type="submit" value="Do it Someday" />
        </p>
    <% } %>
    </fieldset>	
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

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

    <script type="text/javascript">
	     $(document).ready(function(){
    		
		    $("#actionRadio").click(function(){ 
			    $("#actionDiv").slideDown();
			    $("#someDayDiv").slideUp();
		    });
    		
		    $("#someDayRadio").click(function(){ 
			    $("#actionDiv").slideUp();
			    $("#someDayDiv").slideDown();	
		    });
	     });
    </script>
</asp:Content>

