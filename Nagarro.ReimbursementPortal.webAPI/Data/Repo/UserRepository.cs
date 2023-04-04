using Microsoft.EntityFrameworkCore;
using Nagarro.ReimbursementPortal.webAPI.Interfaces;
using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddUser(User user)
        {
            dataContext.Users.AddAsync(user);
        }

        public void DeleteUser(int userId)
        {
            var tempUser = dataContext.Users.FindAsync(userId);
            dataContext.Users.Remove(tempUser.Result);
        }

        public async Task<User> FindUser(int id)
        {
            return await dataContext.Users.FindAsync(id);
        }

        public async Task<User> GetRecordbyid(int id)
        {
            return await dataContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dataContext.Users.ToListAsync();
        }
    }
}
