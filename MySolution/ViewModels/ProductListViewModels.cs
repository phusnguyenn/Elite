using MySolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySolution.ViewModels
{
    public class ProductListViewModels
    {
        public List<House> ListTabOne { get; set; }
        public List<House> ListTabTwo { get; set; }
        public List<House> ListTabThree { get; set; }
        public List<House> ListTabFour { get; set; }

    }
}