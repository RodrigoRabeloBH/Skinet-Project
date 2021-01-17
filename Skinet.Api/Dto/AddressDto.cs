using System.ComponentModel.DataAnnotations;

namespace Skinet.Api.Dto
{
    public class AddressDto
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string Street { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public int Number { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string District { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string City { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        public string State { get; set; }
        

        [Required(ErrorMessage = "{0} is required.")]
        public string ZipCode { get; set; }
    }
}