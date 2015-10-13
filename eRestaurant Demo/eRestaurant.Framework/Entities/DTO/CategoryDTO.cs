using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities.DTO
{
    public class CategoryDTO
    {
        public string Description { get; set; }
        public IEnumerable<MenuItemDTO> MenuItems { get; set; }
    }
}
