using FirstCrudMVV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstCrudMVV
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("crud")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}