using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IIAC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Email { get; set; }
        [StringLength(10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Reference { get; set; }
        public string DeviceId { get; set; }
        public string IpAddress { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? ActivatedDate { get; set; }
    }
}
