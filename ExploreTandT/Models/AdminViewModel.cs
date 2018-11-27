using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class AdminViewModel
    {
        public List<AspNetUser> listoftourists = new List<AspNetUser>();
        public List<AspNetUser> listoftourguide = new List<AspNetUser>();
        public List<AllPackageViewModel> listofpackages = new List<AllPackageViewModel>();
        public string select { get; set; }
        public int selectrange { get; set; }


    }
}