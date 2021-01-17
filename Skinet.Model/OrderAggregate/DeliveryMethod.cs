namespace Skinet.Model.OrderAggregate
{
    public class DeliveryMethod : Entity
    {
        public string ShortName { get; set; }
        public string DelivaryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}