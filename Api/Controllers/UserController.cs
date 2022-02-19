using Api.EfCore.Models;
using Api.Models.RequestDtos;
using Api.Models.Resource;
using Api.ServiceModel.Abstract.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet("Comment/{userıd}")]
        public IActionResult GetUserComments(int userıd)
        {
            return Ok(_mapper.Map<List<Comment>, List<CommentDto>>(_userService.GetCommentsMadeByUser(userıd)));
        }
        [HttpGet("Entry/{userıd}")]
        public IActionResult GetUserEntries(int userıd)
        {
            return Ok(_mapper.Map<List<Entry>, List<EntryDto>>(_userService.GetEntriesByUser(userıd)));
        }
        // GET api/<UserController>/5

        // POST api/<UserController>
        [HttpPost]
        public IActionResult GetUseİfValid([FromBody] UserRequestDto dto)
        {
            if (_userService.ValidateUser(dto))
            {
                return Ok(_mapper.Map<User,UserDto>(_userService.GetUser(dto)));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                return Ok(_mapper.Map<User, UserDto>(_userService.GetUser(new UserRequestDto() { UserName = username })));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
