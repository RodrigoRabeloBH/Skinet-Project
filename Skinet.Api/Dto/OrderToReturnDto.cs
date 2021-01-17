using System;
using System.Collections.Generic;
using Skinet.Model.OrderAggregate;

namespace Skinet.Api.Dto
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string PaymentIntentId { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public ShippingAddress ShippingAddress { get; set; }    
    }
}