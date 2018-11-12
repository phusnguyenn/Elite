using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class UserInterested
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserInterestedId { get; set; }

        [ForeignKey("House")]
        public int HouseId { get; set; }

        public bool Deteled { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual House House { get; set; }
    }
}