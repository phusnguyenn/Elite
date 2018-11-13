using MySolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySolution.ViewModels
{
    public class ProductViewModel
    {
        public ICollection<Township> Townships { get; set; }
        public ICollection<HouseType> HouseTypes { get; set; }
        public ICollection<House> Houses { get; set; }
    }
}