using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.Resources.SiteClasses
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string ImageSource { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
