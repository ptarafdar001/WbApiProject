using Microsoft.EntityFrameworkCore;
using Nagarro.ReimbursementPortal.webAPI.Data.Interfaces;
using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Data.Repo
{
    public class ReimTypeRepository : IReimTypeRepository
    {
        private readonly DataContext dataContext;

        public ReimTypeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddReimType(ReimType type)
        {
            dataContext.ReimTypes.AddAsync(type);
        }

        public void DeleteReimType(int typeId)
        {
            var type = dataContext.ReimTypes.Find(typeId);
            dataContext.ReimTypes.Remove(type);
        }

        public async Task<ReimType> FindReimType(int id)
        {
            return await dataContext.ReimTypes.FindAsync(id);
        }

        public async Task<IEnumerable<ReimType>> GetReimTypesAsync()
        {
            return await dataContext.ReimTypes.ToListAsync();
        }
    }
}
