using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Site.Models;
using Site.Models.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignInUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Index");
            }
            else
            {
                return View("SignInUp");
            }
        }
        [HttpPost]

        public IActionResult SignIn(SignInUpModel signInModel)
        {
            RestClient client = new RestClient("https://localhost:44368/User");
            UserRequestDto requestDto = new UserRequestDto() { UserName = signInModel.SignInUserName, PassWord = signInModel.SignInPassword };
            var request = new RestRequest().AddJsonBody(requestDto);
            var response = client.PostAsync(request).GetAwaiter().GetResult();
            if (response.IsSuccessful)
            {
                CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(2) };
                Response.Cookies.Append("User", response.Content,options);
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, signInModel.SignInUserName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }
            else
            {
                return View("SignInUp");
            }
        }
        [HttpPost]
        public IActionResult SignUp(SignInUpModel signUpModel)
        {
            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(2) };
            RestClient client = new RestClient("https://localhost:44380/User");
            SignUpDto requestDto = new SignUpDto() { UserName = signUpModel.SignUpUserName, Email = signUpModel.SignUpEMail, Password = signUpModel.SignUpPassword };
            var request = new RestRequest().AddJsonBody(requestDto);
            var response = client.PostAsync(request).GetAwaiter().GetResult();
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, signUpModel.SignInUserName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            Response.Cookies.Append("User", response.Content,options);
            return RedirectToAction("Index");
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index","Home");
        }
    }
}
