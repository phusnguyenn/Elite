using Elite.Models.Models;
using MySolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySolution.ViewModels
{
    public class ProductListViewModels
    {
        public List<Category> ListTabOne { get; set; }
        public List<Category> ListTabTwo { get; set; }
        public List<Category> ListTabThree { get; set; }
        public List<Category> ListTabFour { get; set; }

    }
}