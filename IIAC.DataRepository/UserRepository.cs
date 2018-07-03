using Dapper;
using IIAC.DataRepository.Interfaces;
using IIAC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IIAC.DataRepository
{
    public class UserRepository : IUserRepository
    {
        private IDapperHelper _dbHelper;
        private const string UPSERT_USER_SP = "dbo.upsert_user";
        private const string GET_USER_SP = "dbo.get_user";
        private const string GET_USERS_SP = "dbo.get_users";
        private const string DELETE_USER_SP = "dbo.delete_user";

        public UserRepository(IDapperHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool DeleteUser(int id)
        {
            return _dbHelper.Delete(DELETE_USER_SP, new { id = id });
        }

        public User GetUser(int id)
        {
            return _dbHelper.GetAsync<User>(GET_USER_SP, new { id = id });
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {               
                return await _dbHelper.GetAllAsync<User>(GET_USERS_SP);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int UpsertUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", user.Id);
            parameters.Add("@username", user.UserName);
            parameters.Add("@firstName", user.FirstName);
            parameters.Add("@lastName", user.LastName);
            parameters.Add("@gender", user.Gender);
            parameters.Add("@dob", user.Dob);
            parameters.Add("@qualification", user.Qualification);
            parameters.Add("@experience", user.Experience);
            parameters.Add("@email", user.Email);
            parameters.Add("@mobile", user.Mobile);
            parameters.Add("@address", user.Address);
            parameters.Add("@reference", user.Reference);
            parameters.Add("@deviceId", user.DeviceId);
            parameters.Add("@ipAddress", user.IpAddress);
            parameters.Add("@isVerified", user.IsVerified);
            parameters.Add("@activatedDate", user.ActivatedDate);

            return _dbHelper.Upsert(UPSERT_USER_SP, parameters);
        }
    }
}
