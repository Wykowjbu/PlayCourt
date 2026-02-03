using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels.Auth
{
    public class RegisterOwnerViewModel
    {
        [Required(ErrorMessage = "Please select a role.")]
        public string Role { get; set; } = "Owner"; // Default value

        [Required (ErrorMessage = "Please enter business name.")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress (ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = "";

        [Required (ErrorMessage = "Please enter your phone number.")]
        [Phone (ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; } = "";

        [Required (ErrorMessage = "Please enter your password.")]
        [MinLength(8,ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]

        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
