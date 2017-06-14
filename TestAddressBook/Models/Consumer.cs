using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestAddressBook.Models
{
    public class Consumer
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [DisplayName("Telephone Number")]
        public string TelephoneNumber { get; set; }

        public string Address { get; set; }
    }
}