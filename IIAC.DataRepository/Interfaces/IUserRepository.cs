using IIAC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IIAC.DataRepository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        User GetUser(int id);
        int UpsertUser(User user);
        bool DeleteUser(int id);
    }
}
