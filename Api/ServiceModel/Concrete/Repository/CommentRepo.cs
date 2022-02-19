using Api.EfCore;
using Api.EfCore.Models;
using Api.ServiceModel.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Concrete.Repository
{
    public class CommentRepo : ICommentRepo
    {
        private BlogDbContext _context;
        public CommentRepo(BlogDbContext context)
        {
            _context = context;
        }
        public List<Comment> GetCommentsAtEntry(int entryıd)
        {
            return _context.Comments.Include(x => x.User).Where(x => x.EntryId == entryıd).ToList();
        }

        public List<Comment> GetCommentsMadeByUser(int userıd)
        {
            return _context.Comments.Include(x=>x.Entry).Where(x => x.UserId == userıd).ToList();
        }
    }
}
