<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GetOrganized.Web.Models.Topic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Topic
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create</h2>
    
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p id="colorSelector">
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('#Color').ColorPicker({
                            onSubmit: function (hsb, hex, rgb) {
                                $('#Color').val(hex);
                            },
                            onBeforeShow: function () {
                                $(this).ColorPickerSetColor(this.value);
                            }
                        })
                        .bind('keyup', function () {
                            $(this).ColorPickerSetColor(this.value);
                        });
                    });
                </script>
                <label for="Name">Color:</label>
                <%= Html.TextBox("Color") %>
                <%= Html.ValidationMessage("Color", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

