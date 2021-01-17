namespace Skinet.Model.OrderAggregate
{
    public class OrderItem : Entity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }

        //EF Relation
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public OrderItem() { }

        public OrderItem(decimal price, int quantity, int productItemId, string productName, string productImageUrl)
        {
            Price = price;
            Quantity = quantity;
            ProductItemId = productItemId;
            ProductName = productName;
            ProductImageUrl = productImageUrl;
        }
    }
}