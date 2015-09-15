<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from food in Items
group food by new {food.MenuCategoryID, food.CurrentPrice}
//grouping with anonymous type (ie. multiple)
//No need for the select clause when all you want is grouping all the data