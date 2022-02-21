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
            List<CartItem> cart=new List<CartItem>();
            Console.WriteLine(itemid);
            if (Request.Cookies.Any(x=>x.Key=="Cart"))
            {
                cart = JsonConvert.DeserializeObject<List<CartItem>>(Request.Cookies["Cart"]);
                if(cart.Any(x=>x.Item.Id==itemid))
                {
                    cart.Single(x=>x.Item.Id==itemid).Count++;
                }
                else
                {
                    CartItem cartItem=new CartItem(){Item=AllShopItems.GetAllShopItems().First(x => x.Id == itemid),Count=1};
                    cart.Add(cartItem);
                }
                Response.Cookies.Delete("Cart");
            }
            else
            {
                CartItem cartItem=new CartItem(){Item=AllShopItems.GetAllShopItems().First(x => x.Id == itemid),Count=1};
                cart.Add(cartItem);
            }
            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart), options);
            return RedirectToAction("Cart");
        }
        [Authorize]
        [Route("DeleteItem/{itemid}")]
        public IActionResult DeleteItem(int itemid)
        {
            List<CartItem> cart = JsonConvert.DeserializeObject<List<CartItem>>(Request.Cookies["Cart"]);
            if(cart.Single(x=>x.Item.Id==itemid).Count<2)
            {
                cart.Remove(cart.Single(x=>x.Item.Id==itemid));
            }
            else
            {
                cart.Single(x=>x.Item.Id==itemid).Count--;
            }
            Response.Cookies.Delete("Cart");
            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart), options);
            return RedirectToAction("Cart");
        }
        [Authorize]
        public IActionResult Cart()
        {
            List<CartItem> cart = JsonConvert.DeserializeObject<List<CartItem>>(Request.Cookies["Cart"]);
            CartPageModel model = new CartPageModel(cart);
            return View(model);
        }
    }
}
