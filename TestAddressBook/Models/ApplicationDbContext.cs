using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestAddressBook.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("name=TestAddressBookDbConnection")
        {

        }

        internal static IDisposable Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Consumer> Consumers { get; set; }
    }
}