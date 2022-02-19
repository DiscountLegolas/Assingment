using Api2.EfCore.Models;
using Api2.ServiceModel.Abstract.Repository;
using Api2.ServiceModel.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Concrete.Service
{
    public class CommentService : ICommentService
    {
        private ICommentRepo _repo;
        public CommentService(ICommentRepo repo)
        {
            _repo = repo;
        }
        public Comment AddComment(Comment comment)
        {
            return _repo.AddComment(comment);
        }

        public void RemoveComment(int commentıd)
        {
            _repo.RemoveComment(commentıd);
        }
    }
}
