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
    public class CommentController : ControllerBase
    {
        private ICommentService _comment;
        private IMapper _mapper;
        public CommentController(ICommentService comment,IMapper mapper)
        {
            _mapper = mapper;
            _comment = comment;
        }
        [HttpPost]
        public IActionResult AddComment([FromBody] CommentRequestDto requestDto)
        {
            Comment comment = _mapper.Map<CommentRequestDto, Comment>(requestDto);
            CommentDto commentdto = _mapper.Map<Comment, CommentDto>(_comment.AddComment(comment));
            return Ok(commentdto);
        }
        [HttpDelete("{commentıd}")]
        public IActionResult RemoveComment(int commentıd)
        {
            _comment.RemoveComment(commentıd);
            return Ok();
        }
    }
}
