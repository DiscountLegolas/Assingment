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
    public class EntryRepo : IEntryRepo
    {
        private BlogDbContext _context;
        public EntryRepo(BlogDbContext context)
        {
            _context = context;
        }
        public List<Entry> GetAllEntries()
        {
            return _context.Entries.Include(x=>x.Category).ToList();
        }

        public List<Entry> GetEntriesByUser(int userıd)
        {
            return _context.Entries.Where(x => x.UserId == userıd).ToList();
        }
    }
}
