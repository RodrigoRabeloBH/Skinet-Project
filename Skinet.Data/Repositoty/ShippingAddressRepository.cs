using Skinet.Model.OrderAggregate;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public class ShippingAddressRepository : SkinetRepository<ShippingAddress>, IShippingAddressRepository
    {
        public ShippingAddressRepository(SkinetContext context) : base(context)
        {
        }
    }
}