<Query Kind="Statements">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Get the following from the Bills table for the past month:
// BillDate, ID, people served, total potentially billable (BillItem.Quantity * BillItem.UnitCost),
// and actual amount billed
// Then display the total income for the month and the number of patrons served.
var billsThisMonth = from item in Bills
                     where item.PaidStatus 
                     && item.BillDate.Month == DateTime.Today.Month -1
                     && item.BillDate.Year == DateTime.Today.Year - 1
                     orderby item.BillDate descending
                     select new
                     {
                         BillDate = item.BillDate,
                         BillId = item.BillID,
                         NumberInParty = item.NumberInParty,
                         TotalBillable = item.BillItems.Sum (bi => bi.Quantity * bi.UnitCost),
                         ActualBillTotal = item.BillItems.Sum (bi => bi.Quantity * bi.SalePrice)
                     };
var title  = string.Format("Total income for {0} {1}",DateTime.Today.AddMonths(-13).ToString("MMMM"),DateTime.Today.Year - 1);
billsThisMonth.Sum (tm => tm.ActualBillTotal).ToString("C").Dump(title, true);
billsThisMonth.Sum (tm => tm.NumberInParty).Dump("Patrons served", true);