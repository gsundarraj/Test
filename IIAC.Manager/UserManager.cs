using IIAC.DataRepository.Interfaces;
using IIAC.Manager.Interfaces;
using IIAC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IIAC.Manager
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepo;
        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public int UpsertUser(User user)
        {
            return _userRepo.UpsertUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }

        public User GetUser(int id)
        {
            return _userRepo.GetUser(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetUsersAsync();
        }
    }
}
