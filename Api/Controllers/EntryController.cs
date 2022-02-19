using Api.EfCore.Models;
using Api.Models.Resource;
using Api.ServiceModel.Abstract.Service;
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
    public class EntryController : ControllerBase
    {
        private IEntryService _entryService;
        private IMapper _mapper;
        public EntryController(IEntryService entryService,IMapper mapper)
        {
            _mapper = mapper;
            _entryService = entryService;
        }
        [HttpGet]
        public IActionResult GetAllEntries()
        {
            return Ok(_mapper.Map<List<Entry>, List<EntryDto>>(_entryService.GetAllEntries()));
        }
        [HttpGet("{entryid}")]
        public IActionResult GetSpecificEntry(int entryid)
        {
            return Ok(_mapper.Map<Entry,EntryDto>(_entryService.GetAllEntries().First(x => x.EntryId == entryid)));
        }
        [HttpGet("Comment/{entryid}")]
        public IActionResult GetCommentsAtEntry(int entryid)
        {
            return Ok(_mapper.Map<List<Comment>,List<CommentDto>>(_entryService.CommentsAtEntry(entryid)));
        }
    }
}
