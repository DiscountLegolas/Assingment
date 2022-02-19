using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using Site.Models;
using Site.Models.PageModels;
using Site.Models.RequestDtos;
using Site.Models.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<EntryDto> entries = ApiRequests.GenericGetRequest<EntryDto>("https://localhost:44368/Entry");
            HomeIndexModel model = new HomeIndexModel() { Entries = entries };
            TempData["Entries"] = JsonConvert.SerializeObject(entries);
            return View(model);
        }
        [Route("Home/Entry/{entryid}")]
        public IActionResult Entry(int entryid)
        {
            TempData["EntryId"] = entryid;
            List<EntryDto> entries = new List<EntryDto>();
            if (TempData.Keys.Contains("Entries"))
            {
                entries = JsonConvert.DeserializeObject<List<EntryDto>>(((string)TempData["Entries"]));
            }
            else
            {
                entries= ApiRequests.GenericGetRequest<EntryDto>("https://localhost:44368/Entry");
            }
            EntryDto entry = entries.First(x => x.EntryId == entryid);
            List<CommentDto> comments = ApiRequests.GenericGetRequest<CommentDto>(("https://localhost:44368/Entry/Comment/" + entryid));
            EntryPageModel model = new EntryPageModel() { Entry = entry, Comments = comments };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddComment(EntryPageModel model)
        {
            int entryıd = (int)TempData["EntryId"];
            int userıd = JsonConvert.DeserializeObject<UserDto>(Request.Cookies["User"]).UserId;
            CommentRequestDto requestDto = new CommentRequestDto() { CommentContent = model.Comment, EntryId = entryıd, UserId = userıd };
            CommentDto comment = ApiRequests.GenericPostRequest<CommentDto, CommentRequestDto>(requestDto, "https://localhost:44380/Comment");
            return RedirectToAction("Index");
        }
        [Authorize]
        [Route("Home/DeleteComment/{commentıd}")]
        public IActionResult DeleteComment(int commentıd)
        {
            string deletecomment = "https://localhost:44380/Comment/" + commentıd;
            ApiRequests.GenericDeleteRequest(deletecomment);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult AddEntry()
        {
            /*
            RestClient client = new RestClient("https://localhost:44368/Category");
            RestRequest request = new RestRequest();
            List<CategoryDto> categories = JsonConvert.DeserializeObject<List<CategoryDto>>(client.GetAsync(request).GetAwaiter().GetResult().Content);
            */
            List<CategoryDto> categories = ApiRequests.GenericGetRequest<CategoryDto>("https://localhost:44368/Category");
            TempData["Categories"] = categories;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddEntry(AddEntryPageModel addEntry)
        {
            int userıd = JsonConvert.DeserializeObject<UserDto>(Request.Cookies["User"]).UserId;
            AddEntryDto dto = new AddEntryDto() { EntryName = addEntry.EName, EntryContent = addEntry.EContent, UserId = userıd, CategoryId = addEntry.CategoryId };
            ApiRequests.GenericPostRequest<EntryDto, AddEntryDto>(dto, "https://localhost:44380/Entry");
            return RedirectToAction("Index");
        }
    }
}
