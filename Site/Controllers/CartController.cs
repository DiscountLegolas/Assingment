using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Site.Models;
using Site.Models.PageModels;
using Site.Models.Resources.SiteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ShopPageModel model = new ShopPageModel();
            return View(model);
        }
        [Authorize]
        [Route("AddToCart/{itemid}")]
        public IActionResult AddToCart(int itemid)
        {
            if (Request.Cookies.Any(x=>x.Key=="Cart"))
            {
                List<ShopItem> cart = JsonConvert.DeserializeObject<List<ShopItem>>(Request.Cookies["Cart"]);
                cart.Add(AllShopItems.GetAllShopItems().First(x => x.Id == itemid));
            }
            else
            {
                List<ShopItem> cart = new List<ShopItem>();
                cart.Add(AllShopItems.GetAllShopItems().First(x => x.Id == itemid));
                CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(2) };
                Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart), options);
            }
            return RedirectToAction("Cart");
        }
        [Authorize]
        public IActionResult Cart()
        {
            List<ShopItem> cart = JsonConvert.DeserializeObject<List<ShopItem>>(Request.Cookies["Cart"]);
            CartPageModel model = new CartPageModel(cart);
            return View(model);
        }
    }
}
