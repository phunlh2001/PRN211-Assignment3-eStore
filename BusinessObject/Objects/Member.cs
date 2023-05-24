using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Objects
{
    public class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }

        public int MemberId { get; set; }
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "The email invalid")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Company cannot be empty")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "City cannot be empty")]
        [StringLength(15)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country cannot be empty")]
        [StringLength(15)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
