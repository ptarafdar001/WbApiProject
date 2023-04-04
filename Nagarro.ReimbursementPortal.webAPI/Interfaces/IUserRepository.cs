using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Interfaces
{
    public interface IUserRepository
    { 

        Task<IEnumerable<User>> GetUsersAsync();

        void AddUser(User type);

        void DeleteUser(int userId);

        Task<User> FindUser(int id);

        Task<User> GetRecordbyid(int id);
    }
}
