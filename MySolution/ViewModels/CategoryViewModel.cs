using Elite.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elite.ViewModels
{
    public class CategoryViewModel 
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Product> NewProducts { get; set; }
    }
}