using Site.Models.Resources.SiteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.PageModels
{
    public class ShopPageModel
    {
        public List<ShopItem> ShopItems { get; set; }
        public ShopPageModel()
        {
            ShopItems = AllShopItems.GetAllShopItems();
        }
    }
}
