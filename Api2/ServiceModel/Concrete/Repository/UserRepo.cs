using Api2.EfCore;
using Api2.EfCore.Models;
using Api2.Models.RequestDtos;
using Api2.ServiceModel.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api2.ServiceModel.Concrete.Repository
{
    public class UserRepo : IUserRepository
    {
        private BlogDbContext _context;
        public UserRepo(BlogDbContext context)
        {
            _context = context;
        }
        public User AddUser(User addUser)
        {
            var password = addUser.PassWord;
            SHA1 sha = new SHA1CryptoServiceProvider();
            addUser.PassWord = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(addUser.PassWord)));
            Random random = new Random();
            addUser.UserId = random.Next();
            var user= _context.Users.Add(addUser).Entity;
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int userıd)
        {
            if (_context.Users.Any(x=>x.UserId==userıd))
            {
                _context.Users.Remove(_context.Users.FirstOrDefault(x => x.UserId == userıd));
                _context.SaveChanges();
            }

        }

        public User UpdateUser(int userıd, User updateuser)
        {
            _context.Users.Remove(_context.Users.First(x => x.UserId == userıd));
            updateuser.UserId = userıd;
            _context.Users.Add(updateuser);
            _context.SaveChanges();
            return updateuser;
        }
    }
}
