using System.Collections.Generic;
using System.Threading.Tasks;
using Skinet.Model.OrderAggregate;

namespace Skinet.Service.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(string buyerEmail, int deliveryMethodId, string basketId, ShippingAddress shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUser(string buyerEmail);
        Task<Order> GetOrderById(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods();
    }
}