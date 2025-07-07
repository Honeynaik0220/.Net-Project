using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "StreetAddress")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }
        [Display(Name = "Company")]
        public int? Companyid { get; set; }
        [ForeignKey("Companyid")]
        public Company Company { get; set; }
        [NotMapped]
        public string role { get; set; }
    }
}
