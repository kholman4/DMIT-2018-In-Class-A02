using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Waiter
    {
        [Key]
            public int WaiterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(15,MinimumLength=4)]
            public string Phone { get; set; }
        [StringLength(100, MinimumLength=8)]
            public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
