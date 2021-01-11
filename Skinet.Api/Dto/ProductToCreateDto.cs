using System.ComponentModel.DataAnnotations;

namespace Skinet.Api.Dto
{
    public class ProductToCreateOrUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public int ProductBrandId { get; set; }
        public int? TierPriceId { get; set; }
    }
}