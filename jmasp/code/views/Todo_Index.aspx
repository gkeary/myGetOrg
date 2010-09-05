<%@ Import Namespace="GetOrganized.Models"%>
<%@ Import Namespace="MvcContrib.UI.Grid"%> //<label id="add.import.for.grid"/>

<asp:Content ID="Content1" ContentPlaceHolderID="head" 
  runat="server">
  <title>My Todos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" 
  runat="server">
  <h2><%= ViewData["UserName"] %>'s Todos</h2>

<%= Html.Grid(Model).Columns(column => {  //<label id="html.extension.grid"/>
    column.For(  //<label id="define.a.column"/>
         todo =>
         Html.ActionLink("Delete", "Delete", new {todo.Title})). //<label id="define.an.actionLink"/>
         Named("Delete").DoNotEncode(); //<label id="define.do.not.encode"/>
     column.For(
        todo =>
        Html.ActionLink("Edit", "Edit", new { todo.Title })).
        Named("Edit").DoNotEncode();
     column.For(todo => todo.Title);
      })
    .Attributes(style => "text-align: center;") //<label id="define.attributes.for.all.colums"/>
  .Empty("You have completed everything. Congrats!") //<label id="define.if.table.is.empty.render"/>
 %>
   
  <p>
      <%= Html.ActionLink("Create New", "Create") %>
  </p>
</asp:Content>
