using System.ComponentModel.DataAnnotations;

namespace Skinet.Api.Dto
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least one")]
        public int Quantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Type { get; set; }
        public string TierPriceDescription { get; set; }
        public int TierPriceId { get; set; }
        public double Percent { get; set; }
    }
}