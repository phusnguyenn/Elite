using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    [Table("House")]
    public class House
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HouseId { get; set; }

        [ForeignKey("Township")]
        [Column(Order = 1)]
        public int? TownShipId { get; set; }

        [ForeignKey("HouseType")]
        [Column(Order = 2)]
        public int? HouseTypeId { get; set; }

        [ForeignKey("Owner")]
        [Column(Order = 3)]
        public int? OwnerId { get; set; }

        public int Acreage { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string LinkMap { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Township Township { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual HouseType HouseType { get; set; }
        public ICollection<GuestInterested> GuestInteresteds { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}