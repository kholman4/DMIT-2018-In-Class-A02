<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//from row in Bills
//orderby row.BillDate descending
//select row.BillDate
//

//among the bills, get the bill with the maximum (largest) date (Most recent)
//among the bills, get the max (largest) row such that I look at/use the row's BillDate
Bills.Max(row => row.BillDate)