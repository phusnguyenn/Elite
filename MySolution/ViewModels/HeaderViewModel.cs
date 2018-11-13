using Elite.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elite.ViewModels
{
    public class HeaderViewModel
    {
        public ICollection<Category> MenCategories { get; set; }
        public ICollection<Category> WomenCategories { get; set; }
    }
}