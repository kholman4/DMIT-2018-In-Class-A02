using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{    
    public class MenuCategory
    {
        [Key] //This attribute identifies the MenuCategoryID property as mapping to a PK
            public int MenuCategoryID { get; set; }

        [StringLength(35, MinimumLength=5, ErrorMessage="Description must be from 5 to 35 characters in length.")]
        [Required(ErrorMessage="A description is required (5-35 characters)")]
            public string Description { get; set; }

        //Navigation Properties
        public virtual ICollection<Item> Items { get; set; }
    }
}
