﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]

        [Range(1, 1000)]
        public double listPrice { get; set; }   //600
        [Required]

        [Range(1, 1000)]
        public double Price { get; set; }  //550
        [Required]

        [Range(1, 1000)]
        public double Price50 { get; set; }  //500

        [Range(1, 1000)]
        public double Price100 { get; set; }  //450

        [Display(Name = "Imageurl")]
        public string Imageurl {get; set;}

        [Display(Name = "Category")]
        public int Categoryid { get; set; }
        public Category Category { get; set; }

        [Display(Name ="CoverType")]
        public int CoverTypeid { get; set; }
        public CoverType CoverType { get; set; }
    }
}
