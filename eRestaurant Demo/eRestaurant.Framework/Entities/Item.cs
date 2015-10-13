using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{    
    public class Item
    {
        [Key]
            public int ItemId { get; set; }
        [Required, StringLength(100,MinimumLength=5)]
            public string Description { get; set; }
        [Range(0.01, 50.00)]
            public decimal CurrentPrice { get; set; }
        [Range(0.01, 50.00)]
            public decimal CurrentCost { get; set; }
        public bool Active { get; set; }
        [Range(0,5000)]
            public int? Calories { get; set; }
        public string Comment { get; set; }
        public int MenuCategoryID { get; set; }

        //Navigation Properties
        public virtual MenuCategory MenuCategory { get; set; } //Virtual means the info about the Menu Category will only be displayed if needed

        public Item()
        {
            Active = true;
        }
    }
}
