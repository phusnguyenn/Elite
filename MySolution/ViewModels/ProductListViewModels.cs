using Elite.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elite.ViewModels
{
    public class ProductListViewModels
    {
        public List<Product> ListTabOne { get; set; }
        public List<Product> ListTabTwo { get; set; }
        public List<Product> ListTabThree { get; set; }
        public List<Product> ListTabFour { get; set; }

    }
}