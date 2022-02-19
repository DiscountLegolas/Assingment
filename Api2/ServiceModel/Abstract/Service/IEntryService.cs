using Api2.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Abstract.Service
{
    public interface IEntryService
    {
        Entry AddEntry(Entry entry);
        void RemoveEntry(int entryıd);
    }
}
