using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Username { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string  Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        public bool Deteled { get; set; }
        public DateTime DateCreated { get; set; }
    }
}