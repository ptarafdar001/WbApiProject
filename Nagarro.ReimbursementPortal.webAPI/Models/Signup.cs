using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Models
{
    public class Signup
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PanNumber { get; set; }
        public string Bank { get; set; }
        public string BankAccountNumber { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
    }
}
