namespace Skinet.Api.Dto
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int OrderId { get; set; }
    }
}