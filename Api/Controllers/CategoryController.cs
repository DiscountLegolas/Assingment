using Api.EfCore;
using Api.EfCore.Models;
using Api.Models.Resource;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private BlogDbContext _context;
        private IMapper _mapper;
        public CategoryController(IMapper mapper,BlogDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _mapper.Map<List<Category>, List<CategoryDto>>(_context.Categories.ToList());
            return Ok(categories);
        }
    }
}
