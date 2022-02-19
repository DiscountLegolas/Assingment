using Api.EfCore.Models;
using Api.ServiceModel.Abstract.Repository;
using Api.ServiceModel.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Concrete.Service
{
    public class EntryService : IEntryService
    {
        private IEntryRepo _entryrepo;
        private ICommentRepo _commentrepo;
        public EntryService(IEntryRepo entryrepo, ICommentRepo commentrepo)
        {
            _entryrepo = entryrepo;_commentrepo = commentrepo;
        }

        public List<Comment> CommentsAtEntry(int entryıd)
        {
            return _commentrepo.GetCommentsAtEntry(entryıd);
        }

        public List<Entry> GetAllEntries()
        {
            return _entryrepo.GetAllEntries();
        }
    }
}
