<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<Todo>>" %>
<%@ Import Namespace="System.Drawing"%>
<%@ Import Namespace="GetOrganized.Models"%>
<%@ Import Namespace="GetOrganized.ViewHelpers"%>
<%@ Import Namespace="MvcContrib.UI.Grid"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Index</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        $(".deleteTodoLink").livequery('click', function() {
            var element = $(this);
            var todoTitle = element.attr("id");

            $.post(
	        "Todo/Delete",
	        { title: todoTitle },
	        function() {
	            element.parent().parent().
			    fadeOut("slow", function()
			    { $(this).remove(); });
	        }
	        );
        });
        $("#Create_Link").click(function() {
            $("#Create_Div").slideToggle("slow");
        });
        $("#Create_Link")[0].href = "#";

        $("#CreateTodo").submit(function() {
            $.post(
            $(this).attr('action'), 
            $("#CreateTodo").serialize(),  // Serailize form input into a query string

            function(data, textStatus) {
                // Create a new list item for the newly created grocery item using the returned json data.
                var html =
                "<tr><td><a id=\"" + data.Title + "\"" +
                "class=\"deleteTodoLink\" href=\"#\">" +
                "Delete</a></td>" +
                "<td><a href=\"/Todo/Edit?Title=" 
                + data.Title + "\">Edit</a></td>" +
                "<td>" + data.Title + "</td></tr>";
                
                // Append the new item to the grocery list, using a jQuery UI effect.
                // $('html snippet') creates a new DOM element.
                $(html).appendTo($("#main table")).effect("highlight", {}, 3000);
            },
            // Return type
            "json"
        );
            return false;
        });
    });
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= ViewData["UserName"] %>'s Todos</h2>

    <%= Html.Grid(Model).Columns(column => {
            column.For(
                x =>
                Html.ActionLink("Blog it!","PublishToBlogger", new {x.Title})).DoNotEncode();
           column.For(
              x =>
              Html.Link("Delete", "#", new { id = x.Title, 
                  @class = "deleteTodoLink" })).DoNotEncode();
           column.For(
              x =>
              Html.ActionLink("Edit", "Edit", new { x.Title })).
              Named("Edit").DoNotEncode();
           column.For(x => x.Title);
     	    })
        .Attributes(style => "text-align: center;")
     	.Empty("You have completed everything. Congrats!")
     %>

    <p>
        <%= Html.ActionLink("Create New", "Create", null, new { id="Create_Link"}) %>
    </p>
    <div id="Create_Div" style="display:none">
        <% Html.RenderPartial("CreateElements"); %>
    </div>
</asp:Content>

