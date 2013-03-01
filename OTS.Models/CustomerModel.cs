using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace OTS.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}