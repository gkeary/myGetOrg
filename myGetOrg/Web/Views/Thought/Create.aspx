<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GetOrganized.Web.Models.Thought>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Thought
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create Thought
    </h2>
    <p>
        <label for="Topic">
            Topic:</label>
        <%= Html.DropDownList("Topic.Id", 
    (List<SelectListItem>) ViewData["Topics"])%>
    </p>
    <p>
        <input type="submit" value="Create" />
    </p>
    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
