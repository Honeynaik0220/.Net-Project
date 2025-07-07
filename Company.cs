using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.Models
{
    public class Company
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="StreetAddress")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }
        [Display (Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "IsAuthorizedCompany")]
        public bool IsAuthorizedCompany { get; set; }
    }
}
