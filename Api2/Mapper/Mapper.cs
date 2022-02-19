using Api2.EfCore.Models;
using Api2.Models.RequestDtos;
using Api2.Models.Resource;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Comment, CommentDto>().ForMember(x => x.CommentMakerName, opt => opt.MapFrom(a => a.User.UserName)).ForMember(x => x.EntryName, opt => opt.MapFrom(a => a.Entry.EntryName));
            CreateMap<CommentRequestDto, Comment>();
            CreateMap<AddEntryDto, Entry>();
            CreateMap<Entry, EntryDto>().ForMember(x => x.UserName, opt => opt.MapFrom(a => a.User.UserName)).ForMember(x => x.CategoryName, opt => opt.MapFrom(a => a.Category.CategoryName));
        }
    }
}
