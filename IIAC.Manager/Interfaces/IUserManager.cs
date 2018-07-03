using IIAC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IIAC.Manager.Interfaces
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetUsers();
        User GetUser(int id);
        int UpsertUser(User user);
        bool DeleteUser(int id);
    }
}
