using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class SelectedPackagesViewModel
    {
        public int checkid { get; set; }
        
        
        public string Name { get; set; }

        public string Category { get; set; }

        public string Places { get; set; }

        public int Range { get; set; }

        public string TourGuide { get; set; }

        public string Schedule { get; set; }

        public string Vehicle { get; set; }

        public string Hotel { get; set; }

        public string Refreshments { get; set; }

        public DateTime AddedOn { get; set; }

        public string AddedBy { get; set; }
    }
}