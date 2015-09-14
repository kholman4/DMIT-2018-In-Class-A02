<Query Kind="Expression">
  <Connection>
    <ID>4688dd52-597e-4a50-9445-068a55a8744a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from data in Waiters
where data.ReleaseDate == null
select data