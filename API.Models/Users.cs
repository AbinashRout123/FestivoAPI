using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[Required(ErrorMessage = "Enter your Email ID!")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Enter Password !")]
        //[DataType(DataType.Password)]
        //[StringLength(maximumLength: 30, MinimumLength = 8)]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Enter your contact number !")]
        //[StringLength(maximumLength: 10, MinimumLength = 10)]
        public string Contact { get; set; }

        public string Gender { get; set; }

        public string Role { get; set; }
    }
}
