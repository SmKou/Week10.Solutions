/*
** Program.cs code for incorporating MySqlConnector
DBConfiguration.ConnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
- before: app = builder.Build();

** Use of MySqlConnector
MySqlConnection cs = new MySqlConnection(DBConfiguration.ConnectionString);
cs.Open();
MySqlCommand cmd = cs.CreateCommand() as MySqlCommand;
cmd.CommandText = "SELECT * FROM items;";
MySqlDataReader dr = cmd.ExecuteReader() as MySqlDataReader;
while (dr.Read())
{
    int itemId = dr.GetInt32(0);
    string itemDescription = dr.GetString(1);
    Item item = new Item(itemId, itemDescription);
    items.Add(item);
}
cs.Close();
if (cs != null)
    cs.Dispose();
*/

/*
< a href = "/items" > See all items</a>
-> <p>@Html.ActionLink("See all items", "Index", "Items")</p>
param: {string} display text for link
param: {string} target action in controller
param: {string} name of controller sans "Controller" (optional)
- defaults to controller initiated from for current view

<form method="/Items/Create" method="POST">
=> @using (Html.BeginForm())
{
    ...
}
default=/...[Controller]/Create
*/