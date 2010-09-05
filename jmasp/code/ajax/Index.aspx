//START:main
<%@ Page Title="" Language="C#" 
MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<Todo>>" %>
<%@ Import Namespace="System.Drawing"%>
<%@ Import Namespace="GetOrganized.Models"%>
<%@ Import Namespace="GetOrganized.ViewHelpers"%> //<label id="reference.link.helper"/>
<%@ Import Namespace="MvcContrib.UI.Grid"%>

<asp:Content ID="Content1" 
  ContentPlaceHolderID="head" runat="server">
<title>Index</title>
<script type="text/javascript" language="javascript">
  $(document).ready(function() {
    $(".deleteTodoLink").click(function() {
      var element = $(this); //<label id="element.that.was.clicked"/>
      var todoTitle = element.attr("id");

      $.post( //<label id="use.post.command"/>
    "Todo/Delete",
    { title: todoTitle },
      function() {
        element.closest("tr"). //<label id="select.my.parents.parent"/>
        fadeOut("slow", function()
      { $(this).remove(); }); //<label id="remove.element.from.DOM"/>
      }
      );
    });
  });
</script>
</asp:Content>

<asp:Content ID="Content2" 
  ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= ViewData["UserName"] %>'s Todos</h2>

    <%= Html.Grid(Model).Columns(column => {
          column.For(
              x =>
              Html.Link("Delete", "#", new { id = x.Title, //<label id="use.link.helper"/>
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
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
//END:main
//START:create
<asp:Content ID="Content1" 
  ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
  $(document).ready(function() {
  // omitted jQuery code from previous step
  
    $("#Create_Link").click(function() {
        $("#Create_Div").slideToggle("slow"); //<label id="use.jQuery.slider"/>
    });
    $("#Create_Link")[0].href = "#"; //<label id="graceful.degredation.removes.link.for.javascript.browser"/>
  });
</script>
</asp:Content>
<asp:Content ID="Content2" 
  ContentPlaceHolderID="MainContent" runat="server">
<!-- omitted grid code -->
<p>
  <%= Html.ActionLink("Create New", "Create", 
    null, new { id="Create_Link"}) %> //<label id="add.id.so.we.can.jquery"/>
</p>
<div id="Create_Div" style="display:none">
  <% Html.RenderPartial("CreateElements"); %> //<label id="render.partial.in.hidden.div"/>
</div>
</asp:Content>
//END:create
//START:create2
<asp:Content ID="Content1" 
  ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
$(document).ready(function() {
  $("#CreateTodo").submit(function() { //<label id="intercept.submit.click"/>
    $.post(
    $(this).attr('action'), 
    $("#CreateTodo").serialize(),  //<label id="serailize.form.input.into.query.string"/>

    function(data, textStatus) {
      var html = //<label id="create.new.dom.using.json.returned.data"/>
      "<tr><td><a id=\"" + data.Title + "\"" +
      "class=\"deleteTodoLink\" href=\"#\">" +
      "Delete</a></td>" +
      "<td><a href=\"/Todo/Edit?Title=" 
      + data.Title + "\">Edit</a></td>" +
      "<td>" + data.Title + "</td></tr>";

      $(html).appendTo($("#main table")).
        effect("highlight", {}, 3000); //<label id="append.new.todo.use.highlight.effect"/>
    },
    // Return type
    "json" //<label id="specify.json.return.type"/>
  );
    return false;
  });
}
//END:create2
//START:delete2
<script type="text/javascript" language="javascript">
$(document).ready(function() {
    $(".deleteTodoLink").livequery('click', function() { //<label id="add.livequery"/>
      var element = $(this);
      var todoTitle = element.attr("id");

      $.post(
        "Todo/Delete",
        { title: todoTitle },
        function() {
          element.closest("tr").
          fadeOut("slow", function()
          { $(this).remove(); });
        }
      );
    });
});
</script>
</asp:Content>
//END:delete2