using System.ComponentModel.DataAnnotations;

namespace App1.Models
{
    public class Contact
    {
        [Required] //Data Annotatin Atributes
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
