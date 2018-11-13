using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class HouseType
    {
        [Key]
        public int HouseTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageIntro { get; set; }

        public ICollection<House> House { get; set; }
    }
}