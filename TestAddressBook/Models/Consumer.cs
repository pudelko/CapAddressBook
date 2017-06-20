using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAddressBook.Models
{
    public class Consumer
    {        
        public int Id { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Invalid name format")]
        [StringLength(50, ErrorMessage = "{0}: 50 is the length limit")]
        public string Name { get; set; }
                
        [RegularExpression(@"([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Invalid surname format")]
        [Remote("CheckUserSurname", "Home", AdditionalFields="Surname,Name", ErrorMessage = "Customer already exists!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telephone number")]
        public string TelephoneNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        
        public Guid Guid { get; set; }

        
    }
}