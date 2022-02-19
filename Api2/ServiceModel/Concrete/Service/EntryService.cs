using Api2.EfCore.Models;
using Api2.ServiceModel.Abstract.Repository;
using Api2.ServiceModel.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Concrete.Service
{
    public class EntryService : IEntryService
    {
        private IEntryRepo _repo;
        public EntryService(IEntryRepo repo)
        {
            _repo = repo;
        }
        public Entry AddEntry(Entry entry)
        {
            return _repo.AddEntry(entry);
        }

        public void RemoveEntry(int entryıd)
        {
            _repo.RemoveEntry(entryıd);
        }
    }
}
