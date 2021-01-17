using System.Collections.Generic;
using System.Threading.Tasks;
using Skinet.Model.OrderAggregate;

namespace Skinet.Service.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(string customerId, string buyerEmail, int deliveryMethodId, string basketId, ShippingAddress shippingAddress);
        Task<IEnumerable<Order>> GetOrdersForUser(string buyerEmail, string customerId);
        Task<Order> GetOrderById(int id, string buyerEmail);
        Task<IEnumerable<DeliveryMethod>> GetDeliveryMethods();
    }
}