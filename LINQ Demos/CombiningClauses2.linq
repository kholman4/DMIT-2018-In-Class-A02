<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//CombiningClauses2

from food in Items 

where food.MenuCategory.Description == "Entree"
	|| food.MenuCategory.Description == "Beverage"
	
orderby food.CurrentPrice descending

group food by food.MenuCategoryID into result

select result

//Lists all the menu items that are listed as entrees and berverages in order from most to least expensive while grouping
//by menu item category id