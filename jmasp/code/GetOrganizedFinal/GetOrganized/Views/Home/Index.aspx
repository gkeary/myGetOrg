<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexHead" ContentPlaceHolderID="head" runat="server">
<title>Home Page</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function() {

        $("#searchThoughtsTextBox").
            autocomplete("Thought/Search", { minChars: 1 });

        $("#searchButton").click(function() {
            window.location = "Thought/FindDetails?nameOfThought=" +
                escape($("#searchThoughtsTextBox")[0].value);
        });
    }
    );
</script>   
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" 
    runat="server">
    <h2>Quick Links</h2>
    <ul>
    <li><%= Html.ActionLink("Add Topics", 
	    "Index", "Topic") %> </li>
    <li><%= Html.ActionLink("My Todos",
        "Index", "Todo") %></li>
	<li><%= Html.ActionLink("Input Your Thoughts",
	    "Create", "Thought") %> </li>
	<li><%= Html.ActionLink("Process Thoughts into Todos", 
	    "Process", "Thought") %> </li>
    </ul>
    <h2>Search Thoughts</h2>
     <input id="searchThoughtsTextBox" name="title" type="text" />
     <input id="searchButton" type="submit" value="Find" /> 
</asp:Content>
