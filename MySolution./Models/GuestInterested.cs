using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class GuestInterested
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GuestInterestedId { get; set; }

        [ForeignKey("House")]
        [Column(Order = 1)]
        public int HouseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Deteled { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual House House { get; set; }
    }
}