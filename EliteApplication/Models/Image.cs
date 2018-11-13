using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace MySolution.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ImageId { get; set; }

        [ForeignKey("House")]
        public int HouseId { get; set; }

        public string LinkImage { get; set; }
        public bool Deteled { get; set; }
        public virtual House House { get; set; }
    }
}