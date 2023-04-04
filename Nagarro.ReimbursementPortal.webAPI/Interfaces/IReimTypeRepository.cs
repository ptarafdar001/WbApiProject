using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Data.Interfaces
{
    public interface IReimTypeRepository
    {
        Task<IEnumerable<ReimType>> GetReimTypesAsync();

        void AddReimType(ReimType type);

        void DeleteReimType(int typeId);

        Task<ReimType> FindReimType(int id);
    }
}
