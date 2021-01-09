namespace Skinet.Model
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string TierPriceDescription { get; set; }
        public int TierPriceId { get; set; }
        public double Percent { get; set; }
    }
}