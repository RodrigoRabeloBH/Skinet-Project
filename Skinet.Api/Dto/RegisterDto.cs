using System.ComponentModel.DataAnnotations;

namespace Skinet.Api.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
         ErrorMessage = "Password must have 1 Uppercase, 1 Lowcase, 1 number, 1 alphanumeric and at least 6 characters")]
        public string Password { get; set; }
    }
}