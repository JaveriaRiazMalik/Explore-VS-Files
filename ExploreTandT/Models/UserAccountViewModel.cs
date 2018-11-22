using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class UserAccountViewModel
    {
        public List<SelectedPackagesViewModel> listofpackages = new List<SelectedPackagesViewModel>();

        public List<RegisterViewModel> listofusers = new List<RegisterViewModel>();
    }
}