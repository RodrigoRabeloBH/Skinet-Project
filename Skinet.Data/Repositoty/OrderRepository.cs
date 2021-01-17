using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skinet.Model.OrderAggregate;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SkinetContext _context;
        private readonly IProductRepository _productRepo;
        private readonly IBasketRepository _basketRepo;
        private readonly IDeliveryMethodRepository _deliveryRepo;
        private readonly IShippingAddressRepository _shippingRepo;

        public OrderRepository(SkinetContext context, IProductRepository productRepo,
                               IBasketRepository basketRepo, IDeliveryMethodRepository deliveryRepo,
                               IShippingAddressRepository shippingRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _basketRepo = basketRepo;
            _deliveryRepo = deliveryRepo;
            _shippingRepo = shippingRepo;
        }

        public async Task<Order> CreateOrder(string customerId, string buyerEmail, int deliveryMethodId, string basketId, ShippingAddress shippingAddress)
        {
            try
            {
                var basket = await _basketRepo.GetBasket(basketId);

                var items = new List<OrderItem>();

                foreach (var item in basket.Items)
                {
                    var productItem = await _productRepo.GetById(item.Id);

                    var orderItem = new OrderItem(productItem.Price, item.Quantity, item.Id, productItem.Name, item.ImageUrl);

                    items.Add(orderItem);
                }

                var deliveryMethod = await _deliveryRepo.GetById(deliveryMethodId);

                var subtotal = items.Sum(i => i.Price * i.Quantity);

                var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod.Id, subtotal, customerId);

                order.Total = subtotal + deliveryMethod.Price;

                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();

                await _basketRepo.DeleteBasket(basketId);

                order.DeliveryMethod = deliveryMethod;


                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

        }

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethods()
        {
            return await _deliveryRepo.GetAll();
        }

        public async Task<Order> GetOrderById(int id, string buyerEmail)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(o => o.DeliveryMethod)
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id && o.BuyerEmail == buyerEmail);
        }

        public async Task<IEnumerable<Order>> GetOrdersForUser(string buyerEmail, string customerId)
        {
            return await _context.Orders
                 .AsNoTracking()
                 .Include(o => o.DeliveryMethod)
                 .Include(o => o.ShippingAddress)
                 .Include(o => o.OrderItems)
                 .Where(o => o.BuyerEmail == buyerEmail && o.CustomerId == customerId)
                 .ToListAsync();
        }
    }
}