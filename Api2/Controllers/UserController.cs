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
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private IUserService _service;
        public UserController(IMapper mapper,IUserService service)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequestDto userdto)
        {
            var user = _mapper.Map<UserRequestDto, User>(userdto);
            return Ok(_mapper.Map<User, UserDto>(_service.AddUser(user)));
        }
        [HttpDelete("{userıd}")]
        public IActionResult DeleteUser(int userıd)
        {
            _service.DeleteUser(userıd);
            return Ok();
        }
        [HttpPut("{userıd}")]
        public IActionResult UpdateUser(int userıd,[FromBody] UserRequestDto userrequestdto)
        {
            var user = _mapper.Map<UserRequestDto, User>(userrequestdto);
            var userdto = _mapper.Map<User, UserDto>(_service.UpdateUser(userıd, user));
            return Ok(userdto);
        }
    }
}
