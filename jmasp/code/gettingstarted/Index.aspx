//START:partOne
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
 Inherits="System.Web.Mvc.ViewPage<Quote>" %> //<label id="add.generic.type.to.ViewPage.class"/>
<%@ Import Namespace="Quoteomatic.Models"%>

<asp:Content ID="indexTitle" 
  ContentPlaceHolderID="TitleContent" runat="server">
  Quote-o-matic
</asp:Content>

<asp:Content ID="indexContent" 
  ContentPlaceHolderID="MainContent" runat="server">
  
  <h2>Random Quote</h2>
  <%= Html.DisplayFor(m => m) %> //<label id="display.for.model.helper"/>
  
</asp:Content>
//END:partOne
//START:partTwo
<h2>Random Quote</h2>
<blockquote>
<b>&quot; <%= Html.Encode(Model.Contents) %> &quot;</b> //<label id="use.encode.and.surround.with.b.tags.and.quotes"/>
<br />
<span style="padding-left: 100px">
  <%= Html.Encode(Model.Author) %> //<label id="span.author"/>
</span> 
</blockquote>
//END:partTwo
