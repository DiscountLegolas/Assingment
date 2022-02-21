using Site.Models.Resources.SiteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public static class AllShopItems
    {
        public static List<ShopItem> GetAllShopItems()
        {
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem() {Id=1, Name = "Example", Description = "DescriptionlongtextDescriptionlongtext", Price = 45, ImageSource = "https://thumbs.dreamstime.com/b/blue-shoes-29507491.jpg" });
            return shopItems;
        }
    }
}
