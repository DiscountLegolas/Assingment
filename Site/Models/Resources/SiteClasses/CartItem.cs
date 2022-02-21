using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models.Resources.SiteClasses
{
    public class CartItem
    {
        public int Count{get;set;}
        public ShopItem Item{get;set;}
    }
}