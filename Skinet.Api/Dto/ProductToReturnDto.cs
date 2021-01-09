namespace Skinet.Api.Dto
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
        public string TierPriceDescription { get; set; }
        public int TierPriceId { get; set; }
        public double Percent { get; set; }
    }
}