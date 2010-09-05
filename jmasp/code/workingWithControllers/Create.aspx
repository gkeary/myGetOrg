<asp:Content ID="Content1" ContentPlaceHolderID="Head" 
  runat="server">
  <script type="text/javascript"> //<label id="jquery.code.start"/>
  $(document).ready(function()
  {
    $('#Color').ColorPicker(
    {
      onSubmit: function(hsb, hex, rgb) 
      {
        $('#Color').val(hex);
      },
      onBeforeShow: function() 
      {
        $(this).ColorPickerSetColor(this.value);
      }
    })
    .bind('keyup', function() 
    {
    $(this).ColorPickerSetColor(this.value);
    });
  });
  </script> //<label id="jquery.code.end"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" 
  runat="server">
  <div class="editor-label">
    <%= Html.LabelFor(model => model.Color) %>
  </div>
  <div class="editor-field">  
    <%= Html.TextBoxFor(model => model.Color) %>
    <%= Html.ValidationMessageFor(model => model.Color) %>
  </div>
</asp:Content>
