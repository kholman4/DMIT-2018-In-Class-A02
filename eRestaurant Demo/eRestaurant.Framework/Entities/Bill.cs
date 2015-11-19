using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Bill
    {
        [Key]
            public int BillID { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime? OrderPlaced { get; set; }
        public int NumberInParty { get; set; }
        public bool PaidStatus { get; set; }
        public int WaiterID { get; set; }
        public int? TableID { get; set; }
        public int? ReservationID { get; set; }
        public DateTime OrderReady { get; set; }
        public string Comment { get; set; }
        public DateTime OrderServed { get; set; }
        public TimeSpan? OrderPaid { get; set; }

        public Bill()
        {
            BillDate = DateTime.Now;
        }

        //Navigation Properties
        public virtual ICollection<BillItem> Items { get; set; } //A bill can have many bill items
        public virtual Waiter Waiter { get; set; }
        public virtual Table Table { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
