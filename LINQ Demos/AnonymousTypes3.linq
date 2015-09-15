<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//

from food in Items
group food by food.MenuCategory into foodGroup
select new
{
	CategoryID = foodGroup.Key.MenuCategoryID,
	Category = foodGroup.Key.Description,
	Count = foodGroup.Count(),
	MenuItems = foodGroup.ToList()
}

//puts the 