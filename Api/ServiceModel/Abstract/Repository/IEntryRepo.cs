using Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Abstract.Repository
{
    public interface IEntryRepo
    {
        List<Entry> GetAllEntries();
        List<Entry> GetEntriesByUser(int userıd);
    }
}
