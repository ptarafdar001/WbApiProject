using Microsoft.EntityFrameworkCore;
using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ReimType> ReimTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Signup> SignupUsers { get; set; }
       
    }
}
