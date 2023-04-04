using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string ReimType { get; set; }
        public int RequestedAmount { get; set; }
        public int ApprovedAmount { get; set; }
        public string Currency { get; set; }
        public string RecipeLink { get; set; }
        public string Flag { get; set; }
    }
}
