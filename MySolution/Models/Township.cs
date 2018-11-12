using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class Township
    {
        [Key]
        public int TownshipId { get; set; }
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        public string MainImage { get; set; }
        public ICollection<House> House { get; set; }
    }
}