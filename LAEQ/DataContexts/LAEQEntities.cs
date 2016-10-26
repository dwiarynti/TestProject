using LAEQ.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LAEQ.DataContexts
{
    public class LAEQEntities : DbContext
    {
        public LAEQEntities()
            :base("DefaultConnection")
        { }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}