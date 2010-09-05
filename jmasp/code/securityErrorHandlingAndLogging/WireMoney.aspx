<form action="Wire" method="post">

<%= Html.AntiForgeryToken() %>  //<label id="antiForgery"/>

Wire Money: <%= Html.TextBox("money") %>

<input type="submit" value="Wire" />
</form>
