using System;
using System.Collections.Generic;

namespace Skinet.Model.OrderAggregate
{
    public class Order : Entity
    {
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        // EF Relation 
        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public int DeliveryMethodId { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
        public int ShippingAddressId { get; set; }
        public Order() { }

        public Order(List<OrderItem> orderItems, string buyerEmail, ShippingAddress shippingAddress, int deliveryMethodId, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            OrderItems = orderItems;
            Subtotal = subtotal;
            DeliveryMethodId = deliveryMethodId;
        }
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}