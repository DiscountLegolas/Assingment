using Site.Models.Resources.SiteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.PageModels
{
    public class CartPageModel
    {
        public List<ShopItem> CartItems { get; set; }
        public CartPageModel(List<ShopItem> cartıtems)
        {
            CartItems = cartıtems;
        }
    }
}
