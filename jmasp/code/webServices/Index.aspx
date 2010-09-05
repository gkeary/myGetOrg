<%= Html.Grid(Model).Columns(column => {
          column.For(
           x =>
            Html.ActionLink("Blog it!","PublishToBlogger", 
              new { x.Title }))
          .DoNotEncode();
                
//omitted rest of Grid
