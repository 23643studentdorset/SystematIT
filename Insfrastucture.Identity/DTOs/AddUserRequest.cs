using Infrastucture.Identity.Validators;
using System.ComponentModel.DataAnnotations;


namespace Infrastucture.Identity.DTOs
{
    public class AddUserRequest
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is Required")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string Company { get; set; }

        [Required]
        [DateOfBirthValidator]       
        public string Dob { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }

    }
}
