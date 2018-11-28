using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class AllPackageViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Name should be in Alphabets")]
        public string Name { get; set; }


        public string Category { get; set; }

        [Required]
        [Display(Name = "Places")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Place should be in Valid")]
        public string Places {get; set;}


        public int Range { get; set; }

        public string TourGuide { get; set; }
        
        public string Schedule { get; set; }

        [Required]
        [Display(Name = "Vehicle")]
        
        public string Vehicle { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Error")]
        public string Hotel { get; set; }

        public string Refreshments { get; set; }

        public int packageId { get; set;}
    }
}