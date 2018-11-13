using Elite.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Models.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; } = Gender.Unknown;
        public DateTime DateOfBirth { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public long RoleId { get; set; }


    }
}
