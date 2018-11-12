using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class Admin
    {
        public Admin()
        {
            this.Username = "";
            this.Password = "";
            this.FirstName = "";
            this.BirthDay = DateTime.Now;
            this.Email = "";
            this.Address = "";
            this.Gender = "";
            this.PhoneNumber = "";
            this.Token = "";
            this.Deteled = false;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int AdminId { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Email { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public string Gender { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public string Token { get; set; }

        public bool Deteled { get; set; }

    }
}