<%@ Page Title="" 
  Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
  Inherits="System.Web.Mvc.ViewPage<GetOrganized.Models.Thought>" %>
<%@ Import Namespace="GetOrganized.Models"%>
<%@ Import Namespace="GetOrganized.ViewHelpers"%> //<label id="import.view.helper"/>

<asp:Content ID="Content1" 
  ContentPlaceHolderID="MainContent" runat="server">
    <!-- form setup and the rest of the form omitted -->
      <p>
    <label for="Topic">Topic:</label>
                <%= ColorDropDownHelper.Topic("Topic.Id",  //<label id="use.color.html.helper"/>
      (List<Topic>) ViewData["RealTopics"]) %>
            </p>
</asp:Content>
