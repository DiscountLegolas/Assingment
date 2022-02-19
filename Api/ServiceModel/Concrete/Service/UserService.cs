using Api.EfCore.Models;
using Api.Models.RequestDtos;
using Api.ServiceModel.Abstract.Repository;
using Api.ServiceModel.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.Concrete.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ICommentRepo _commentrepo;
        private IEntryRepo _entryrepo;
        public UserService(IUserRepository userRepository,ICommentRepo commentrepo,IEntryRepo entryRepo)
        {
            _commentrepo = commentrepo;
            _entryrepo = entryRepo;
            _userRepository = userRepository;
        }

        public List<Comment> GetCommentsMadeByUser(int userıd)
        {
            return _commentrepo.GetCommentsMadeByUser(userıd);
        }

        public List<Entry> GetEntriesByUser(int userıd)
        {
            return _entryrepo.GetEntriesByUser(userıd);
        }

        public User GetUser(UserRequestDto userRequest)
        {
            return _userRepository.GetUser(userRequest);
        }

        public bool ValidateUser(UserRequestDto userRequest)
        {
            return _userRepository.ValidateUser(userRequest);
        }
    }
}
