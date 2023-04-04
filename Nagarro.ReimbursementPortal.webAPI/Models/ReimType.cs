using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Models
{
    public class ReimType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime lastUpdatedOn { get; set; }

        public int LastUpdatedBy { get; set; }
    }
}
