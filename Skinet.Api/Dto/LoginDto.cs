using System.ComponentModel.DataAnnotations;

namespace Skinet.Api.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Password { get; set; }
    }
}