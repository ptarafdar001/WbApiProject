using Nagarro.ReimbursementPortal.webAPI.Data.Interfaces;
using Nagarro.ReimbursementPortal.webAPI.Data.Repo;
using Nagarro.ReimbursementPortal.webAPI.Interfaces;
using Nagarro.ReimbursementPortal.webAPI.Interfaces.IUow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public IReimTypeRepository ReimTypeRepository =>
            new ReimTypeRepository(dataContext);

        public IUserRepository UserRepository => 
            new UserRepository(dataContext);



        public async Task<bool> SaveAsync()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
