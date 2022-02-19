using Api2.EfCore;
using Api2.EfCore.Models;
using Api2.ServiceModel.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Concrete.Repository
{
    public class EntryRepo : IEntryRepo
    {
        private BlogDbContext _context;
        public EntryRepo(BlogDbContext context)
        {
            _context = context;
        }
        public Entry AddEntry(Entry entry)
        {
            entry.EntryId = new Random().Next();
            _context.Entries.Add(entry);
            entry.Category = _context.Categories.First(x => x.CategoryId == entry.CategoryId);
            entry.User = _context.Users.First(x => x.UserId == entry.UserId);
            _context.SaveChanges();
            return entry;
        }

        public void RemoveEntry(int entryıd)
        {
            if (_context.Entries.Any(x=>x.EntryId==entryıd))
            {
                _context.Entries.Remove(_context.Entries.First(x=>x.EntryId==entryıd));
                _context.SaveChanges();
            }
        }
    }
}
