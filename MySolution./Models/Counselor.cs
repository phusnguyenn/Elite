using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MySolution.Models
{
    public class Counselor
    {
        public Counselor()
        {
            FirstName = "";
            LastName = "";
            Gender = "";
            PhoneNumber = "";
            Email = "";
            Image = "";
            Deleted = false;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CounselorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool Deleted { get; set; }

    }
}