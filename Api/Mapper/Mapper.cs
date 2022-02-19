using Api.EfCore.Models;
using Api.Models.Resource;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<Entry, EntryDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.CategoryName));
            CreateMap<User, UserDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
