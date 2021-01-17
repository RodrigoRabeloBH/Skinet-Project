namespace Skinet.Api.Dto
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShippingAddres { get; set; }
    }
}