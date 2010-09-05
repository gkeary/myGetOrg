<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GetOrganized.Models.Thought>" %>
<%@ Import Namespace="GetOrganized.Models"%>
<%@ Import Namespace="GetOrganized.ViewHelpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <form action="Create" method="post" enctype="multipart/form-data">
        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="Topic">Topic:</label>
                <%= ColorDropDownHelper.Topic("Topic.Id", (List<Topic>) ViewData["Topics"]) %>
            </p>
            <p>
                Attachment: <input type="file" name="ImageAttachment" />
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    </form>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

