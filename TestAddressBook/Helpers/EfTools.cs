using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestAddressBook.Models;

namespace TestAddressBook.Helpers
{
    public class EfTools
    {
        /// <summary>
        /// Rebuilds Database when model was changed
        /// </summary>
        public static void RebuildDataBase()
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }
        
    }
}