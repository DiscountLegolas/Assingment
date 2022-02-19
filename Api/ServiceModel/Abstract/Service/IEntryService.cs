using Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Abstract.Service
{
    public interface IEntryService
    {
        List<Comment> CommentsAtEntry(int entryıd);
        List<Entry> GetAllEntries();
    }
}
