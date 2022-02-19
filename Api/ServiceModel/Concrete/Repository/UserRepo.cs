using Api.EfCore;
using Api.EfCore.Models;
using Api.Models.RequestDtos;
using Api.ServiceModel.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceModel.Concrete.Repository
{
    public class UserRepo : IUserRepository
    {
        private BlogDbContext _context;
        public UserRepo(BlogDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUser(UserRequestDto userRequest)
        {
            return _context.Users.First(x => x.UserName == userRequest.UserName);
        }

        public bool ValidateUser(UserRequestDto userRequest)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            if (_context.Users.Any(x=>x.UserName==userRequest.UserName&&x.PassWord==Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(userRequest.PassWord)))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
