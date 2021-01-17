using Skinet.Model.OrderAggregate;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public class DeliveryMethodRepository : SkinetRepository<DeliveryMethod>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(SkinetContext context) : base(context) { }
    }
}