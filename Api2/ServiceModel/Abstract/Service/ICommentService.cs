using Api2.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Abstract.Service
{
    public interface ICommentService
    {
        Comment AddComment(Comment comment);
        void RemoveComment(int commentıd);
    }
}
