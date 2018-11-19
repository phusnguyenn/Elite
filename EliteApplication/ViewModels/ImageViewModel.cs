using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elite.ViewModels
{
    public class ImageViewModel
    {
        public Models.Models.Image Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } 
    }
}