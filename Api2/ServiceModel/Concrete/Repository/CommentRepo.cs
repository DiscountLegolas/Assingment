using Api2.EfCore;
using Api2.EfCore.Models;
using Api2.ServiceModel.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Concrete.Repository
{
    public class CommentRepo:ICommentRepo
    {
        private BlogDbContext _context;
        public CommentRepo(BlogDbContext context)
        {
            _context = context;
        }

        public Comment AddComment(Comment addcomment)
        {
            Random random = new Random();
            addcomment.CommentId = random.Next();
            var comment = _context.Comments.Add(addcomment).Entity;
            comment.User = _context.Users.First(x => x.UserId == addcomment.UserId);
            comment.Entry = _context.Entries.First(x => x.EntryId == addcomment.EntryId);
            _context.SaveChanges();
            return comment;
        }

        public void RemoveComment(int commentıd)
        {
            if (_context.Comments.Any(x=>x.CommentId==commentıd))
            {
                _context.Comments.Remove(_context.Comments.FirstOrDefault(x => x.CommentId == commentıd));
                _context.SaveChanges();
            }
        }
    }
}
