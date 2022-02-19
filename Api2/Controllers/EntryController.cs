using Api2.EfCore.Models;
using Api2.Models.RequestDtos;
using Api2.Models.Resource;
using Api2.ServiceModel.Abstract.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private IEntryService _entry;
        private IMapper _mapper;
        public EntryController(IEntryService entry, IMapper mapper)
        {
            _mapper = mapper;
            _entry = entry;
        }
        [HttpPost]
        public IActionResult AddEntry([FromBody] AddEntryDto addentryDto)
        {
            Entry entry = _mapper.Map<AddEntryDto, Entry>(addentryDto);
            EntryDto entryDto = _mapper.Map<Entry, EntryDto>(_entry.AddEntry(entry));
            return Ok(entryDto);
        }
        [HttpDelete("{entryıd}")]
        public IActionResult DeleteEntry(int entryıd)
        {
            _entry.RemoveEntry(entryıd);
            return Ok();
        }
    }
}
