using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.DTOs
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Email { get; set; }

        [Required]
        public string ReimType { get; set; }

        [Required]
        public int RequestedAmount { get; set; }

        [Required]
        public int ApprovedAmount { get; set; }

        [Required]
        public string Currency { get; set; }

        public string RecipeLink { get; set; }
        public string Flag { get; set; }
    }
}
