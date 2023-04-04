using Nagarro.ReimbursementPortal.webAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Interfaces.IUow
{
    public interface IUnitOfWork
    {
        IReimTypeRepository ReimTypeRepository { get; }

        IUserRepository UserRepository { get; }

        Task<bool> SaveAsync();
    }
}
