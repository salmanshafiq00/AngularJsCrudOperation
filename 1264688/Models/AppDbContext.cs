using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _1264688.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbConnection")
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}