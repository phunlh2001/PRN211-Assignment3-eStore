using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models
{
    public class Member
    {
        [Key]
        [Column("MemberID")]
        public int ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "The email invalid")]
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

        [NotMapped]
        [StringLength(30)]
        [Required(ErrorMessage = "Confirm Password cannot be empty")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { set; get; }

        //Config foreign key
        [ForeignKey("MemberID")]
        public virtual ICollection<Order> Orders { set; get; }
    }
}