using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExploreTandT.Models
{
    public class ImageViewModel
    {
        [Display(Name = "Add Image")]
        public HttpPostedFileBase Image { get; set; }
        [Display(Name = "Add Image")]
        public string ImagePath { get; set; }

    }
}