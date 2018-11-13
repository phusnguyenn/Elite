using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySolution.ViewModels
{
    public class ImageViewModel
    {
        public Models.Image Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; } 
    }
}