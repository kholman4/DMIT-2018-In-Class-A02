using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="An Event Code is required (one character only)")]
        [StringLength(1, ErrorMessage="Event Codes may only be one single character.)")]
            public string EventCode { get; set; }
        [Required()][StringLength(30, MinimumLength=5)]//The number first is the maximum length
            public string Description { get; set; }

        public bool Active { get; set; }

        //Nav Prop
        public virtual ICollection<Reservation> Reservations { get; set; }
        //Collection because many reservations can have a special event code

        public SpecialEvent()
        {
            //for all new special events, there is a business rule stating they should automatically be set to active
            //similar to having a default constraint in a database
            Active = true;
            //to avoid null reference errors for our navigation property 
            Reservations = new HashSet<Reservation>();
        }
    }
}
