using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.DTOs
{
    public class ReimTypeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ReimType Name is madetory field")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Onlly Numerics are not allowed")]
        public string Name { get; set; }

    }
}
